using System.ComponentModel.DataAnnotations;

namespace TodoApi.Domain.ViewModels.TodoViewModels
{
    public class TodoInputModel
    {
        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [StringLength(75, ErrorMessage = "Campo {0} deve conter no máximo {1} caracteres.")]
        public string Title { get; set; }

        [StringLength(200, ErrorMessage = "Campo {0} deve conter no máximo {1} caracteres.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        public bool IsFinished { get; set; }
    }
}
