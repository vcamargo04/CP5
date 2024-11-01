using MongoDB.Driver;
using SorveteriaModel;

namespace SorveteriaDatabase
{
    public class FIAPMongoDBContext
    {
        private readonly IMongoDatabase _database;

        public FIAPMongoDBContext(IMongoClient mongoClient)
        {
            _database = mongoClient.GetDatabase("rm99494"); // Nome do banco de dados
        }

        public IMongoCollection<Sorvete> Sorvetes => _database.GetCollection<Sorvete>("SorveteriaAPI"); // Nome da coleção
    }
}
