﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL_EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AGarciaGenJulioEntities : DbContext
    {
        public AGarciaGenJulioEntities()
            : base("name=AGarciaGenJulioEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Alumno> Alumnoes { get; set; }
        public virtual DbSet<Semestre> Semestres { get; set; }
        public virtual DbSet<Grupo> Grupoes { get; set; }
        public virtual DbSet<Horario> Horarios { get; set; }
        public virtual DbSet<Plantel> Plantels { get; set; }
    
        public virtual ObjectResult<AlumnoGetById_Result> AlumnoGetById(Nullable<int> idAlumno)
        {
            var idAlumnoParameter = idAlumno.HasValue ?
                new ObjectParameter("IdAlumno", idAlumno) :
                new ObjectParameter("IdAlumno", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AlumnoGetById_Result>("AlumnoGetById", idAlumnoParameter);
        }
    
        public virtual int AlumnoUpdate(Nullable<int> idAlumno, string nombre, string apellidoPaterno, string apellidoMaterno, string email, Nullable<int> idSemestre)
        {
            var idAlumnoParameter = idAlumno.HasValue ?
                new ObjectParameter("IdAlumno", idAlumno) :
                new ObjectParameter("IdAlumno", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var idSemestreParameter = idSemestre.HasValue ?
                new ObjectParameter("IdSemestre", idSemestre) :
                new ObjectParameter("IdSemestre", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AlumnoUpdate", idAlumnoParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, emailParameter, idSemestreParameter);
        }
    
        public virtual ObjectResult<SemestreGetAll_Result> SemestreGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SemestreGetAll_Result>("SemestreGetAll");
        }
    
        public virtual int AlumnoAdd(string nombre, string apellidoPaterno, string apellidoMaterno, string email, Nullable<int> idSemestre, string turno, Nullable<int> idGrupo)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var idSemestreParameter = idSemestre.HasValue ?
                new ObjectParameter("IdSemestre", idSemestre) :
                new ObjectParameter("IdSemestre", typeof(int));
    
            var turnoParameter = turno != null ?
                new ObjectParameter("Turno", turno) :
                new ObjectParameter("Turno", typeof(string));
    
            var idGrupoParameter = idGrupo.HasValue ?
                new ObjectParameter("IdGrupo", idGrupo) :
                new ObjectParameter("IdGrupo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AlumnoAdd", nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, emailParameter, idSemestreParameter, turnoParameter, idGrupoParameter);
        }
    
        public virtual ObjectResult<AlumnoGetAll_Result> AlumnoGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AlumnoGetAll_Result>("AlumnoGetAll");
        }
    
        public virtual ObjectResult<GrupoGetByIdPlantel_Result> GrupoGetByIdPlantel(Nullable<int> idPlantel)
        {
            var idPlantelParameter = idPlantel.HasValue ?
                new ObjectParameter("IdPlantel", idPlantel) :
                new ObjectParameter("IdPlantel", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GrupoGetByIdPlantel_Result>("GrupoGetByIdPlantel", idPlantelParameter);
        }
    
        public virtual ObjectResult<PlantelGetAll_Result> PlantelGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PlantelGetAll_Result>("PlantelGetAll");
        }
    }
}
