using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using Учет_сделок.Models_BD;
using Учет_сделок.Pages;

namespace Учет_сделок.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
           
        }
        private string sha256(string password)
        {
            SHA256Managed sHA256 = new SHA256Managed();
            byte[] hash = sHA256.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("x2"));
            }
            return result.ToString();
        }
        private void decodePassword()
        {
            var employees = App.db.Employee.ToList();
            for (int i = 0; i < employees.Count; i++)
            {
                employees[i].Password = sha256(employees[i].Password);
                App.db.SaveChanges();
            }
        }
        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string securePassword = sha256(password.Password);
                Employee enterUser = App.db.Employee.FirstOrDefault(u => u.Login == login.Text && u.Password == securePassword);

                if (enterUser != null)
                {
                    if (enterUser.Post == "Менеджер") 
                    {                       
                        App.workEmployee = enterUser;
                        NavigationService.Content = new MainMenu();
                    }
                    else
                    if (enterUser.Post == "Технический инспектор проектного отдела") 
                    {
                        App.workEmployee = enterUser;
                        NavigationService.Content = new MainMenu();
                    }
                }
                else throw new Exception("Сотрудник не найден! Введен неверный логин или пароль");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
