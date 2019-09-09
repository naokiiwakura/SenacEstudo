using Domain.Aplication;
using Domain.Infra;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class FamiliaService : IFamiliaService
    {
        private readonly IFamiliaRepository _familiaRepository;

        public FamiliaService(IFamiliaRepository repository)
        {
            _familiaRepository = repository;
        }

        public int CalcularPontos(Familia familia)
        {
            var renda = familia.Rendas.Sum(p => p.Valor);
            if (renda <= 900)
            {
                return 5;
            }

            else if (renda <=1500)
            {
                return 3;
            }

            else if (renda <= 2000)
            {
                return 1;
            }

            return 0;
        }

        public List<Familia> SortearFamilia()
        {
            throw new NotImplementedException();
        }
    }
}
