﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sigex.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class sigexdbEntities : DbContext
    {
        public sigexdbEntities()
            : base("name=sigexdbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Examan> Examen { get; set; }
        public virtual DbSet<preguntasExaman> preguntasExamen { get; set; }
        public virtual DbSet<TipoPregunta> TipoPreguntas { get; set; }
    }
}
