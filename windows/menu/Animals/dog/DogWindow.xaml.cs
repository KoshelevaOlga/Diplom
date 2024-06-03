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

namespace AnimalShelter.windows.menu.Animals.dog
{
    /// <summary>
    /// Логика взаимодействия для DogWindow.xaml
    /// </summary>
    public partial class DogWindow : Window
    {
        BD.vw_Dog allAnim = null;
        public DogWindow()
        {
            InitializeComponent();
        }
        public DogWindow(BD.vw_Dog anim)
        {
            InitializeComponent();

            allAnim = anim;

            imgAnim.Source = new BitmapImage(new Uri(anim.Photo));

            tbName.Text = anim.Nick;
            tbBirth.Text = anim.Birth.ToShortDateString();
            tbBreed.Text = anim.Breed;
            //tbGender
            var gender = ClassHelper.EF.Context.Animal.Join(ClassHelper.EF.Context.vw_Dog,
                                                                    a => a.Nickname,
                                                                    b => b.Nick,
                                                                    (a, b) => new { a.IdGender, b.Nick }).Where(i => i.Nick == anim.Nick).Join(ClassHelper.EF.Context.Gender,
                                                                            a => a.IdGender,
                                                                            b => b.Id,
                                                                            (a, b) => new { b.Title }).Select(i => i.Title).FirstOrDefault();

            tbGender.Text = gender;

            //tbKostr
            
            List<string> sterilizationValues = new List<string> { "да", "нет" };

            cmbKostr.ItemsSource = sterilizationValues;

            string currentSterilizationValue = ClassHelper.EF.Context.Animal
                .Join(ClassHelper.EF.Context.vw_Dog,
                      a => a.Nickname,
                      b => b.Nick,
                      (a, b) => new { a.Sterilization, b.Nick })
                .Where(i => i.Nick == anim.Nick)
                .Select(i => i.Sterilization ? "да" : "нет")
                .FirstOrDefault();

            cmbKostr.SelectedItem = currentSterilizationValue;

            //tbWes
            List<decimal> wesList = ClassHelper.EF.Context.Animal.Join(ClassHelper.EF.Context.vw_Dog,
                                                                            a => a.Nickname,
                                                                            b => b.Nick,
                                                                            (a, b) => new { a.Weight, b.Nick }).Where(i => i.Nick == anim.Nick).Select(i => i.Weight).ToList();
            tbWes.Text = String.Join(", ", wesList.Select(b => b.ToString()));

            //tbOkras
            List<string> OkrasList = ClassHelper.EF.Context.Animal.Join(ClassHelper.EF.Context.vw_Dog,
                                                                           a => a.Nickname,
                                                                           b => b.Nick,
                                                                           (a, b) => new { a.Tint, b.Nick }).Where(i => i.Nick == anim.Nick).Select(i => i.Tint).ToList();
            tbOkras.Text = String.Join(", ", OkrasList.Select(b => b.ToString()));

            //cmbAviar
            cmbAviar.ItemsSource = ClassHelper.EF.Context.Aviary.Join(ClassHelper.EF.Context.Location,
                                                                        a => a.Id,
                                                                        b => b.IdAviary,
                                                                        (a, b) => new { aviary = a.Id, b.IdAnimal }).Join(ClassHelper.EF.Context.Animal,
                                                                        a => a.IdAnimal,
                                                                        b => b.Id,
                                                                        (a, b) => new { a.aviary, b.Nickname }).ToList();
            cmbAviar.DisplayMemberPath = "aviary";
            cmbAviar.SelectedItem = ClassHelper.EF.Context.Aviary.Join(ClassHelper.EF.Context.Location,
                                                                        a => a.Id,
                                                                        b => b.IdAviary,
                                                                        (a, b) => new { aviary = a.Id, b.IdAnimal }).Join(ClassHelper.EF.Context.Animal,
                                                                        a => a.IdAnimal,
                                                                        b => b.Id,
                                                                        (a, b) => new { a.aviary, b.Nickname }).Where(i => i.Nickname == anim.Nick).FirstOrDefault();
            //cmbKorm
            var foodList = ClassHelper.EF.Context.Food.Join(ClassHelper.EF.Context.Animal,
                                                          a => a.Id,
                                                          b => b.TypeOfFeed,
                                                          (a, b) => new { a.Title, b.Nickname }).ToList();

            cmbKorm.ItemsSource = foodList;
            cmbKorm.DisplayMemberPath = "Title";

            var selectedFood = foodList.FirstOrDefault(i => i.Nickname == anim.Nick);
            cmbKorm.SelectedIndex = foodList.IndexOf(selectedFood);

            tbInfo.Text = anim.Description;
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
            var animal = ClassHelper.EF.Context.Animal.FirstOrDefault(i => i.Nickname == allAnim.Nick);
            if (animal != null)
            {
                //ves
                animal.Weight = Convert.ToDecimal(tbWes.Text);
                //okras
                animal.Tint = tbOkras.Text;
                //korm
                animal.TypeOfFeed = (cmbKorm.SelectedItem as BD.Food).Id;
                //volier

                //discript
                animal.Description = tbInfo.Text;
                //costr
                if (cmbKostr.Text == "Да")
                {
                    animal.Sterilization = Convert.ToBoolean(1);
                }
                else
                {
                    animal.Sterilization = Convert.ToBoolean(0);
                }

            }
        }

        private void btFemili_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            string anim = tbName.Text as string;
            menu.NewClientWindow newClientWindow = new menu.NewClientWindow(anim);
            newClientWindow.Show();
            this.Close();
        }
    }
}
