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

[Authorize(Roles = Roles.Admin)]
[ApiVersion("1.0")]
public class CompradorController : ApiControllerBase
{
    protected readonly IServiceComprador _compradorService;
    public CompradorController(IServiceComprador compradorService) =>
            _compradorService = compradorService;

    [ClaimsAuthorize(ClaimTypes.Comprador, "Ler")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompradorResponse>>> ObterTodos()
    {
        var compradores = await _compradorService.ObterTodosAsync();
        var compradoresResponse = compradores.Select(comprador => CompradorResponse.ConverteParaResponse(comprador));
        return Ok(compradoresResponse);
    }
    [ClaimsAuthorize(ClaimTypes.Comprador, "Ler")]
    [HttpGet("{id}")]
    public async Task<ActionResult<CompradorResponse>> ObterPorId(Guid id)
    {
        var comprador = await _compradorService.ObterPorIdAsync(id);
        if (comprador is null)
        {
            return NotFound();
        }
        var compradorResponse = CompradorResponse.ConverteParaResponse(comprador);
        return Ok(compradorResponse);
    }
    //public async Task<IActionResult> Inserir()
    //{
    //    return View();
    //}
    [ClaimsAuthorizeAttribute(ClaimTypes.Comprador, "Inserir")]
    [HttpPost]
    public async Task<ActionResult<Guid>> Inserir(InsercaoCompradorRequest compradorRequest)
    {
        var comprador = InsercaoCompradorRequest.ConverterParaEntidade(compradorRequest);
        var id = (Guid)await _compradorService.AdicionarAsync(comprador);
        return CreatedAtAction(nameof(ObterPorId), new { id = id }, id);
    }
    //public async Task<IActionResult> Atualizar(Guid id)
    //{
    //    var comprador = await _compradorService.ObterPorIdAsync(id);
    //    return Ok(comprador);
    //}
    [ClaimsAuthorizeAttribute(ClaimTypes.Comprador, "Atualizar")]
    [HttpPut]
    public async Task<ActionResult> Atualizar(AtualizacaoCompradorRequest atualizarComprador)
    {
        var comprador = AtualizacaoCompradorRequest.ConverterParaEntidade(atualizarComprador);
        await _compradorService.AtualizarAsync(comprador);
        return Ok();
    }
    [Authorize(Policy = Policies.HorarioComercial)]
    [ClaimsAuthorizeAttribute(ClaimTypes.Comprador, "Excluir")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Excluir(Guid id)
    {
        await _compradorService.RemoverPorIdAsync(id);
        return Ok();
    }
}
