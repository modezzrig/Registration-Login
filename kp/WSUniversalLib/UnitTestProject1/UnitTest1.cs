using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {   /*тестирует правильность расчета методом*/
        [TestMethod]
        public void GetQuanityForProduct_NonExistentProductType() /*если допустимое значение материала*/
        {
            var calc = new WSUniversalLib.Calculation();
            int arg1 = 3;
            int arg2 = 2;
            int arg3 = 5;
            float arg4 = 4;
            float arg5 = 7;
            int result = WSUniversalLib.Calculation.GetQuantityForProduct(arg1, arg2, arg3, arg4, arg5);
        }

        [TestMethod]
        public void GetQuanityForProduct_NonExistentProductType2() /*если недопустимое значение материала*/
        {
            var calc = new WSUniversalLib.Calculation();
            int arg1 = 3;
            int arg2 = 4;
            int arg3 = 5;
            float arg4 = 4;
            float arg5 = 7;
            int result = WSUniversalLib.Calculation.GetQuantityForProduct(arg1, arg2, arg3, arg4, arg5);
        }
    }
}
