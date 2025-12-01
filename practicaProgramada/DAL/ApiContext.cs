using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PracticaProgramada.DAL.Entidades;

namespace PracticaProgramada.DAL;
 public partial class ApiContext : DbContext
 {
    public ApiContext() 
    {
        
    }
    public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
    public virtual DbSet<Estudiante> Estudiantes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.ToTable("Estudiante");
            entity.Property(e => e.Id).HasColumnName("ID");
        });
        OnModelCreating(modelBuilder);
    }
    partial void onModelCreatingPartial(ModelBuilder modelBuilder);
 }

