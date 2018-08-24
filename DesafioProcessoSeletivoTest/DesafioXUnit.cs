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
            bool foramTestadas = false;
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
}
