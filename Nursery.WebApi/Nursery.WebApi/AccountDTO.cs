using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nursery.WebApi
{
    public class LoginDTO
    {
        [Required(ErrorMessage ="Пошта пуста"), 
            EmailAddress(ErrorMessage = "Не валідна пошта")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Пароль пустий")]
        public string Password { get; set; }
    }
}
