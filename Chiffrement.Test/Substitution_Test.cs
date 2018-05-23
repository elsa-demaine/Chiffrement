using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Chiffrement.Test
{
    [TestClass]
    public class Substitution_Test
    {
        [TestMethod]
        public void Test_newAlphabet_1()
        {
            Substitution substitution = new Substitution();

            string res = substitution.newAlphabet("xyz");

            Assert.AreEqual(res, "xyzabcdefghijklmnopqrstuvw");
            Assert.IsTrue(res.Length == 26);
        }

        [TestMethod]
        public void Test_newAlphabet_2()
        {
            Substitution substitution = new Substitution();

            string res = substitution.newAlphabet("testing");

            Assert.AreEqual(res, "tesingabcdfhjklmopqruvwxyz");
            Assert.IsTrue(res.Length == 26);
        }

        [TestMethod]
        public void Test_Chiffrer()
        {
            Substitution substitution = new Substitution();

            string res = substitution.Chiffrer("la phrase a tester", "xyzabcdefghijklmnopqrstuvw");

            Assert.AreEqual(res, "ix meoxpb x qbpqbo");
        }

        [TestMethod]
        public void Test_Chiffrer_spéceaux()
        {
            Substitution substitution = new Substitution();

            string res = substitution.Chiffrer("La phrase à testér !", "xyzabcdefghijklmnopqrstuvw");

            Assert.AreEqual(res, "Lx meoxpb à qbpqéo !");
        }

        [TestMethod]
        public void Test_Start()
        {
            //Mock<Substitution> mockSub = new Mock<Substitution>();
            //mockSub.Setup(e => e.);

            //Substitution mockSubstitution = mockSub.Object;

            //Assert.IsTrue();
        }
    }
}
