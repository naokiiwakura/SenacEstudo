using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class FamiliaDto
    {
        public string FamiliaId { get; set; }
        public int QuantidadeDeCriteriosAtendidos { get; set; }
        public int PontuacaoTotal { get; set; }
        public DateTime? DataSelecao { get; set; }
    }
}
