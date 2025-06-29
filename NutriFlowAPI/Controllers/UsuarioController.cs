﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NutriFlowAPI.Models;
using NutriFlowAPI.Models.Usuario;
using NutriFlowAPI.Services.Usuario;
using NutriFlowAPI.DTO.Usuario;

namespace NutriFlowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioInterface _usuarioInterface;
        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpGet("ListarUsuarios")]
        public async Task<ActionResult<ResponseModel<List<UsuarioModel>>>> ListarUsuarios()
        {
            var usuarios = await _usuarioInterface.ListarUsuarios();

            return Ok(usuarios);
        }

        [HttpGet("BuscarUsuarioPorId/{idUsuario}")]
        public async Task<ActionResult<ResponseModel<UsuarioModel>>> BuscarUsuarioPorId(int idUsuario)
        {
            var usuario = await _usuarioInterface.BuscarUsuarioPorId(idUsuario);

            return Ok(usuario);
        }

        [HttpPost("CriarUsuario")]
        public async Task<ActionResult<ResponseModel<List<UsuarioModel>>>> CriarUsuario(UsuarioCriacaoDTO usuarioCriacaoDTO)
        {
            var usuarios = await _usuarioInterface.CriarUsuario(usuarioCriacaoDTO);
            return Ok(usuarios);
        }

        [HttpPut("EditarUsuario")]
        public async Task<ActionResult<ResponseModel<List<UsuarioModel>>>> EditarUsuario(UsuarioEdicaoDTO usuarioEdicaoDTO)
        {
            var usuarios = await _usuarioInterface.EditarUsuario(usuarioEdicaoDTO);
            return Ok(usuarios);
        }

        [HttpDelete("ExcluirUsuario")]
        public async Task<ActionResult<ResponseModel<List<UsuarioModel>>>> ExcluirUsuario(int idUsuario)
        {
            var usuarios = await _usuarioInterface.ExcluirUsuario(idUsuario);
            return Ok(usuarios);
        }
    }
}
