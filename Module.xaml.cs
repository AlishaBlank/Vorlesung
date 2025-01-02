﻿using System;
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
                var neueEintragung = new Noteneintragung
                {
                    Fach = dialog.Fach,
                    Note = dialog.Note,
                    ECTS = dialog.ECTS // ECTS Punkt statt Kommentar
                };
                NotenEintragung.Add(neueEintragung);
                UpdateECTSSum();
            }
        }

        private void NoteLoeschen(object sender, RoutedEventArgs e)
        {
            if (NotenListe.SelectedItem is Noteneintragung selectedEntry)
            {
                NotenEintragung.Remove(selectedEntry);
                UpdateECTSSum();
            }
        }

        private void NoteBearbeiten(object sender, RoutedEventArgs e)
        {
            if (NotenListe.SelectedItem is Noteneintragung selectedEntry)
            {
                var dialog = new NoteneintragungDialog(selectedEntry.Fach, selectedEntry.Note, selectedEntry.ECTS);
                if (dialog.ShowDialog() == true)
                {
                    selectedEntry.Fach = dialog.Fach;
                    selectedEntry.Note = dialog.Note;
                    selectedEntry.ECTS = dialog.ECTS; // ECTS Punkt anpassen
                    NotenListe.Items.Refresh();
                    UpdateECTSSum();
                }
            }
        }

        // Methode zur Berechnung und Anzeige der Summe der ECTS-Punkte
        private void UpdateECTSSum()
        {
            int summe = NotenEintragung.Sum(ne => ne.ECTS);
            SummeECTS.Content = $"Summe ECTS: {summe}";
        }
    }
}

