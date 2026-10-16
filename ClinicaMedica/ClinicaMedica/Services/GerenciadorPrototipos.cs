using System.Collections.Generic;
using ClinicaMedica.Models;

namespace ClinicaMedica.Services
{
    public class GerenciadorPrototipos
    {
        private readonly Dictionary<string, PacoteExame> prototipos =
            new Dictionary<string, PacoteExame>();

        public void CadastrarPrototipo(
            string chave,
            PacoteExame prototipo
        )
        {
            prototipos[chave] = prototipo;
        }

        public PacoteExame? ObterClone(string chave)
        {
            if (prototipos.TryGetValue(
                chave,
                out PacoteExame? modeloOriginal
            ))
            {
                return modeloOriginal.Clonar();
            }

            return null;
        }
    }
}
