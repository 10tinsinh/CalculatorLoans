using CalculatorLoans.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorLoans.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        [HttpGet("GetLoans")]
        public IActionResult GetLoans(int tientrathang, double laixuat, double tongtienvay)
        {
            var vay = new Laivay();
            vay.tientrathang = tientrathang;
            vay.tongtienvay = tongtienvay;
            vay.laixuat = laixuat;
            int thangtinh = 0;
            double tongtienlai =0;
            List<Response> result = new List<Response>(); 
            while(vay.tongtienvay >= vay.tientrathang)
            {
                thangtinh += 1;
                double laithang = (vay.tongtienvay * vay.laixuat) / 100;
                double tientragoc = vay.tientrathang - laithang;
                vay.tongtienvay = vay.tongtienvay - tientragoc;
                tongtienlai += laithang;

                var result1 = new Response
                {
                    thang = thangtinh.ToString(),
                    lai = Math.Round(laithang,2),
                    tientrathang = vay.tientrathang,
                    tientragoc = Math.Round(tientragoc,2),
                    tongtiengoc = Math.Round(vay.tongtienvay,2),
                    tongtienlai = Math.Round(tongtienlai)

                };
                result.Add(result1);


            }
            return Ok(result.ToList());

        }

        
    }
}
