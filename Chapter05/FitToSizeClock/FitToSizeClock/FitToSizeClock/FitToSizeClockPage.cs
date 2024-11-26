using System;
using Xamarin.Forms;

namespace FitToSizeClock
{
    public class FitToSizeClockPage : ContentPage
    {
        public FitToSizeClockPage()
        {
            Label clockLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,    
                VerticalOptions = LayoutOptions.Center
            };

            Content = clockLabel;

            Boolean highSwitch = false;
            // Handle the SizeChanged event for the page.
            SizeChanged += (object sender, EventArgs args) =>
                {
                    // Scale the font size to the page width
                    //      (based on 11 characters in the displayed string).
                    if (!highSwitch)
                    {
                        clockLabel.BackgroundColor = Color.Coral;
                        highSwitch = true;
                    }
                    else
                    {
                        clockLabel.BackgroundColor = Color.Aqua;
                        highSwitch = false;

                    }
                    if (this.Width > 0)
                        clockLabel.FontSize = this.Width / 6.5;
                };

            // Start the timer going.
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    // Set the Text property of the Label.
                    clockLabel.Text = DateTime.Now.ToString("h:mm:ss-tt\n");
                    clockLabel.Text += DateTime.UtcNow.ToString(("h:mm:ss-tt"));
                    return true;
                });
        }
    }
}
