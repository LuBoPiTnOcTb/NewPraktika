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
using Учет_сделок.Models_BD;

namespace Учет_сделок.Pages
{
    /// <summary>
    /// Логика взаимодействия для ContractEditPage.xaml
    /// </summary>
    public partial class ContractEditPage : Page
    {
        public ContractEditPage()
        {
            InitializeComponent();
            CbTitleObject.ItemsSource = App.db.Object.ToList();             
            CbFIOEmployee.ItemsSource = App.db.Employee.ToList();            
            CbStampEquipment.ItemsSource = App.db.Main_Equipment_Boiler_.ToList();
            
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
                    if (CbFIOEmployee.Text != null && CbStampEquipment.Text != null && CbTitleObject.Text != null && TbPrice.Text != "")
                    {
                        Contract newContract = new Contract();                        
                        newContract.ID_Contract = App.db.Contract.Max(c => c.ID_Contract) + 1;
                        newContract.ID_Equipment = (CbStampEquipment.SelectedItem as Main_Equipment_Boiler_).ID_Equipment;
                        newContract.ID_Employee = (CbFIOEmployee.SelectedItem as Employee).ID_Employee;
                        newContract.ID_Object = (CbTitleObject.SelectedItem as Models_BD.Object).ID_Object;
                        newContract.Price = Convert.ToInt32(TbPrice.Text);
                        newContract.Date_Conclusion = DateTime.Now;
                        newContract.Valid_For = DateTime.Now.AddDays(90);
                        App.db.Contract.Add(newContract);
                        App.db.SaveChanges();
                        MessageBox.Show("Договор добавлен!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.Content = new ContractPage();
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
