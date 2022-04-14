using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Учет_сделок.Models_BD;

namespace Учет_сделок
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static AccountingforTransactionsEntities db = new AccountingforTransactionsEntities();
        public static Employee workEmployee;
        public static Contract workContract;
    }
}
