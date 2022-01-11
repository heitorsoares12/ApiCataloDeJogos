using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("88c23a07-e3e4-482d-acc4-004ca0acc72e"), new Jogo{ Id = Guid.Parse("88c23a07-e3e4-482d-acc4-004ca0acc72e"), Nome = "Fifa 21", Produtora = "EA", Preco = 200} },
            {Guid.Parse("987b4da5-3425-403d-af00-a9058f56918d"), new Jogo{ Id = Guid.Parse("987b4da5-3425-403d-af00-a9058f56918d"), Nome = "Fifa 20", Produtora = "EA", Preco = 190} },
            {Guid.Parse("5a9c108f-ec7d-4254-a803-e3f90501f522"), new Jogo{ Id = Guid.Parse("5a9c108f-ec7d-4254-a803-e3f90501f522"), Nome = "Fifa 19", Produtora = "EA", Preco = 180} },
            {Guid.Parse("bd94f40f-7249-4afc-8728-55d1a2b9567f"), new Jogo{ Id = Guid.Parse("bd94f40f-7249-4afc-8728-55d1a2b9567f"), Nome = "Fifa 18", Produtora = "EA", Preco = 170} },
            {Guid.Parse("9a3018ac-99c8-47b5-b040-0fe01a416aeb"), new Jogo{ Id = Guid.Parse("9a3018ac-99c8-47b5-b040-0fe01a416aeb"), Nome = "Street Fighter", Produtora = "Capcom", Preco = 80} },
            {Guid.Parse("292340ad-f494-45e3-b220-920f65157090"), new Jogo{ Id = Guid.Parse("292340ad-f494-45e3-b220-920f65157090"), Nome = "GTA V", Produtora = "Rockstar", Preco = 190} }
        };

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora)
        {
            var retorno = new List<Jogo>();

            foreach (var jogo in jogos.Values)
            {
                if (jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora))
                    retorno.Add(jogo);
            }

            return Task.FromResult(retorno);
        }

        public Task Inserir(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Fechar conexao com o banco
        }
    }
}
