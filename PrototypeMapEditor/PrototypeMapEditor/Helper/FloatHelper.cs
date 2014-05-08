using System;
using PrototypeMapEditor.Core.Culture;

namespace PrototypeMapEditor.Helper
{
    public static class FloatHelper
    {
        public static float ToSingle(this object value, float defaultValue = 0)
        {
            try
            {
                return Convert.ToSingle(value, CultureFacade.Culture);
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}
