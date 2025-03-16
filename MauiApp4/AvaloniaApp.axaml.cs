using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaSample.MauiApp;
using Application = Avalonia.Application;

namespace MauiSample
{
    public class AvaloniaApp : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new Avalonia.Controls.Window
                {
                };
                desktop.MainWindow.Show();
            }


            base.OnFrameworkInitializationCompleted();
        }
    }
}