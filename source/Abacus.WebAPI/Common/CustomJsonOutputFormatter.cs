using System.Buffers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;

namespace Abacus.WebApi.Common
{
    public class AbacusJsonOutputFormatter : JsonOutputFormatter
    {
        public AbacusJsonOutputFormatter(JsonSerializerSettings defaultSerializerSettings)
               : base(defaultSerializerSettings, ArrayPool<char>.Shared)
        {
        }

        public AbacusJsonOutputFormatter(JsonSerializerSettings defaultSerializerSettings, ArrayPool<char> charPool)
            : base(defaultSerializerSettings, charPool)
        {
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            if (context.HttpContext.Request.Query.TryGetValue("pretty", out var values))
            {
                var response = context.HttpContext.Response;
                using (var writer = context.WriterFactory(response.Body, selectedEncoding))
                {
                    var customSerializer = base.CreateJsonSerializer();

                    if (!values.Contains("false") && values.Contains("true"))
                    {
                        customSerializer.Formatting = Formatting.Indented;

                    }
                    else if (values.Contains("false"))
                    {
                        customSerializer.Formatting = Formatting.None;
                    }

                    customSerializer.Serialize(writer, context.Object);

                    await writer.FlushAsync();
                }
            }
            else
            {
                await base.WriteResponseBodyAsync(context, selectedEncoding);
            }
        }
    }
}
