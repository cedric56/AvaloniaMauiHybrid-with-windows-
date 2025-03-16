using Avalonia.Controls.ApplicationLifetimes;
using Avalonia;
using CommunityToolkit.Maui;
using System.Diagnostics;
using System.Runtime.InteropServices;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Handlers;
using Telerik.Maui.Controls.Compatibility;
using Syncfusion.Maui.Core.Hosting;
using ZXing.Net.Maui.Controls;

namespace AvaloniaSample.WinUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<AvaloniaSample.WinUI.App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .UseTelerik()
            .ConfigureSyncfusionCore()            
            .UseBarcodeReader()            
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitMediaElement();

            return builder.Build();
        }
    }

    //public class MauiApplication : Microsoft.Maui.Controls.Application
    //{

    //    [DllImport("user32.dll")]
    //    static extern bool ShowWindow(nint hWnd, int nCmdShow);

    //    protected override Window CreateWindow(IActivationState? activationState)
    //    {
    //        var window = new Window()
    //        {
    //            Height = 0,
    //            Width = 0,
    //            Page = new ContentPage()
    //        };
    //        window.Activated += Window_Activated;

    //        return window;
    //    }

    //    private void Window_Activated(object? sender, EventArgs e)
    //    {
    //        var window = (Window)sender;
    //        var view = (MauiWinUIWindow)window.Handler.PlatformView;
    //        ShowWindow(view.WindowHandle, 0);
    //    }

    //    public MauiApplication()
    //    {
    //        //MainPage = new AppShell();

    //        var builder = AppBuilder.Configure<App>()
    //        .UsePlatformDetect()
    //        .LogToTrace();

    //        builder.AfterSetup(_ =>
    //        {

    //        });
    //        var lifetime = new ClassicDesktopStyleApplicationLifetime
    //        {
    //            Args = null,
    //        };

    //        builder.SetupWithLifetime(lifetime);

    //        var process = Process.GetCurrentProcess();


    //        EventHandler handler = null;
    //        lifetime.MainWindow.Closed += handler = (sender, e) =>
    //        {
    //            lifetime.MainWindow.Closed -= handler;
    //            process.Kill();
    //        };
    //        lifetime.MainWindow.Show();
    //    }


    //}
}