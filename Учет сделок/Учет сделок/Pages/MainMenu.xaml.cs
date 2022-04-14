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

namespace Учет_сделок.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
            TbUser.Text = "Добро пожаловать, " + App.workEmployee.Surname + " " + App.workEmployee.Name + " " + App.workEmployee.Middle_Name;
        }
        private void btnObject_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new ObjectPage();
        }

        private void btnCompany_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new CompaniesPage();
        }

        private void btnEquipment_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new EquipmentPage();
        }

        private void btnContract_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new ContractPage();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new Authorization();
        }
    }
}
