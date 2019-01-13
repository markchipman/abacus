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
        private readonly JsonSerializerSettings _prettySerializerSettings;

        public AbacusJsonOutputFormatter(JsonSerializerSettings serializerSettings)
               : this(serializerSettings, ArrayPool<char>.Shared)
        {
        }

        public AbacusJsonOutputFormatter(JsonSerializerSettings serializerSettings, ArrayPool<char> charPool)
            : base(serializerSettings, charPool)
        {
            _prettySerializerSettings = (serializerSettings ?? new JsonSerializerSettings()).DeepCopy();
            _prettySerializerSettings.Formatting = Formatting.Indented;
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            if (context.HttpContext.Request.Query.TryGetValue("pretty", out var values))
            {
                if (!values.Contains("false") && values.Contains("true"))
                {
                    var response = context.HttpContext.Response;
                    using (var writer = context.WriterFactory(response.Body, selectedEncoding))
                    {
                        var prettySerializer = JsonSerializer.Create(_prettySerializerSettings);
                        prettySerializer.Serialize(writer, context.Object);
                        await writer.FlushAsync();
                    }
                    return;
                }
            }

            await base.WriteResponseBodyAsync(context, selectedEncoding);
        }
    }
}
