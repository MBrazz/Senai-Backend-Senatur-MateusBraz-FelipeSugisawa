using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Senaitur.WebApi.DataBaseFirst.Domains
{
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Informe o e-mail do usuário")]
        // Define o tipo do dado
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Define que a senha é obrigatório
        [Required(ErrorMessage = "Informe a senha do usuário")]
        // Define o tipo do dado
        [DataType(DataType.Password)]
        // Define os requisitos da senha
        [StringLength(20, MinimumLength = 5, ErrorMessage = "A senha deve conter no mínimo 5 e no máximo 20 caracteres")]
        public string Senha { get; set; }
        public int? IdTipoUsuario { get; set; }

        public TiposUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
