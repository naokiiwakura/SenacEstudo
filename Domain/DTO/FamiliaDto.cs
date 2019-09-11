using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class FamiliaDto
    {
        public string FamiliaId { get; set; }
        public PontosTotaisDto PontosECriterios { get; set; }
        public DateTime? DataSelecao { get; set; }
    }
}
