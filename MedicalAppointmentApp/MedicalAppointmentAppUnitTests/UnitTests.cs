using NUnit.Framework;
using MedicalAppointmentApp;
using MedicalAppointmentApp.Pages;
using MedicalAppointmentApp.Utilities;
using System;
using System.Windows.Controls;
using System.Collections.Generic;

namespace MedicalAppointmentAppUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [Description("Should create new Id")]
        public void Test1()
        {
            int id = Utilities.GenerateId();
            Assert.IsInstanceOf<int>(id);
        }
        [Test]
        [Description("Generated Ids cannot be equal")]
        public void Test2()
        {
            List<bool> result = new List<bool>();
            for (int i = 0; i < 100; i++)
            {
                double a = Convert.ToDouble(Utilities.GenerateId());
                double b = Convert.ToDouble(Utilities.GenerateId());
                result.Add(a == b);
            }
            Assert.IsFalse(result.Contains(true));
        }
        [Test]
        [Description("Generated Ids cannot be equal zero")]
        public void Test3()
        {
            List<bool> result = new List<bool>();
            for (int i = 0; i < 100; i++)
            {
                double a = Convert.ToDouble(Utilities.GenerateId());
                result.Add(a == 0);
            }
            Assert.IsFalse(result.Contains(true));
        }
    }
}