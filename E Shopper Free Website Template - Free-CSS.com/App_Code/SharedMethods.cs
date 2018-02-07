using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

/// <summary>
/// Summary description for SharedMethods
/// </summary>
public class SharedMethods
{
    public SharedMethods()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void ResizeImage(string FileNameInput, string FileNameOutput, double ResizeHeight, double ResizeWidth, ImageFormat OutputFormat)
    {
        using (System.Drawing.Image photo = new Bitmap(FileNameInput))
        {
            int sourceWidth = photo.Width; 
            int sourceHeight = photo.Height; 
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)ResizeWidth / (float)sourceWidth);
            nPercentH = ((float)ResizeHeight / (float)sourceHeight);

            //if we have to pad the height pad both the top and the bottom
            //with the difference between the scaled height and the desired height
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = (int)((ResizeWidth - (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW; 
                destY = (int)((ResizeHeight - (sourceHeight * nPercent)) / 2);
            }

          //  int newWidth = (int)(sourceWidth * nPercent); 
          //  int newHeight = (int)(sourceHeight * nPercent);

            int newWidth = 700;
            int newHeight = 700;
            using (Bitmap bmp = new Bitmap(newWidth, newHeight))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    g.DrawImage(photo, 0, 0, newWidth, newHeight);

                    if (ImageFormat.Png.Equals(OutputFormat))
                    {
                        bmp.Save(FileNameOutput, OutputFormat);
                    }
                    else if (ImageFormat.Jpeg.Equals(OutputFormat))
                    {
                        ImageCodecInfo[] info = ImageCodecInfo.GetImageEncoders();
                        EncoderParameters encoderParameters;
                        using (encoderParameters = new System.Drawing.Imaging.EncoderParameters(1))
                        {
                            // use jpeg info[1] and set quality to 90
                            encoderParameters.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 90L);
                            bmp.Save(FileNameOutput, info[1], encoderParameters);
                        }
                    }
                }
            }
        }
    }

    public static Image ResizeFixedSize(Image imgPhoto, int Width, int Height)
    {
        int sourceWidth = imgPhoto.Width;
        int sourceHeight = imgPhoto.Height;
        int sourceX = 0;
        int sourceY = 0;
        int destX = 0;
        int destY = 0;

        float nPercent = 0;
        float nPercentW = 0;
        float nPercentH = 0;

        nPercentW = ((float)Width / (float)sourceWidth);
        nPercentH = ((float)Height / (float)sourceHeight);

        //if we have to pad the height pad both the top and the bottom
        //with the difference between the scaled height and the desired height
        if (nPercentH < nPercentW)
        {
            nPercent = nPercentH;
            destX = (int)((Width - (sourceWidth * nPercent)) / 2);
        }
        else
        {
            nPercent = nPercentW;
            destY = (int)((Height - (sourceHeight * nPercent)) / 2);
        }

        int destWidth = (int)(sourceWidth * nPercent);
        int destHeight = (int)(sourceHeight * nPercent);

        Bitmap bmPhoto = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
        bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

        Graphics grPhoto = Graphics.FromImage(bmPhoto);

        grPhoto.Clear(System.Drawing.ColorTranslator.FromHtml("#F4F4F4"));
        grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

        grPhoto.DrawImage(imgPhoto,
            new Rectangle(destX, destY, destWidth, destHeight),
            new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
            GraphicsUnit.Pixel);

        grPhoto.Dispose();
        return bmPhoto;
    }

    public static Image getThumbNail(string fileName)
    {
        FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
        Image im = Image.FromStream(fs);
        Size szMax = new Size(300, 300);
        Size sz = getProportionalSize(szMax, im.Size);
        // superior image quality   
        Bitmap bmpResized = new Bitmap(sz.Width, sz.Height);
        using (Graphics g = Graphics.FromImage(bmpResized))
        {
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(
                im,
                new Rectangle(Point.Empty, sz),
                new Rectangle(Point.Empty, im.Size),
                GraphicsUnit.Pixel);
        }
        im.Dispose(); im = null;
        fs.Close(); fs.Dispose(); fs = null;
        return bmpResized;
    }

    public static Size getProportionalSize(Size szMax, Size szReal)
    {
        int nWidth;
        int nHeight;
        double sMaxRatio;
        double sRealRatio;

        if (szMax.Width < 1 || szMax.Height < 1 || szReal.Width < 1 || szReal.Height < 1)
            return Size.Empty;

        sMaxRatio = (double)szMax.Width / (double)szMax.Height;
        sRealRatio = (double)szReal.Width / (double)szReal.Height;

        if (sMaxRatio < sRealRatio)
        {

            nWidth = Math.Min(szMax.Width, szReal.Width);
            nHeight = (int)Math.Round(nWidth / sRealRatio);
        }
        else
        {
            nHeight = Math.Min(szMax.Height, szReal.Height);
            nWidth = (int)Math.Round(nHeight * sRealRatio);
        }

        return new Size(nWidth, nHeight);
    }
    public static string EnryptString(string strEncrypted)
    {
        byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
        string encrypted = Convert.ToBase64String(b);
        return encrypted;
    }
    public static string DecryptString(string encrString)
    {
        byte[] b = Convert.FromBase64String(encrString);
        string decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
        return decrypted;
    }

}