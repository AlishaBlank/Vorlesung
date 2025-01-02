using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vorlesung
{
    /// <summary>
    /// Interaktionslogik für Module.xaml
    /// </summary>
    public partial class Module : Page
    {
        ObservableCollection<Noteneintragung> NotenEintragung = new ObservableCollection<Noteneintragung>();
        public Module()
        {
            InitializeComponent();
            NotenListe.ItemsSource = NotenEintragung;
        }

        private void NoteHinzufuegen(object sender, RoutedEventArgs e)
        {
            var dialog = new NoteneintragungDialog();
            if (dialog.ShowDialog() == true)
            {
                NotenEintragung.Add(new Noteneintragung
                {
                    Fach = dialog.Fach,
                    Note = dialog.Note,
                    Kommentar = dialog.Kommentar,
                });
            }
        }

            private void NoteLoeschen(object sender, RoutedEventArgs e)
            {
                if (NotenListe.SelectedItem is Noteneintragung selectedEntry)
                {
                    NotenEintragung.Remove(selectedEntry);
                }
            }

            private void NoteBearbeiten(object sender, RoutedEventArgs e)
            {
                if (NotenListe.SelectedItem is Noteneintragung selectedEntry)
                {
                    var dialog = new NoteneintragungDialog(selectedEntry.Fach, selectedEntry.Note, selectedEntry.Kommentar);
                    if (dialog.ShowDialog() == true)
                    {
                        selectedEntry.Fach = dialog.Fach;
                        selectedEntry.Note = dialog.Note;
                        selectedEntry.Kommentar = dialog.Kommentar;
                        NotenListe.Items.Refresh();
                    }
                }
            }
        }
    }

