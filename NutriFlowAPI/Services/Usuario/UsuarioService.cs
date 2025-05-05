using NutriFlowAPI.Models;
using NutriFlowAPI.Models.Usuario;
using NutriFlowAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using NutriFlowAPI.DTO.Usuario;

namespace NutriFlowAPI.Services.Usuario
{
    public class UsuarioService : IUsuarioInterface
    {

        private readonly AppDbContext _context;
        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<UsuarioModel>> BuscarUsuarioPorId(int idUsuario)
        {
            ResponseModel<UsuarioModel> resposta = new ResponseModel<UsuarioModel>();
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuarioBanco => usuarioBanco.Id == idUsuario);

                if (usuario == null) 
                {
                    resposta.Mensagem = "Nenhum registro encontrado";

                    return resposta;
                }

                resposta.Dados = usuario;
                resposta.Mensagem = "Usuario localizado";
                
                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<UsuarioModel>>> CriarUsuario(UsuarioCriacaoDTO usuarioCriacaoDTO)
        {
            ResponseModel<List<UsuarioModel>> resposta = new ResponseModel<List<UsuarioModel>>();

            try
            {
                var usuario = new UsuarioModel()
                {
                    Nome = usuarioCriacaoDTO.Nome,
                    Sobrenome = usuarioCriacaoDTO.Sobrenome,
                    Email = usuarioCriacaoDTO.Email,
                    DataNascimento = usuarioCriacaoDTO.DataNascimento,
                    Telefone = usuarioCriacaoDTO.Telefone,
                    Senha = usuarioCriacaoDTO.Senha,
                    DataCadastro = usuarioCriacaoDTO.DataCadastro,
                    PaisId = usuarioCriacaoDTO.PaisId,
                    CidadeId = usuarioCriacaoDTO.CidadeId,
                };

                _context.Add(usuario);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Usuarios.ToListAsync();
                resposta.Mensagem = "Usuario criado com sucesso!";
                return resposta;
                
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios()
        {
            ResponseModel<List<UsuarioModel>> resposta = new ResponseModel<List<UsuarioModel>>();
            try
            {
                var usuarios = await _context.Usuarios.ToListAsync();

                resposta.Dados = usuarios;
                resposta.Mensagem = "Todos os usuarios foram coletados";
                
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                
                return resposta;
            }
        }
    }
}
