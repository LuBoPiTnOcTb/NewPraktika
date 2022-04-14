using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Учет_сделок.Pages
{
    /// <summary>
    /// Логика взаимодействия для ObjectEditPage.xaml
    /// </summary>
    public partial class ObjectEditPage : Page
    {
        public ObjectEditPage()
        {
            InitializeComponent();
            CbTitleCompany.ItemsSource = App.db.Company.ToList();

        }
        private void OnlyLetters(object sender, TextCompositionEventArgs e)
        {
            Regex inp = new Regex("^[А-Я]+", RegexOptions.IgnoreCase);
            Regex ing = new Regex("^[A-Z]+", RegexOptions.IgnoreCase);
            if (!inp.IsMatch(e.Text) && !ing.IsMatch(e.Text))
                e.Handled = true;
        }
        private void BtnReady_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var choice = MessageBox.Show("Вы точно хотите добавить данный объект ? ", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (choice == MessageBoxResult.Yes)
                {
                    if (TbAddressObject.Text != null && TbPurpose.Text != null && TbTitleObject.Text != null && TbWorkMode.Text != null && CbTitleCompany.Text != null )
                    {
                        Models_BD.Object newObject = new Models_BD.Object();
                        newObject.ID_Object = App.db.Object.Max(c => c.ID_Object) + 1;
                        newObject.Address_Object = TbAddressObject.Text;
                        newObject.Purpose = TbPurpose.Text;
                        newObject.Title_Object = TbTitleObject.Text;
                        newObject.Work_Mode = TbWorkMode.Text;
                        newObject.ID_Company = (CbTitleCompany.SelectedItem as Company).ID_Company;
                        App.db.Object.Add(newObject);
                        App.db.SaveChanges();
                        MessageBox.Show("Объект добавлен!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.Content = new ObjectPage();
                    }
                    else MessageBox.Show("Введены некорректные данные или остались незаполненные поля!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
