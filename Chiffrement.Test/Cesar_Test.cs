using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiffrement.Test
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class Cesar_Test
    {
        [TestMethod]
        public void TestCodage()
        {
            Cesar mainCesar = new Cesar();
            string test = mainCesar.Codage("vive les maths", 3);
            Assert.AreEqual(test, "ylyh ohv pdwkv");
        }
        [TestMethod]
        public void TestCodageOnlyString()
        {
            Cesar cesar = new Cesar();
            var test = cesar.Decodage("ylyh ohv pdwkv");
            string decodeTest = "ylyh ohv pdwkv";

            Assert.AreEqual(test[0], decodeTest);
        }
        
        [TestMethod]
        public void TestDecodage()
        {
            Cesar mainCesar = new Cesar();
            string test = mainCesar.Decodage("ylyh ohv pdwkv", 3);
            Assert.AreEqual(test, "vive les maths");
        }
    }
}
