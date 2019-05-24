using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nsGEN_ReCaptcha;

namespace SisAdmisiones
{
    public partial class BuildCaptcha : System.Web.UI.Page
    {
        private void variables()
        {
            Bitmap captchabmp = new Bitmap(170, 50);
            Graphics captchagraphic = Graphics.FromImage(captchabmp);
            captchagraphic.Clear(Color.White);
            captchagraphic.TextRenderingHint = TextRenderingHint.AntiAlias;

            Font captchafont = new Font("Verdana", 24);
            Font captchafont2 = new Font("Verdana", 24);
            HatchBrush captchafont3 = new HatchBrush(HatchStyle.Shingle, Color.GhostWhite, Color.DarkCyan);

            string captchastr = "";
            char[] captchaarray = new char[7];
            int x;
            Random rand = new Random();
            Random upperlower = new Random();
            Random captcha = new Random();

            int z;
            int y;
            string temp;
            //string randomStr = "";

            for (x = 0; x < 7; x++)
            {
                z = captcha.Next(0, 2);
                if (z == 1)
                {
                    captchaarray[x] = System.Convert.ToChar(rand.Next(65, 90));
                }
                else
                {
                    captchaarray[x] = System.Convert.ToChar(rand.Next(49, 57));
                }
            }

            for (x = 0; x < 7; x++)
            {
                if (Char.IsLetter(captchaarray[x]))
                {
                    y = upperlower.Next(0, 99);
                    if (y >= 0 && y <= 49)
                    {
                        temp = (captchaarray[x].ToString());
                        temp = temp.ToLower();
                        captchastr += temp.ToString();
                    }
                    else
                    {
                        temp = (captchaarray[x].ToString());
                        temp = temp.ToUpper();
                        captchastr += temp.ToString();
                    }
                }
                else
                {
                    temp = (captchaarray[x].ToString());
                    captchastr += temp.ToString();
                }
            }

            Session.Add("captchastr", captchastr);
            // Session["captchastr"] = captchastr;

            String backgroundstring = "=========";/* this will be used as a way to merge the image letters/numbers to make it hard for an OCR reader to segment*/
            captchagraphic.DrawString(backgroundstring, captchafont2, Brushes.Gold, 0, 5);// adds the backgroundstring to the image

            for (int i = 1; i < 170; i = i + 5)
            {
                captchagraphic.DrawLine(new Pen(Brushes.LawnGreen), i, 0, i, 50);
            }
            captchagraphic.DrawString(captchastr, captchafont, captchafont3, 3, 3);//adds the string we created to the image
            captchagraphic.DrawLine(new Pen(Brushes.Olive), 0, 20, 170, 20);//these next 3 lines create the "strike-through" effect
            captchagraphic.DrawLine(new Pen(Brushes.Azure), 0, 0, 170, 50);
            captchagraphic.DrawLine(new Pen(Brushes.Blue), 0, 50, 170, 0);
            Response.ContentType = "image/GIF";

            captchabmp.Save(Response.OutputStream, ImageFormat.Gif);
            captchafont.Dispose();
            captchafont2.Dispose();
            captchagraphic.Dispose();
            captchabmp.Dispose();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            variables();
        }
    }
}