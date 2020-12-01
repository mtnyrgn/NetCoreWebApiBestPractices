using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBestPractices.Core.BaseDocument
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class BsonCollectionAttribute : Attribute
    {
        public BsonCollectionAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }

        public string CollectionName { get; set; 
        }
    }
}
