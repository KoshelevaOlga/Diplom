﻿using AnimalShelter.BD;
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

namespace AnimalShelter.windows.menu.Animals.kat
{
    /// <summary>
    /// Логика взаимодействия для KatListWindow.xaml
    /// </summary>
    public partial class KatListWindow : Window
    {
        public KatListWindow()
        {
            InitializeComponent();
            GetlvAnim();
        }
        private void GetlvAnim()
        {
            lvAnim.ItemsSource = ClassHelper.EF.Context.vw_Cat.ToList();
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
        private void BtnAnim_Clic(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var anim = button.DataContext as BD.vw_Cat;
            menu.Animals.kat.KatWindow katWindow = new kat.KatWindow(anim);
            katWindow.Show();
            this.Close();
        }

        private void BtnKat_Click(object sender, RoutedEventArgs e)
        {
            GetlvAnim();
        }

        private void BtnDog_Click(object sender, RoutedEventArgs e)
        {
            menu.Animals.dog.DogListWindow dogListWindow = new dog.DogListWindow();
            dogListWindow.Show();
            this.Close();
        }

        private void BtnRebit_Click(object sender, RoutedEventArgs e)
        {
            menu.Animals.rebit.RebitListWindow rebitListWindow = new rebit.RebitListWindow();
            rebitListWindow.Show();
            this.Close();
        }

        private void BtnAll_Click(object sender, RoutedEventArgs e)
        {
            menu.Animals.enather.AllListWindow allListWindow = new enather.AllListWindow();
            allListWindow.Show();
            this.Close();
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            menu.NewAnimWindow newAnimWindow = new NewAnimWindow();
            newAnimWindow.Show();
            this.Close();
        }
    }
}