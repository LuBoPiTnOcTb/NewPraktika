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
    /// Логика взаимодействия для EquipmentEditPage.xaml
    /// </summary>
    public partial class EquipmentEditPage : Page
    {
        public EquipmentEditPage()
        {
            InitializeComponent();
        }
        private void OnlyNumbers(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
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
                var choice = MessageBox.Show("Вы точно хотите добавить данное оборудование ? ", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (choice == MessageBoxResult.Yes)
                {
                    if (TbUnitOfMeasurement.Text != null && TbStamp.Text != null && TbService.Text != null && TbQuantity.Text != "" && TbPower.Text != "" && TbModel.Text != null )
                    {
                        Main_Equipment_Boiler_ newEquipment = new Main_Equipment_Boiler_();
                        newEquipment.ID_Equipment = App.db.Main_Equipment_Boiler_.Max(c => c.ID_Equipment) + 1;
                        newEquipment.Model = TbModel.Text;
                        newEquipment.Stamp = TbStamp.Text;
                        newEquipment.Power = Convert.ToInt32(TbPower.Text);
                        newEquipment.Quantity = Convert.ToInt32(TbQuantity.Text);
                        newEquipment.Unit_Of_Measurement = TbUnitOfMeasurement.Text;
                        newEquipment.Service = TbService.Text;
                        App.db.Main_Equipment_Boiler_.Add(newEquipment);
                        App.db.SaveChanges();
                        MessageBox.Show("Оборудование добавлено!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.Content = new EquipmentPage();
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
