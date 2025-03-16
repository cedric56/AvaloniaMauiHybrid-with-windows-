using Avalonia;
using Avalonia.ReactiveUI;
using Maui.AvaloniaMaui;
using System;
using System.Reflection.PortableExecutable;

namespace AvaloniaApplication1.Desktop
{
    internal sealed class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UseMaui<MauiApplication>()
                .UsePlatformDetect()
                .WithInterFont()
                .LogToTrace()
                .UseReactiveUI();
    }

    public class MauiApplication : Microsoft.Maui.Controls.Application
{
}
}
