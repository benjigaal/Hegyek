using Microsoft.VisualStudio.TestTools.UnitTesting;
using hegyekCLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hegyekCLI.Tests
{
    [TestClass()]
    public class HegycsucsTests
    {
        [TestMethod()]
        [DataRow("Bükk","Fodor-hegy;Bükk-vidék;0", true)]
        [DataRow("kő","Füstös-kő-bérc;Bükk-vidék;0", true)]
        [DataRow("Bükk","Írott-kő;Kőszegi-hegység;0", false)]
        public void KeresTest(string szo, string line, bool expected)
        {
            Hegycsucs hegycsucs = new Hegycsucs(line);
            Assert.AreEqual(expected, hegycsucs.Keres(szo));
        }
    }
}