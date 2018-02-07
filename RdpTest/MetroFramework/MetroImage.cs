
using System;
using System.Drawing;

namespace MetroFramework
{
    class MetroImage
    {
        public static Image ResizeImage(Image imgToResize, Rectangle maxOffset)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = (float)maxOffset.Width / sourceWidth;
            nPercentH = (float)maxOffset.Height / sourceHeight;

            nPercent = nPercentH < nPercentW ? nPercentH : nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            return imgToResize.GetThumbnailImage(destWidth, destHeight, null, IntPtr.Zero);
        }
    }
}
