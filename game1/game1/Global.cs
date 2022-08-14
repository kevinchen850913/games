using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1
{
    public enum maincmds
    {
        移動卡片,
        打出卡片
    };

    public enum subcmd
    {
    };

    public class BasicUnit
    {
        public string name;
        public int hp;
    }
    public class Cmd
    {
        public int maincmd;
        public int subcmd;
        public int data;
    }

    public static class Global
    {
        public static Queue<Cmd> myqueue = new Queue<Cmd>();
        public static Bitmap TextToBitmap(string text, Font font, Rectangle rect, Color fontcolor, Color backColor)
        {
            Graphics g;
            Bitmap bmp;
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            if (rect == Rectangle.Empty)
            {
                bmp = new Bitmap(1, 1);
                g = Graphics.FromImage(bmp);
                SizeF sizef = g.MeasureString(text, font, PointF.Empty, format);

                int width = (int)(sizef.Width + 1);
                int height = (int)(sizef.Height + 1);
                rect = new Rectangle(0, 0, width, height);
                bmp.Dispose();

                bmp = new Bitmap(width, height);
            }
            else
            {
                bmp = new Bitmap(rect.Width, rect.Height);
            }

            g = Graphics.FromImage(bmp);
            
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.FillRectangle(new SolidBrush(backColor), rect);
            g.DrawString(text, font, Brushes.Black, rect, format);
            return bmp;
        }
    }  
}
