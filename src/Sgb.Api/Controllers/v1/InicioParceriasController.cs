using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sgb.Api.Controllers.Shared;
using Sgb.Application.DTOs.Request;
using Sgb.Application.DTOs.Request.Atualizacao;
using Sgb.Application.DTOs.Response;
using Sgb.Domain.Interfaces.Service;
using Sgb.Identity.Constants;

namespace Sgb.Api.Controllers.v1;

[ApiVersion("1.0")]
public class InicioParceriasController : ApiControllerBase
{
    private IServiceInicioParceria _parceriaService;

    public InicioParceriasController(IServiceInicioParceria parceriaService) =>
        _parceriaService = parceriaService;
    
    //[ClaimsAuthorize(ClaimTypes.InicioParceria, "Ler")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InicioParceriaResponse>>> ObterTodos()
    {
        var parcerias = await _parceriaService.ObterTodosAsync();
        var parceriasResponse = parcerias.Select(parceria => InicioParceriaResponse.ConverteParaResponse(parceria));
        return Ok(parceriasResponse);
    }
    //[ClaimsAuthorize(ClaimTypes.InicioParceria, "Ler")]
    [HttpGet("{id}")]
    public async Task<ActionResult<InicioParceriaResponse>> ObterPorId(Guid id)
    {
        var parcerias = await _parceriaService.ObterPorIdAsync(id);

        if (parcerias is null)
            return NotFound();

        var parceriasResponse = InicioParceriaResponse.ConverteParaResponse(parcerias);
        return Ok(parceriasResponse);
    }
    //[ClaimsAuthorizeAttribute(ClaimTypes.InicioParceria, "Inserir")]
    [HttpPost]
    public async Task<ActionResult<Guid>> Inserir(InsercaoInicioParceriaRequest insercaoparceria)
    {
        if (insercaoparceria == null)
            return BadRequest("Dados Inválidos");

        var parceria = InsercaoInicioParceriaRequest.ConverterParaEntidade(insercaoparceria);            
        await _parceriaService.AdicionarAsync(parceria);
        return Ok(parceria);
    }
    //[ClaimsAuthorizeAttribute(ClaimTypes.InicioParceria, "Atualizar")]
    [HttpPut]
    public async Task<ActionResult> Atualizar(AtualizacaoInicioParceriaRequest parceriaRequest)
    {
        var parceria = AtualizacaoInicioParceriaRequest.ConverterParaEntidade(parceriaRequest);
        await _parceriaService.AtualizarAsync(parceria);
        return RedirectToAction("ObterTodos");
    }
    [Authorize(Policy = Policies.HorarioComercial)]
    //[ClaimsAuthorizeAttribute(ClaimTypes.InicioParceria, "Excluir")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Excluir(Guid id)
    {
        await _parceriaService.RemoverPorIdAsync(id);
        return Ok();
    }
}
