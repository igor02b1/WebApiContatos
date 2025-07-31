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
        Task<Response<List<ContatoModel>>> GetContatos();
        Task<Response<List<ContatoModel>>> CreateContatos(ContatoModel novoContato);
        Task<Response<ContatoModel>> GetContatosById(int id);
        Task<Response<List<ContatoModel>>> UpdateContatos(ContatoModel ContatoEditado);
        Task<Response<List<ContatoModel>>> DeleteContatos(int id);
        Task<Response<List<ContatoModel>>> InativaContatos(int id);
    }
}
