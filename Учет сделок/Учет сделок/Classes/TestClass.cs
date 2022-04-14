using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Учет_сделок.Models_BD;

namespace Учет_сделок.Classes
{
    public class TestClass
    {
        public static bool SortTitleCompany()
        {
            var EnterUser = App.db.Company.OrderBy(c => c.Title_Company).ToList();
            if (EnterUser != null)
            {
                return true;
            }
            else return false;
        }

        public static bool SortEquipmentPower()
        {
            var EnterUser = App.db.Main_Equipment_Boiler_.OrderBy(c => c.Power).ToList();
            if (EnterUser != null)
            {
                return true;
            }
            else return false;
        }
        public static bool SortEquipmentModel()
        {
            var EnterUser = App.db.Main_Equipment_Boiler_.OrderBy(c => c.Model).ToList();
            if (EnterUser != null)
            {
                return true;
            }
            else return false;
        }
        public static bool SortAddressCompany()
        {
            var EnterUser = App.db.Company.OrderBy(c => c.Address_Company).ToList();
            if (EnterUser != null)
            {
                return true;
            }
            else return false;
        }
        public static bool SortObjectTitle()
        {
            var EnterUser = App.db.Object.OrderBy(c => c.Title_Object).ToList();
            if (EnterUser != null)
            {
                return true;
            }
            else return false;
        }
        public static bool SortObjectPurpose()
        {
            var EnterUser = App.db.Object.OrderBy(c => c.Purpose).ToList();
            if (EnterUser != null)
            {
                return true;
            }
            else return false;
        }
        public static bool SortObjectAddress()
        {
            var EnterUser = App.db.Object.OrderBy(c => c.Address_Object).ToList();
            if (EnterUser != null)
            {
                return true;
            }
            else return false;
        }
        public static bool SortObjectWork()
        {
            var EnterUser = App.db.Object.OrderBy(c => c.Work_Mode).ToList();
            if (EnterUser != null)
            {
                return true;
            }
            else return false;
        }
        public static bool SortDirectorCompany()
        {
            var EnterUser = App.db.Company.OrderBy(c => c.Director).ToList();
            if (EnterUser != null)
            {
                return true;
            }
            else return false;
        }
        public static bool SortTitleCompanyObject()
        {
            var EnterUser = App.db.Object.OrderBy(c => c.Company.Title_Company).ToList();
            if (EnterUser != null)
            {
                return true;
            }
            else return false;
        }
        public static bool SortContractDateConcl()
        {
            var EnterUser = App.db.Contract.OrderBy(c => c.Date_Conclusion).ToList();
            if (EnterUser != null)
            {
                return true;
            }
            else return false;
        }
        public static bool SortContractValidFor()
        {
            var EnterUser = App.db.Contract.OrderBy(c => c.Valid_For).ToList();
            if (EnterUser != null)
            {
                return true;
            }
            else return false;
        }
        public static bool SortContractDirectorComp()
        {
            var EnterUser = App.db.Contract.OrderBy(c => c.Object.Company.Director).ToList();
            if (EnterUser != null)
            {
                return true;
            }
            else return false;
        }
        public static bool SortContractTitleComp()
        {
            var EnterUser = App.db.Contract.OrderBy(c => c.Object.Company.Title_Company).ToList();
            if (EnterUser != null)
            {
                return true;
            }
            else return false;
        }
        public static bool SortContractTitleObj()
        {
            var EnterUser = App.db.Contract.OrderBy(c => c.Object.Title_Object).ToList();
            if (EnterUser != null)
            {
                return true;
            }
            else return false;
        }
        public static bool SortContractPrice()
        {
            var EnterUser = App.db.Contract.OrderBy(c => c.Price).ToList();
            if (EnterUser != null)
            {
                return true;
            }
            else return false;
        }
        public static bool DeleteCompany(string TitleCompany, string AddressCompany, string NumberPhone, string Director, string INN)
        {
            try
            {
                var cdwd = App.db.Company.Where(c => c.Title_Company == TitleCompany && c.Address_Company == AddressCompany && c.Number_Phone == NumberPhone && c.Director == Director && c.Bank_Details.INN == INN).ToList();
                if (cdwd != null)
                {
                    App.db.Company.RemoveRange(cdwd);
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }
        public static bool NotDeleteCompany(string TitleCompany, string AddressCompany, string NumberPhone, string Director, string INN)
        {
            try
            {
                var cdwd = App.db.Company.Where(c => c.Title_Company == TitleCompany && c.Address_Company == AddressCompany && c.Number_Phone == NumberPhone && c.Director == Director && c.Bank_Details.INN == INN).ToList();
                if (cdwd == null)
                {
                    App.db.Company.RemoveRange(cdwd);
                    return false;
                }
            }
            catch (Exception)
            {
            }
            return true;
        }
        public static bool DeleteObject(string TitleObject, string Purpose, string Work, string Addressobj, string TitleCompany)
        {
            try
            {
                var cdwd = App.db.Object.Where(c => c.Company.Title_Company == TitleCompany && c.Title_Object == TitleObject && c.Purpose == Purpose && c.Work_Mode == Work && c.Address_Object == Addressobj).ToList();
                if (cdwd != null)
                {
                    App.db.Object.RemoveRange(cdwd);
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }
        public static bool NotDeleteObject(string TitleObject, string Purpose, string Work, string Addressobj, string TitleCompany)
        {
            try
            {
                var cdwd = App.db.Object.Where(c => c.Company.Title_Company == TitleCompany && c.Title_Object == TitleObject && c.Purpose == Purpose && c.Work_Mode == Work && c.Address_Object == Addressobj).ToList();
                if (cdwd == null)
                {
                    App.db.Object.RemoveRange(cdwd);
                    return false;
                }
            }
            catch (Exception)
            {
            }
            return true;
        }
    }
}
