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

        public async Task<Response<List<ContatoModel>>> GetContatos()
        {
            var lista = await _context.Contatos.ToListAsync();
            return new Response<List<ContatoModel>>
            {
                Dados = lista,
                Sucesso = true,
                Mensagem = lista.Any()
                    ? "Contatos recuperados com sucesso."
                    : "Nenhum contato encontrado."
            };
        }

        public async Task<Response<List<ContatoModel>>> CreateContatos(ContatoModel novoContato)
        {
            _context.Contatos.Add(novoContato);
            await _context.SaveChangesAsync();

            // retorna a lista atualizada
            return await GetContatos();
        }

        public async Task<Response<ContatoModel>> GetContatosById(int id)
        {
            var contato = await _context.Contatos.FindAsync(id);
            if (contato == null)
                return new Response<ContatoModel>
                {
                    Dados = null,
                    Sucesso = false,
                    Mensagem = "Contato não encontrado."
                };

            return new Response<ContatoModel>
            {
                Dados = contato,
                Sucesso = true,
                Mensagem = "Contato encontrado."
            };
        }

        public async Task<Response<List<ContatoModel>>> UpdateContatos(ContatoModel ContatoEditado)
        {
            _context.Contatos.Update(ContatoEditado);
            await _context.SaveChangesAsync();
            return await GetContatos();
        }

        public async Task<Response<List<ContatoModel>>> DeleteContatos(int id)
        {
            var contato = await _context.Contatos.FindAsync(id);
            if (contato == null)
                return new Response<List<ContatoModel>>
                {
                    Dados = null,
                    Sucesso = false,
                    Mensagem = "Contato não encontrado."
                };

            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();
            return await GetContatos();
        }

        public async Task<Response<List<ContatoModel>>> InativaContatos(int id)
        {
            var contato = await _context.Contatos.FindAsync(id);
            if (contato == null)
                return new Response<List<ContatoModel>>
                {
                    Dados = null,
                    Sucesso = false,
                    Mensagem = "Contato não encontrado."
                };

            contato.Ativo = false;
            _context.Contatos.Update(contato);
            await _context.SaveChangesAsync();
            return await GetContatos();
        }
    }
}
