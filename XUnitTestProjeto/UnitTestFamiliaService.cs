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
                Rendas = new List<Renda> { new Renda { Valor = 900 }, new Renda { Valor = 500 } },
                Pessoas = new List<Pessoa> {
                    new Pessoa { DataDeNascimento = new DateTime(1968,1,1), Tipo = "Pretendente"},
                    new Pessoa { DataDeNascimento = new DateTime(2015,1,1), Tipo = "Dependente"},
                    new Pessoa { DataDeNascimento = new DateTime(2014,1,1), Tipo = "Dependente"},
                    new Pessoa { DataDeNascimento = new DateTime(1988,1,1), Tipo = "Dependente"}
                }

            });


            lista.Add(new Familia
            {
                Id = "994d69bf-1635-48fd-9f70-5b7c5c25dab0",
                Rendas = new List<Renda> { new Renda { Valor = 300 }, new Renda { Valor = 200 }, },
                Pessoas = new List<Pessoa> {
                    new Pessoa { DataDeNascimento = new DateTime(1976,1,1), Tipo = "Pretendente"},
                    new Pessoa { DataDeNascimento = new DateTime(1980,1,1), Tipo = "Dependente"}
                }
            });

            lista.Add(new Familia
            {
                Id = "38d89727-fc4a-41c2-83b6-1161bee29768",
                Rendas = new List<Renda> { new Renda { Valor = 1200 }, new Renda { Valor = 302 }, },
                Pessoas = new List<Pessoa> {
                    new Pessoa { DataDeNascimento = new DateTime(1995,1,1), Tipo = "Pretendente"},
                    new Pessoa { DataDeNascimento = new DateTime(2015,1,1), Tipo = "Dependente"},
                    new Pessoa { DataDeNascimento = new DateTime(2002,1,1), Tipo = "Dependente"},
                    new Pessoa { DataDeNascimento = new DateTime(2013,1,1), Tipo = "Dependente"}
                }
            });

            lista.Add(new Familia
            {
                Id = "c94e2617-e57f-4c96-b68d-a4855e054094",
                Rendas = new List<Renda> { new Renda { Valor = 1200 }, new Renda { Valor = 302 }, },
                Pessoas = new List<Pessoa> {
                    new Pessoa { DataDeNascimento = new DateTime(1995, 1, 1), Tipo = "Dependente" },
                    new Pessoa { DataDeNascimento = new DateTime(2002, 1, 1), Tipo = "Dependente" },
                    new Pessoa { DataDeNascimento = new DateTime(2001, 1, 1), Tipo = "Dependente" },
                    new Pessoa { DataDeNascimento = new DateTime(2010, 1, 1), Tipo = "Dependente" },
                    new Pessoa { DataDeNascimento = new DateTime(2011, 1, 1), Tipo = "Dependente" }
                }
            });

            lista.Add(new Familia
            {
                Id = "3270f111-6662-47ac-b1fe-553191f652f2",
                Rendas = new List<Renda> { new Renda { Valor = 1200 }, new Renda { Valor = 302 }, },
                Pessoas = new List<Pessoa> { new Pessoa { DataDeNascimento = new DateTime(1974, 12, 31), Tipo = "Pretendente" } }
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
            var pontos = _familiaService.CalcularPontosPorRenda(familia);

            //Confirmação
            Assert.Equal(pontuacao, pontos);
        }

        [Theory]
        [InlineData("53ce49c7-e793-48c8-bf69-381c9e5dc9e3",3)]
        [InlineData("994d69bf-1635-48fd-9f70-5b7c5c25dab0",2)]
        [InlineData("38d89727-fc4a-41c2-83b6-1161bee29768", 1)]
        [InlineData("c94e2617-e57f-4c96-b68d-a4855e054094", 0)]
        [InlineData("3270f111-6662-47ac-b1fe-553191f652f2",2)]
        public void TestCalcularPontosPorIdade(string idFamilia, int pontuacao)
        {
            //Arranjo
            var familia = FuncaoRetornaFamilias().FirstOrDefault(p => p.Id == idFamilia);

            //Ação
            var pontos = _familiaService.CalcularPontosPorIdade(familia);

            //Confirmacao
            Assert.Equal(pontuacao, pontos);
        }

        [Theory]
        [InlineData("53ce49c7-e793-48c8-bf69-381c9e5dc9e3",2)]
        [InlineData("994d69bf-1635-48fd-9f70-5b7c5c25dab0",0)]
        [InlineData("38d89727-fc4a-41c2-83b6-1161bee29768",3)]
        [InlineData("c94e2617-e57f-4c96-b68d-a4855e054094",3)]
        public void TestCalcularPontosPorDependente(string idFamilia, int pontuacao)
        {
            //Arranjo
            var familia = FuncaoRetornaFamilias().FirstOrDefault(p => p.Id == idFamilia);

            //Ação
            var pontos = _familiaService.CalcularPontosPorDependente(familia);

            //Confirmacao
            Assert.Equal(pontuacao, pontos);
        }





    }
}
