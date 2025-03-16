using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Application = Avalonia.Application;
using Window = Avalonia.Controls.Window;

namespace AvaloniaSample.MauiAvalonia.AvaloniaControls
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
                desktop.MainWindow = new Window
                {
                    Content = new MainView()
                };
                desktop.MainWindow.Show();
            }


            base.OnFrameworkInitializationCompleted();
        }
    }
}