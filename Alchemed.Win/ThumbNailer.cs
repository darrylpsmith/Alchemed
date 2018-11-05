using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultWill
{
    public class ThumbNailer
    {

        public Image GetThumbnail(string FileName)
        {

            Image.GetThumbnailImageAbort callback =
                new Image.GetThumbnailImageAbort(ThumbnailCallback);
            Image image = new Bitmap(FileName);
            Image pThumbnail = image.GetThumbnailImage(100, 100, callback, new
               IntPtr());

            return pThumbnail;


            //Image image = Image.FromFile(fileName);
            //Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
            //thumb.Save(Path.ChangeExtension(fileName, "thumb"));

            //e.Graphics.DrawImage(
            //   pThumbnail,
            //   10,
            //   10,
            //   pThumbnail.Width,
            //   pThumbnail.Height);
        }


        /// 
        /// Creates a resized bitmap from an existing image on disk.
        /// Call Dispose on the returned Bitmap object
        /// 
        /// 
        /// 
        /// 
        /// Bitmap or null
        //public Bitmap CreateThumbnail(string lcFilename, int lnWidth, int lnHeight, , string thumbnailFileName)
        public string CreateThumbnail(string lcFilename, int lnWidth, int lnHeight, string thumbnailFileName)
        {
            System.Drawing.Bitmap bmpOut = null;
            try
            {
                Bitmap loBMP = new Bitmap(lcFilename);
                ImageFormat loFormat = loBMP.RawFormat;
                decimal lnRatio;
                int lnNewWidth = 0;
                int lnNewHeight = 0;

                //Check for exif data to determin orientation of camera when photo was taken and rotate to what's expected
                if (loBMP.PropertyIdList.Contains(0x112)) //0x112 = Orientation
                {
                    var prop = loBMP.GetPropertyItem(0x112);
                    if (prop.Type == 3 && prop.Len == 2)
                    {
                        UInt16 orientationExif = BitConverter.ToUInt16(loBMP.GetPropertyItem(0x112).Value, 0);
                        if (orientationExif == 8)
                        {
                            loBMP.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        }
                        else if (orientationExif == 3)
                        {
                            loBMP.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        }
                        else if (orientationExif == 6)
                        {
                            loBMP.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        }
                    }
                }

                //*** If the image is smaller than a thumbnail just return it
                if (loBMP.Width < lnWidth && loBMP.Height < lnHeight)
                    //return loBMP;
                return "";
                if (loBMP.Width > loBMP.Height)
                {
                    lnRatio = (decimal)lnWidth / loBMP.Width;
                    lnNewWidth = lnWidth;
                    decimal lnTemp = loBMP.Height * lnRatio;
                    lnNewHeight = (int)lnTemp;
                }
                else
                {
                    lnRatio = (decimal)lnHeight / loBMP.Height;
                    lnNewHeight = lnHeight;
                    decimal lnTemp = loBMP.Width * lnRatio;
                    lnNewWidth = (int)lnTemp;
                }

                // System.Drawing.Image imgOut = 
                //      loBMP.GetThumbnailImage(lnNewWidth,lnNewHeight,
                //                              null,IntPtr.Zero);
                // *** This code creates cleaner (though bigger) thumbnails and properly
                // *** and handles GIF files better by generating a white background for
                // *** transparent images (as opposed to black)
                bmpOut = new Bitmap(lnNewWidth, lnNewHeight);
                Graphics g = Graphics.FromImage(bmpOut);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.FillRectangle(Brushes.White, 0, 0, lnNewWidth, lnNewHeight);
                g.DrawImage(loBMP, 0, 0, lnNewWidth, lnNewHeight);
                loBMP.Dispose();
            }
            catch
            {
                return null;
            }


            string commonAppDataFolder = StaticFunctions.GetApplicationCommonDataFolder();
            if (Directory.Exists(commonAppDataFolder) == false)
            {
                Directory.CreateDirectory(commonAppDataFolder);
            }

            bmpOut.Save($"{commonAppDataFolder}/{thumbnailFileName}");

            return $"{commonAppDataFolder}/{thumbnailFileName}";
        }

        public bool ThumbnailCallback()
        {
            return true;
        }
        public string CreateAndSaveThumbNailstring(string fileName, string thumbnailFileName)
        {

            try
            {

                Image thumb = GetThumbnail(fileName);
                string commonAppDataFolder = StaticFunctions.GetApplicationCommonDataFolder();
                if (Directory.Exists(commonAppDataFolder) == false)
                {
                    Directory.CreateDirectory(commonAppDataFolder);
                }

                thumb.Save($"{commonAppDataFolder}/{thumbnailFileName}");
                return $"{commonAppDataFolder}/{thumbnailFileName}";
            }
            catch (Exception)
            {
                return null;
                
            }

        }

    }
}
