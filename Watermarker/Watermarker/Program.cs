using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Watermarker
{
    static class Program
    {

        static void Main()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'), "hill.jpg");
            WatermarkProcess watermark = new WatermarkProcess(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "marker.png"));
            Image img = watermark.MakeImageWatermark(Image.FromFile(path), new WatermarkSettings()
            {
                WatermarkTextEnable = true,
                WatermarkText="蓝狐数科",
                TextColor=Color.Red,
                TextRotatedDegree =45,
                WatermarkPictureEnable = true,
                TextSettings=new CommonSettings() {
                    Size=60,
                    Opacity=0.4,
                    PositionList = new List<WatermarkPosition>(new WatermarkPosition[] { WatermarkPosition.Center })
                },
                PictureSettings = new CommonSettings()
                {
                    Opacity = 0.5,
                    PositionList = new List<WatermarkPosition>(new WatermarkPosition[] { WatermarkPosition.BottomLeftCorner })
                }
            });
            img.Save(Guid.NewGuid().ToString()+".jpg",ImageFormat.Jpeg);
            img.Dispose();
            Console.WriteLine("处理完毕！");
            Console.Read();
        }
    }
}
