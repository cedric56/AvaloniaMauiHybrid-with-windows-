#if WINDOWS10_0_19041_0_OR_GREATER
using Maui.AvaloniaMaui.Controls;

namespace Maui.AvaloniaMaui.Platforms.Windows
{
    public partial class MauiAvaloniaView : Microsoft.UI.Xaml.Controls.ContentControl
    {        

        readonly AvaloniaView _mauiView;

        public MauiAvaloniaView(AvaloniaView mauiView)
        {
            _mauiView = mauiView;
        }
     
        public void UpdateContent()
        {
            Content = Content;
        }
    }
}
#endif