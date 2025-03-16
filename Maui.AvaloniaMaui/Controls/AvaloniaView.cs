﻿using Microsoft.Maui.Controls;

namespace Maui.AvaloniaMaui.Controls
{
    [ContentProperty(nameof(Content))]
    public class AvaloniaView : View
    {
        public static readonly BindableProperty ContentProperty =
            BindableProperty.Create(nameof(Content), typeof(object), typeof(AvaloniaView), true);

        public object Content
        {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }
    }
}
