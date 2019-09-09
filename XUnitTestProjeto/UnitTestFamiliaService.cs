using Domain.Aplication;
using Domain.Infra;
using Domain.Model;
using Moq;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProjeto
{
    public class UnitTestFamiliaService
    {
        private readonly IFamiliaService _familiaService;
        private readonly Mock<IFamiliaRepository> _familiaRepositoryMock = new Mock<IFamiliaRepository>();

        public UnitTestFamiliaService()
        {
            _familiaService = new FamiliaService(_familiaRepositoryMock.Object);
        }

        #region Mock da lista de famílias

        public List<Familia> FuncaoRetornaFamilias()
        {
            var lista = new List<Familia>();

            lista.Add(new Familia { Id = "53ce49c7-e793-48c8-bf69-381c9e5dc9e3",
                Rendas = new List<Renda> { new Renda { Valor = 900 }, new Renda { Valor = 500 } }
            });


            lista.Add(new Familia
            {
                Id = "994d69bf-1635-48fd-9f70-5b7c5c25dab0",
                Rendas = new List<Renda> { new Renda { Valor = 300 }, new Renda { Valor = 200 }, }
            });

            lista.Add(new Familia
            {
                Id = "38d89727-fc4a-41c2-83b6-1161bee29768",
                Rendas = new List<Renda> { new Renda { Valor = 1200 }, new Renda { Valor = 302 }, }
            });


            return lista;
        }

        #endregion


        [Theory]
        [InlineData("53ce49c7-e793-48c8-bf69-381c9e5dc9e3",3)]
        [InlineData("994d69bf-1635-48fd-9f70-5b7c5c25dab0", 5)]
        [InlineData("38d89727-fc4a-41c2-83b6-1161bee29768", 1)]
        public void TestCalcularPontosPorRenda(string idFamilia, int pontuacao)
        {
            //Arranjo
            var familia = FuncaoRetornaFamilias().FirstOrDefault(p => p.Id == idFamilia);

            //Ação
            var pontos = _familiaService.CalcularPontos(familia);

            //Confirmação
            Assert.Equal(pontuacao, pontos);
        }
    }
}
