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
    
    public partial class Asignatura
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> idProfesor { get; set; }
    
        public virtual Docente Docente { get; set; }
    }
}
