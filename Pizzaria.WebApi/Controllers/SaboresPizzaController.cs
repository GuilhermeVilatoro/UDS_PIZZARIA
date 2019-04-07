using Microsoft.AspNetCore.Mvc;
using Pizzaria.Application.ViewModels;
using Pizzaria.Application.Services;

namespace Pizzaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaboresPizzaController : ApiController
    {
        private readonly ISaboresPizzaService _saboresPizzaService;

        public SaboresPizzaController(ISaboresPizzaService saboresPizzaService) : base()
        {
            _saboresPizzaService = saboresPizzaService;
        }

        // GET: api/SaboresPizza
        [HttpGet]
        public IActionResult GetSaboresPizzaViewModel()
        {           
            return Response(_saboresPizzaService.GetAll());
        }

        // GET: api/SaboresPizza/5
        [HttpGet("{id}")]
        public IActionResult GetSaboresPizzaViewModel(int id)
        {
            var viewModel = _saboresPizzaService.GetById(id);

            return Response(viewModel);
        }

        // PUT: api/Livro/5
        [HttpPut("{id}")]
        public IActionResult PutSaboresPizzaViewModel(int id, [FromBody]SaboresPizzaViewModel saboresPizzaViewModel)
        {
            if (!ModelState.IsValid)
                return Response(saboresPizzaViewModel);

            var saboresPizzaViewModelAtual = _saboresPizzaService.GetById(id);
            if (saboresPizzaViewModelAtual == null)
                return new NotFoundObjectResult($"Não existe sabor cadastrado com o identificador {id}!");            

            _saboresPizzaService.Update(saboresPizzaViewModelAtual);

            return Response(saboresPizzaViewModelAtual);
        }

        // POST: api/SaboresPizza
        [HttpPost]
        public IActionResult PostSaboresPizzaViewModel(SaboresPizzaViewModel saboresPizzaViewModel)
        {
            if (!ModelState.IsValid)
                return Response(saboresPizzaViewModel);

            _saboresPizzaService.Add(saboresPizzaViewModel);

            return Response(saboresPizzaViewModel);
        }        
    }
}