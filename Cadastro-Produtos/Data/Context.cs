using Cadastro_Produtos.Models;
using Microsoft.EntityFrameworkCore;

namespace Cadastro_Produtos.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options): base(options) 
        { 
            
    
        }
        public DbSet<ProdutosModel> Produtos { get; set; }
    }
}
