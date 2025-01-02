using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaktionslogik für ToDo.xaml
    /// </summary>
    public partial class ToDo : Page
    {
        public ObservableCollection<string> ToDoTask {  get; set; }
        public ToDo()
        {
            InitializeComponent();
            ToDoTask = new ObservableCollection<string>();
            //Liste mit Elementen verknüpfen
            ToDoList.ItemsSource = ToDoTask;
        }

        private void ToDosHinzufuegen(object sender, RoutedEventArgs e)
        {
            var dialog = new TextInputDialog("Neue Aufgabe Hinzufügen:");
            if (dialog.ShowDialog() == true)
            {
                ToDoTask.Add(dialog.InputText);
            }
        }

        private void ToDosLoeschen(object sender, RoutedEventArgs e)
        {
            if (ToDoList.SelectedItem != null)
            {
                ToDoTask.Remove(ToDoList.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Bitte wähle eine Aufgabe aus, die gelöscht werden soll.", "Hinweis", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ToDosBearbeiten(object sender, RoutedEventArgs e)
        {
            if (ToDoList.SelectedItem != null)
            {
                var dialog = new TextInputDialog("Aufgabe bearbeiten:", ToDoList.SelectedItem.ToString());
                if (dialog.ShowDialog() == true)
                {
                    int index = ToDoTask.IndexOf(ToDoList.SelectedItem.ToString());
                    ToDoTask[index] = dialog.InputText;
                }
            }
            else
            {
                MessageBox.Show("Bitte wähle eine Aufgabe aus, die bearbeitet werden soll.", "Hinweis", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ToDosErledigt(object sender, RoutedEventArgs e)
        {
            if (ToDoList.SelectedItem != null)
            {
                int index = ToDoTask.IndexOf(ToDoList.SelectedItem.ToString());
                ToDoTask[index] = "[Erledigt]     " + ToDoTask[index];
            }
            else
            {
                MessageBox.Show("Bitte eine Aufgabe auswählen, die als `Erledigt` markiert werden soll");
            }
        }
    }
}
