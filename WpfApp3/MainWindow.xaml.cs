using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button.Content.ToString() == "Copy") tbox.Copy();
            else if (button.Content.ToString() == "Paste") tbox.Paste();
            else if (button.Content.ToString() == "Select All") tbox.SelectAll();
            else if (button.Content.ToString() == "C") tbox.TextAlignment = TextAlignment.Center;
            else if (button.Content.ToString() == "L") tbox.TextAlignment = TextAlignment.Left;
            else if (button.Content.ToString() == "R") tbox.TextAlignment = TextAlignment.Right;
            tbox.Focus();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            string filePath = $"{tbox_save.Text}.json";
            if (File.Exists(filePath))
                MessageBox.Show("File already exists, enter another name");

            var JsonStr = JsonSerializer.Serialize(tbox.Text);

            File.WriteAllText(filePath, JsonStr);
            MessageBox.Show("Data Successfully Added");
        }

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            string filePath = $"{tbox_load.Text}.json";
            if (!File.Exists(filePath))
            {
                MessageBox.Show("There is no file");
                return;
            }

            var readJsonStr = File.ReadAllText(filePath);
            string? Text = JsonSerializer.Deserialize<string>(readJsonStr) ?? null;

            if (Text == null)
            {
                MessageBox.Show("No data exists");
                return;
            }

            tbox.Text = Text;
        }
    }
}
