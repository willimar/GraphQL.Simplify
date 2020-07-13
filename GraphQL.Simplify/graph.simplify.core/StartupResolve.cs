using graph.simplify.core.enums;
using graph.simplify.core.types;
using graph.simplify.core.values;
using GraphQL;
using GraphQL.Http;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;

namespace graph.simplify.core
{
    public static class StartupResolve
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            // If using Kestrel:
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            #region Dependencias

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            services.AddScoped<BoolValue>();
            services.AddScoped<ByteValue>();
            services.AddScoped<CharValue>();
            services.AddScoped<DateTimeValue>();
            services.AddScoped<DecimalValue>();
            services.AddScoped<DoubleValue>();
            services.AddScoped<FloatValue>();
            services.AddScoped<IntValue>();
            services.AddScoped<LongValue>();
            services.AddScoped<OperationValue>();
            services.AddScoped<ShortValue>();
            services.AddScoped<StatementValue>();
            services.AddScoped<StringValue>();
            services.AddScoped<OrderValue>();
            services.AddScoped<QueryInfoValue>();
            //services.AddScoped<GuidValue>();

            services.AddScoped<ComplexInputTypes<BoolValue>>();
            services.AddScoped<ComplexInputTypes<ByteValue>>();
            services.AddScoped<ComplexInputTypes<CharValue>>();
            services.AddScoped<ComplexInputTypes<DateTimeValue>>();
            services.AddScoped<ComplexInputTypes<DecimalValue>>();
            services.AddScoped<ComplexInputTypes<DoubleValue>>();
            services.AddScoped<ComplexInputTypes<FloatValue>>();
            services.AddScoped<ComplexInputTypes<IntValue>>();
            services.AddScoped<ComplexInputTypes<LongValue>>();
            services.AddScoped<ComplexInputTypes<OperationValue>>();
            services.AddScoped<ComplexInputTypes<ShortValue>>();
            services.AddScoped<ComplexInputTypes<StatementValue>>();
            services.AddScoped<ComplexInputTypes<StringValue>>();
            services.AddScoped<ComplexInputTypes<QueryInfoValue>>();
            //services.AddScoped<ComplexInputTypes<GuidValue>>();

            services.AddScoped<BooleanGraphType>();
            services.AddScoped<DateTimeGraphType>();
            services.AddScoped<DecimalGraphType>();
            services.AddScoped<FloatGraphType>();
            services.AddScoped<IntGraphType>();
            services.AddScoped<ULongGraphType>();
            services.AddScoped<ShortGraphType>();
            services.AddScoped<StringGraphType>();
            services.AddScoped<GuidGraphType>();

            services.AddScoped<EnumeratorType<Operation>>();
            services.AddScoped<EnumeratorType<Statement>>();
            services.AddScoped<EnumeratorType<Order>>();

            services.AddScoped<IDocumentWriter, DocumentWriter>();
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();

            #endregion
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());
        }
    }
}
