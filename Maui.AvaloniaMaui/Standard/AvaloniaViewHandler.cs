#if !ANDROID && !IOS && !WINDOWS && !MACOS && !MACCATALYST
using Maui.AvaloniaMaui.Controls;
using Maui.AvaloniaMaui.Platforms.Standard;
using Microsoft.Maui.Handlers;

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

            platformView.Content = VirtualView.Content as MauiAvaloniaView;
        }
        
        public static void MapContent(AvaloniaViewHandler handler, AvaloniaView view)
        {
            handler.PlatformView?.UpdateContent();
        }
    }
}
#endif