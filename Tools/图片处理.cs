using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
     public  class ImgHelp
    {
        public static byte[] ImageToBytes(Image image)
        {
            if(image !=null )
            { 
            ImageFormat format = image.RawFormat;
                using (MemoryStream ms = new MemoryStream())
                {
                    if (format.Equals(ImageFormat.Jpeg))
                    {
                        image.Save(ms, ImageFormat.Jpeg);
                    }
                    else if (format.Equals(ImageFormat.Png))
                    {
                        image.Save(ms, ImageFormat.Png);
                    }
                    else if (format.Equals(ImageFormat.Bmp))
                    {
                        image.Save(ms, ImageFormat.Bmp);
                    }
                    else if (format.Equals(ImageFormat.Gif))
                    {
                        image.Save(ms, ImageFormat.Gif);
                    }
                    else if (format.Equals(ImageFormat.Icon))
                    {
                        image.Save(ms, ImageFormat.Icon);
                    }
                    else
                    {
                        image.Save(ms, ImageFormat.Jpeg);
                    }
                    byte[] buffer = new byte[ms.Length];
                    //Image.Save()会改变MemoryStream的Position，需要重新Seek到Begin
                    ms.Seek(0, SeekOrigin.Begin);
                    ms.Read(buffer, 0, buffer.Length);
                    return buffer;
                }           
            }   else
                {
                    return null;
                }    
        }
        /// <summary>
        /// Convert Byte[] to Image
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static Image BytesToImage(byte[] buffer)
        {   
            Image image = null;
            if (buffer != null)
            {
                MemoryStream ms = new MemoryStream(buffer);            
                try
                {
                    image = System.Drawing.Image.FromStream(ms);
                    return image;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return image;
            }
        }
        public static Bitmap  BytesToBitmap(byte[] buffer)
        {
            MemoryStream stream = null;
            try
            {
                stream = new MemoryStream(buffer );
                return new Bitmap((Image)new Bitmap(stream));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            finally
            {
                stream.Close();
            }
        }
    }

}
