using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PosterShop
{
    public partial class Topics
    {
        public Topics()
        {
            Posters = new HashSet<Posters>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage ="Поле не может быть пустым!")]
        [Display(Name="Тема")]
        public string Name { get; set; }

        public virtual ICollection<Posters> Posters { get; set; }
    }
}
