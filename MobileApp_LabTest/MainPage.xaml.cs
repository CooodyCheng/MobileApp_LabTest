namespace MobileApp_LabTest;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();

        Slider1.ValueChanged += Slider_ValueChanged;

    }

 //   private void OnCounterClicked(object sender, ValueChangedEventArgs args)
	//{
        
 //   }

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
		Slider sldr = sender as Slider;
        int newValue = (int)sldr.Value;
        label1.Text = $"{newValue}";

        if (newValue >= 0 && newValue < 40)
        {
            label2.Text = "Failed";
            label2.TextColor = Color.FromHex("#FF0000");
        }
        else if (newValue >= 40 && newValue < 80)
        {
            label2.Text = "Passed";
            label2.TextColor = Color.FromHex("#000000");
        }
        else if (newValue >= 80 && newValue <= 100)
        {
            label2.Text = "Excellent";
            label2.TextColor = Color.FromHex("#00FF00");
        }
    }
}

