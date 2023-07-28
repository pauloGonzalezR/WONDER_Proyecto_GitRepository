using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WONDER_Proyecto.Models
{
    public class TipoUsuario
    {
        [Key]
        public int ID_TIPO_USUARIO { get; set; }
        [Required(ErrorMessage = "Favor ingrese la descripción del tipo de usuario")]
        [StringLength(10, ErrorMessage = "El largo del tipo de usuario debe ser menor a 101 y mínimo 3", MinimumLength = 3)]
        [DisplayName("Tipo de Usuario")]
        public string DESCRIPCION { get; set; }
    }
}
