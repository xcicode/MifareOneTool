using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace MifareOneTool
{
    class GitHubUpdate
    {
        public Version localVersion;
        public string remoteVersion="未知";
        public void Update(string GitHubR)
        {
            try
            {//.net4.5可用
                //处理HttpWebRequest访问https有安全证书的问题（ 请求被中止: 未能创建 SSL/TLS 安全通道。）
                //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var request = (HttpWebRequest)WebRequest.Create("https://api.github.com/repos/" + GitHubR + "/releases/latest");
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                JObject jo = JObject.Parse(responseString);
                if (jo.GetValue("message") == null)
                {
                    dynamic json = Newtonsoft.Json.Linq.JToken.Parse(responseString) as dynamic;
                    if (json.prerelease == false)
                    {
                        this.remoteVersion = (string)json.tag_name;
                    }
                }
                else
                {
                    Console.Error.WriteLine("GitHub更新失效");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public GitHubUpdate(string GitHubR)
        {
            this.localVersion = Assembly.GetExecutingAssembly().GetName().Version;
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("https://api.github.com/repos/" + GitHubR + "/releases/latest");
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                JObject jo = JObject.Parse(responseString);
                if (jo.GetValue("message") == null)
                {
                    dynamic json = Newtonsoft.Json.Linq.JToken.Parse(responseString) as dynamic;
                    if(json.prerelease==false){
                        this.remoteVersion=(string)json.tag_name;
                    }
                }
                else
                {
                    Console.Error.WriteLine("GitHub更新失效");
                }
            }
            catch (Exception ex)
            {
                System.Console.Error.WriteLine(ex.Message);
            }
        }
    }
}
