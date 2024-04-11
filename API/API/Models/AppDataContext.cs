using Microsoft.EntityFrameworkCore;

namespace API.Models;

//Classe que representa Entity Framework Core : Code First
public class AppDataContext : DbContext
{
    //Representação das classes que vão virar
    //tabelas do banco de dados
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Configuração da conexão com o banco de dados
        optionsBuilder.UseSqlite("Data Source=app.db");
    }
}
