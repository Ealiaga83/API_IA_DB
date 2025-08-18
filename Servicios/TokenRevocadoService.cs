using System.Collections.Concurrent;

namespace API_IA_DB.Servicios
{
    public class TokenRevocadoService
    {
        private static readonly ConcurrentDictionary<string, DateTime> tokensRevocados = new();

        public void RevocarToken(string token)
        {
            tokensRevocados[token] = DateTime.UtcNow;
        }

        public bool EstaRevocado(string token)
        {
            return tokensRevocados.ContainsKey(token);
        }
    }
}
