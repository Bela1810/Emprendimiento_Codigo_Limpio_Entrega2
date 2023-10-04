using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Emprendimiento_Codigo_Limpio_Entrega2.Models
{
    public class MiembroModel
    {
        [Required(ErrorMessage = "El id es obligatorio.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El rol es obligatorio.")]
        public string Rol { get; set; }

        [Required(ErrorMessage = "El email es obligatorio.")]
        public string Email { get; set; }

        // Constructor sin parámetros
        public MiembroModel()
        {
        }

        public MiembroModel(int id, string nombre, string apellidos, string rol, string email)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            Rol = rol;
            Email = email;
        }
    }
}