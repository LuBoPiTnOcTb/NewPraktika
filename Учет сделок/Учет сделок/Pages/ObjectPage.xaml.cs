using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
    /// Логика взаимодействия для ObjectPage.xaml
    /// </summary>
    public partial class ObjectPage : Page
    {
        public ObjectPage()
        {
            InitializeComponent();
            dgObject.ItemsSource = App.db.Object.ToList();
            CbSort.SelectedIndex = 0;
            if (App.workEmployee.Post == "Технический инспектор проектного отдела")
            {
                BtnAdd.Visibility = Visibility.Hidden;
                BtnDel.Visibility = Visibility.Hidden;
                tbAction.Visibility = Visibility.Hidden;
            }
        }
        private void GetData(string search = "", string Filter = "")
        {
            try
            {
                var objects = App.db.Object.ToList();
                if (!String.IsNullOrEmpty(search) && !String.IsNullOrWhiteSpace(search))
                {
                    objects = objects.Where(c => c.Address_Object.ToString().Contains(search.ToLower())).ToList();
                }
                if (!String.IsNullOrEmpty(Filter) && !String.IsNullOrWhiteSpace(Filter))
                {
                    if (Filter == "Названию")
                    {
                        objects = objects.ToList().OrderBy(c => c.Title_Object).ToList();
                    }
                    else if (Filter == "Назначению")
                    {
                        objects = objects.ToList().OrderBy(c => c.Purpose).ToList();
                    }
                    else if (Filter == "Адресу")
                    {
                        objects = objects.ToList().OrderBy(c => c.Address_Object).ToList();
                    }
                    else if (Filter == "Режиму работы")
                    {
                        objects = objects.ToList().OrderBy(c => c.Work_Mode).ToList();
                    }
                    else if (Filter == "Компании")
                    {
                        objects = objects.ToList().OrderBy(c => c.Company.Title_Company).ToList();
                    }
                }
                if (objects.Count != 0)
                {
                    dgObject.ItemsSource = objects.ToList();
                }
                else throw new Exception("Данные не найдены!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }        
        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetData(TbSearch.Text, CbSort.SelectedItem.ToString());
        }

        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetData(TbSearch.Text, ((ComboBoxItem)CbSort.SelectedValue).Content.ToString());
        }

        private void dgObject_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new ObjectEditPage();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (dgObject.SelectedItem != null)
            {
                try
                {
                    var cdwd = dgObject.SelectedItem as Models_BD.Object;
                    var choice = MessageBox.Show("Вы точно хотите удалить выбранные данные?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (choice == MessageBoxResult.Yes)
                    {
                        App.db.Object.Remove(cdwd);
                        App.db.SaveChanges();
                        dgObject.ItemsSource = App.db.Object.ToList();
                        MessageBox.Show("Удаление успешно!", "Готово", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!");
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!");
                }
            }
            else MessageBox.Show("Выберите запись которую хотите удалить", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
