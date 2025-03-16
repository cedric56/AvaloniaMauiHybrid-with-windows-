using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Avalonia;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.XamlTypeInfo;
using System.Threading;
using Avalonia.Media;
using Avalonia.Platform;
using WinRT.Interop;
using Avalonia.Controls;
using System.Runtime.InteropServices;
using Window = Microsoft.UI.Xaml.Window;
using System.Reflection.Metadata;
using System.Xml.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App1
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Microsoft.UI.Xaml.Application
    {
        public static Window MainWindow;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            var avaloniaBuilder = AppBuilder.Configure<AvaloniaApp>();
            avaloniaBuilder.UsePlatformDetect();
            avaloniaBuilder.SetupWithoutStarting();
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            MainWindow = new MainWindow();
            MainWindow.Activate();
        }

        private Window? m_window;
    }

    public sealed partial class AvaloniaHost : Microsoft.UI.Xaml.Controls.UserControl
    {


        public FrameworkElement Previous
        {
            get { return (FrameworkElement)GetValue(PreviousProperty); }
            set { SetValue(PreviousProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Previous.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PreviousProperty =
            DependencyProperty.Register("Previous", typeof(FrameworkElement), typeof(AvaloniaHost), new PropertyMetadata(null));




        [DllImport("user32.dll")]
        public static extern int SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        // MoveWindow moves a window or changes its size based on a window handle.
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);


        private Avalonia.Controls.Window? _avaloniaTopLevel;
        private IntPtr _hWnd;

        public AvaloniaHost()
        {
            //this.InitializeComponent();
            this.Loaded += AvaloniaHost_Loaded;
        }

        private void AvaloniaHost_Loaded(object sender, RoutedEventArgs e)
        {
            // Get WinUI 3 window handle
            _hWnd = WindowNative.GetWindowHandle(App.MainWindow);

            // Initialize Avalonia inside the panel
            InitAvalonia();
        }
        [DllImport("User32.dll", SetLastError = true)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        // Win32 API to retrieve the HWND of a UIElement
        [DllImport("user32.dll")]
        public static extern IntPtr GetHwndFromUIElement(UIElement element);

        public const uint SWP_NOSIZE = 0x0001;
        public const uint SWP_NOZORDER = 0x0004;

        public static (double X, double Y) GetPosition(FrameworkElement element, UIElement relativeTo = null)
        {
            if (element == null) return (0, 0);

            relativeTo ??= (App.MainWindow.Content as UIElement);
            var transform = element.TransformToVisual(relativeTo);
            var position = transform.TransformPoint(new Windows.Foundation.Point(0, 0));

            return (position.X, position.Y);
        }
        private void InitAvalonia()
        {
            if (_hWnd == IntPtr.Zero) return;

            // Create Avalonia TopLevel
            _avaloniaTopLevel = new Avalonia.Controls.Window
            {
                Background = Brushes.Transparent,
                TransparencyBackgroundFallback = Brushes.Transparent,
        ExtendClientAreaToDecorationsHint = false,
                ExtendClientAreaChromeHints = ExtendClientAreaChromeHints.NoChrome,
                ExtendClientAreaTitleBarHeightHint = -1,
                SystemDecorations = SystemDecorations.None,
                BorderBrush = Brushes.Transparent,
                BorderThickness = new Avalonia.Thickness(0)

                //WindowHandle = _hWnd
            };

            // Create Avalonia Content
            var avaloniaControl = new Avalonia.Controls.Button
            {
                Content = "Hello from Avalonia!",
                Foreground = Brushes.White,
                BorderBrush = Brushes.White,
                BorderThickness = new Avalonia.Thickness(1)
            };

            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(App.MainWindow);
            var avaloniaHandle = _avaloniaTopLevel.TryGetPlatformHandle().Handle;

            App.MainWindow.SizeChanged += (sender, args) =>
            {
                var p = this.TransformToVisual(null).TransformPoint(new Windows.Foundation.Point(0.0, 0.0));
                SetWindowPos(avaloniaHandle, hwnd, (int)p.X, (int)p.Y, 0, 0, SWP_NOZORDER | SWP_NOSIZE | SWP_SHOWWINDOW);                
            };
            avaloniaControl.Loaded += (sender, args) =>
            {
                this.Width = avaloniaControl.DesiredSize.Width;
                this.Height = avaloniaControl.DesiredSize.Height;

                var p = this.TransformToVisual(null).TransformPoint(new Windows.Foundation.Point(0, 0));
                SetWindowPos(avaloniaHandle, hwnd, (int)p.X, (int)p.Y, 0,0, SWP_NOZORDER | SWP_NOSIZE | SWP_SHOWWINDOW);
            };

            avaloniaControl.Click += (sender, args) =>
            {

            };

            //_avaloniaTopLevel.SystemDecorations = SystemDecorations.None;
            ////_avaloniaTopLevel.TransparencyLevelHint = new List<WindowTransparencyLevel>() { WindowTransparencyLevel.AcrylicBlur };
            ////_avaloniaTopLevel.CanResize = false;
            //_avaloniaTopLevel.ExtendClientAreaChromeHints = ExtendClientAreaChromeHints.NoChrome;
            //_avaloniaTopLevel.ExtendClientAreaToDecorationsHint = false;
            ////_avaloniaTopLevel.ExtendClientAreaTitleBarHeightHint = -1;
            _avaloniaTopLevel.SizeToContent = SizeToContent.WidthAndHeight;
            // Attach control to the Avalonia TopLevel
            _avaloniaTopLevel.Content = avaloniaControl;
            _avaloniaTopLevel.Show();

            var position = GetPosition(this);
            SetParent(avaloniaHandle, hwnd);

            try
            {
                var d = GetHwndFromUIElement(this);
            }
            catch (Exception ex)
            {

            }

            
            // Move the window
            //SetWindowPos(hwnd, IntPtr.Zero, newX, newY, 0, 0, SWP_NOSIZE | SWP_NOZORDER);
            
        }

    //    [DllImport("user32.dll", SetLastError = true)]
    //    [return: MarshalAs(UnmanagedType.Bool)]
    //    public static extern bool SetWindowPos(
    //    IntPtr hWnd,
    //    IntPtr hWndInsertAfter,
    //    int X,
    //    int Y,
    //    int cx,
    //    int cy,
    //    uint uFlags
    //);

        // Constants
        public static readonly IntPtr HWND_TOP = IntPtr.Zero;
        //public const uint SWP_NOSIZE = 0x0001;
        public const uint SWP_NOMOVE = 0x0002;
        //public const uint SWP_NOZORDER = 0x0004;
        public const uint SWP_SHOWWINDOW = 0x0040;

        private const int GWLP_HWNDPARENT = -8;
        // P/Invoke for getting the window handle (HWND)
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);


        public static (double X, double Y) GetElementPosition(FrameworkElement element)
        {
            double x = 0, y = 0;
            UIElement parent = element;

            while (parent != null)
            {
                if (parent is FrameworkElement fe)
                {
                    x += fe.TransformToVisual(null).TransformPoint(new Windows.Foundation.Point(0, 0)).X;
                    y += fe.TransformToVisual(null).TransformPoint(new Windows.Foundation.Point(0, 0)).Y;
                }
                parent = VisualTreeHelper.GetParent(parent) as UIElement;
            }

            return (x, y);
        }
    }
}
