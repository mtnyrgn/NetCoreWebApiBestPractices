using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using NetCoreBestPractices.Core.BaseDocument;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBestPractices.Core.Documents
{
    [BsonCollection("persons")] //Mongo üzerinde tabloyu hangi isimle çağıracağımı belirttim
    public class Person : MongoBaseDocument //Her tablom baseden kalıtım almalı.Yani objectId'yi( yada daha fazlasını) default olarak içermeli.
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
