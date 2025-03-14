using Avalonia;
using Avalonia.Maui;
using AvaloniaSample;
using AvaloniaSample.Maui;
using AvaloniaSample.Views;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Handlers;
using CommunityToolkit.Maui.Core.Views;
using CommunityToolkit.Maui.Views;
using HarmonyLib;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Dispatching;
using Microsoft.Maui.Embedding;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Hosting;
using Microsoft.UI;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.XamlTypeInfo;
using Moq;
using Syncfusion.Maui.Core.Hosting;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Windows.Media.Playback;
using WinRT.Interop;
using ZXing.Net.Maui.Controls;
using static ClassLibray1.MediaElementHandlerEx;

namespace ClassLibray1
{
    internal sealed class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args)
        {
            var builder = BuildAvaloniaApp();

            builder.StartWithClassicDesktopLifetime(args);
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
        {
            return AppBuilder.Configure<App>()
                .UseMaui<MauiApplication>((b) =>
                {
                    b.Services.AddLogging(logging =>
                    {
                        //logging.AddDebug();
                    });
                    b.ConfigureSyncfusionCore()
                .UseMauiCommunityToolkit();
                    //.UseMauiCommunityToolkitMediaElement();

                    b.UseBarcodeReader();
                    b.ConfigureMauiHandlers(handlers =>
                    {
                        handlers.AddHandler<MediaElement, MediaElementHandlerEx>();
                    });
                })
                .UsePlatformDetect();
        }

        public static void Prefix()
        {
            
        }
    }

    public class MauiApplication : Microsoft.Maui.Controls.Application
    {

    }

    public class MediaElementHandlerEx : MediaElementHandler
    {
        public MediaElementHandlerEx() 
            : base(PropertyMapper, CommandMapper)
        {
        }

        protected override MauiMediaElement CreatePlatformView()
        {
            var view = new MediaPlayerElement()
            {
                //Source = UriMediaSource.FromUri("https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4")
            };
            
            view.Source = Windows.Media.Core.MediaSource.CreateFromUri(new Uri("https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"));
            view.AutoPlay = true;
            return new MauiMediaElement(view);
        }
    }
}
