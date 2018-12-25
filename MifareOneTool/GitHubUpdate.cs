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
        Version localVersion;
        Version remoteVersion;
        //public static T FromJSON<T>(this string input)
        //{
        //    try
        //    {
        //        return JsonConvert.DeserializeObject<T>(input);
        //    }
        //    catch (Exception ex)
        //    {
        //        return default(T);
        //    }
        //}
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
                        ;
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
