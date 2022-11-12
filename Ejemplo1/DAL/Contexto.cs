using Microsoft.EntityFrameworkCore;
using Ejemplo1.Model;

namespace Ejemplo1.DAl{
public class Contexto : DbContext
    {     

         public DbSet<Car> Car { get; set; }
        
        public Contexto(DbContextOptions<Contexto> options) : base(options) 
        { 

         }
     }
    
}