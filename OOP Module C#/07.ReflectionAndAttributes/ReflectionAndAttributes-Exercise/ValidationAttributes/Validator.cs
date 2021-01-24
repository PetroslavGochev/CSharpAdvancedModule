namespace ValidationAttributes
{
    using System.Reflection;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var propertyInfos = obj.GetType().GetProperties();

            foreach (var propertyInfo in propertyInfos)
            {
                var attributes = propertyInfo.GetCustomAttributes<MyValidationAttribute>();
                var objectValue = propertyInfo.GetValue(obj);

                foreach (var attribute in attributes)
                {
                    var value = attribute.IsValid(objectValue);

                    if (!value)
                        return false;
                }
            }

            return true;
        }
    }
}