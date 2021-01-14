namespace ValidationAttributes
{
    using System;

    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj) => obj != null;
    }
}
