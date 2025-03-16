using System.Diagnostics;
using System.Reflection.PortableExecutable;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Application = Microsoft.Maui.Controls.Application;

namespace AvaloniaSample.Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            //var builder = AppBuilder.Configure<AvaloniaSample.App>()
            //.UsePlatformDetect()
            //.LogToTrace();

            //builder.AfterSetup(_ =>
            //{

            //});
            //var lifetime = new ClassicDesktopStyleApplicationLifetime
            //{
            //    Args = null,
            //};

            //builder.SetupWithLifetime(lifetime);

            //var process = Process.GetCurrentProcess();
            //EventHandler handler = null;
            //lifetime.MainWindow.Closed += handler = (sender, e) =>
            //{
            //    lifetime.MainWindow.Closed -= handler;
            //    process.Kill();
            //};
            //var handle = lifetime.MainWindow.TryGetPlatformHandle().Handle;
            //Dispatcher.Dispatch(() =>
            //{
            //    var windowHandle = process.MainWindowHandle;
            //    SetParent(windowHandle, handle);
            //    ShowWindow(windowHandle, 0);
            //});
        }
    }
}
