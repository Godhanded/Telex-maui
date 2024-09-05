namespace MauiApp1.Services
{
    public static class NotificationService
    {
        public static void ShowNotification(string title, string message)
        {
#if WINDOWS
            // Call the Windows-specific notification method
            MauiApp1.WinUI.App.ShowWindowsNotification(title, message);
#endif
        }
    }
}
