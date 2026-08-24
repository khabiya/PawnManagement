

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

public static class ImageExtensions
{
  public static Image ImageFromRawBgraArray(
    this byte[] arr,
    int width,
    int height,
    PixelFormat pixelFormat)
  {
    Bitmap bitmap = new Bitmap(width, height, pixelFormat);
    Rectangle rect = new Rectangle(0, 0, width, height);
    BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
    int length = width * Image.GetPixelFormatSize(bitmap.PixelFormat) / 8;
    IntPtr scan0 = bitmapdata.Scan0;
    for (int index = 0; index < height; ++index)
    {
      Marshal.Copy(arr, index * length, scan0, length);
      scan0 += bitmapdata.Stride;
    }
    bitmap.UnlockBits(bitmapdata);
    return (Image) bitmap;
  }
}
