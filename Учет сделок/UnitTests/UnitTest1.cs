using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Учет_сделок.Classes;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
            public void ValidSortTitleCompany()
            {
                bool isValid = TestClass.SortTitleCompany();
                Assert.AreEqual(true, isValid);
            }
        [TestMethod]
        public void ValidSortEquipmentPower()
        {
            bool isValid = TestClass.SortEquipmentPower();
            Assert.AreEqual(true, isValid);
        }
       [TestMethod]
        public void ValidSortEquipmentModel()
        {
            bool isValid = TestClass.SortEquipmentModel();
            Assert.AreEqual(true, isValid);
        }
        [TestMethod]
        public void ValidSortAddressCompany()
        {
            bool isValid = TestClass.SortAddressCompany();
            Assert.AreEqual(true, isValid);
        }
        [TestMethod]
        public void ValidSortObjectTitle()
        {
            bool isValid = TestClass.SortObjectTitle();
            Assert.AreEqual(true, isValid);
        }
        [TestMethod]
        public void ValidObjectPurpose()
        {
            bool isValid = TestClass.SortObjectPurpose();
            Assert.AreEqual(true, isValid);
        }
        [TestMethod]
        public void ValidObjectAddress()
        {
            bool isValid = TestClass.SortObjectAddress();
            Assert.AreEqual(true, isValid);
        }
        [TestMethod]
        public void ValidSortObjectWork()
        {
            bool isValid = TestClass.SortObjectWork();
            Assert.AreEqual(true, isValid);
        }
        [TestMethod]
        public void ValidSortDirectorCompany()
        {
            bool isValid = TestClass.SortDirectorCompany();
            Assert.AreEqual(true, isValid);
        }
        [TestMethod]
        public void ValidSortTitleCompanyObject()
        {
            bool isValid = TestClass.SortTitleCompanyObject();
            Assert.AreEqual(true, isValid);
        }
        [TestMethod]
        public void ValidSortContractDateConcl()
        {
            bool isValid = TestClass.SortContractDateConcl();
            Assert.AreEqual(true, isValid);
        }
        [TestMethod]
        public void ValidSortContractValidFor()
        {
            bool isValid = TestClass.SortContractValidFor();
            Assert.AreEqual(true, isValid);
        }
        [TestMethod]
        public void ValidSortContractDirectorComp()
        {
            bool isValid = TestClass.SortContractDirectorComp();
            Assert.AreEqual(true, isValid);
        }
        [TestMethod]
        public void ValidSortContractTitleComp()
        {
            bool isValid = TestClass.SortContractTitleComp();
            Assert.AreEqual(true, isValid);
        }
        [TestMethod]
        public void ValidSortContractTitleObj()
        {
            bool isValid = TestClass.SortContractTitleObj();
            Assert.AreEqual(true, isValid);
        }
        [TestMethod]
        public void ValidSortContractPrice()
        {
            bool isValid = TestClass.SortContractPrice();
            Assert.AreEqual(true, isValid);
        }
        [TestMethod]
        public void ValidDeleteCompany()
        {
            bool isValid = TestClass.DeleteCompany("МосОблГаз", "г.Чехов", "89123133122", "Романов Роман Романович", "5084038342");
            Assert.AreEqual(true, isValid);
        }
        [TestMethod]
        public void NotValidDeleteCompany()
        {
            bool isValid = TestClass.NotDeleteCompany("", "", "", "", "");
            Assert.AreEqual(true, isValid);
        }
        [TestMethod]
        public void ValidDeleteObject()
        {
            bool isValid = TestClass.NotDeleteObject("Торговый комплекс Цистерна", "Отопительная теплогенераторная для обеспечения нужд отопления торгового комплекса Цистерна", "Отопительный сезон 214 дней, круглосуточный", "Московская область, г.Чехов, дом №11 на уч. с кад. № 50:75:0030000:90, 50:75:0030004:0019", "ООО Солнышко");
            Assert.AreEqual(true, isValid);
        }
        [TestMethod]
        public void NotValidDeleteObject()
        {
            bool isValid = TestClass.NotDeleteObject("", "", "", "", "");
            Assert.AreEqual(true, isValid);
        }
    }
}
