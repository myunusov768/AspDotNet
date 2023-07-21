using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace AspCore;
public sealed class DbTodo : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("DbTodo");
    }
    public DbSet<Todo> Todos { get; set; }
}