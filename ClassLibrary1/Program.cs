using MauiSample;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.XamlTypeInfo;
using System;
using System.Threading;

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
            global::WinRT.ComWrappersSupport.InitializeComWrappers();

            Microsoft.UI.Xaml.Application.Start(
               (ApplicationInitializationCallbackParams callback) =>
               {
                   var uiContext = new DispatcherQueueSynchronizationContext(DispatcherQueue.GetForCurrentThread());
                   SynchronizationContext.SetSynchronizationContext(uiContext);
                   var app = new WinUIApp();
                   
               }
           );
        }
    }
    public class MauiApplication : Microsoft.Maui.Controls.Application
    {
      
    }

    public class WinUIApp : MauiWinUIApplication, IXamlMetadataProvider
    {
        private Window _mainWindow;
        private XamlControlsXamlMetaDataProvider provider;

        public IXamlType GetXamlType(string fullName)
        {
            return provider.GetXamlType(fullName);
        }

        public IXamlType GetXamlType(Type type)
        {
            return provider.GetXamlType(type);
        }

        public XmlnsDefinition[] GetXmlnsDefinitions()
        {
            return provider.GetXmlnsDefinitions();
        }

        protected override MauiApp CreateMauiApp()
        {
            //XamlControlsXamlMetaDataProvider.Initialize();
            //provider = new();

            //Resources.MergedDictionaries.Add(new XamlControlsResources());


            var builder = MauiApp.CreateBuilder()
                    .UseMauiApp<App>();
            return builder.Build();
        }

        //protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        //{
        //    XamlControlsXamlMetaDataProvider.Initialize();
        //    provider = new();

        //    Resources.MergedDictionaries.Add(new XamlControlsResources());

        //    _mainWindow = new Window();
        //    _mainWindow.Activate();

            
        //}
    }
}
