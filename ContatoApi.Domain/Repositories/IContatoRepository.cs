using ContatoApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatoApi.Domain.Repositories
{
    public interface IContatoRepository
    {
        Task<IEnumerable<ContatoModel>> ObterTodosAsync();
        Task<ContatoModel?> ObterPorIdAsync(int id);
        Task AdicionarAsync(ContatoModel contato);
        Task AtualizarAsync(ContatoModel contato);
        Task RemoverAsync(int id);
        Task AtivarAsync(int id);
        Task DesativarAsync(int id);
    }
}
