using System;
using System.Collections.Generic;
using System.Drawing;
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
