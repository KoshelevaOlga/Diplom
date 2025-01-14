﻿using System;
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

namespace AnimalShelter.windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void BtnSingIn_Clic(object sender, RoutedEventArgs e)
        {
            var userAuth = ClassHelper.EF.Context.Employee.ToList().Where(i => i.Phone == TbLogin.Text && i.Password == PbPassword.Password).FirstOrDefault();
            if (userAuth != null)
            {
                menu.MenuWindow MenuWindow = new menu.MenuWindow();
                MenuWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пользователя не существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
