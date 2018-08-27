using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DesafioProcessoSeletivoTest
{
    public class DesafioXUnit
    {
        /* Este teste cobra conceitos de teste unitário e conceitos de cobertura de código.
         * 
         * 1 - Utilizando o exemplo abaixo escreva testes unitários(XUnit) para as rotinas de ClasseParaTeste e ClasseFilhaParaTeste. 
         *
         * Obs: Lembre-se de cobrir construtores e métodos.
         */

        [Fact(DisplayName = "Classes devem ser testadas.")]
        public void Teste()
        {
            bool foramTestadas = true;
            Assert.True(foramTestadas);
        }

    }

    // Classe que deve ser testada.
    public class ClasseParaTeste
    {
        public ClasseParaTeste(
            string nomeUsuarioCriacao,
            ICollection<ClasseFilhaParaTeste> classesFilhas
            )
        {
            this.DataHoraCriacao = DateTime.Now;
            this.NomeUsuarioCriacao = nomeUsuarioCriacao;
            this.ClassesFilhas = classesFilhas;
        }

        public long Id { get; private set; }
        public DateTime DataHoraCriacao { get; private set; }
        public string NomeUsuarioCriacao { get; private set; }
        public DateTime? DataHoraUltimaAlteracao { get; private set; }
        public string NomeUsuarioAlteracao { get; private set; }
        public ICollection<ClasseFilhaParaTeste> ClassesFilhas { get; private set; }

        public bool TenhoPrimeiroFilho()
        {
            return this.ClassesFilhas.Any(x => x.PrimeiroFilho);
        }

        public void InserirNovoFilho(ClasseFilhaParaTeste filho, string nomeUsuarioAlteracao)
        {
            if (filho.PrimeiroFilho && this.TenhoPrimeiroFilho())
                throw new InvalidOperationException("Não posso ter dois primeiros filhos.");

            this.ClassesFilhas.Add(filho);
            this.DataHoraUltimaAlteracao = DateTime.Now;
            this.NomeUsuarioAlteracao = nomeUsuarioAlteracao;
        }
    }

    // Classe que deve ser testada.
    public class ClasseFilhaParaTeste
    {
        public ClasseFilhaParaTeste(bool primeiroFilho, string nomeDoFilho)
        {
            this.PrimeiroFilho = primeiroFilho;
            this.NomeDoFilho = nomeDoFilho;
        }

        public long Id { get; private set; }
        public bool PrimeiroFilho { get; private set; }
        public string NomeDoFilho { get; private set; }
    }

    public class TesteClasseFilhaParaTeste
    {
        public ClasseFilhaParaTeste classeFilhaParaTeste;

        /* Teste do método construtor da classe classeFilhaParaTeste */
        [Theory]
        [InlineData(null, null)]
        [InlineData(true, null)]
        [InlineData(false, null)]
        [InlineData(true, "nomeDoFilho")]
        public void testeMetodoConstrutorClasseFilhaParaTeste(bool primeiroFilho, string nomeDoFilho)
        {
            classeFilhaParaTeste = new ClasseFilhaParaTeste(primeiroFilho, nomeDoFilho);

            Assert.True(primeiroFilho.Equals(classeFilhaParaTeste.PrimeiroFilho));
            Assert.Equal(nomeDoFilho, classeFilhaParaTeste.NomeDoFilho);
            Assert.NotNull(classeFilhaParaTeste);
        }
    }

    public class TesteClasseParaTeste
    {
        public ClasseParaTeste classeParaTeste;

        /* Inicio de dados para testes em métodos da classe classeParaTeste */
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[]{null, null},
                new object[]{ "nomeUsuarioCriacao", null},
                new object[]{ null, new List<ClasseFilhaParaTeste> {
                    new ClasseFilhaParaTeste(true, null),
                    new ClasseFilhaParaTeste(false, null),
                    new ClasseFilhaParaTeste(true, "anderson"),
                    new ClasseFilhaParaTeste(false, "anderson")
                    }
                },
                new object[]{ "nomeUsuarioCriacao", new List<ClasseFilhaParaTeste> {
                    new ClasseFilhaParaTeste(true, null),
                    new ClasseFilhaParaTeste(false, null),
                    new ClasseFilhaParaTeste(true, "anderson"),
                    new ClasseFilhaParaTeste(false, "anderson")
                    }
                }
            };

        public static IEnumerable<object[]> DataPrimeiroFilho =>
            new List<object[]>
            {
                new object[]{
                    null,
                    new List<ClasseFilhaParaTeste> {
                        new ClasseFilhaParaTeste(false, "anderson"),
                        new ClasseFilhaParaTeste(false, "anderson2")
                    },
                    false
                },
                new object[]{
                    "nomeUsuarioCriacao",
                    new List<ClasseFilhaParaTeste> {
                        new ClasseFilhaParaTeste(false, "anderson"),
                        new ClasseFilhaParaTeste(true, "anderson2")
                    },
                    true
                },
                new object[]{
                    "nomeUsuarioCriacao",
                    new List<ClasseFilhaParaTeste> {
                        new ClasseFilhaParaTeste(true, "anderson"),
                        new ClasseFilhaParaTeste(false, "anderson2")
                    },
                    true
                }
            };

        public static IEnumerable<object[]> DataPrimeiroFilhoArgumentNullException =>
            new List<object[]>
            {
                new object[]{null, null},
                new object[]{ "nomeUsuarioCriacao", null}
            };

        public static IEnumerable<object[]> DataNovoFilho =>
            new List<object[]>
            {
                new object[]{new ClasseFilhaParaTeste(true, "filho 3"), "nomeUsuarioAlteracao", new List<ClasseFilhaParaTeste> {
                        new ClasseFilhaParaTeste(false, "filho 1"),
                        new ClasseFilhaParaTeste(false, "filho 2")
                    }
                },
                new object[]{new ClasseFilhaParaTeste(false, "filho 3"), "nomeUsuarioAlteracao", new List<ClasseFilhaParaTeste> {
                        new ClasseFilhaParaTeste(false, "filho 1"),
                        new ClasseFilhaParaTeste(false, "filho 2")
                    }
                }
            };

        public static IEnumerable<object[]> DataNovoNullException =>
            new List<object[]>
            {
                new object[]{null, null, null},
            };

        public static IEnumerable<object[]> DataNovoInvalidOperationException =>
            new List<object[]>
            {
                new object[]{new ClasseFilhaParaTeste(true, "filho 3"), "nomeUsuarioAlteracao", new List<ClasseFilhaParaTeste> {
                        new ClasseFilhaParaTeste(true, "filho 1"),
                        new ClasseFilhaParaTeste(false, "filho 2")
                    }
                },
                new object[]{new ClasseFilhaParaTeste(true, "filho 3"), "nomeUsuarioAlteracao", new List<ClasseFilhaParaTeste> {
                        new ClasseFilhaParaTeste(false, "filho 1"),
                        new ClasseFilhaParaTeste(true, "filho 2")
                    }
                }
            };
        /* Inicio de dados para testes em métodos da classe classeParaTeste */

        /* Teste método construtor da classe ClasseParaTeste */
        [Theory]
        [MemberData(nameof(Data))]
        public void ClasseParaTeste(
            string nomeUsuarioCriacao,
            ICollection<ClasseFilhaParaTeste> classesFilhas
            )
        {
            classeParaTeste = new ClasseParaTeste(nomeUsuarioCriacao, classesFilhas);

            Assert.NotNull(classeParaTeste);
            Assert.Equal(nomeUsuarioCriacao, classeParaTeste.NomeUsuarioCriacao);
            Assert.Equal(classesFilhas, classeParaTeste.ClassesFilhas);
            Assert.True(
                classeParaTeste.DataHoraCriacao != null &&
                DateTime.Now >= classeParaTeste.DataHoraCriacao &&
                (classeParaTeste.DataHoraCriacao - DateTime.Now).Seconds >= -2
            );
        }

        /* Teste método tenhoPrimeiroFilho da classe ClasseParaTeste */
        [Theory]
        [MemberData(nameof(DataPrimeiroFilho))]
        public void TenhoPrimeiroFilho(
            string nomeUsuarioCriacao,
            ICollection<ClasseFilhaParaTeste> classesFilhas,
            bool resultado
        )
        {
            classeParaTeste = new ClasseParaTeste(nomeUsuarioCriacao, classesFilhas);
            Assert.Equal(classeParaTeste.TenhoPrimeiroFilho(), resultado);
        }

        /* Teste de exceção método tenhoPrimeiroFilho da classe ClasseParaTeste */
        [Theory]
        [MemberData(nameof(DataPrimeiroFilhoArgumentNullException))]
        public void TenhoPrimeiroFilhoArgumentNullException(
            string nomeUsuarioCriacao,
            ICollection<ClasseFilhaParaTeste> classesFilhas
        )
        {
            classeParaTeste = new ClasseParaTeste(nomeUsuarioCriacao, classesFilhas);
            Exception ex = Assert.Throws<ArgumentNullException>(() => classeParaTeste.TenhoPrimeiroFilho());

            Assert.Equal("Value cannot be null.\r\nParameter name: source", ex.Message);
            System.Console.WriteLine(ex.Message);
        }

        /* Teste do método inserirPrimeiroFilho da classe ClasseParaTeste */
        [Theory]
        [MemberData(nameof(DataNovoFilho))]
        public void InserirNovoFilho(ClasseFilhaParaTeste filho, string nomeUsuarioAlteracao, ICollection<ClasseFilhaParaTeste> filhos)
        {

            classeParaTeste = new ClasseParaTeste("anderson", filhos);

            classeParaTeste.InserirNovoFilho(filho, nomeUsuarioAlteracao);

            Assert.Equal(nomeUsuarioAlteracao, classeParaTeste.NomeUsuarioAlteracao);
            Assert.Contains(classeParaTeste.ClassesFilhas, f => f.Equals(filho));
            Assert.True(
                classeParaTeste.DataHoraUltimaAlteracao != null &&
                DateTime.Now >= classeParaTeste.DataHoraUltimaAlteracao &&
                (DateTime.Now - classeParaTeste.DataHoraUltimaAlteracao.Value).Seconds >= -2
            );
        }

        /* Teste de exceção método inserirPrimeiroFilho da clsse ClasseParaTeste */
        [Theory]
        [MemberData(nameof(DataNovoInvalidOperationException))]
        public void InserirNovoFilhoThrowsInvalidOperationException(ClasseFilhaParaTeste filho, string nomeUsuarioAlteracao, ICollection<ClasseFilhaParaTeste> filhos)
        {

            classeParaTeste = new ClasseParaTeste("anderson", filhos);

            Exception ex = Assert.Throws<InvalidOperationException>(() => classeParaTeste.InserirNovoFilho(filho, nomeUsuarioAlteracao));

            Assert.Equal("Não posso ter dois primeiros filhos.", ex.Message);
 
        }

        /* Teste de exceção método inserirPrimeiroFilho da clsse ClasseParaTeste */
        [Theory]
        [MemberData(nameof(DataNovoNullException))]
        public void InserirNovoFilhoThrowsException(ClasseFilhaParaTeste filho, string nomeUsuarioAlteracao, ICollection<ClasseFilhaParaTeste> filhos)
        {

            classeParaTeste = new ClasseParaTeste("anderson", filhos);

            Exception ex = Assert.Throws<NullReferenceException>(() => classeParaTeste.InserirNovoFilho(filho, nomeUsuarioAlteracao));

            Assert.Equal("Object reference not set to an instance of an object.", ex.Message);

        }
    }

}
