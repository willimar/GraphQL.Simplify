using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace graph.simplify.consumer
{
    public class GraphClient<TEntity> where TEntity : class
    {
        public IBody<TEntity> Body { get; private set; }
        public IQueryInfo QueryInfo { get; private set; }
        public int TimeOut { get; set; }
        public dynamic Result { get; private set; }

        public void Resolve(Uri uri)
        {
            using (var navigator = new HttpClient())
            {
                var body = $"{{\"operationName\":null,\"variables\":{{}},\"query\":\"{this.Body}\"}}";
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                var post = navigator.PostAsync(uri, content);
                post.Wait(this.TimeOut);
                this.Result = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(post.Result.Content.ReadAsStringAsync().Result);
            }
        }

        public GraphClient()
        {
            this.Body = new BodyAbs<TEntity>();
            this.QueryInfo = new QueryInfoAbs();
            this.TimeOut = 1000 * 30;
        }
    }
}
