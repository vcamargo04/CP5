using System.ComponentModel.DataAnnotations;

namespace SorveteriaModel.DTO
{
    public class SorveteRequest
    {
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Nome do sorvete deve ter entre 10 e 50 caracteres")]
        [Required(ErrorMessage = "Nome do sorvete é necessário")]
        public string Nome { get; set; }

        [Range(1.00, 10000.00, ErrorMessage = "O preço do sorvete deve estar entre R$ 1,00 e R$ 10.000,00")]
        [Required(ErrorMessage = "Preço do sorvete é necessário")]
        public decimal Preco { get; set; }

        [StringLength(50, MinimumLength = 10, ErrorMessage = "Categoria do sorvete deve ter entre 10 e 50 caracteres")]
        [Required(ErrorMessage = "Categoria do sorvete é necessária")]
        public string Categoria { get; set; }

        [StringLength(50, MinimumLength = 10, ErrorMessage = "Nome do fabricante deve ter entre 10 e 50 caracteres")]
        [Required(ErrorMessage = "Nome do fabricante é necessário")]
        public string Fabricante { get; set; }
    }
}
