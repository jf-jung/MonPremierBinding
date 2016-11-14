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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MonPremierBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Activity> activities = new ObservableCollection<Activity>();

        public MainWindow()
        {
            InitializeComponent();

            activities.Add(new Activity() { Name = "Activité joyeuse" });
            activities.Add(new Activity() { Name = "Activité triste" });

            // On défini une source de données pour notre ListBox
            lbActivities.ItemsSource = activities;
        }

        private void btnAddActivity_Click(object sender, RoutedEventArgs e)
        {
            // Ajout d'une nouvelle activité. 
            // On utilise une forme raccourcie spécifique à C# pour 
            // instancier la nouvelle Activity
            // et définir son Name
            // C'est ce qu'on appelle un "initialiseur d'objet"
            activities.Add(new Activity { Name = "Nouvelle activité" });
        }

        private void btnChangeActivity_Click(object sender, RoutedEventArgs e)
        {
            // On omet les accolades, seule l'instruction suivante est prise en compte. Attention, danger !
            // On peut se le permettre dans un cas comme celui-ci, car notre méthode ne comporte qu'une seule
            // et unique instruction dans corps, 
            if (lbActivities.SelectedItem != null)
                (lbActivities.SelectedItem as Activity).Name = "Activité qui change";
        }

        private void btnDeleteActivity_Click(object sender, RoutedEventArgs e)
        {
            // Même remarque que précédemment
            if (lbActivities.SelectedItem != null)
                activities.Remove(lbActivities.SelectedItem as Activity);
        }
    }

    // Notez qu'il est possible, en C#, de définir plusieurs classe séparées au sein du même fichier.
    public class Activity : INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}