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
using Учет_сделок.Pages;

namespace Учет_сделок
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new Authorization();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Result = MessageBox.Show("Закрыть приложение ?", "Закрытие", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void BtnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new MainMenu();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            {
                if (MainFrame.CanGoBack)
                {
                    MainFrame.GoBack();
                }
            }
        }


        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (WinMW.Title == "Главное меню" || WinMW.Title == "Авторизация" || WinMW.Title == "")
            {
                BtnMainMenu.Visibility = Visibility.Hidden;
                BtnBack.Visibility = Visibility.Hidden;
            }
            else
            {
                BtnMainMenu.Visibility = Visibility.Visible;
                BtnBack.Visibility = Visibility.Visible;
            }
        }
    }
}

