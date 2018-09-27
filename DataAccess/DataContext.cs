using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataAccess
{
    public class DataContext:DbContext
    {
        public DbSet<Unidad> Unidades { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<ProgramaEducativo> ProgramasEducativos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Mes> Meses { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Trimestre> Trimestres { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Nombramiento> Nombramientos { get; set; }
        public DbSet<Maestro> Maestros { get; set; }
        public DbSet<PerfilDocente> PerfilesDocentes { get; set; }
        public DbSet<ProgramaEducativoDetalle> ProgramasEducativosDetalles { get; set; }
        public DbSet<ModuloGrupo> ModulosGrupo { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DataContext() : base("name=DBHorarios")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DataContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Unidad>().HasKey(i => i.Id);
            modelBuilder.Entity<Departamento>().HasOptional(i => i.Unidad).WithMany().HasForeignKey(i => i.UnidadId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ProgramaEducativo>().HasKey(i => i.Id);
            modelBuilder.Entity<ProgramaEducativo>().HasOptional(i => i.Departamento).WithMany().HasForeignKey(i => i.DepartamentoId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Mes>().HasKey(i => i.Id);
            modelBuilder.Entity<Categoria>().HasKey(i => i.Id);
            modelBuilder.Entity<Materia>().HasOptional(i => i.Categoria).WithMany().HasForeignKey(i => i.CategoriaId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Turno>().HasKey(i => i.Id);
            modelBuilder.Entity<Trimestre>().HasOptional(i => i.Mes).WithMany().HasForeignKey(i => i.MesId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Modulo>().HasKey(i => i.Id);
            modelBuilder.Entity<Nombramiento>().HasKey(i => i.Id);
            modelBuilder.Entity<Nombramiento>().Property(i => i.MaxHoras).HasPrecision(3, 1);
            modelBuilder.Entity<Materia>().Property(i => i.Horas).HasPrecision(2, 1);
            modelBuilder.Entity<Maestro>().HasOptional(i => i.Unidad).WithMany().HasForeignKey(i => i.UnidadId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Maestro>().HasOptional(i => i.Departamento).WithMany().HasForeignKey(i => i.DepartamentoId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Maestro>().HasOptional(i => i.Nombramiento).WithMany().HasForeignKey(i => i.NombramientoId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Maestro>().HasOptional(i => i.ProgramaEducativo).WithMany().HasForeignKey(i => i.ProgramaEducativoId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Maestro>().HasKey(i => i.Id);
            modelBuilder.Entity<ProgramaEducativo>().HasOptional(i => i.Unidad).WithMany().HasForeignKey(i => i.UnidadId).WillCascadeOnDelete(false);
            modelBuilder.Entity<PerfilDocente>().HasKey(i => i.Id);
            modelBuilder.Entity<PerfilDocente>().HasOptional(i => i.Maestro).WithMany().HasForeignKey(i => i.MaestroId).WillCascadeOnDelete(false);
            modelBuilder.Entity<PerfilDocente>().HasOptional(i => i.Materia).WithMany().HasForeignKey(i => i.MateriaId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ProgramaEducativoDetalle>().HasOptional(i => i.ProgramaEducativo).WithMany().HasForeignKey(i => i.ProgamaEducativoId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ProgramaEducativoDetalle>().HasOptional(i => i.Materia).WithMany().HasForeignKey(i => i.MateriaId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ProgramaEducativoDetalle>().HasOptional(i => i.Trimestre).WithMany().HasForeignKey(i => i.TrimestreId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ProgramaEducativoDetalle>().HasKey(i => i.Id);
            modelBuilder.Entity<Grupo>().HasOptional(i => i.ProgramaEducativo).WithMany().HasForeignKey(i => i.ProgramaEducativoId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Grupo>().HasOptional(i => i.Trimestre).WithMany().HasForeignKey(i => i.TrimestreId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Grupo>().HasOptional(i => i.Turno).WithMany().HasForeignKey(i => i.TurnoId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Grupo>().HasKey(i => i.Id);
            modelBuilder.Entity<ModuloGrupo>().HasKey(i => i.Id);
            modelBuilder.Entity<GrupoDisponibilidad>().HasOptional(i => i.Maestro).WithMany().HasForeignKey(i => i.MaestroId).WillCascadeOnDelete(false);
            modelBuilder.Entity<GrupoDisponibilidad>().HasOptional(i => i.Materia).WithMany().HasForeignKey(i => i.MateriaId).WillCascadeOnDelete(false);
            modelBuilder.Entity<GrupoDisponibilidad>().HasOptional(i => i.Grupo).WithMany().HasForeignKey(i => i.GrupoId).WillCascadeOnDelete(false);
            modelBuilder.Entity<GrupoDisponibilidad>().HasOptional(i => i.Modulo).WithMany().HasForeignKey(i => i.ModuloId).WillCascadeOnDelete(false);
            modelBuilder.Entity<GrupoDisponibilidad>().HasOptional(i => i.Trimestre).WithMany().HasForeignKey(i => i.TrimestreId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ModuloGrupo>().HasKey(i => i.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
