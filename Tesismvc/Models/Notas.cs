//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tesismvc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Notas
    {
        public int id { get; set; }
        public string Nota { get; set; }
        public Nullable<int> idalumno { get; set; }
        public Nullable<int> idcurso { get; set; }
        public Nullable<int> idprofesor { get; set; }
    
        public virtual Alumnos Alumnos { get; set; }
        public virtual Curso Curso { get; set; }
        public virtual Docente Docente { get; set; }
    }
}
