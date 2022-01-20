using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSUniversalLib
{
    public class Calculation
    {
        //метод считающий колличество материала, нужного для производства продукта
        public static int GetQuantityForProduct(int productType, int materialType, int count, float width, float length)
        {
            float ch = (width * length) * productType; /*ситает, не учитывая брак*/
            int result = 0;
            //ситает, учитывая брак
            if (materialType == 1)
            {
                double brak = (ch * 100) / 0.3;
                Math.Round(brak);
                float f = (float)brak;
                float f1 = ch - f;
                result = result + (int)f1;

            }

            else if (materialType == 2)
            {
                double brak = (ch * 100) / 0.12;
                Math.Round(brak);
                float f = (float)brak;
                float f1 = ch - f;
                result = result + (int)f1;
            }
            else
            {
                return -1;
            }
                
                return result;
        }
    }
}
