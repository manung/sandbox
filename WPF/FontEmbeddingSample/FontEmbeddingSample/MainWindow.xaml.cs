using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FontEmbeddingSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            var relativeUri = new Uri("pack://application:,,,/Resources;component/Fonts/");

            foreach (FontFamily fontFamily in Fonts.GetFontFamilies(relativeUri, "."))
            {
                // Perform action.
                AddFont(fontFamily, FontStretches.Medium, "Sample");
            }

            AddFont(new FontFamily("Arial"), FontStretches.Medium, "Sample");
            AddFont(new FontFamily("Calibri"), FontStretches.Medium, "Sample");
            AddFont(new FontFamily("Segoe UI"), FontStretches.Medium, "Sample");
            //AddFont(new FontFamily(relativeUri, "./#Interstate"), "1.23");
            //AddFont(new FontFamily(relativeUri, "./#Interstate-Regular"), "1.23");
            //AddFont(new FontFamily(relativeUri, "./#Interstate-BoldCondensed"), "1.23");
            //AddFont(new FontFamily(relativeUri, "./#Helvetica Neue LT Pro 75 Bold"), "1.23");
        }

        private readonly List<FontWeight> _weights = new List<FontWeight>
                                                {
                                                    FontWeights.Black,
                                                    FontWeights.Bold,
                                                    FontWeights.Heavy,
                                                    FontWeights.Medium,
                                                    FontWeights.Normal,
                                                    FontWeights.Regular,
                                                    FontWeights.Light,
                                                    FontWeights.Thin
                                                };

        private void AddFont(FontFamily fontFamily, FontStretch fontStretch, string text)
        {
            var stackPanel = new StackPanel();
            stackPanel.Margin = new Thickness(5);

            stackPanel.Children.Add(NewTextBlock(fontFamily, FontWeights.Normal, FontStretches.Normal, fontFamily.ToString()));

            foreach(var weight in _weights)
            {
                stackPanel.Children.Add(NewTextBlock(fontFamily, weight, fontStretch, weight + ": " + text));
            }

            FontList.Children.Add(stackPanel);
        }

        private static TextBlock NewTextBlock(FontFamily fontFamily, FontWeight weight, FontStretch fontStretch, string text)
        {
            var textBlock = new TextBlock
                                {
                                    HorizontalAlignment = HorizontalAlignment.Left,
                                    VerticalAlignment = VerticalAlignment.Top,
                                    FontSize = PointsToPixels(9),
                                    Text = text,
                                    FontWeight = weight,
                                    FontFamily = fontFamily,
                                    FontStretch = fontStretch
                                };

            return textBlock;
        }

        public static double PointsToPixels(double points)
        {
            return points * (96.0 / 72.0);
        }
    }
}
