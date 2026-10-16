using System.Collections.Generic;
using ClinicaMedica.Models;

namespace ClinicaMedica.Services
{
    public class GerenciadorPrototipos
    {
        private readonly Dictionary<string, PacoteExame> prototipos =
            new Dictionary<string, PacoteExame>();

        // Cadastra um pacote modelo no dicionário.
        public void CadastrarPrototipo(
            string chave,
            PacoteExame prototipo
        )
        {
            prototipos[chave] = prototipo;
        }

        // Busca o protótipo e retorna uma cópia.
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
                // Desafio 3:
                // Clonar() já retorna PacoteExame.
                // Por isso, não precisamos fazer cast.
                return modeloOriginal.Clonar();
            }

            // Retorna null se a chave não existir.
            return null;
        }
    }
}
