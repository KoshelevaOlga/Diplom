using AnimalShelter.BD;
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

namespace AnimalShelter.windows.menu.Voler.Home
{
    /// <summary>
    /// Логика взаимодействия для HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        BD.vw_HomeAviary Aviary = null;
        public HomeWindow()
        {
            InitializeComponent();
        }
        public HomeWindow(BD.vw_HomeAviary volier)
        {
            InitializeComponent();

            Aviary = volier;
            tbNumVolier.Text = Convert.ToString(volier.Number);
            tbHeight.Text = Convert.ToString(volier.Size);
            //tbQantity.Text = Convert.ToString(ClassHelper.EF.Context.Aviary.Where(i => i.Id == volier.Number).FirstOrDefault());
            TbResponsible.Text = Convert.ToString(volier.Responsible);
            TbPhone.Text = Convert.ToString(volier.Phone);

            lvAnim.ItemsSource = ClassHelper.EF.Context.Animal.Join(ClassHelper.EF.Context.Breed,
                                                                a => a.IdBreed,
                                                                b => b.Id,
                                                                (a, b) => new { Photo = a.Photo, a.Id, Nick = a.Nickname, Birth = a.DateOfBirth, Breed = b.Title, Description = a.Description }).
                                                                Join(ClassHelper.EF.Context.Location,
                                                                a => a.Id,
                                                                b => b.IdAnimal,
                                                                (a, b) => new { Photo = a.Photo, Nick = a.Nick, Birth = a.Birth, Breed = a.Breed, Description = a.Description, b.IdAviary }).Where(i => i.IdAviary == volier.Number).ToList();
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
            menu.Voler.HomeVolierWindow homeVolierWindow = new HomeVolierWindow();
            homeVolierWindow.Show();
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
