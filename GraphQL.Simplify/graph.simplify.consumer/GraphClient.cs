using graph.simplify.consumer.abstractions;
using graph.simplify.consumer.interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace graph.simplify.consumer
{
    public class GraphClient 
    {
        public List<IBody> Body { get; private set; }
        public int TimeOut { get; set; }
        public dynamic Result { get; private set; }

        public void Resolve(Uri uri)
        {
            using (var navigator = new HttpClient())
            {
                var bodyValue = string.Join(",", this.Body);

                var body = $"{{\"operationName\":null,\"variables\":{{}},\"query\":\"{{{bodyValue}}}\"}}";
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                var post = navigator.PostAsync(uri, content);
                post.Wait(this.TimeOut);
                this.Result = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(post.Result.Content.ReadAsStringAsync().Result);
            }
        }

        public IBody AppendBody(string name)
        {
            var body = new BodyAbs(name);
            this.Body.Add(body);
            return body;
        }

        public GraphClient()
        {
            this.Body = new List<IBody>();
            this.TimeOut = 1000 * 30;
        }
    }
}
