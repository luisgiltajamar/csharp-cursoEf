//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CursosEF.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Profesor
    {
        public Profesor()
        {
            this.Curso = new HashSet<Curso>();
        }
    
        public int idProfesor { get; set; }
        public string nombre { get; set; }
        public int? experiencia { get; set; }
    
        public virtual ICollection<Curso> Curso { get; set; }
    }
}
