using System.Drawing;

namespace PrototypeMapEditor.Helper
{
    public static class ImageHelper
    {
        public static Image Crop(this Image img, Rectangle cropArea)
        {
            var bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }
    }
}
