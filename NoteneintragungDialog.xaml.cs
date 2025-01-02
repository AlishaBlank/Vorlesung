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
    /// Interaktionslogik für NoteneintragungDialog.xaml
    /// </summary>
    public partial class NoteneintragungDialog : Window
    {
        public string Fach => FachEingabe.Text;
        public double Note => double.TryParse(NoteEingabe.Text, out var result) ? result : 0;
        public string Kommentar => KommentarEingabe.Text;
        public NoteneintragungDialog(string fach = "", double note = 0, string kommentar = "")
        {
            InitializeComponent();
            FachEingabe.Text = fach;
            NoteEingabe.Text = note.ToString("F1");
            KommentarEingabe.Text = kommentar;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void AbbrechenButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult= false;
        }
    }
}
