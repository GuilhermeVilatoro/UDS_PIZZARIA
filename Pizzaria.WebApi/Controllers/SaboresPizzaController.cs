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
        public IActionResult PutSaboresPizzaViewModel([FromBody]SaboresPizzaViewModel saboresPizzaViewModel)
        {
            if (!ModelState.IsValid)
                return Response(saboresPizzaViewModel);

            _saboresPizzaService.Update(saboresPizzaViewModel);

            return Response(saboresPizzaViewModel);
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

        // DELETE: api/SaboresPizza/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSaboresPizzaViewModel(int id)
        {
            _saboresPizzaService.Delete(id);

            return Response();
        }
    }
}