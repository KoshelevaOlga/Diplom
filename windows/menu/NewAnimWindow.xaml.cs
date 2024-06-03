using Microsoft.Win32;
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
    /// Логика взаимодействия для NewAnimWindow.xaml
    /// </summary>
    public partial class NewAnimWindow : Window
    {
        public NewAnimWindow()
        {
            InitializeComponent();

            List<string> sterilizationValues = new List<string> { "да", "нет" };
            cmbKostr.ItemsSource = sterilizationValues;

            cmbBreed.ItemsSource = ClassHelper.EF.Context.Breed.ToList();
            cmbBreed.DisplayMemberPath = "Title";
            cmbBreed.SelectedIndex = 0;

            cmbGender.ItemsSource = ClassHelper.EF.Context.GenderAnimal.ToList();
            cmbGender.DisplayMemberPath = "Title";
            cmbGender.SelectedIndex = 0;

            cmbAviar.ItemsSource = ClassHelper.EF.Context.Aviary.ToList();
            cmbAviar.DisplayMemberPath = "Id";
            cmbAviar.SelectedIndex = 0;

            cmbKorm.ItemsSource = ClassHelper.EF.Context.Food.ToList();
            cmbKorm.DisplayMemberPath = "Title";
            cmbKorm.SelectedIndex = 0;
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

        private string Photo = null;
        private void btChoseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                imgAnim.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                Photo = openFileDialog.FileName;
            }
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Кличка не добавлена", "Неудача", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (string.IsNullOrEmpty(dpBirth.Text))
            {
                MessageBox.Show("Дата рождения не добавлена", "Неудача", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (string.IsNullOrEmpty(tbOkras.Text))
            {
                MessageBox.Show("Окрас не добавлена", "Неудача", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (string.IsNullOrEmpty(tbWes.Text))
            {
                MessageBox.Show("Вес животного не добавлен", "Неудача", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            BD.Animal newAnimal = new BD.Animal();

            newAnimal.Nickname = tbName.Text;
            newAnimal.Status = Convert.ToBoolean(1);
            newAnimal.DateOfBirth = Convert.ToDateTime(dpBirth.Text);
            newAnimal.Tint = tbOkras.Text;
            newAnimal.Weight = Convert.ToDecimal(tbWes.Text);
            newAnimal.FeedRateInGram = Convert.ToInt32(400);
            newAnimal.Description = tbInfo.Text;

            if (cmbKostr.Text == "Да")
            {
                newAnimal.Sterilization = Convert.ToBoolean(1);
            }
            else
            {
                newAnimal.Sterilization = Convert.ToBoolean(0);
            }

            if (Photo != null)
            {
                newAnimal.Photo = Photo;
            }

            newAnimal.IdGender = (cmbGender.SelectedItem as BD.GenderAnimal).Id;
            newAnimal.IdBreed = (cmbBreed.SelectedItem as BD.Breed).Id;
            newAnimal.TypeOfFeed = (cmbKorm.SelectedItem as BD.Food).Id;
            

            ClassHelper.EF.Context.Animal.Add(newAnimal);
            ClassHelper.EF.Context.SaveChanges();
            MessageBox.Show("Питомец добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            BD.Location newLocation = new BD.Location();
            int maxId = ClassHelper.EF.Context.Animal.Max(i => i.Id);
            newLocation.IdAviary = (cmbAviar.SelectedItem as BD.Aviary).Id;
            newLocation.IdAnimal = maxId;

            ClassHelper.EF.Context.Location.Add(newLocation);
            ClassHelper.EF.Context.SaveChanges();
        }
    }
}
