using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stratego;

namespace TestStratego
{
    [TestClass]
    public class VeldTest
    {
        [TestMethod]
        public void TestDictionary()
        {
            var veld1 = new Veld(3, 9);
            var veld2 = new Veld(2, 5);
            var veld3 = new Veld(3, 9);
            var dict = new Dictionary<Veld, bool> {{veld1, true}};
            
            Assert.IsFalse(dict.ContainsKey(veld2));
            Assert.IsTrue(dict.ContainsKey(veld3));
        }

        // testen van buren gebeurt in BordTest
    }
}