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

        // Busca o protótipo e cria uma cópia usando Clone().
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
                // Clone() retorna object.
                // Por isso, precisamos converter para PacoteExame.
                return (PacoteExame)modeloOriginal.Clone();
            }

            // Retorna null se a chave não existir.
            return null;
        }
    }
}
