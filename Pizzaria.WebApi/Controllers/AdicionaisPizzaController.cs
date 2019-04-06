using Microsoft.AspNetCore.Mvc;
using Pizzaria.Application.ViewModels;
using Pizzaria.Application.Services.Interfaces;

namespace Pizzaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdicionaisPizzaController : ApiController
    {
        private readonly IAdicionaisPizzaService _adicionaisPizzaService;

        public AdicionaisPizzaController(IAdicionaisPizzaService adicionaisPizzaService) : base()
        {
            _adicionaisPizzaService = adicionaisPizzaService;
        }

        // GET: api/AdicionaisPizza
        [HttpGet]
        public IActionResult GetAdicionaisPizzaViewModel()
        {
            return Response(_adicionaisPizzaService.GetAll());
        }

        // GET: api/AdicionaisPizza/5
        [HttpGet("{id}")]
        public IActionResult GetAdicionaisPizzaViewModel(int id)
        {
            var viewModel = _adicionaisPizzaService.GetById(id);

            return Response(viewModel);
        }

        // PUT: api/Livro/5
        [HttpPut("{id}")]
        public IActionResult PutAdicionaisPizzaViewModel(int id, [FromBody]AdicionaisPizzaViewModel adicionaisPizzaViewModel)
        {
            if (!ModelState.IsValid)
                return Response(adicionaisPizzaViewModel);

            var adicionaisPizzaViewModelAtual = _adicionaisPizzaService.GetById(id);
            if (adicionaisPizzaViewModelAtual == null)
                return new NotFoundObjectResult($"Não existe adicional de pizza cadastrado com o identificador {id}!");           

            _adicionaisPizzaService.Update(adicionaisPizzaViewModel);

            return Response(adicionaisPizzaViewModel);
        }

        // POST: api/AdicionaisPizza
        [HttpPost]
        public IActionResult PostAdicionaisPizzaViewModel(AdicionaisPizzaViewModel AdicionaisPizzaViewModel)
        {
            if (!ModelState.IsValid)
                return Response(AdicionaisPizzaViewModel);

            _adicionaisPizzaService.Add(AdicionaisPizzaViewModel);

            return Response(AdicionaisPizzaViewModel);
        }

        // DELETE: api/AdicionaisPizza/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAdicionaisPizzaViewModel(int id)
        {
            _adicionaisPizzaService.Delete(id);

            return Response();
        }
    }
}