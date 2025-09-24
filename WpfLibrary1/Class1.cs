
namespace Lib_9
{
    public class ProductCalculator
    {
        public static int ProductMas(int[] mas)
        {
            int product = 1;
            for (int i = 0; i < mas.Length; i++) 
            { 
                if (mas[i] != 0) product = product * mas[i]; 
            }    
            return product;
        }
    }

}
