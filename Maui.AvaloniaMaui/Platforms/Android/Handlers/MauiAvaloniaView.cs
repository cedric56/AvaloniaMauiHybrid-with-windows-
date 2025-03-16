#if ANDROID
using Android.Content;
using Maui.AvaloniaMaui.Controls;
using Color = Android.Graphics.Color;

namespace Maui.AvaloniaMaui.Platforms.Android.Handlers
{
    public class MauiAvaloniaView : Avalonia.Android.AvaloniaView
    {
        readonly AvaloniaView _mauiView;

        public MauiAvaloniaView(Context context, AvaloniaView mauiView) : base(context)
        {
            _mauiView = mauiView;

            SetBackgroundColor(Color.Transparent);
        }

        public void UpdateContent()
        {
            Content = _mauiView.Content;
        }
    }
}
#endif