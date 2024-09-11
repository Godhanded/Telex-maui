namespace Telex.Services
{
    public static class NotificationService
    {
        public static void ShowNotification(string title, string message)
        {
#if WINDOWS
            // Call the Windows-specific notification method
            Telex.WinUI.App.ShowWindowsNotification(title, message);
#endif
        }
    }
}
