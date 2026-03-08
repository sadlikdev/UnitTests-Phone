using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary.Phone;
using System;

namespace TestProject1
{
    [TestClass]
    public sealed class OwnerTests
    {
        [TestMethod]
        public void Check_If_Owner_Nameless_Throws_Exception()
        {
            string owner = "";
            string phoneNumber = "123456789";
            Assert.Throws<ArgumentException>(() => new Phone(owner, phoneNumber));
        }
        [TestMethod]
        public void Check_If_Owner_Null_Throws_Exception()
        {
            string owner = null;
            string phoneNumber = "123456789";
            Assert.Throws<ArgumentException>(() => new Phone(owner, phoneNumber));
        }
        [DataTestMethod]
        [DataRow("Mary Jane")]
        [DataRow("James Sunderland")]
        [DataRow("Anakin Skywalker")]
        public void Check_If_Ok_Owner_Saves(string ownerid)
        {
            string phoneNumber = "123456789";
            var phone = new Phone(ownerid, phoneNumber);
            Assert.AreEqual(ownerid, phone.Owner);
        }
        [TestMethod]
        public void Check_If_Owner_Invalid_Throws_Exception()
        {
            string owner = "John D@e";
            string phoneNumber = "123456789";
            Assert.Throws<ArgumentException>(() => new Phone(owner, phoneNumber));
        }

    }

    [TestClass]
    public sealed class PhoneNumerTest
    {

        public void Check_If_Phone_Number_NonExistent_Throws_Exception()
        {
            string owner = "John Doe";
            string phoneNumber = "";
            Assert.Throws<ArgumentException>(() => new Phone(owner, phoneNumber));
        }

        public void Check_If_Phone_Number_Null_Throws_Exception()
        {
            string owner = "John Doe";
            string phoneNumber = null;
            Assert.Throws<ArgumentException>(() => new Phone(owner, phoneNumber));
        }

        [DataTestMethod]
        [DataRow("0123456789")]
        [DataRow("123")]
        [DataRow("123@34%6&8")]
        public void Check_If_Phone_Number_Invalid_Throws_Exception(string nrTel)
        {
            string owner = "John Doe";
            string phoneNumber = nrTel;
            Assert.Throws<ArgumentException>(() => new Phone(owner, phoneNumber));
        }
        
        [DataTestMethod]
        [DataRow("526954852")]
        [DataRow("456218422")]
        [DataRow("003004004")]
        public void Check_If_Ok_Number_Saves(string phonenr)
        {
            string owner = "John Doe";
            var phone = new Phone(owner, phonenr);
            Assert.AreEqual(phonenr, phone.PhoneNumber);
        }
    }
}