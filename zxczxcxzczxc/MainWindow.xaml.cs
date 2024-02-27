using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphicalEditor
{
    public partial class MainWindow : Window
    {
        private Brush currentBrushColor = Brushes.Black;
        private double currentBrushSize = 5;
        private Mode currentMode = Mode.Draw;

        public enum Mode
        {
            Draw,
            Edit,
            Delete
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var colorComboBox = sender as ComboBox;
            string selectedColor = colorComboBox.SelectedValue.ToString();
            currentBrushColor = (Brush)new BrushConverter().ConvertFromString(selectedColor);
        }

        private void SizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var sizeSlider = sender as Slider;
            currentBrushSize = sizeSlider.Value;
        }

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            currentMode = Mode.Draw;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            currentMode = Mode.Edit;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            currentMode = Mode.Delete;
        }

        private void Canvas_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (currentMode == Mode.Draw)
            {
                Point position = e.GetPosition(sender as IInputElement);
                Ellipse ellipse = new Ellipse
                {
                    Width = currentBrushSize,
                    Height = currentBrushSize,
                    Fill = currentBrushColor
                };

                Canvas.SetLeft(ellipse, position.X - currentBrushSize / 2);
                Canvas.SetTop(ellipse, position.Y - currentBrushSize / 2);

                canvas.Children.Add(ellipse);
            }
            else if (currentMode == Mode.Edit)
            {
                // Add code for editing shapes on canvas
            }
            else if (currentMode == Mode.Delete)
            {
                // Add code for deleting shapes on canvas
            }
        }
    }
}