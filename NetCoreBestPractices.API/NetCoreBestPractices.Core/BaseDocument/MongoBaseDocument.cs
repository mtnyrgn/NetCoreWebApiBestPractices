using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBestPractices.Core.BaseDocument
{
    public abstract class MongoBaseDocument //Document RDBMS'teki row ile aynı anlama sahip. Her document yani row oluştuğu esnada mongodbde ona bir objectId oluşturulur. Bu yüzden her rowda olması
    { //gereken özellikler için bir baseDocument oluşturduk.
        [BsonId] //Id olacağı söylendi.
        [BsonRepresentation(BsonType.String)]
        public ObjectId Id { get; set; } //MongoDb de primary key Object Id ile ifade ediliyor.
        public DateTime CreatedTime => Id.CreationTime; //Oluşturma zamanını direk ObjectIdnin oluşturma zamanına eşitledim.
    }
}
