using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Senaitur.WebApi.DataBaseFirst.Domains
{
    public partial class Pacotes
    {
        public int IdPacote { get; set; }
        [Required(ErrorMessage = "O nome do pacote é obrigatório")]
        public string NomePacote { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe a data de ida do pacote")]
        // Define o tipo de dado
        [DataType(DataType.Date)]
        public DateTime? DataIda { get; set; }

        [Required(ErrorMessage = "Informe a data de volta do pacote")]
        // Define o tipo de dado
        [DataType(DataType.Date)]
        public DateTime? DataVolta { get; set; }

        public decimal? Valor { get; set; }
        public bool? Ativo { get; set; }
        public string NomeCidade { get; set; }
    }
}
