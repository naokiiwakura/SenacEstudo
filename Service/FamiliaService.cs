using Domain.Aplication;
using Domain.Infra;
using Domain.Model;
using Service.Tools;
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

        public int CalcularPontosPorRenda(Familia familia)
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

        public int CalcularPontosPorDependente(Familia familia)
        {
            throw new NotImplementedException();
        }

        public int CalcularPontosPorIdade(Familia familia)
        {
            var pessoa = familia.Pessoas
                .Where(p => p.Tipo == "Pretendente")
                .FirstOrDefault();

            if(pessoa != null)
            {
                var idade = Auxiliar.CalculateAge(pessoa.DataDeNascimento);
                if(idade >= 45)
                {
                    return 3;
                }
                else if (idade > 30)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            return 0;
        }

        public int CalcularPontosTotais(Familia familia)
        {
            throw new NotImplementedException();
        }

        public List<Familia> SortearFamilia()
        {
            throw new NotImplementedException();
        }
    }
}
