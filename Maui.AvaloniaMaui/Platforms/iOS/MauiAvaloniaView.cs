#if IOS
using Maui.AvaloniaMaui.Controls;
using AvaloniaControl = Avalonia.Controls.Control;

namespace Maui.AvaloniaMaui.Platforms.iOS
{
    public class MauiAvaloniaView : Avalonia.iOS.AvaloniaView
    {
        readonly AvaloniaView _mauiView;

        public MauiAvaloniaView(AvaloniaView mauiView)
        {
            _mauiView = mauiView;
        }

        public void UpdateContent()
        {
            Content = _mauiView.Content as AvaloniaControl;
        }
    }
}
#endif