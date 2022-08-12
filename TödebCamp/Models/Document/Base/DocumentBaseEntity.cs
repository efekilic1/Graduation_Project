using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Models.Document.Base
{
    public abstract class DocumentBaseEntity
    {
        public ObjectId Id { get; set; }
        public string ObjectId => Id.ToString();

        [BsonElement]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime InsertedAt { get; set; } = DateTime.Now;

    }
}