using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BVMinh.DemoArchitecture.Entity.Entities
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [BsonElement("_id")]
        public string StudentID { get; set; }
        [BsonRequired]
        [BsonElement("StudentName")]
        public string StudentName { get; set; }
    }
}
