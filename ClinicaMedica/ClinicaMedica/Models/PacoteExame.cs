using System;
using System.Collections.Generic;

namespace ClinicaMedica.Models
{
    public class PacoteExame
    {
        public string NomePacote { get; set; }
        public string OrientacoesJejum { get; set; }
        public string NomePaciente { get; set; }

        public List<Procedimento> Procedimentos { get; set; }

        public PacoteExame(string nomePacote, string orientacoesJejum)
        {
            NomePacote = nomePacote;
            OrientacoesJejum = orientacoesJejum;
            NomePaciente = "NÃO ATRIBUÍDO";
            Procedimentos = new List<Procedimento>();
        }

        public void AdicionarProcedimento(Procedimento procedimento)
        {
            Procedimentos.Add(procedimento);
        }

        // Cópia profunda
        public PacoteExame Clonar()
        {
            PacoteExame copia = new PacoteExame(
                NomePacote,
                OrientacoesJejum
            );

            copia.NomePaciente = NomePaciente;

            // Cria uma nova lista e clona cada procedimento
            foreach (Procedimento procedimento in Procedimentos)
            {
                copia.Procedimentos.Add(procedimento.Clonar());
            }

            return copia;
        }

        // Cópia superficial
        // Usada apenas para demonstrar o problema de compartilhar a lista
        public PacoteExame ClonarSuperficial()
        {
            PacoteExame copia = new PacoteExame(
                NomePacote,
                OrientacoesJejum
            );

            copia.NomePaciente = NomePaciente;

            // A mesma lista será compartilhada pelos dois objetos
            copia.Procedimentos = Procedimentos;

            return copia;
        }

        public void ExibirResumo()
        {
            Console.WriteLine(
                $"\n[PACOTE]: {NomePacote} | Paciente: {NomePaciente}"
            );

            Console.WriteLine(
                $"  Orientação: {OrientacoesJejum}"
            );

            Console.WriteLine("  Procedimentos inclusos:");

            decimal total = 0;

            foreach (Procedimento procedimento in Procedimentos)
            {
                Console.WriteLine(
                    $"   - {procedimento.Nome}: R$ {procedimento.Valor:F2}"
                );

                total += procedimento.Valor;
            }

            Console.WriteLine($"  Total: R$ {total:F2}");
        }
    }
}
