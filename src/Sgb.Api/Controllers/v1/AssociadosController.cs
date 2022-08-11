using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sgb.Api.Attributes;
using Sgb.Api.Controllers.Shared;
using Sgb.Application.DTOs.Request;
using Sgb.Application.DTOs.Request.Atualizacao;
using Sgb.Application.DTOs.Response;
using Sgb.Domain.Interfaces.Service;
using Sgb.Identity.Constants;

namespace Sgb.Api.Controllers.v1;

[ApiVersion("1.0")]
public class AssociadosController : ApiControllerBase
{
    private IServiceAssociado _serviceAssociado;
    public AssociadosController(IServiceAssociado serviceAssociado) =>    
        _serviceAssociado = serviceAssociado;
       
    //[ClaimsAuthorize(ClaimTypes.Associado, "Ler")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AssociadoResponse>>> ObterTodos()
    {
        var associados = await _serviceAssociado.ObterTodosAsync();
        var associadosResponse = associados.Select(associado => AssociadoResponse.ConverteParaResponse(associado));
        return Ok(associados);
    }
    //[ClaimsAuthorize(ClaimTypes.Associado, "Ler")]
    [HttpGet("{id}")]
    public async Task<ActionResult<AssociadoResponse>> ObterPorId(Guid id)
    {
        var associado = await _serviceAssociado.ObterPorIdAsync(id);

        if (associado is null)
            return NotFound("Dados inválidos, verifique e tente novamente.");
        var associadoResponse = AssociadoResponse.ConverteParaResponse(associado);
        return Ok(associadoResponse);
    }
    //[ClaimsAuthorizeAttribute(ClaimTypes.Associado, "Inserir")]
    [HttpPost]
    public async Task<ActionResult<Guid>> Inserir(InsercaoAssociadoRequest associadoRequest)
    {
        if (associadoRequest == null)
            return BadRequest("Dados Inválidos");

        var associado = InsercaoAssociadoRequest.ConverterParaEntidade(associadoRequest);
        await _serviceAssociado.AdicionarAsync(associado);

        return Ok(associado);
    }  
    //[ClaimsAuthorizeAttribute(ClaimTypes.Associado, "Atualizar")]
    [HttpPut]
    public async Task<ActionResult> Atualizar(AtualizacaoAssociadoRequest associadoRequest)
    {
        var produto = AtualizacaoAssociadoRequest.ConverterParaEntidade(associadoRequest);
        await _serviceAssociado.AtualizarAsync(produto);
        return Ok(produto);
    }
    [Authorize(Policy = Policies.HorarioComercial)]
    //[ClaimsAuthorizeAttribute(ClaimTypes.Associado, "Excluir")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Excluir(Guid id)
    {
        await _serviceAssociado.RemoverPorIdAsync(id);
        return Ok();
    }
}
