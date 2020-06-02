using graph.simplify.consumer;
using graph.simplify.consumer.enums;
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
            var client = new GraphClient();
            var body = client.AppendBody("Address");

            body.AppendArgument("PostalCode")
                .AppendCheck(OperationType.EqualTo, Statement.And, "36038-000")
                .AppendCheck(OperationType.EqualTo, Statement.Or, "36016-410");

            body.QueryInfo.Limit = 2;
            body.QueryInfo.Page = 0;

            body.ResultFields.Add("postalCode");
            body.ResultFields.Add("district");
            body.ResultFields.Add("fullStreetName");

            client.Resolve(new Uri(@"https://postalcode-api.herokuapp.com/graphql"));

            var resultA = client.Result.data.address[0].postalCode;
            var resultB = client.Result.data.address[1].postalCode;

            Assert.True(Convert.ToString(resultA) == "36038-000");
            Assert.True(Convert.ToString(resultB) == "36016-410");
        }
    }
}
