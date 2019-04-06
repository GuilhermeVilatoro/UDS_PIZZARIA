using Microsoft.AspNetCore.Mvc;
using Pizzaria.Application.Services;
using Pizzaria.Application.ViewModels;

namespace Pizzaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TamanhosPizzaController : ApiController
    {
        private readonly ITamanhosPizzaService _tamanhosPizzaService;

        public TamanhosPizzaController(ITamanhosPizzaService tamanhosPizzaService) : base()
        {
            _tamanhosPizzaService = tamanhosPizzaService;
        }

        // GET: api/TamanhosPizza
        [HttpGet]
        public IActionResult GetTamanhosPizzaViewModel()
        {
            return Response(_tamanhosPizzaService.GetAll());
        }

        // GET: api/TamanhosPizza/5
        [HttpGet("{id}")]
        public IActionResult GetTamanhosPizzaViewModel(int id)
        {
            var viewModel = _tamanhosPizzaService.GetById(id);

            return Response(viewModel);
        }

        // PUT: api/TamanhosPizza/5
        [HttpPut("{id}")]
        public IActionResult PutTamanhosPizzaViewModel(int id, [FromBody]TamanhosPizzaViewModel tamanhosPizzaViewModel)
        {
            if (!ModelState.IsValid)
                return Response(tamanhosPizzaViewModel);

            var tamanhosPizzaViewModelAtual = _tamanhosPizzaService.GetById(id);
            if (tamanhosPizzaViewModelAtual == null)
                return new NotFoundObjectResult($"Não existe tamanho cadastrado com o identificador {id}!");

            _tamanhosPizzaService.Update(tamanhosPizzaViewModelAtual);

            return Response(tamanhosPizzaViewModelAtual);
        }

        // POST: api/TamanhosPizza
        [HttpPost]
        public IActionResult PostTamanhosPizzaViewModel(TamanhosPizzaViewModel tamanhosPizzaViewModel)
        {
            if (!ModelState.IsValid)
                return Response(tamanhosPizzaViewModel);

            _tamanhosPizzaService.Add(tamanhosPizzaViewModel);

            return Response(tamanhosPizzaViewModel);
        }

        // DELETE: api/TamanhosPizza/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTamanhosPizzaViewModel(int id)
        {
            _tamanhosPizzaService.Delete(id);

            return Response();
        }
    }
}