using NUnit.Framework;
using System;

namespace UnitTestForKosuMesafesi
{
    [TestFixture]
    public class Tests
    {
    
        [TestCase(32.2, 23, 30,222.18)]
        [TestCase(31.2, 45, 434,6093.36)]
        [TestCase(34.3, 23, 43,339.227)]
        public void Calc(double adimSayisi, double adimUzunlugu, int sure, double expected)
        {
            var time = new TimeSpan(0, sure, 0);
           var sonuc = Calculate.CalculateValue(adimSayisi,adimUzunlugu,time);
           

            Assert.AreEqual(sonuc, expected);
          
        }
    }
}