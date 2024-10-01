using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using Defender.BudgetTracker.Domain.Enums;
using MongoDB.Bson.IO;
using MongoDB.Bson;

namespace Defender.BudgetTracker.Domain.Serialization;

public class CustomSerializators : SerializerBase<DateOnly>
{
    private static readonly DateTimeSerializer DateTimeSerializer = new DateTimeSerializer(DateTimeKind.Utc);

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, DateOnly value)
    {
        var dateTime = value.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc);
        DateTimeSerializer.Serialize(context, dateTime);
    }

    public override DateOnly Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var dateTime = DateTimeSerializer.Deserialize(context);
        return DateOnly.FromDateTime(dateTime);
    }
}

public class CurrencyDictionarySerializer : DictionarySerializerBase<Dictionary<Currency, decimal>>
{
    protected override Dictionary<Currency, decimal> CreateInstance()
    {
        return new Dictionary<Currency, decimal>();
    }

    protected override Dictionary<Currency, decimal> DeserializeValue(
        BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var bsonReader = context.Reader;
        var dictionary = new Dictionary<Currency, decimal>();

        bsonReader.ReadStartDocument();
        while (bsonReader.ReadBsonType() != BsonType.EndOfDocument)
        {
            var key = (Currency)Enum.Parse(typeof(Currency), bsonReader.ReadName());
            var value = (decimal)bsonReader.ReadDecimal128();
            dictionary.Add(key, value);
        }
        bsonReader.ReadEndDocument();

        return dictionary;
    }

    protected override void SerializeValue(
        BsonSerializationContext context, BsonSerializationArgs args, Dictionary<Currency, decimal> value)
    {
        var bsonWriter = context.Writer;

        bsonWriter.WriteStartDocument();
        foreach (var kvp in value)
        {
            bsonWriter.WriteName(kvp.Key.ToString());
            bsonWriter.WriteDecimal128(kvp.Value);
        }
        bsonWriter.WriteEndDocument();
    }
}
