using System;
using Xamarin.Forms;

namespace FontSizes
{
    public class FontSizesPage : ContentPage
    {
        public FontSizesPage()
        {
            BackgroundColor = Color.White;
            StackLayout stackLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            // Do the NamedSize values.
            NamedSize[] namedSizes = 
            {
                NamedSize.Default, NamedSize.Micro, NamedSize.Small,
                NamedSize.Medium, NamedSize.Large
            };

            foreach (NamedSize namedSize in namedSizes)
            {
                double fontSize = Device.GetNamedSize(namedSize, typeof(Label));

                stackLayout.Children.Add(new Label
                    {
                        Text = String.Format("Named Size = {0} ({1:F2})",
                                             namedSize, fontSize),
                        FontSize = fontSize,
                        TextColor = Color.Black
                    });
            }

            // Resolution in device-independent units per inch.
            double resolution = 160;

            // Draw horizontal separator line.
            stackLayout.Children.Add(
                new BoxView
                {
                    Color = Color.Magenta,
                    HeightRequest = resolution / 10
                });

            // Do some numeric point sizes.
            int[] ptSizes = { 4, 6, 8, 10, 12, 16, 18, 28 };

            foreach (double ptSize in ptSizes)
            {
                double fontSize = resolution * ptSize / 72;

                stackLayout.Children.Add(new Label
                    {
                        Text = String.Format("Point Size = {0} ({1:F2})",
                                             ptSize, fontSize),
                        FontSize = fontSize,
                        TextColor = Color.Aquamarine
                    });
            }

            Content = stackLayout;
        }
    }
}
