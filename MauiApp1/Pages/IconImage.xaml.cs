using Sleepwise.Models;

namespace Sleepwise.Pages;

public partial class IconImage : ContentView
{
    public static readonly BindableProperty InsightObjectProperty =
        BindableProperty.Create(nameof(InsightObject), typeof(InsightMapping), typeof(IconImage));

    public InsightMapping InsightObject
    {
        get { return (InsightMapping)GetValue(InsightObjectProperty); }
        set { SetValue(InsightObjectProperty, value); }
    }


    public IconImage()
	{
        InitializeComponent();
        this.BindingContext = this;
    }
}