using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Tweekipedia
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //URLパラメータの仕様
            //lang : 言語コード
            //title : ページのタイトル

            //urlパラメータを確認
            if (!((Request.QueryString["lang"] is null) || (Request.QueryString["title"] is null)))
            {
                string lang = HttpUtility.UrlDecode(Request.QueryString["lang"]);
                string url_title = HttpUtility.UrlDecode(Request.QueryString["title"]);
                string title = url_title.Replace("_", " ");
                if (title == "") title = "Wikipedia";
                og_title.Attributes.Add("content", title + " - " 
                    + lang.ToLower() + ".wikipedia.org");
                body_script.Text = "<script>" +
                    "location.href = \"https://" + lang + ".wikipedia.org/wiki/"
                    + HttpUtility.UrlEncode(url_title) + "\";</script>";

                //OGP image
                if(System.IO.File.Exists(Server.MapPath("~") + "Logos\\" + lang + ".png"))
                {
                    og_image.Attributes.Add("content", "Logos/" + lang + "_logo.png");
                }
                else
                {
                    if(MakeWpLogo(lang))
                    {
                        og_image.Attributes.Add("content", 
                            "https://tweekipedia.azurewebsites.net/Logos/" + lang + "_logo.png");
                    }
                }

            }
            else
            {
                og_title.Attributes.Add("content", "Tweekipedia");
                og_image.Attributes.Add("content", "https://tweekipedia.azurewebsites.net/Logos/ogp_default.png");
            }
        }

        bool MakeWpLogo(string lang)
        {
            try
            {
                //logoをダウンロード
                using (var wc = new System.Net.WebClient())
                {
                    wc.DownloadFile(
                        "https://wikipedia.org/static/images/project-logos/" + lang + "wiki.png",
                        Server.MapPath("~") + "Logos\\" + lang + "_origin.png");
                }
                using (var bmp = new System.Drawing.Bitmap(
                    Server.MapPath("~") + "Logos\\" + lang + "_origin.png"))

                {
                    var newbmp = EditLogoBitmap(bmp);
                    newbmp.Save(Server.MapPath("~") + "Logos\\" + lang + "_logo.png");
                }
                System.IO.File.Delete(Server.MapPath("~") + "Logos\\" + lang + "_origin.png");
               return true;
            }
            catch
            {
               return false;
            }
        }


        //参考にしたサイト
        //https://stackoverflow.com/questions/27318549/replacing-transparent-background-with-white-color-in-png-images
        //１画像の透過を白に置き換える。
        //２画像のまわりに余白を追加する。
        System.Drawing.Bitmap EditLogoBitmap(System.Drawing.Bitmap bmp)
        {
            var bmp2 = new System.Drawing.Bitmap(bmp.Width + 32, bmp.Height + 32);
            System.Drawing.Rectangle rect =
                new System.Drawing.Rectangle(
                    new System.Drawing.Point(16,16),
                    bmp.Size);
            using (var G = System.Drawing.Graphics.FromImage(bmp2))
            {
                G.Clear(System.Drawing.Color.White);
                G.DrawImageUnscaledAndClipped(bmp, rect);
            }
            return bmp2;
        }
    }
}