using graph.simplify.consumer;
using System;
using Xunit;

namespace graph.simplify.test
{
    internal class Address
    {
        public string PostalCode { get; set; }
    }

    public class ConsumerTest
    {
        
        [Fact]
        public void GraphClientTest()
        {
            var client = new GraphClient<Address>();

            client.Body.AppendArgument("PostalCode")
                .AppendCheck(OperationType.EqualTo, Statement.And, "36038-000")
                .AppendCheck(OperationType.EqualTo, Statement.Or, "36016-410");

            client.Body.QueryInfo.Limit = 2;
            client.Body.QueryInfo.Page = 0;

            client.Body.ResultFields.Add("postalCode");
            client.Body.ResultFields.Add("district");
            client.Body.ResultFields.Add("fullStreetName");

            client.Resolve(new Uri(@"https://postalcode-api.herokuapp.com/graphql"));

            var resultA = client.Result.data.address[0].postalCode;
            var resultB = client.Result.data.address[1].postalCode;

            Assert.True(Convert.ToString(resultA) == "36038-000");
            Assert.True(Convert.ToString(resultB) == "36016-410");
        }
    }
}
