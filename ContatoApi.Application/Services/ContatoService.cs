using ContatoApi.Application.Interfaces;
using ContatoApi.Application.Utils;
using ContatoApi.Application.Validators;
using ContatoApi.Domain.Models;
using ContatoApi.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContatoApi.Application.Services
{
    public class ContatoService : IContatoServices
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task<Response<List<ContatoModel>>> GetContatos()
        {
            var response = new Response<List<ContatoModel>>();

            try
            {
                var contatosResponse = await _contatoRepository.GetContatos();
                var contatosAtivos = contatosResponse.Dados?.SomenteAtivos() ?? new List<ContatoModel>();

                if (contatosAtivos.Count == 0)
                {
                    response.Mensagem = "Nenhum contato encontrado.";
                }

                response.Dados = contatosAtivos;
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = ex.Message;
            }

            return response;
        }

        public async Task<Response<List<ContatoModel>>> CreateContatos(ContatoModel novoContato)
        {
            var response = new Response<List<ContatoModel>>();

            try
            {
                if (novoContato == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Dados inválidos.";
                    return response;
                }

                if (!ValidarData.ValidacaoData(novoContato.DataNascimento))
                {
                    response.Sucesso = false;
                    response.Mensagem = "A data de nascimento tem que ser menor que a data atual.";
                    return response;
                }

                if (!CalcularIdade.ContatoMaiorDeIdade(novoContato.DataNascimento))
                {
                    response.Sucesso = false;
                    response.Mensagem = "Contato tem que ser maior de idade.";
                    return response;
                }

                novoContato.Idade = CalcularIdade.CalcularContatoIdade(novoContato.DataNascimento);

                await _contatoRepository.CreateContatos(novoContato);

                var contatosResponse = await _contatoRepository.GetContatos();
                response.Dados = contatosResponse.Dados?.SomenteAtivos();
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = ex.Message;
            }

            return response;
        }

        public async Task<Response<ContatoModel>> GetContatosById(int id)
        {
            var response = new Response<ContatoModel>();

            try
            {
                var contatoResponse = await _contatoRepository.GetContatosById(id);

                if (contatoResponse.Dados == null || !contatoResponse.Dados.Ativo)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Contato não encontrado ou inativo.";
                    return response;
                }

                response.Dados = contatoResponse.Dados;
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = ex.Message;
            }

            return response;
        }

        public async Task<Response<List<ContatoModel>>> UpdateContatos(ContatoModel contatoEditado)
        {
            var response = new Response<List<ContatoModel>>();

            try
            {
                var contatoExistente = await _contatoRepository.GetContatosById(contatoEditado.Id);

                if (contatoExistente.Dados == null || !contatoExistente.Dados.Ativo)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Contato não encontrado ou inativo.";
                    return response;
                }

                contatoEditado.DataAlteracao = DateTime.Now;
                await _contatoRepository.UpdateContatos(contatoEditado);

                var contatosResponse = await _contatoRepository.GetContatos();
                response.Dados = contatosResponse.Dados?.SomenteAtivos();
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = ex.Message;
            }

            return response;
        }

        public async Task<Response<List<ContatoModel>>> DeleteContatos(int id)
        {
            var response = new Response<List<ContatoModel>>();

            try
            {
                var contatoResponse = await _contatoRepository.GetContatosById(id);

                if (contatoResponse.Dados == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Contato não encontrado.";
                    return response;
                }

                await _contatoRepository.DeleteContatos(id);

                var contatosResponse = await _contatoRepository.GetContatos();
                response.Dados = contatosResponse.Dados?.SomenteAtivos();
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = ex.Message;
            }

            return response;
        }

        public async Task<Response<ContatoModel>> InativaContatos(int id)
        {
            var response = new Response<ContatoModel>();

            try
            {
                var contatoResponse = await _contatoRepository.GetContatosById(id);

                if (contatoResponse.Dados == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Contato não encontrado.";
                    return response;
                }

                var contato = contatoResponse.Dados;
                contato.Ativo = false;
                contato.DataAlteracao = DateTime.Now;

                await _contatoRepository.UpdateContatos(contato);

                response.Dados = contato;
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = ex.Message;
            }

            return response;
        }
    }
}
