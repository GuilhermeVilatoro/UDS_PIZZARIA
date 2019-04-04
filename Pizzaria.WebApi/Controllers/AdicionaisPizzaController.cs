using Microsoft.AspNetCore.Mvc;
using Pizzaria.Application.Services;
using Pizzaria.Application.ViewModels;

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

        // PUT: api/AdicionaisPizza/5
        [HttpPut("{id}")]
        public IActionResult PutAdicionaisPizzaViewModel([FromBody]AdicionaisPizzaViewModel adicionaisPizzaViewModel)
        {
            if (!ModelState.IsValid)
                return Response(adicionaisPizzaViewModel);

            _adicionaisPizzaService.Update(adicionaisPizzaViewModel);

            return Response(adicionaisPizzaViewModel);
        }

        // POST: api/AdicionaisPizza
        [HttpPost]
        public IActionResult PostAdicionaisPizzaViewModel(AdicionaisPizzaViewModel adicionaisPizzaViewModel)
        {
            if (!ModelState.IsValid)
                return Response(adicionaisPizzaViewModel);

            _adicionaisPizzaService.Add(adicionaisPizzaViewModel);

            return Response(adicionaisPizzaViewModel);
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