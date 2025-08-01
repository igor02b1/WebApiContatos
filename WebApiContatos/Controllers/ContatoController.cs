using ContatoApi.Domain.Models;
using ContatoApi.Infrastructure.DataContext;
using Microsoft.AspNetCore.Mvc;
using ContatoApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContatoApi.Application.Interfaces;

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
            {
                return NotFound(response);
            }
                
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Response<List<ContatoModel>>>> Create(ContatoModel novoContato)
        {
            var response = await _contatoService.CreateContatos(novoContato);
            if (!response.Sucesso)
            {
                return BadRequest(response);
            }
                
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarContato(int id, [FromBody] ContatoModel contatoEditado)
        {
            if (id != contatoEditado.Id)
            {
                return BadRequest("ID da URL não bate com o ID do corpo da requisição.");
            }            

            var response = await _contatoService.UpdateContatos(contatoEditado);

            if (!response.Sucesso)
            {
                return BadRequest(response.Mensagem);
            }               
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<List<ContatoModel>>>> Delete(int id)
        {
            var response = await _contatoService.DeleteContatos(id);
            if (!response.Sucesso)
            {
                return BadRequest(response);
            }                
            return Ok(response);
        }

        [HttpPatch("inativar/{id}")]
        public async Task<ActionResult<Response<List<ContatoModel>>>> Inativar(int id)
        {
            var response = await _contatoService.InativaContatos(id);
            if (!response.Sucesso)
            {
                return BadRequest(response);
            }                
            return Ok(response);
        }
    }
}
