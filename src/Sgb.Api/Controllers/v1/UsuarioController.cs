﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sgb.Api.Controllers.Shared;
using Sgb.Application.DTOs.Request;
using Sgb.Application.DTOs.Response;
using Sgb.Application.Service;
using System.Security.Claims;

namespace Sgb.Api.Controllers.v1;

[ApiVersion("1.0")]
[AllowAnonymous]
public class UsuarioController : ApiControllerBase
{
    IIdentityService _identityService;

    public UsuarioController(IIdentityService identityService) =>
        _identityService = identityService;

    [HttpPost("cadastro")]
    public async Task<ActionResult<UsuarioCadastroResponse>> Cadastrar (UsuarioCadastroRequest usuarioCadastro)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var resultado = await _identityService.CadastrarUsuario(usuarioCadastro);
        if (resultado.Sucesso)
            return Ok(resultado);
        else if(resultado.Erros.Count > 0)
            return BadRequest(resultado);

        return StatusCode(StatusCodes.Status500InternalServerError);
    }
    [HttpPost("login")]
    public async Task<ActionResult<UsuarioCadastroResponse>> Login(UsuarioLoginRequest usuarioLogin)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var resultado = await _identityService.Login(usuarioLogin);
        if (resultado.Sucesso)
            return Ok(resultado);

        return Unauthorized(resultado);
    }
    [Authorize]
    [HttpPost("refresh-login")]
    public async Task<ActionResult<UsuarioCadastroResponse>> RefreshLogin()
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        var usuarioId = identity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (usuarioId == null)
            return BadRequest();

        var resultado = await _identityService.LoginSemSenha(usuarioId);
        if (resultado.Sucesso)
            return Ok(resultado);

        return Unauthorized(resultado);
    }
}
