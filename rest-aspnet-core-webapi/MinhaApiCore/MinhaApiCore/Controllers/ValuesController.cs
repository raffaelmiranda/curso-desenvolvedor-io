using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MinhaApiCore.Controllers
{
    [Route("api/[controller]")]
    //[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
    public class ValuesController : MainController
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> ObterTodos() 
        {
            //ActionResult tipado pode retornar tanto um tipo de Result como algum valor
            var valores = new string[] { "value1", "value2" };

            if (valores.Length < 5000)
            {
                return BadRequest();
            }

            return valores;
        }


        [HttpGet]
        public ActionResult ObterResultado()
        {
            //ActionResult só pode devolver Result
            var valores = new string[] { "value1", "value2" };

            if (valores.Length < 5000)
            {
                return CustomResponse();
            }

            return CustomResponse(valores);
        }

        [HttpGet("obter-valores")]
        public IEnumerable<string> ObterValores()
        {
            //Só pode retornar dados tipados e nunca um Result
            var valores = new string[] { "value1", "value2" };

            if (valores.Length < 5000)
            {
                return null;
            }

            return valores;
        }

        // GET api/values/obter-por-id/5
        [HttpGet("obter-por-id/{id:int}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        //[ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesDefaultResponseType]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))] //As Conveções substituem os ProducesResponseType
        public ActionResult Post(Product product)
        {
            //ProducesResponseType: tipo de dados que a Action produz para
            //questão de documentação
            if (product.Id == 0)
            {
                return BadRequest();
            }

            //return Ok(product); //retorna um status code 200 mas no atributo diz que retorna 201
            return CreatedAtAction(nameof(Post), product); // retorna status code 201
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        //[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public ActionResult Put([FromRoute]int id, [FromForm]Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (id != product.Id)
                return NotFound();

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete([FromQuery]int id)
        {
        }
    }

    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    sucess = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                sucess = false,
                error = ObterErros()
            });
        }

        public bool OperacaoValida()
        {
            return true;
        }

        protected string ObterErros()
        {
            return "";
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
