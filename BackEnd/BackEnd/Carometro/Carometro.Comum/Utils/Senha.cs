using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Comum.Utils
{
    public static class Senha
    {
        public static string Criptografar(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool ValidarHashes(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }
    }
}
