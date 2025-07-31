using ContatoApi.Domain.Models;
using ContatoApi.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatoApi.Domain.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly ApplicationDbContext _context;

        public ContatoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContatoModel>> ObterTodosAsync()
        {
            return await _context.Contatos.ToListAsync();
        }

        public async Task<ContatoModel?> ObterPorIdAsync(int id)
        {
            return await _context.Contatos.FindAsync(id);
        }

        public async Task AdicionarAsync(ContatoModel contato)
        {
            _context.Contatos.Add(contato);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(ContatoModel contato)
        {
            _context.Contatos.Update(contato);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var contato = await _context.Contatos.FindAsync(id);
            if (contato != null)
            {
                _context.Contatos.Remove(contato);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AtivarAsync(int id)
        {
            var contato = await _context.Contatos.FindAsync(id);
            if (contato != null)
            {
                contato.Ativo = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesativarAsync(int id)
        {
            var contato = await _context.Contatos.FindAsync(id);
            if (contato != null)
            {
                contato.Ativo = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}
