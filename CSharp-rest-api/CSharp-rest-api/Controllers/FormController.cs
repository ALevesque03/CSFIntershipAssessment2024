using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

namespace CSharp_rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly FormService service = new FormService();

        [HttpGet]
        public async Task<ActionResult<List<Form>>> Get()
        {
            try
            {
                List<Form> forms = await service.GetForms();

                return forms;
            }
            catch (Exception ex)
            {
                return Problem(title: "An internal error has occured. Please contact the system admin");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Form>> Get(int? id = null)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                Form form = await service.GetForm(id);

                return form;
            }
            catch (Exception ex)
            {
                return Problem(title: "An internal error has occured or record you are trying to retrieve does not exist. Please contact the system admin");
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(string? name = null, int owned = 0, bool goodPet = false)
        {
            try
            {
                if (name == null)
                {
                    return Problem(title: "A name must be provided");
                }
                Form form = new Form { Name = name, Owned = owned, GoodPet = goodPet };
                Form createdForm = await service.CreateForm(form);

                return createdForm.FormId;
            }
            catch (Exception ex)
            {
                return Problem(title: $"An internal error has occured or record you are trying to retrieve does not exist. {ex}");
            }
        }
    }
}
