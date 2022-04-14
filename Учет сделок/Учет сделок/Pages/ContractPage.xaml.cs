using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
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
using word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using Page = System.Windows.Controls.Page;
using excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace Учет_сделок.Pages
{
    /// <summary>
    /// Логика взаимодействия для ContractPage.xaml
    /// </summary>
    public partial class ContractPage : Page
    {
        public ContractPage()
        {
            InitializeComponent();
            dgContract.ItemsSource = App.db.Contract.ToList();
            CbSort.SelectedIndex = 0;
            if (App.workEmployee.Post == "Технический инспектор проектного отдела")
            {
                BtnAdd.Visibility = Visibility.Hidden;
                BtnDel.Visibility = Visibility.Hidden;
                tbAction.Visibility = Visibility.Hidden;
            }
        }
        private void OnlyNumbers(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
        private void GetData(string search = "", string Filter = "")
        {
            try
            {
                var contracts = App.db.Contract.ToList();
                if (!String.IsNullOrEmpty(search) && !String.IsNullOrWhiteSpace(search))
                {
                    contracts = contracts.Where(c => c.ID_Contract.ToString().Contains(search.ToLower())).ToList();
                }
                if (!String.IsNullOrEmpty(Filter) && !String.IsNullOrWhiteSpace(Filter))
                {
                    if (Filter == "Дате заключения")
                    {
                        contracts = contracts.ToList().OrderBy(c => c.Date_Conclusion).ToList();
                    }
                    else if (Filter == "Дате окончания")
                    {
                        contracts = contracts.ToList().OrderBy(c => c.Valid_For).ToList();
                    }
                    else if (Filter == "Директору")
                    {
                        contracts = contracts.ToList().OrderBy(c => c.Object.Company.Director).ToList();
                    }
                    else if (Filter == "Компании")
                    {
                        contracts = contracts.ToList().OrderBy(c => c.Object.Company.Title_Company).ToList();
                    }
                    else if (Filter == "Объекту")
                    {
                        contracts = contracts.ToList().OrderBy(c => c.Object.Title_Object).ToList();
                    }
                    else if (Filter == "Цене")
                    {
                        contracts = contracts.ToList().OrderBy(c => c.Price).ToList();
                    }
                }
                if (contracts.Count != 0)
                {
                    dgContract.ItemsSource = contracts.ToList();
                }
                else throw new Exception("Данные не найдены!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
       
        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetData(TbSearch.Text, ((ComboBoxItem)CbSort.SelectedValue).Content.ToString());
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new ContractEditPage();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (dgContract.SelectedItem != null)
            {
                try
                {
                    var cdwd = dgContract.SelectedItem as Contract;
                    var choice = MessageBox.Show("Вы точно хотите удалить выбранные данные?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (choice == MessageBoxResult.Yes)
                    {
                        App.db.Contract.Remove(cdwd);
                        App.db.SaveChanges();
                        dgContract.ItemsSource = App.db.Contract.ToList();
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

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetData(TbSearch.Text, CbSort.SelectedItem.ToString());
        }

        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgContract.SelectedItem != null)
                {
                    Contract selected = dgContract.SelectedItem as Contract;
                    SaveFileDialog sfd = new SaveFileDialog();
                    string source = $@"{Directory.GetCurrentDirectory()}\Договор.doc";
                    word.Application app = new word.Application();
                    word.Document doc = app.Documents.Open(source);
                    word.Bookmarks wB = doc.Bookmarks;
                    doc.Activate();
                    try
                    {
                        if (sfd.ShowDialog() == false)
                        {
                            doc.Close();
                            doc = null;
                            app.Quit();
                            return;
                        }
                        wB["НазваниеКомпании"].Range.Text = selected.Object.Company.Title_Company;
                        wB["НазваниеКомпании1"].Range.Text = selected.Object.Company.Title_Company;
                        wB["НазваниеКомпании4"].Range.Text = selected.Object.Company.Title_Company;
                        wB["НазваниеКомпании5"].Range.Text = selected.Object.Company.Title_Company;
                        wB["Директор"].Range.Text = selected.Object.Company.Director;
                        wB["АдресОбъекта"].Range.Text = selected.Object.Address_Object;
                        wB["АдресОбъекта1"].Range.Text = selected.Object.Address_Object;
                        wB["НазначениеОбъекта"].Range.Text = selected.Object.Purpose;
                        wB["РежимРаботы"].Range.Text = selected.Object.Work_Mode;
                        wB["Марки"].Range.Text = selected.Main_Equipment_Boiler_.Stamp;
                        wB["Модель"].Range.Text = selected.Main_Equipment_Boiler_.Model;
                        wB["Мощность"].Range.Text = Convert.ToString(selected.Main_Equipment_Boiler_.Power);
                        wB["ОбщаяМощность"].Range.Text = Convert.ToString(selected.Main_Equipment_Boiler_.PowerSumm);
                        wB["КоличествоКотлов"].Range.Text = Convert.ToString(selected.Main_Equipment_Boiler_.Quantity);
                        wB["Цена"].Range.Text = String.Format("{0:0 руб.}", selected.Price); ;
                        wB["НомерДоговора"].Range.Text = Convert.ToString(selected.ID_Contract);
                        wB["НомерДоговора1"].Range.Text = Convert.ToString(selected.ID_Contract);
                        wB["ДатаЗаключения"].Range.Text = selected.Date_Conclusion.ToShortDateString();
                        wB["ДатаЗаключения1"].Range.Text = selected.Date_Conclusion.ToShortDateString();
                        wB["ДействуетПо"].Range.Text = Convert.ToString(selected.Valid_For);
                        doc.SaveAs2(sfd.FileName);
                        doc.Close();
                        doc = null;
                        app.Quit();
                        MessageBox.Show("Файл успешно создан");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        doc.Close();
                        doc = null;
                        app.Quit();
                    }
                }
                else throw new Exception("Запись не выбрана,выберите запись и повторите попытку!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dgContract_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DpStart.SelectedDate == null && DpFinish.SelectedDate == null)
                {
                    MessageBox.Show("Введены некорректные данные или остались незаполненные поля!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    excel.Application app = new excel.Application();
                    excel.Workbook wB;
                    excel.Worksheet wS;
                    wB = app.Workbooks.Add();
                    wS = (excel.Worksheet)wB.Worksheets.get_Item(1);
                    wS.Cells[4, 1] = "Номер договора";
                    wS.Cells[4, 2] = "Дата подписания";
                    wS.Cells[4, 3] = "Дата окончания действия";
                    wS.Cells[4, 4] = "Название объекта";
                    wS.Cells[4, 5] = "Название компании";
                    wS.Cells[4, 6] = "Директор компании";
                    wS.Cells[4, 7] = "Стоимость";
                    try
                    {
                        if (sfd.ShowDialog() == false)
                        {
                            wB.Close();
                            wB = null;
                            app.Quit();
                            return;
                        }
                        List<Contract> contracts = App.db.Contract.Where(c => c.Date_Conclusion >= DpStart.DisplayDate && c.Date_Conclusion <= DpFinish.DisplayDate).ToList();
                        dgContract.ItemsSource = contracts;
                        for (int i = 0; i < contracts.Count; i++)
                        {
                            wS.Cells[i + 5, 1].Value = contracts[i].ID_Contract;
                            wS.Cells[i + 5, 2].Value = contracts[i].Date_Conclusion;
                            wS.Cells[i + 5, 3].Value = contracts[i].Valid_For;
                            wS.Cells[i + 5, 4].Value = contracts[i].Object.Title_Object;
                            wS.Cells[i + 5, 5].Value = contracts[i].Object.Company.Title_Company;
                            wS.Cells[i + 5, 6].Value = contracts[i].Object.Company.Director;
                            wS.Cells[i + 5, 7].Value = contracts[i].Price;
                        }
                        wS.Columns.AutoFit();
                        app.Application.ActiveWorkbook.SaveAs(sfd.FileName);
                        MessageBox.Show("Файл успешно сохранен");
                        app.Quit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        app.Quit();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private void BtnExportGraph_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int count = 0;
                var app = new excel.Application();
                try
                {
                    SaveFileDialog svd = new SaveFileDialog();
                    svd.Title = "Сохранить как...";
                    svd.Filter = "Excel file(*.xlsx)|.*xslx";
                    svd.OverwritePrompt = true;
                    svd.CheckPathExists = true;
                    if (svd.ShowDialog() == false)
                    {
                        app.Quit();
                    }
                    else
                    {
                        List<Contract> specializationList = App.db.Contract.ToList();
                        app.Workbooks.Add(Type.Missing);
                        var worksheet = (excel.Worksheet)app.Worksheets[1];
                        count = specializationList.Count;
                        for (int i = 0; i < count; i++)
                        {
                            worksheet.Cells[i + 1, 1] = specializationList[i].Date_Conclusion;
                            worksheet.Cells[i + 1, 2] = specializationList[i].Price;
                        }
                        worksheet.Columns.AutoFit();
                        var xlCharts = (excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                        var myChart = (excel.ChartObject)xlCharts.Add(110, 0, 350, 250);
                        var chart = myChart.Chart;
                        var seriesCollection = (excel.SeriesCollection)chart.SeriesCollection(Type.Missing);
                        var series = seriesCollection.NewSeries();
                        series.XValues = worksheet.get_Range("A1", "A" + count);
                        series.Values = worksheet.get_Range("B1", "B" + count);
                        chart.ChartType = excel.XlChartType.xl3DColumn;
                        app.Application.ActiveWorkbook.SaveAs(svd.FileName);
                        app.Quit();
                        MessageBox.Show("Отчет сформирован!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    app.Quit();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void BtnFiltr_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DpStart.SelectedDate == null && DpFinish.SelectedDate == null)
                {
                    MessageBox.Show("Введены некорректные данные или остались незаполненные поля!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }else
                if (DpStart.SelectedDate >= DpFinish.SelectedDate)
                {
                    MessageBox.Show("Дата окончания не может быть раньше даты началы или равна ей,исправьте данные и повторите попытку", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else dgContract.ItemsSource = App.db.Contract.Where(c => c.Date_Conclusion >= DpStart.DisplayDate && c.Date_Conclusion <= DpFinish.DisplayDate).ToList();
            }
            catch
            {
                MessageBox.Show("Введены некорректные данные или остались незаполненные поля!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
