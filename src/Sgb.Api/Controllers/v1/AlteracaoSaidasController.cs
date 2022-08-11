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
public class AlteracaoSaidasController : ApiControllerBase
{
    private IServiceAlteracaoSaida _saidaService;

    public AlteracaoSaidasController(IServiceAlteracaoSaida saidaService) =>    
        _saidaService = saidaService;
    

    //[ClaimsAuthorize(ClaimTypes.AlteracaoSaida, "Ler")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AlteracaoSaidaResponse>>> ObterTodos()
    {
        var saidas = await _saidaService.ObterTodosAsync();
        var saidasResponse = saidas.Select(saida => AlteracaoSaidaResponse.ConverteParaResponse(saida));
        return Ok(saidasResponse);
    }
    //[ClaimsAuthorize(ClaimTypes.AlteracaoSaida, "Ler")]
    [HttpGet("{id}")]
    public async Task<ActionResult<AlteracaoSaidaResponse>> ObterPorId(Guid id)
    {
        var saida = await _saidaService.ObterPorIdAsync(id);
        
        if (saida is null)
            return NotFound("Dados inválidos, verifique e tente novamente.");

        var saidaResponse = AlteracaoSaidaResponse.ConverteParaResponse(saida);
        return Ok(saidaResponse);
    }
    [ClaimsAuthorizeAttribute(ClaimTypes.AlteracaoSaida, "Inserir")]
    [HttpPost]
    public async Task<ActionResult<Guid>> Inserir(InsercaoAlteracaoSaidaRequest saidaRequest)
    {
        var saida = InsercaoAlteracaoSaidaRequest.ConverterParaEntidade(saidaRequest);
         await _saidaService.AdicionarAsync(saida);
        return Ok(saida);
    }
    //[ClaimsAuthorizeAttribute(ClaimTypes.AlteracaoSaida, "Atualizar")]
    [HttpPut]
    public async Task<ActionResult> Atualizar(AtualizacaoAlteracaoSaidaRequest saidaRequest)
    {
        var saida = AtualizacaoAlteracaoSaidaRequest.ConverterParaEntidade(saidaRequest);
        await _saidaService.AtualizarAsync(saida);
        return Ok(saida);
    }
    [Authorize(Policy = Policies.HorarioComercial)]
    //[ClaimsAuthorizeAttribute(ClaimTypes.AlteracaoSaida, "Excluir")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Excluir(Guid id)
    {
        await _saidaService.RemoverPorIdAsync(id);
        return Ok();
    }
}
