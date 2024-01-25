using Awesomedevevents.API.Entities;
using CadastroUsuario.API.Log_De_Erro;
using Domain.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Awesomedevevents.API.Controllers
{
    [Route("api/Usuario")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly IUsuario _usuario;
        public APIController(IUsuario usuario)
        {
            _usuario = usuario;
        }

        Logs_De_Erro logs_De_Erro = new Logs_De_Erro();

        [HttpGet("GetUsuariosBanco")]
        public IActionResult GetUsuariosBanco()
        {
            try
            {
                var RetornoListaUsuario = _usuario.GetUsuariosBanco().Where(rr => !rr.IsDeleted).ToList();
                if (!RetornoListaUsuario.Any())
                {
                    return NotFound("Nenhum Usuário foi localizado");
                }
                return Ok(RetornoListaUsuario);
            }
            catch (Exception ex)
            {
                logs_De_Erro.Excecao_Erro(ex);
                throw ex;
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetUsuariosId(int id)
        {
            try
            {
                var RetornoFiltroUsuario = _usuario.GetUsuariosId().SingleOrDefault(rr => rr.Id == id);

                if (RetornoFiltroUsuario == null)
                {
                    return NotFound("Usuário não encontrado");
                }

                return Ok(RetornoFiltroUsuario);
            }
            catch (Exception ex)
            {
                logs_De_Erro.Excecao_Erro(ex);
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        [HttpPost]
        public IActionResult IncluirUsuario(Usuario dadosUsuario)
        {

            try
            {
                bool sucessoInclusao = _usuario.IncluirUsuario(dadosUsuario);

                if (!sucessoInclusao)
                {
                    return NotFound("Erro ao incluir usuário");
                }
                return Ok("Usuário incluido com sucesso");
            }
            catch (Exception ex)
            {
                logs_De_Erro.Excecao_Erro(ex);
                return NotFound("Erro ao incluir usuário");
            }
        }


        [HttpPut("{id}")]
        public IActionResult AtualizaUsuario(Guid id, UsuarioEntitie Entrada_Dados)
        {
            try
            {
                var RetornoAtualizaUsuario = _usuario.AtualizaUsuario(id);

                if (!RetornoAtualizaUsuario)
                {
                    return NotFound("Erro ao atualizar Usuário");
                }
            }
            catch (Exception ex)
            {
                logs_De_Erro.Excecao_Erro(ex);
                return NotFound("Erro ao atualizar usuário");
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario(Guid id)
        {
            try
            {
                var retornoDeletarUsuario = _usuario.DeletarUsuario(id);
                if (!retornoDeletarUsuario)
                {
                    return NotFound("Erro ao deletar usuário");
                }
            }
            catch (Exception ex)
            {
                logs_De_Erro.Excecao_Erro(ex);
                return NotFound("Erro ao deletar usuário");

            }
            return Ok();
        }

    }
}
