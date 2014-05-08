using System.Globalization;
using System.Threading;

namespace PrototypeMapEditor.Core.Culture
{
    public static class CultureFacade
    {
        private static CultureInfo _cultureInfo;
        public static CultureInfo Culture
        {
            get
            {
                if (_cultureInfo == null)
                {
                    _cultureInfo = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentCulture = _cultureInfo;
                    Thread.CurrentThread.CurrentUICulture = _cultureInfo;
                }
                return _cultureInfo;
            }
        }
    }
}