using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lo_Fi_Shop.Page;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lo_Fi_Shop.Page.Tests
{
    [TestClass()]
    public class CraftPageTests
    {
        [TestMethod()]
        public void SummaPCTest()
        {
            int[] TestData = { 1, 2, 3, 5 };
            int TestMetod = CraftPage.SummaPC(TestData);
            int Result = 11;

            Assert.AreEqual(Result, TestMetod);
        }
    }
}