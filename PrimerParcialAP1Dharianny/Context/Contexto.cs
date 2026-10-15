using PrimerParcialAP1Dharianny.Models;
using Microsoft.EntityFrameworkCore;

namespace PrimerParcialAP1Dharianny.Context;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Colectas> Colectas { get; set; } = null!;
}