using System;
using CurrencyConverterForms;
using CurrencyConverterLibreria;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyConverterTests
{
    [TestClass]
    public class ConvertTest
    {
        [TestMethod]
        public void ConversionBreadth()
        {
            decimal result;
            decimal amount;
            BaseCurrency fromCur;
            BaseCurrency toCur;

            amount = 100.0M;
            fromCur = new UsdCurrency();
            toCur = new UsdCurrency();
            result = ConvertibleCurrency.CurrencyConvert(amount, fromCur, toCur);
            Assert.AreEqual(100.0M, result, "USD to USD NO CAMBIA");

            fromCur = new PenCurrency();
            toCur = new PenCurrency();
            result = ConvertibleCurrency.CurrencyConvert(amount, fromCur, toCur);
            Assert.AreEqual(100.0M, result, "PEN to PEN NO CAMBIA");

            fromCur = new EurCurrency();
            toCur = new EurCurrency();
            result = ConvertibleCurrency.CurrencyConvert(amount, fromCur, toCur);
            Assert.AreEqual(100.0M, result, "EUR to EUR NO CAMBIA");
            decimal expected;
            
            fromCur = new UsdCurrency();
            toCur = new EurCurrency();
            result = ConvertibleCurrency.CurrencyConvert(amount, fromCur, toCur);
            expected = amount * (decimal) 0.85;
            Assert.AreEqual(expected, result, "US to AUS is incorrect");
           
            fromCur = new PenCurrency();
            toCur = new EurCurrency();
            result = ConvertibleCurrency.CurrencyConvert(amount, fromCur, toCur);
            expected = amount * (decimal) 4.16;
            Assert.AreEqual(expected, result, "PEN to EUR es incorrecto");
        }

        [TestMethod]
        public void ConvertTo()
        {
            ConvertibleCurrency currency;
            decimal result;
            decimal expected;

            currency = new ConvertibleCurrency(new UsdCurrency(), 100.0M);
            result = currency.ConvertTo(new UsdCurrency());
            Assert.AreEqual(100.0M, result, "USD to USD no cambia");

            currency = new ConvertibleCurrency(new EurCurrency(), 100.0M);
            result = currency.ConvertTo(new PenCurrency());
            expected = 100.0M / (decimal) 4.16;
            Assert.AreEqual(expected, result, " EUR a PEN resultado incorrecto");
        }
    }
}
