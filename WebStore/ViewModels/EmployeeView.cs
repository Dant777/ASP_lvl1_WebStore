using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels
{
    public class EmployeeView
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Имя является обязательным полем")]
        [Display(Name = "Имя")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Имя должно быть не менее 2 и не более 200 символов")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Имя является обязательным полем")]
        [Display(Name = "Фамилие")]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Имя является обязательным полем")]
        [Display(Name = "Возвраст")]
        public int Age { get; set; }

        [Display(Name = "Должность")]
        public string Position { get; set; }
    }
}
