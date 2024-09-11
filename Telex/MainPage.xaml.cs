using Telex.Services;

namespace Telex
{
    public partial class MainPage : ContentPage
    {
        const string getMessageScript = "GetMessage()";
        const string removeMessageScript = "RemoveMessage()";
        string disableContextMenuScript = @"
            document.addEventListener('contextmenu', function(e) {
                e.preventDefault();
            });
        ";

        public MainPage()
        {
            InitializeComponent();
            TWebView.Navigated += WebView_Navigated;
        }

        private async void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            // Execute the script in the WebView
            TWebView.Eval(disableContextMenuScript);

            await HandleNotifications();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await DisplayToast("Startup", "Telex Is Now Running");

        }

        private async Task HandleNotifications()
        {
            while (true)
            {
                if (TWebView.IsLoaded)
                {
                    try
                    {
                        var message = await TWebView.EvaluateJavaScriptAsync(getMessageScript);
                        await TWebView.EvaluateJavaScriptAsync(removeMessageScript);
                        if (!string.IsNullOrEmpty(message) && message != "null")
                        {
                            var splitMessage = message.Split(',');
                            if (splitMessage.Length == 2)
                                await DisplayToast(splitMessage[0], splitMessage[1]);
                        }
                        await Task.Delay(1000); // Delay for 1 second

                    }
                    catch (Exception ex)
                    {
                        break;
                    }
                }
                else break;
            }
        }

        private static async Task DisplayToast(string title, string message)
        {
            NotificationService.ShowNotification(title, message);
            //var toast = Toast.Make(text, duration, fontSize);

            //await toast.Show();
        }
    }

}
