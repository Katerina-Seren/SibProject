//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SibProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FILE
    {
        public int Id { get; set; }
        public int ID_PROJECT { get; set; }
        public string Name { get; set; }
    
        public virtual PROJECT PROJECT { get; set; }
    }
}
