using System;

namespace _04._Fixing_Vol2
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                int num1 = 30;
                int num2 = 60;
                byte result = Convert.ToByte(num1 * num2);
                Console.WriteLine("{0} x {1} = {2}", num1, num2, result);
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
            }
          
        
        }
    }
}
