using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using sensoryIntegration_BLL;
using sensoryIntegration_Model;

namespace sensoryIntegration_MT.Handler
{
    /// <summary>
    /// ContactHandler 的摘要说明
    /// </summary>
    public class ContactHandler : IHttpHandler
    {
        public static encyClopedias_BLL ebl = new encyClopedias_BLL();

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"].ToString();
            switch (action)
            {
                case "ContactUs":
                    ContactUs(context);
                    break;
                case "editorUplodaImg":
                    editorUplodaImg(context);
                    break; 
                case "SaveHtml":
                    SaveHtml(context);
                    break;
                case "GetEncyClopedias":
                    GetEncyClopedias(context);
                    break;
                default:
                    break;
            }
        }


        private void ContactUs(HttpContext context)
        {
            string name = context.Request.Form["name"];
            string phone = context.Request.Form["phone"];
            string content = context.Request.Form["content"];

            context.Response.Write("true");
        }

        private void editorUplodaImg(HttpContext context)
        {
            var file = context.Request.Files[0];
            string path = "/uploads/news/" + file.FileName;
            file.SaveAs(context.Request.MapPath(path));//必须得是相对路径
            resopnse resopnse = new resopnse();
            List<data> datas = new List<data>() {
                new data()
                {
                    url = path,
                    alt = "图片简介",
                    href = ""
                }
            };
            resopnse.errno = 0;
            resopnse.data = datas;
            context.Response.Write(JsonConvert.SerializeObject(resopnse));
        }
        private void SaveHtml(HttpContext context)
        {
            string htmlTxt = context.Request.Form["htmlTxt"];
            encyClopedias_Model encyClopedias = new encyClopedias_Model();
            encyClopedias.htmlTxt = htmlTxt;
            encyClopedias.IsDelete = "0";
            if (ebl.SaveEncyClopedias(encyClopedias))
            {
                context.Response.Write("新闻添加成功！");
            }
            else
            {
                context.Response.Write("新闻添加失败！请联系管理员");
            }
        }

        private void GetEncyClopedias(HttpContext context)
        {
            encyClopedias_Model ency = new encyClopedias_Model();
            string jsonStr = "";
            List<encyClopedias_Model> encyClopedias = ebl.GetEncyClopedias(ency);
            jsonStr = JsonConvert.SerializeObject(encyClopedias);
            context.Response.Write(jsonStr);
        }

        private void UplodaImage(HttpContext context)
        {
            var file = context.Request.Files[0];
            string path = "/uploads/news/" + file.FileName;

        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public class resopnse { 
            public int errno { get; set; }
            public List<data> data { get; set; }
        }
        public class data { 
            public string url { get; set; }
            public string alt { get; set; }
            public string href { get; set; }
        }
    }
}