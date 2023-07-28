using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WONDER_Proyecto.Models
{
    public class Empleado
    {
        [Key]
        public int ID_EMPLEADO { get; set; }
        [Required(ErrorMessage = "Favor ingrese su nombre")]
        [StringLength(10, ErrorMessage = "El largo del nombre debe ser menor a 101 y mínimo 3", MinimumLength = 3)]
        [DisplayName("Nombre")]
        public string NOMBRE { get; set; }
        [Required(ErrorMessage = "Favor ingrese su apellido paterno")]
        [StringLength(10, ErrorMessage = "El largo del apellido paterno debe ser menor a 101 y mínimo 3", MinimumLength = 3)]
        [DisplayName("Apellido Paterno")]
        public string APELLIDO_PATERNO { get; set; }
        [Required(ErrorMessage = "Favor ingrese su apellido materno")]
        [StringLength(10, ErrorMessage = "El largo del apellido materno debe ser menor a 101 y mínimo 3", MinimumLength = 3)]
        [DisplayName("Apellido Materno")]
        public string APELLIDO_MATERNO { get; set; }
        [Required(ErrorMessage = "Favor ingrese su correo electrónico")]
        [StringLength(10, ErrorMessage = "El largo del correo electrónico debe ser menor a 101 y mínimo 3", MinimumLength = 3)]
        [DisplayName("Correo Electrónico")]
        public string CORREO { get; set; }
        [Required(ErrorMessage = "Favor ingrese su nombre de usuario a utilizar")]
        [StringLength(10, ErrorMessage = "El largo del nombre de usuario debe ser menor a 101 y mínimo 3", MinimumLength = 3)]
        [DisplayName("Nombre de Usuario")]
        public string USUARIO { get; set; }
        [Required(ErrorMessage = "Favor ingrese su contraseña")]
        [StringLength(10, ErrorMessage = "El largo de la contraseña debe ser menor a 101 y mínimo 3", MinimumLength = 3)]
        [DisplayName("Contraseña")]
        public string CONTRASENNA { get; set; }
        public int TIPO_USUARIO { get; set; }
    }
}