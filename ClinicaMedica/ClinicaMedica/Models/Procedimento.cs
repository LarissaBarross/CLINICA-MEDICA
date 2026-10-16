using System;
using ClinicaMedica.Interfaces;

namespace ClinicaMedica.Models
{
    public class Procedimento :
        ICloneable,
        IPrototipo<Procedimento>
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

        // Mantém o método do ICloneable.
        public object Clone()
        {
            return MemberwiseClone();
        }

        // Método da interface genérica.
        // Agora o retorno é Procedimento,
        // e não object.
        public Procedimento Clonar()
        {
            return (Procedimento)Clone();
        }
    }
}
