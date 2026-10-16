using System;
using System.Collections.Generic;
using ClinicaMedica.Interfaces;

namespace ClinicaMedica.Models
{
    public class PacoteExame :
        ICloneable,
        IPrototipo<PacoteExame>
    {
        public string NomePacote { get; set; }
        public string OrientacoesJejum { get; set; }
        public string NomePaciente { get; set; }

        public List<Procedimento> Procedimentos { get; set; }

        public PacoteExame(
            string nomePacote,
            string orientacoesJejum
        )
        {
            NomePacote = nomePacote;
            OrientacoesJejum = orientacoesJejum;
            NomePaciente = "NÃO ATRIBUÍDO";
            Procedimentos = new List<Procedimento>();
        }

        public void AdicionarProcedimento(
            Procedimento procedimento
        )
        {
            Procedimentos.Add(procedimento);
        }

        // Método exigido pela interface ICloneable.
        // Utiliza MemberwiseClone() e mantém a cópia profunda.
        public object Clone()
        {
            // Cria uma cópia inicial do pacote.
            PacoteExame copia =
                (PacoteExame)MemberwiseClone();

            // Cria uma nova lista para não compartilhar
            // os procedimentos com o pacote original.
            copia.Procedimentos =
                new List<Procedimento>();

            // Clona cada procedimento individualmente.
            foreach (
                Procedimento procedimento
                in Procedimentos
            )
            {
                copia.Procedimentos.Add(
                    (Procedimento)procedimento.Clone()
                );
            }

            return copia;
        }

        // Método exigido pela interface IPrototipo<PacoteExame>.
        // Retorna PacoteExame diretamente.
        public PacoteExame Clonar()
        {
            return (PacoteExame)Clone();
        }

        // Cópia superficial usada apenas para demonstração.
        public PacoteExame ClonarSuperficial()
        {
            return (PacoteExame)MemberwiseClone();
        }

        public void ExibirResumo()
        {
            Console.WriteLine(
                $"\n[PACOTE]: {NomePacote}" +
                $" | Paciente: {NomePaciente}"
            );

            Console.WriteLine(
                $"Orientação: {OrientacoesJejum}"
            );

            Console.WriteLine(
                "Procedimentos inclusos:"
            );

            decimal total = 0;

            foreach (
                Procedimento procedimento
                in Procedimentos
            )
            {
                Console.WriteLine(
                    $"{procedimento.Nome}: " +
                    $"R$ {procedimento.Valor:F2}"
                );

                total += procedimento.Valor;
            }

            Console.WriteLine(
                $"Total: R$ {total:F2}"
            );
        }
    }
}
