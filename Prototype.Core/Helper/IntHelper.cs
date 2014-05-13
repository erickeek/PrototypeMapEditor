using System;
using Prototype.Core.Culture;

namespace Prototype.Core.Helper
{
    public static class IntHelper
    {
        public static int ToInt32(this object value, int defaultValue = 0)
        {
            try
            {
                return Convert.ToInt32(value, CultureFacade.Culture);
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}
