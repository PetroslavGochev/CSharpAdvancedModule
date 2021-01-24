namespace ValidationAttributes
{
    using System;

    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int min, int max)
        {
            minValue = min;
            maxValue = max;
        }

        public override bool IsValid(object obj)
        {
            var value = Convert.ToInt32(obj);

            return minValue <= value && value <= maxValue;
        }
    }
}
