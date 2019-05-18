using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/{controller}")]
    public class CalculationController : ControllerBase
    {

        [HttpGet("add")]
        public double Add([FromQuery]double value1, [FromQuery]double value2)
        {
            return value1 + value2;
        }

        [HttpGet("sub/a/{value1}/b/{valeu2}")]
        public double Sub([FromRoute]double value1, [FromRoute]double valeu2)
        {

            return valeu2 - value1;

        }

        [HttpPost("mult")]
        public double Mult([FromBody] CalculationParamenter mat)
        {
            return mat.Value1 * mat.Value2;
        }


        [HttpPost("div")]
        public double Div([FromForm]CalculationParamenter mat){
            return mat.Value1 / mat.Value2;
        }
    }
}