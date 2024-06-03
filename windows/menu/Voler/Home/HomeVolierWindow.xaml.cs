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

namespace AnimalShelter.windows.menu.Voler
{
    /// <summary>
    /// Логика взаимодействия для HomeVolierWindow.xaml
    /// </summary>
    public partial class HomeVolierWindow : Window
    {
        public HomeVolierWindow()
        {
            InitializeComponent();
            GetlvHomeAviary();
        }
        public void GetlvHomeAviary()
        {
            lvVolier.ItemsSource = ClassHelper.EF.Context.vw_HomeAviary.ToList();
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

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            menu.VolerWindow volerWindow = new menu.VolerWindow();
            volerWindow.Show();
            this.Close();
        }

        private void BtnStreet_Click(object sender, RoutedEventArgs e)
        {
            menu.Voler.Stret.StreetVolierWindow streetVolierWindow = new Stret.StreetVolierWindow();
            streetVolierWindow.Show();
            this.Close();
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            GetlvHomeAviary();
        }

        private void BtnTime_Click(object sender, RoutedEventArgs e)
        {
            menu.Voler.TimeVolierWindow timeVolierWindow = new TimeVolierWindow();
            timeVolierWindow.Show();
            this.Close();
        }

        private void BtnVolier_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var volier = button.DataContext as BD.vw_HomeAviary;
            menu.Voler.Home.HomeWindow homeWindow = new Home.HomeWindow(volier);
            homeWindow.Show();
            this.Close();
        }
    }
}
