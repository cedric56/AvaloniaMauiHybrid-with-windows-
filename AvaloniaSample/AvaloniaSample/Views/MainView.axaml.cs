using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Maui.Controls;
using CommunityToolkit.Maui.Core.Primitives;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Media;
using Syncfusion.Maui.ProgressBar;
using System;
using System.Threading;
using ZXing.Net.Maui;

namespace AvaloniaSample.Views;

public partial class MainView : UserControl
{
    MediaElement mediaElement;
    public MainView()
    {
        InitializeComponent();
    }

    public async void Click(object sender, EventArgs e)
    {
        var a = await MediaPicker.CaptureVideoAsync();
    }

    private void MediaElement_OnPositionChanged(object? sender, MediaPositionChangedEventArgs e)
    {
        var mediaElement = (MediaElement)sender!;
        var progressBar = (SfCircularProgressBar)this.Get<MauiControlHost>("ProgressBarHost").Content!;
        progressBar.IsIndeterminate = false;
        progressBar.Minimum = 0;
        progressBar.Maximum = 1;
        progressBar.Progress = e.Position / mediaElement.Duration;
    }
    protected void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        foreach (var barcode in e.Results)
            Console.WriteLine($"Barcodes: {barcode.Format} -> {barcode.Value}");
    }
    protected override void OnUnloaded(RoutedEventArgs e)
    {
        base.OnUnloaded(e);

        // Stop and cleanup MediaElement when we navigate away
        
    }
}