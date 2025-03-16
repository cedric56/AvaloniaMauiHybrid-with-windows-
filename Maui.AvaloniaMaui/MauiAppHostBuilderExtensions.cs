using Avalonia;
using Maui.AvaloniaMaui.Controls;
using Maui.AvaloniaMaui.Handlers;

namespace Maui.AvaloniaMaui
{
    public static class MauiAppHostBuilderExtensions
    {
        public static MauiAppBuilder UseAvalonia<TApp>(this MauiAppBuilder builder, Action<AppBuilder>? customizeBuilder = null) where TApp : Avalonia.Application, new()
        {
            var avaloniaBuilder = AppBuilder.Configure<TApp>();
#if ANDROID
            avaloniaBuilder.UseAndroid();
#elif IOS
            avaloniaBuilder.UseiOS();
#elif WINDOWS10_0_19041_0_OR_GREATER
            avaloniaBuilder.UsePlatformDetect();
#endif

            customizeBuilder?.Invoke(avaloniaBuilder);

            avaloniaBuilder.SetupWithoutStarting();

            return builder
                .ConfigureMauiHandlers(handlers =>
                {
#if ANDROID || IOS || WINDOWS10_0_19041_0_OR_GREATER
                    handlers.AddHandler(typeof(AvaloniaView), typeof(AvaloniaViewHandler));
#endif
                });;
        }
    }
}
