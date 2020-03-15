using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PosterShop
{
    public partial class Shops
    {
        public Shops()
        {
            Reservations = new HashSet<Reservations>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым!")]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым!")]
        [Display(Name = "График работы")]
        public string Worktime { get; set; }

        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
