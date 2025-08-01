using ContatoApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatoApi.Application.Interfaces
{
    public interface IContatoServices
    {
        Task<Response<List<ContatoModel>>> GetContatos();
        Task<Response<ContatoModel>> GetContatosById(int id);
        Task<Response<List<ContatoModel>>> CreateContatos(ContatoModel novoContato);
        Task<Response<List<ContatoModel>>> UpdateContatos(ContatoModel ContatoEditado);
        Task<Response<List<ContatoModel>>> DeleteContatos(int id);
        Task<Response<ContatoModel>> InativaContatos(int id);
        
               
    }
}
