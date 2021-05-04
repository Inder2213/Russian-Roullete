using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Russian_Roullete;

namespace RussianRoulleteUnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        gun unitTestObj = new gun();
        [TestMethod]
        public void Testbulletechange()
        {
            var actu = unitTestObj.bulletechange(5);
            Assert.AreEqual(expected:6,actu);
        }
       public void Testbulletchange()
        {
            var actu = unitTestObj.bulletechange(5);
            Assert.AreNotEqual(notExpected:5,actual:6);
        }
    }
}
