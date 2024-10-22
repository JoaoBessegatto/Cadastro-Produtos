using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Cadastro_Produtos.Models
{
    [Table("Cadastro")]
    public class ProdutosModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; } 
        public double Preco {  get; set; }  
        public DateTime DataCadastro { get; set; }


    }
}
