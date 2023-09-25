using FirstDecision.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstDecision.DataLayer.Context;

public partial class FirstDecisionContext : DbContext
{
    public FirstDecisionContext(DbContextOptions<FirstDecisionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pessoa> Pessoa { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pessoa__3214EC27898C14E2");
        });

        OnModelCreatingPartial(modelBuilder); 
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}