using System.Collections.Generic;
using ClinicaMedica.Models;

namespace ClinicaMedica.Services
{
    public class GerenciadorPrototipos
    {
        private readonly
            Dictionary<string, PacoteExame>
            prototipos =
            new Dictionary<string, PacoteExame>();

        // Cadastra um pacote modelo no dicionário.
        public void CadastrarPrototipo(
            string chave,
            PacoteExame prototipo
        )
        {
            prototipos[chave] = prototipo;
        }

        // Busca um modelo e cria uma cópia.
        public PacoteExame? ObterClone(
            string chave
        )
        {
            if (
                prototipos.TryGetValue(
                    chave,
                    out PacoteExame? modeloOriginal
                )
            )
            {
                // O método Clone() retorna object.
                // Por isso, fazemos a conversão para PacoteExame.
                return (PacoteExame)modeloOriginal.Clone();
            }

            // Retorna null caso a chave não exista.
            return null;
        }
    }
}
