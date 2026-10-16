using System;
using System.Collections.Generic;

namespace ClinicaMedica.Models
{
    public class PacoteExame : ICloneable
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

        public object Clone()
        {
            PacoteExame copia = new PacoteExame(
                NomePacote,
                OrientacoesJejum
            );

            copia.NomePaciente = NomePaciente;

            foreach (Procedimento procedimento in Procedimentos)
            {
                copia.Procedimentos.Add(
                    (Procedimento)procedimento.Clone()
                );
            }

            return copia;
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

            decimal total = 0;

            foreach (Procedimento procedimento in Procedimentos)
            {
                Console.WriteLine(
                    $"{procedimento.Nome}: " +
                    $"R$ {procedimento.Valor:F2}"
                );

                total += procedimento.Valor;
            }

            Console.WriteLine($"Total: R$ {total:F2}");
        }
    }
}
