using Domain.DTO;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Aplication
{
    public interface IFamiliaService
    {
        int CalcularPontosPorRenda(Familia familia);
        int CalcularPontosPorIdade(Familia familia);
        int CalcularPontosPorDependente(Familia familia);
        int CalcularPontosTotais(Familia familia);
        List<FamiliaDto> SortearFamilia();
    }
}
