using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// Gives a welcome message.
        /// </summary>
        /// <returns>
        /// A return message "Welcome to 5125!"
        /// </returns>
        /// <example>
        /// GET : 'https://localhost:7262/api/Values' -> Welcome to 5125
        /// Result: "Welcome to 5125!"
        /// </example>

        [HttpGet]
        public string Welcome()
        {
            return ("Welcome to 5125");
        }
        /// <summary>
        /// This summary will give your name and it will greet you with that
        /// </summary>
        /// <param name="FName"></param>
        /// <return>
        /// "Greetings to {FName}", where {FName} is an input string
        /// </return>
        /// <example>
        /// GET 'https://localhost:7262/api/Values/Welcome1?FName=Fenil'
        /// Reslut : "Hi Fenil!"

        [HttpGet(template: "Welcome1")]
        public string Welcome1(string FName)
        {
            string message = "Hi " + FName + "!";
            return message;
        
        }

        /// <summary>
        /// Calculate the cube for given number.
        /// </summary>
        /// <param name="Cube_Num">Help to calculate cube</param>
        /// <return>
        /// The cube of the number 
        /// </return>
        /// <example>
        /// 'GET'https://localhost:7262/api/Values/Cube?Cube_Num=50
        /// result = 12500
        /// </example>

        [HttpGet(template: "Cube")]
        public int Cube(int Cube_Num)
        {
            int cube = Cube_Num * Cube_Num * Cube_Num;
            return cube;
        }
        /// <summary>
        /// Give the result of a knock-knock joke.
        /// </summary>
        /// <returns>
        /// A string "Who’s there?"
        /// </returns>
        /// <example>
        /// 'POST'https://localhost:7262/api/Values/template = Joke'
        /// Result: "Who’s there?"
        /// </example>

        [HttpPost("template = Joke")]
        public string Joke()
        {
            return ("Who's there?");
        }


        /// <summary>
        /// Give the result of secret integer.
        /// </summary>
        /// <param name="secret_integer">The confidential integer included in the request body.
        /// </param>
        /// <returns>
        /// A string message result the secret_integer.
        /// </returns>
        /// <example>
        /// 'POST' \'https://localhost:7262/api/Values/template = integer?secret_integer=12'
        /// Request : 12
        /// Result  : "Shh.. the secret is 12"

        [HttpPost("template = integer")]
        public string integer(int secret_integer)
        {
            string message = ("Shh.. the secret is " + secret_integer);
            return message;
        }

        /// <summary>
        /// Computes the area of a regular hexagon based on the provided side length
        /// </summary>
        /// <param name="Hexagon">"The hexagon's side length must be greater than 0.".
        /// </param>
        /// <returns>
        /// The area of the hexagon is double.
        /// </returns>
        /// <example>
        /// 'GET' \''https://localhost:7262/api/Values/template = hexagon?Hexagon=2'
        /// Result: 10.392304845413264
        /// </example>

        [HttpGet("template = hexagon")]
        public double hexagon(double Hexagon)
        {
            double square = (3 * Math.Sqrt(3) / 2) * Math.Pow(Hexagon, 2);
            return square;
        }

        /// <summary>
        /// Result will give a current date
        /// </summary>
        /// <param name="current_days">the days.</param>
        /// <returns>A string result will in these format yyyy-MM-dd format.</returns>
        /// <example>
        /// 'GET' \'https://localhost:7262/api/Values/template = days?days=5'
        /// Result: 2025-02-01
        /// </example>

        [HttpGet("template = days")]
        public string days(int days)
        {
            DateTime format = DateTime.Today.AddDays(days);
            return (format.ToString("yyyy-MM-dd"));
        }

        /// <summary>
        /// Calculates the Bill of SquashFellows plushies.
        /// </summary>
        /// <param name="Small">The msall is number of small plushies.</param>
        /// <param name="Large">The large is number of  plushies.</param>
        /// <returns>
        /// It returns order details,subtotal,total and tax.
        /// </returns>
        /// <example>
        /// POST http://localhost:5000/api/q8/squashfellows
        /// Request Body: Small=1&Large=1
        /// Response: "1 Small @ $25.50 = $25.50; 1 Large @ $40.50 = $40.50; Subtotal = $66.00; Tax = $8.58 HST; Total = $74.58"
        /// </example>

        //[HttpPost("template = SquashFellows")]
        //public string SquahFellows([FromForm] int Small, [FromForm] int Large)
        {
            [HttpPost("template = squashfellows")]
            public string SquashFellows([FromForm] int Small, [FromForm] int Large)
        {
            double smallPrice = 25.50;
            double largePrice = 40.50;
            double HST = 0.13;

            double smallTotal = Small * smallPrice;
            double largeTotal = Large * largePrice;
            double subtotal = smallTotal + largeTotal;
            double tax = Math.Round(subtotal * HST, 2);
            double total = Math.Round(subtotal + tax, 2);

            return $"{Small} Small @ ${smallPrice} = ${smallTotal:F2}; " +
                   $"{Large} Large @ ${largePrice} = ${largeTotal:F2}; " +
                   $"Subtotal = ${subtotal:F2}; " +
                   $"Tax = ${tax:F2} HST; " +
                   $"Total = ${total:F2}";
        }
    }



