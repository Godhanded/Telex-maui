using Microsoft.UI.Xaml;
using Windows.UI.Notifications;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MauiApp1.WinUI
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : MauiWinUIApplication
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        public static void ShowWindowsNotification(string title, string message)
        {
            // Create a toast notification template
            var toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);

            // Set the title and message of the notification
            var stringElements = toastXml.GetElementsByTagName("text");
            stringElements[0].AppendChild(toastXml.CreateTextNode(title));
            stringElements[1].AppendChild(toastXml.CreateTextNode(message));

            // Create and display the toast notification
            var toastNotification = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toastNotification);
        }
    }

}
