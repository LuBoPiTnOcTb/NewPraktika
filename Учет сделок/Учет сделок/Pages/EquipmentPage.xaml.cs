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
using Учет_сделок.Models_BD;

namespace Учет_сделок.Pages
{
    /// <summary>
    /// Логика взаимодействия для EquipmentPage.xaml
    /// </summary>
    public partial class EquipmentPage : Page
    {
        public EquipmentPage()
        {
            InitializeComponent();
            dgEquipment.ItemsSource = App.db.Main_Equipment_Boiler_.ToList();
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
                var equipments = App.db.Main_Equipment_Boiler_.ToList();
                if (!String.IsNullOrEmpty(search) && !String.IsNullOrWhiteSpace(search))
                {
                    equipments = equipments.Where(c => c.Stamp.ToString().Contains(search.ToLower())).ToList();
                }
                if (!String.IsNullOrEmpty(Filter) && !String.IsNullOrWhiteSpace(Filter))
                {
                    if (Filter == "Моделе")
                    {
                        equipments = equipments.ToList().OrderBy(c => c.Model).ToList();
                    }
                    else if (Filter == "Мощности")
                    {
                        equipments = equipments.ToList().OrderBy(c => c.Power).ToList();
                    }
                    else if (Filter == "Сумманой мощности")
                    {
                        equipments = equipments.ToList().OrderBy(c => c.PowerSumm).ToList();
                    }
                    else if (Filter == "Кол-ву")
                    {
                        equipments = equipments.ToList().OrderBy(c => c.Quantity).ToList();
                    }
                }
                if (equipments.Count != 0)
                {
                    dgEquipment.ItemsSource = equipments.ToList();
                }
                else throw new Exception("Данные не найдены!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }       
        private void dgEquipment_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new EquipmentEditPage();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (dgEquipment.SelectedItem != null)
            {
                try
                {
                    var cdwd = dgEquipment.SelectedItem as Main_Equipment_Boiler_;
                    var choice = MessageBox.Show("Вы точно хотите удалить выбранные данные?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (choice == MessageBoxResult.Yes)
                    {
                        App.db.Main_Equipment_Boiler_.Remove(cdwd);
                        App.db.SaveChanges();
                        dgEquipment.ItemsSource = App.db.Main_Equipment_Boiler_.ToList();
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

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetData(TbSearch.Text, CbSort.SelectedItem.ToString());
        }
    }
}
