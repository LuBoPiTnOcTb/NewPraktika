using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
    /// Логика взаимодействия для CompaniesPage.xaml
    /// </summary>
    public partial class CompaniesPage : Page
    {
        public CompaniesPage()
        {
            InitializeComponent();
            GetData();
            CbSort.SelectedIndex = 0;
            if (App.workEmployee.Post == "Технический инспектор проектного отдела")
            {
               BtnAdd.Visibility = Visibility.Hidden;
               BtnDel.Visibility = Visibility.Hidden;
               tbAction.Visibility = Visibility.Hidden;
            }
        }
        private void OnlyLetters(object sender, TextCompositionEventArgs e)
        {
            Regex inp = new Regex("^[А-Я]+", RegexOptions.IgnoreCase);
            Regex ing = new Regex("^[A-Z]+", RegexOptions.IgnoreCase);
            if (!inp.IsMatch(e.Text) && !ing.IsMatch(e.Text))
                e.Handled = true;
        }
            
        private void GetData(string search="",string Filter = "")
        {
            try
            {
                var companies = App.db.Company.ToList();
                if (!String.IsNullOrEmpty(search)&&!String.IsNullOrWhiteSpace(search))
                {
                    companies = companies.Where(c => c.Title_Company.ToLower().Contains(search.ToLower())).ToList();
                }
                if (!String.IsNullOrEmpty(Filter) && !String.IsNullOrWhiteSpace(Filter))
                {
                    if (Filter=="Директору")
                    {
                        companies = companies.ToList().OrderBy(c=>c.Director).ToList();
                    }
                    else if (Filter == "Названию")
                    {
                        companies = companies.ToList().OrderBy(c => c.Title_Company).ToList();
                    }
                    else if (Filter == "Адресу")
                    {
                        companies = companies.ToList().OrderBy(c => c.Address_Company).ToList();
                    }
                }
                if (companies.Count != 0)
                {
                    dgCompany.ItemsSource = companies.ToList();
                }
                else throw new Exception("Данные не найдены!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SearchTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetData(TbSearch.Text, CbSort.SelectedItem.ToString());
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new CompanyEditPage();
        }
        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (dgCompany.SelectedItem != null)
            {
                try
                {
                    var cdwd = dgCompany.SelectedItem as Company;
                    var choice = MessageBox.Show("Вы точно хотите удалить выбранные данные?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (choice == MessageBoxResult.Yes)
                    {
                        App.db.Company.Remove(cdwd);                        
                        App.db.SaveChanges();
                        dgCompany.ItemsSource = App.db.Company.ToList();
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

        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetData(TbSearch.Text, ((ComboBoxItem)CbSort.SelectedValue).Content.ToString());
        }

        private void dgCompany_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
