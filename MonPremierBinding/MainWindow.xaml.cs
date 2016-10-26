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
        private List<Activity> activities = new List<Activity>();

        public MainWindow()
        {
            InitializeComponent();

            activities.Add(new Activity() { Name = "Activité joyeuse" });
            activities.Add(new Activity() { Name = "Activité triste" });

            // ON défini une source de données pour notre ListBox
            lbActivities.ItemsSource = activities;
        }
    }

    public class Activity
    {
        public string Name { get; set; }
    }
}