using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChequeEmExtenso.ConsoleApp;

namespace Validar.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DeveRetornarDois()
        {
            Numeros numeroTeste1 = new Numeros();
            string test = numeroTeste1.Unidades("2");

            Assert.AreEqual("dois", test);
        }

        [TestMethod]
        public void DeveRetornarDez()
        {
            Numeros numeroTeste2 = new Numeros();
            string test = numeroTeste2.Dezenas("10");

            Assert.AreEqual("dez", test);
        }
        

    }
}
