using ContatoApi.Application.Services;
using ContatoApi.Domain.Models;
using ContatoApi.Infrastructure.DataContext;
using Microsoft.AspNetCore.Mvc;

using ContatoApi.Application.Services;
using ContatoApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiContatos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoServices _contatoService;

        public ContatoController(IContatoServices contatoService)
        {
            _contatoService = contatoService;
        }

        [HttpGet]
        public async Task<ActionResult<Response<List<ContatoModel>>>> GetAll()
        {
            var response = await _contatoService.GetContatos();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response<ContatoModel>>> GetById(int id)
        {
            var response = await _contatoService.GetContatosById(id);
            if (!response.Sucesso)
                return NotFound(response);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Response<List<ContatoModel>>>> Create(ContatoModel novoContato)
        {
            var response = await _contatoService.CreateContatos(novoContato);
            if (!response.Sucesso)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<Response<List<ContatoModel>>>> Update(ContatoModel contato)
        {
            var response = await _contatoService.UpdateContatos(contato);
            if (!response.Sucesso)
                return NotFound(response);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<List<ContatoModel>>>> Delete(int id)
        {
            var response = await _contatoService.DeleteContatos(id);
            if (!response.Sucesso)
                return NotFound(response);
            return Ok(response);
        }

        [HttpPatch("inativar/{id}")]
        public async Task<ActionResult<Response<List<ContatoModel>>>> Inativar(int id)
        {
            var response = await _contatoService.InativaContatos(id);
            if (!response.Sucesso)
                return NotFound(response);
            return Ok(response);
        }
    }
}
