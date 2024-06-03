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

namespace AnimalShelter.windows.menu
{
    /// <summary>
    /// Логика взаимодействия для VolerWindow.xaml
    /// </summary>
    public partial class VolerWindow : Window
    {
        public VolerWindow()
        {
            InitializeComponent();
        }


        private void BtnAnimals_Clic(object sender, RoutedEventArgs e)
        {
            menu.AnimalsWindow animalWindow = new menu.AnimalsWindow();
            animalWindow.Show();
            this.Close();
        }

        private void BtnVoler_Clic(object sender, RoutedEventArgs e)
        {
            menu.VolerWindow volerWindow = new menu.VolerWindow();
            volerWindow.Show();
            this.Close();
        }

        private void BtnFood_Clic(object sender, RoutedEventArgs e)
        {
            menu.FoodWindow foodWindow = new menu.FoodWindow();
            foodWindow.Show();
            this.Close();
        }

        private void BtnFamili_Clic(object sender, RoutedEventArgs e)
        {
            menu.FemeliWindow femeliWindow = new menu.FemeliWindow();
            femeliWindow.Show();
            this.Close();
        }

        private void BtnMenu_Clic(object sender, RoutedEventArgs e)
        {
            menu.MenuWindow menuWindow = new menu.MenuWindow();
            menuWindow.Show();
            this.Close();
        }

        private void BtnStreet_Click(object sender, RoutedEventArgs e)
        {
            menu.Voler.Stret.StreetVolierWindow streetVolierWindow = new Voler.Stret.StreetVolierWindow();
            streetVolierWindow.Show();
            this.Close();
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            menu.Voler.HomeVolierWindow homeVolierWindow = new Voler.HomeVolierWindow();
            homeVolierWindow.Show();
            this.Close();
        }

        private void BtnTime_Click(object sender, RoutedEventArgs e)
        {
            menu.Voler.TimeVolierWindow timeVolierWindow = new Voler.TimeVolierWindow();
            timeVolierWindow.Show();
            this.Close();
        }

    }
}
