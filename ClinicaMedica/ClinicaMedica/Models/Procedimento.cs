namespace ClinicaMedica.Models
{
    public class Procedimento
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public Procedimento(string nome, decimal valor)
        {
            Nome = nome;
            Valor = valor;
        }

        // Cria uma nova cópia do procedimento
        public Procedimento Clonar()
        {
            return new Procedimento(Nome, Valor);
        }
    }
}
