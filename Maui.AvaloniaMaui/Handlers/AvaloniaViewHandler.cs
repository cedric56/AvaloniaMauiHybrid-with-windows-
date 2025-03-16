﻿using Maui.AvaloniaMaui.Controls;
using Microsoft.Maui.Handlers;

namespace Maui.AvaloniaMaui.Handlers
{
    public partial class AvaloniaViewHandler
    {
        public static IPropertyMapper<AvaloniaView, AvaloniaViewHandler> PropertyMapper = new PropertyMapper<AvaloniaView, AvaloniaViewHandler>(ViewHandler.ViewMapper)
        {
            [nameof(AvaloniaView.Content)] = MapContent
        };

        public AvaloniaViewHandler() : base(PropertyMapper)
        {
        }
    }
}
