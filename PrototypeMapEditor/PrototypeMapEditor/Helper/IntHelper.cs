using System;

namespace PrototypeMapEditor.Helper
{
    public static class IntHelper
    {
        public static int ToInt32(this object value, int defaultValue = 0)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}
