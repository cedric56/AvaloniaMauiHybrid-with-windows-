#if WINDOWS10_0_19041_0_OR_GREATER
using Maui.AvaloniaMaui.Controls;
using Maui.AvaloniaMaui.Platforms.Windows;
using Microsoft.Maui.Handlers;
using AvaloniaControl = Avalonia.Controls.Control;

namespace Maui.AvaloniaMaui.Handlers
{
    public partial class AvaloniaViewHandler : ViewHandler<AvaloniaView, MauiAvaloniaView>
    {
        protected override MauiAvaloniaView CreatePlatformView()
        {
            return new MauiAvaloniaView(VirtualView);
        }

        protected override void ConnectHandler(MauiAvaloniaView platformView)
        {
            base.ConnectHandler(platformView);

            platformView.Content = VirtualView.Content as AvaloniaControl;
        }
        
        public static void MapContent(AvaloniaViewHandler handler, AvaloniaView view)
        {
            handler.PlatformView?.UpdateContent();
        }
    }
}
#endif