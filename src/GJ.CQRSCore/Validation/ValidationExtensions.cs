namespace GJ.CQRSCore.Validation
{
    public static class ValidationExtensions
    {
        public static void ValidateNotNull(this ValidationResults results, int property, string propertyName)
        {
            if (property == -1)
            {
                results.AddValidationResult(propertyName, "{0} cannot be null");
            }
        }
        public static void ValidateNotNullOrEmpty(this ValidationResults results, string property, string propertyName)
        {
            if (string.IsNullOrEmpty(property))
            {
                results.AddValidationResult(propertyName, "{0} cannot be null or empty");
            }
        }
    }
}
