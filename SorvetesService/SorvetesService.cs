using SorveteriaModel.DTO;
using SorveteriaModel;


namespace SorvetesService
{
    public class SorveteService
    {
        public Sorvete RequestToSorvete(SorveteRequest sorveteRequest)
        {
            return new Sorvete
            {
                Nome = sorveteRequest.Nome,
                Preco = sorveteRequest.Preco,
                Categoria = sorveteRequest.Categoria,
                Fabricante = sorveteRequest.Fabricante
            };
        }

        public SorveteResponse SorveteToResponse(Sorvete sorvete)
        {
            return new SorveteResponse
            {
                Id = sorvete.Id,
                Nome = sorvete.Nome,
                Preco = sorvete.Preco,
                Categoria = sorvete.Categoria
            };
        }

        public List<SorveteResponse> SorvetesToListResponse(List<Sorvete> sorvetes)
        {
            return sorvetes.Select(sorvete => new SorveteResponse
            {
                Id = sorvete.Id,
                Nome = sorvete.Nome,
                Preco = sorvete.Preco,
                Categoria = sorvete.Categoria
            }).ToList();
        }
    }
}
