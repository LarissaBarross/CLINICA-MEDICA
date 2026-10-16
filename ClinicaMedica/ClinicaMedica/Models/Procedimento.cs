using System;

namespace ClinicaMedica.Models
{
    public class Procedimento : ICloneable
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public Procedimento(
            string nome,
            decimal valor
        )
        {
            Nome = nome;
            Valor = valor;
        }

        // Desafio 2:
        // Cria uma cópia do objeto usando MemberwiseClone().
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}

