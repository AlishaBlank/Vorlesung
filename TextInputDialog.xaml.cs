using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Vorlesung
{
    /// <summary>
    /// Interaktionslogik für TextInputDialog.xaml
    /// </summary>
    public partial class TextInputDialog : Window
    {
        public string InputText => TextInput.Text;
        public TextInputDialog(string prompt, string defaultText = "")
        {
            InitializeComponent();
            DialogPrompt.Text = prompt; // Text für die Eingabeaufforderung setzen
            TextInput.Text = defaultText; // Standardtext festlegen
            TextInput.Focus(); // Fokus auf das Textfeld setzen
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true; // Fenster mit "OK" schließen
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Fenster mit "Abbrechen" schließen
        }
    }
}
