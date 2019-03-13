using System;
using Microsoft.AspNetCore.Mvc;
using MatrixCalculation;
using MatrixMultiplication.Model;

namespace MatrixMultiplication.Controllers
{
    [Route("api/Numbers")]
    public class NumbersController : Controller
    {
        private Numbers Numbers { get; set; }
        public NumbersController()
        {
            Numbers = new Numbers();
        }
        private string HD5HashResult { get; set; }


        [Produces("text/plain")]
        [HttpGet("InitMatrix/{size}")]

        public IActionResult InitMatrix(int size)
        {
            try
            {
                if(Numbers.GenerateMartix(size))
                return Ok(size.ToString());
                return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("text/plain")]
        [HttpGet("GetDataset/{dataset}/{type}/{idx}")]

        public IActionResult GetDataset(string dataset, string type, int idx)
        {
            try
            {
                var data = Numbers.ReadMartix();
                return Ok(data);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("text/plain")]
        [HttpGet("Validate/{hash}")]
        public IActionResult Validate(string hash)
        {
            try
            {
                Numbers.ParseMatrix();
                var calc = new Calculation(Numbers.Size, Numbers.MatrixA, Numbers.MatrixB);
                HD5HashResult = calc.MatrixMultiplication();
                var result = HD5HashResult == hash ? "Success" : "Failure";
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }





    }
}