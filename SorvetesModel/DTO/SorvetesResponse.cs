using MongoDB.Bson;

namespace SorveteriaModel.DTO
{
    public class SorveteResponse
    {
        public ObjectId Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Categoria { get; set; }
    }
}
