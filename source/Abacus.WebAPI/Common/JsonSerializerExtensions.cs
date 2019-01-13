﻿using Newtonsoft.Json;

namespace Abacus.WebApi.Common
{
    public static class JsonSerializerExtensions
    {
        public static JsonSerializer DeepCopy(this JsonSerializer serializer)
        {
            var copy = new JsonSerializer
            {
                Context = serializer.Context,
                Culture = serializer.Culture,
                ContractResolver = serializer.ContractResolver,
                ConstructorHandling = serializer.ConstructorHandling,
                CheckAdditionalContent = serializer.CheckAdditionalContent,
                DateFormatHandling = serializer.DateFormatHandling,
                DateFormatString = serializer.DateFormatString,
                DateParseHandling = serializer.DateParseHandling,
                DateTimeZoneHandling = serializer.DateTimeZoneHandling,
                DefaultValueHandling = serializer.DefaultValueHandling,
                EqualityComparer = serializer.EqualityComparer,
                FloatFormatHandling = serializer.FloatFormatHandling,
                Formatting = serializer.Formatting,
                FloatParseHandling = serializer.FloatParseHandling,
                MaxDepth = serializer.MaxDepth,
                MetadataPropertyHandling = serializer.MetadataPropertyHandling,
                MissingMemberHandling = serializer.MissingMemberHandling,
                NullValueHandling = serializer.NullValueHandling,
                ObjectCreationHandling = serializer.ObjectCreationHandling,
                PreserveReferencesHandling = serializer.PreserveReferencesHandling,
                ReferenceResolver = serializer.ReferenceResolver,
                ReferenceLoopHandling = serializer.ReferenceLoopHandling,
                StringEscapeHandling = serializer.StringEscapeHandling,
                TraceWriter = serializer.TraceWriter,
                TypeNameHandling = serializer.TypeNameHandling,
                SerializationBinder = serializer.SerializationBinder,
                TypeNameAssemblyFormatHandling = serializer.TypeNameAssemblyFormatHandling
            };

            foreach (var converter in serializer.Converters)
            {
                copy.Converters.Add(converter);
            }

            return copy;
        }

        public static JsonSerializerSettings DeepCopy(this JsonSerializerSettings settings)
        {
            var copy = new JsonSerializerSettings
            {
                Context = settings.Context,
                Culture = settings.Culture,
                ContractResolver = settings.ContractResolver,
                ConstructorHandling = settings.ConstructorHandling,
                CheckAdditionalContent = settings.CheckAdditionalContent,
                DateFormatHandling = settings.DateFormatHandling,
                DateFormatString = settings.DateFormatString,
                DateParseHandling = settings.DateParseHandling,
                DateTimeZoneHandling = settings.DateTimeZoneHandling,
                DefaultValueHandling = settings.DefaultValueHandling,
                EqualityComparer = settings.EqualityComparer,
                FloatFormatHandling = settings.FloatFormatHandling,
                Formatting = settings.Formatting,
                FloatParseHandling = settings.FloatParseHandling,
                MaxDepth = settings.MaxDepth,
                MetadataPropertyHandling = settings.MetadataPropertyHandling,
                MissingMemberHandling = settings.MissingMemberHandling,
                NullValueHandling = settings.NullValueHandling,
                ObjectCreationHandling = settings.ObjectCreationHandling,
                PreserveReferencesHandling = settings.PreserveReferencesHandling,
                ReferenceResolver = settings.ReferenceResolver,
                ReferenceLoopHandling = settings.ReferenceLoopHandling,
                StringEscapeHandling = settings.StringEscapeHandling,
                TraceWriter = settings.TraceWriter,
                TypeNameHandling = settings.TypeNameHandling,
                SerializationBinder = settings.SerializationBinder,
                TypeNameAssemblyFormatHandling = settings.TypeNameAssemblyFormatHandling
            };

            foreach (var converter in settings.Converters)
            {
                copy.Converters.Add(converter);
            }

            return copy;
        }
    }
}
