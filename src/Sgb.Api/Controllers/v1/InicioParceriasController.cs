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
public class InicioParceriasController : ApiControllerBase
{
    private IServiceInicioParceria _parceriaService;

    public InicioParceriasController(IServiceInicioParceria parceriaService)
    {
        _parceriaService = parceriaService;
    }

    [ClaimsAuthorize(ClaimTypes.InicioParceria, "Ler")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InicioParceriaResponse>>> ObterTodos()
    {
        var parcerias = await _parceriaService.ObterTodosAsync();
        var parceriasResponse = parcerias.Select(parceria => InicioParceriaResponse.ConverteParaResponse(parceria));
        return Ok(parceriasResponse);
    }
    [ClaimsAuthorize(ClaimTypes.InicioParceria, "Ler")]
    [HttpGet("{id}")]
    public async Task<ActionResult<InicioParceriaResponse>> ObterPorId(Guid id)
    {
        var parcerias = await _parceriaService.ObterPorIdAsync(id);

        if (parcerias is null)
            return NotFound();

        var parceriasResponse = InicioParceriaResponse.ConverteParaResponse(parcerias);
        return Ok(parceriasResponse);
    }
    //public async Task<IActionResult> Inserir(Guid id)
    //{
    //    var cp = (from comp in _context.Compradores
    //              select new SelectListItem()
    //              {
    //                  Text = comp.Nome,
    //                  Value = comp.CadastroId.ToString()
    //              }).ToList();
    //    cp.Insert(0, new SelectListItem()
    //    {
    //        Text = "---Selecione---",
    //        Value = string.Empty
    //    });
    //    ViewBag.selectComprador = cp;

    //    var asp = (from assoc in _context.Associados
    //               select new SelectListItem()
    //               {
    //                   Text = assoc.Nome,
    //                   Value = assoc.CadastroId.ToString()
    //               }).ToList();
    //    asp.Insert(0, new SelectListItem()
    //    {
    //        Text = "---Selecione---",
    //        Value = string.Empty
    //    });
    //    ViewBag.selectAssociado = asp;

    //    var classf = Enum.GetValues(typeof(Classificacao))
    //     .Cast<Classificacao>()
    //     .Select(v => new SelectListItem
    //     {
    //         Text = v.ToString(),
    //         Value = ((int)v).ToString(),
    //     }).ToList();
    //    classf.Insert(0, new SelectListItem()
    //    {
    //        Text = "---Selecionar---",
    //        Value = string.Empty.ToString(),
    //    });
    //    ViewData["Classificacao"] = classf;

    //    var compraV = Enum.GetValues(typeof(CompraVenda))
    //        .Cast<CompraVenda>()
    //        .Select(c => new SelectListItem
    //        {
    //            Text = c.ToString(),
    //            Value = ((int)c).ToString()
    //        }).ToList();
    //    compraV.Insert(0, new SelectListItem()
    //    {
    //        Text = "---Selecionar---",
    //        Value = string.Empty.ToString(),
    //    });
    //    ViewData["CompraVenda"] = compraV;
        
    //    return View();
    //}
    [ClaimsAuthorizeAttribute(ClaimTypes.InicioParceria, "Inserir")]
    [HttpPost]
    public async Task<ActionResult<Guid>> Inserir(InsercaoInicioParceriaRequest insercaoparceria)
    {
        var parceria = InsercaoInicioParceriaRequest.ConverterParaEntidade(insercaoparceria);            
        var id = (Guid)await _parceriaService.AdicionarAsync(parceria);
        return CreatedAtAction(nameof(ObterPorId), new { id = id }, id);
    }
    //public async Task<IActionResult> Atualizar(Guid id)
    //{
    //    var cp = (from comp in _context.Compradores
    //              select new SelectListItem()
    //              {
    //                  Text = comp.Nome,
    //                  Value = comp.CadastroId.ToString()
    //              }).ToList();
    //    cp.Insert(0, new SelectListItem()
    //    {
    //        Text = "---Selecione---",
    //        Value = string.Empty
    //    });
    //    ViewBag.selectComprador = cp;
    //    var asp = (from assoc in _context.Associados
    //               select new SelectListItem()
    //               {
    //                   Text = assoc.Nome,
    //                   Value = assoc.CadastroId.ToString()
    //               }).ToList();
    //    asp.Insert(0, new SelectListItem()
    //    {
    //        Text = "---Selecione---",
    //        Value = string.Empty
    //    });
    //    ViewBag.selectAssociado = asp;

    //    var classf = Enum.GetValues(typeof(Classificacao))
    //     .Cast<Classificacao>()
    //     .Select(v => new SelectListItem
    //     {
    //         Text = v.ToString(),
    //         Value = ((int)v).ToString(),
    //     }).ToList();
    //    classf.Insert(0, new SelectListItem()
    //    {
    //        Text = "---Selecionar---",
    //        Value = string.Empty.ToString(),
    //    });
    //    ViewData["Classificacao"] = classf;

    //    var compraV = Enum.GetValues(typeof(CompraVenda))
    //        .Cast<CompraVenda>()
    //        .Select(c => new SelectListItem
    //        {
    //            Text = c.ToString(),
    //            Value = ((int)c).ToString()
    //        }).ToList();
    //    compraV.Insert(0, new SelectListItem()
    //    {
    //        Text = "---Selecionar---",
    //        Value = string.Empty.ToString(),
    //    });
    //    ViewData["CompraVenda"] = compraV;

    //    var parceria = await _parceriaService.ObterPorIdAsync(id);
    //    return View(parceria);
    //}
    [ClaimsAuthorizeAttribute(ClaimTypes.InicioParceria, "Atualizar")]
    [HttpPut]
    public async Task<ActionResult> Atualizar(AtualizacaoInicioParceriaRequest parceriaRequest)
    {
        var parceria = AtualizacaoInicioParceriaRequest.ConverterParaEntidade(parceriaRequest);
        await _parceriaService.AtualizarAsync(parceria);
        return RedirectToAction("ObterTodos");
    }
    [Authorize(Policy = Policies.HorarioComercial)]
    [ClaimsAuthorizeAttribute(ClaimTypes.InicioParceria, "Excluir")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Excluir(Guid id)
    {
        await _parceriaService.RemoverPorIdAsync(id);
        return Ok();
    }
}
