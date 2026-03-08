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
        public void Check_If_Owner_Returns_Value()
        {
            string expectedOwner = "John Doe";
            string phoneNumber = "123456789";
            var phone = new Phone(expectedOwner, phoneNumber);
            Assert.AreEqual(expectedOwner, phone.Owner);
        }
    }

    [TestClass]
    public sealed class PhoneNumerTest
    {
        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void Check_If_Phone_Number_NonExistentOrNull_Throws_SpecificException(string invalidNumber)
        {
            string owner = "John Doe";
            string expectedMessage = "Phone number is empty or null!";
            Assert.AreEqual (expectedMessage, Assert.Throws<ArgumentException>(() => new Phone(owner, invalidNumber)).Message);

        }


        [DataTestMethod]
        [DataRow("0123456789")]
        [DataRow("123")]
        [DataRow("123@34%6&8")]
        [DataRow("908 786 543")]
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
            Assert. AreEqual(phonenr, phone.PhoneNumber);

        }
        [TestMethod]
        public void Check_If_Phone_Number_Returns_Value()
        {
            string owner = "John Doe";
            string expectedPhoneNumber = "123456789";
            var phone = new Phone(owner, expectedPhoneNumber);
            Assert.AreEqual(expectedPhoneNumber, phone.PhoneNumber);
        }

        [TestMethod]
        public void Check_If_Phone_Number_Valid_Bool_True()
        {
            string owner = "John Doe";
            string phoneNumber = "123456789";
            var phone = new Phone(owner, phoneNumber);
            Assert.AreEqual(phoneNumber, phone.PhoneNumber);
        }




    }

    [TestClass]
    public sealed class OtherTests
    {
        [TestMethod]
        public void Check_If_Phone_Book_Empty()
        {
            string owner = "John Doe";
            string phoneNumber = "123456789";
            var phone = new Phone(owner, phoneNumber);
            Assert.AreEqual(0, phone.Count);
        }

        [TestMethod]
        public void Check_If_Over_Capacity_Throws_Exception()
        {
            string owner = "John Doe";
            string phoneNumber = "123456789";
            var phone = new Phone(owner, phoneNumber);
            for (int i = 0; i < phone.PhoneBookCapacity; i++)
            {
                phone.AddContact($"Contact{i}", $"12345678{i}");
            }
            Assert.Throws<InvalidOperationException>(() => phone.AddContact("ExtraContact", "123456789"));
        }
        [TestMethod]
        public void Capacity_Returns_100()
        {

            var phone = new Phone("John Doe", "123456789");
            int capacity = phone.PhoneBookCapacity;
            Assert.AreEqual(100, capacity);

        }

        [TestMethod]
        public void AddContact_DuplicateName_ShouldReturnFalse()
        {

            var phone = new Phone("Jan Kowalski", "123456789");
            string name = "Adam Nowak";
            string number1 = "111222333";
            string number2 = "444555666";

            bool firstAttempt = phone.AddContact(name, number1);
            bool secondAttempt = phone.AddContact(name, number2);

            Assert.IsTrue(firstAttempt);
            Assert.IsFalse(secondAttempt);

        }

        [TestMethod]
        public void Call_ExistingContact_ShouldReturnCorrectString()
        {

            var phone = new Phone("Jan", "123456789");
            string name = "Adam";
            string number = "999888777";
            phone.AddContact(name, number);

            string expected = $"Calling {number} ({name}) ...";
            string result = phone.Call(name);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Call_NonExistingContact_ShouldThrowException()
        {

            var phone = new Phone("Jan", "123456789");
            string nonExistingName = "NonExisting";
            Assert.Throws<InvalidOperationException>(() => phone.Call(nonExistingName));

        }

    }

}












