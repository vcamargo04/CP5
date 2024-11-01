using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.EntityFrameworkCore;

namespace SorveteriaModel
{
    [Collection("sorvetes")]
    public class Sorvete
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId Id { get; set; }

        [BsonElement("nome")]
        public string Nome { get; set; }

        [BsonElement("preco")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Preco { get; set; }

        [BsonElement("categoria")]
        public string Categoria { get; set; }

        [BsonElement("fabricante")]
        public string Fabricante { get; set; }
    }
}
