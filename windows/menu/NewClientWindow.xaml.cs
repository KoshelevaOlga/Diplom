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
using System.Xml.Linq;

namespace AnimalShelter.windows.menu
{
    /// <summary>
    /// Логика взаимодействия для NewClientWindow.xaml
    /// </summary>
    public partial class NewClientWindow : Window
    {
        string animals = null;
        public NewClientWindow()
        {
            InitializeComponent();
        }
        public NewClientWindow( string anim)
        { 
            InitializeComponent();

            animals = anim;

            tbNikc.Text = animals;

            List<string> breedList = ClassHelper.EF.Context.Animal.Join(ClassHelper.EF.Context.Breed,
                                                                           a => a.IdBreed,
                                                                           b => b.Id,
                                                                           (a, b) => new { a.Nickname, b.Title }).Where(i => i.Nickname == animals).Select(i => i.Title).ToList();
            tbBreed.Text = String.Join(", ", breedList.Select(b => b.ToString()));

            cmbGender.ItemsSource = ClassHelper.EF.Context.Gender.ToList();
            cmbGender.DisplayMemberPath = "Title";
            cmbGender.SelectedIndex = 0;
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
        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFirstName.Text))
            {
                MessageBox.Show("Фамилия не добавлена", "Неудача", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (string.IsNullOrEmpty(tbLastName.Text))
            {
                MessageBox.Show("Имя не добавлено", "Неудача", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (string.IsNullOrEmpty(dpBirth.Text))
            {
                MessageBox.Show("Дата рождения не добавлена", "Неудача", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            BD.Client newClient = new BD.Client();

            newClient.FirstName = tbFirstName.Text;
            newClient.LasstName = tbLastName.Text;
            newClient.Phone = tbPhone.Text;
            newClient.DateOfBirth = Convert.ToDateTime(dpBirth.Text);
            newClient.Addres = tbAddres.Text;
            newClient.IdGender = (cmbGender.SelectedItem as BD.Gender).Id;

            ClassHelper.EF.Context.Client.Add(newClient);
            ClassHelper.EF.Context.SaveChanges();
            MessageBox.Show("Питомец отправился в новую семью", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            BD.AnimalClient newAnimalClient = new BD.AnimalClient();

            newAnimalClient.IdAction = 3;

            int animId = ClassHelper.EF.Context.Animal.Where(i => i.Nickname == animals).Select(i => i.Id).FirstOrDefault();
            newAnimalClient.IdAnimal = animId;

            int maxId = ClassHelper.EF.Context.Client.Max(i => i.Id);
            newAnimalClient.IdClient = maxId;
            newAnimalClient.StartDay = DateTime.Today;

            ClassHelper.EF.Context.AnimalClient.Add(newAnimalClient);
            ClassHelper.EF.Context.SaveChanges();

            BD.Animal udateAnimal = new BD.Animal();
            var anim = ClassHelper.EF.Context.Animal.FirstOrDefault(i => i.Id == animId);
            if (anim != null)
            {
                anim.Status = false;
            }

            ClassHelper.EF.Context.SaveChanges();
        }
    }
}
