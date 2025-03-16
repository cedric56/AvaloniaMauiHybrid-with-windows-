using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using AvaloniaSample.MauiAvalonia.AvaloniaControls;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Application = Microsoft.Maui.Controls.Application;

namespace AvaloniaSample.MauiAvalonia
{
    public partial class App : Application
    {
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window()
            {
                Height = 0,
                Width = 0,
                Page = new ContentPage()
            };
            window.Activated += Window_Activated;

            return window;
        }

        private void Window_Activated(object? sender, EventArgs e)
        {
#if WINDOWS10_0_19041_0_OR_GREATER
            var window = (Window)sender;
            var view = (MauiWinUIWindow)window.Handler.PlatformView;
            ShowWindow(view.WindowHandle, 0);
#endif
        }

        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();

            var builder = AppBuilder.Configure<AvaloniaApp>()
            .UsePlatformDetect()
            .LogToTrace();

            builder.AfterSetup(_ =>
            {

            });
            var lifetime = new ClassicDesktopStyleApplicationLifetime
            {
                Args = null,
            };

            builder.SetupWithLifetime(lifetime);

            var process = Process.GetCurrentProcess();


            EventHandler handler = null;
            lifetime.MainWindow.Closed += handler = (sender, e) =>
            {
                lifetime.MainWindow.Closed -= handler;
                process.Kill();
            };
        }
    }
}
