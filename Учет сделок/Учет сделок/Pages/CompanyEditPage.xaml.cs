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
    /// Логика взаимодействия для CompanyEditPage.xaml
    /// </summary>
    public partial class CompanyEditPage : Page
    {
        public CompanyEditPage()
        {
            InitializeComponent();
        }
        private void OnlyLetters(object sender, TextCompositionEventArgs e)
        {
            Regex inp = new Regex("^[А-Я]+", RegexOptions.IgnoreCase);
            Regex ing = new Regex("^[A-Z]+", RegexOptions.IgnoreCase);
            if (!inp.IsMatch(e.Text) && !ing.IsMatch(e.Text))
                e.Handled = true;
        }
        private void OnlyNumbers(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
        private void BtnReady_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var choice = MessageBox.Show("Вы точно хотите добавить данный договор ? ", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (choice == MessageBoxResult.Yes)
                {
                    if (TbTitleCompany.Text != null && TbPPC.Text != null && TbPaymentAccount.Text != null && TbOGRN.Text != null && TbNumberPhone.Text != null && TbINN.Text != null && TbDirector.Text != null && TbCorrespondent_Account.Text != null && TbBIC.Text != null && TbAddress.Text != null)
                    {
                        Company newCompany = new Company();
                        Bank_Details newBank = new Bank_Details();
                        newBank.ID_Bank_Details = App.db.Bank_Details.Max(c => c.ID_Bank_Details) + 1;
                        newBank.INN = TbINN.Text;
                        newBank.BIC = TbBIC.Text;
                        newBank.Payment_Account = TbPaymentAccount.Text;
                        newBank.Correspondent_Account = TbCorrespondent_Account.Text;
                        newBank.OGRN = TbOGRN.Text;
                        newBank.PPC = TbPPC.Text;
                        newCompany.ID_Company = App.db.Company.Max(c => c.ID_Company) + 1;
                        newCompany.Title_Company = TbTitleCompany.Text;
                        newCompany.Number_Phone = TbNumberPhone.Text;
                        newCompany.Address_Company = TbAddress.Text;
                        newCompany.Director = TbDirector.Text;
                        newCompany.ID_Bank_Details = App.db.Bank_Details.Max(c=>c.ID_Bank_Details) + 1;                                               
                        App.db.Bank_Details.Add(newBank);
                        App.db.Company.Add(newCompany);
                        App.db.SaveChanges();
                        MessageBox.Show("Компания добавлена!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.Content = new CompaniesPage();
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
