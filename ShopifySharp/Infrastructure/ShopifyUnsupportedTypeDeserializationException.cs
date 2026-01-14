#nullable enable
using System;

namespace ShopifySharp;

[Serializable]
public class ShopifyUnsupportedTypeDeserializationException(
    Type rootType,
    string? jsonPath = null,
    Type? offendingType = null,
    string? requestId = null,
    Exception? innerException = null)
    : ShopifyJsonParseException(BuildMessage(rootType, jsonPath, offendingType),
        jsonPath,
        requestId,
        innerException)
{
    public Type RootType { get; } = rootType;
    public Type? OffendingType { get; } = offendingType;
    public string? JsonPath { get; } = jsonPath;

    private static string BuildMessage(Type rootType, string? jsonPath, Type? offendingType)
    {
        var root = rootType.FullName ?? rootType.Name;
        var offending = offendingType != null ? $": '{offendingType.FullName}'" : string.Empty;
        var path = !string.IsNullOrWhiteSpace(jsonPath) ? $" at JSON path '{jsonPath}'" : string.Empty;

        return
            $"Deserialization of '{root}' failed. " +
            $"An unsupported abstract or interface type was encountered{offending}{path}. " +
            "This typically indicates a Shopify API version mismatch or missing polymorphic configuration " +
            "attributes (e.g., [JsonDerivedType]/[JsonPolymorphic]) on a custom return type.";
    }
}
