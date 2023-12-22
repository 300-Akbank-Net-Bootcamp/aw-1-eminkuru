using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace VbApi.Controllers;

public class Staff
{
   
    public string? Name { get; set; }

  
    public string? Email { get; set; }

   
    public string? Phone { get; set; }

    public decimal? HourlySalary { get; set; }
}

[Route("api/[controller]")]
[ApiController]
public class StaffController : ControllerBase
{
    public StaffController()
    {
    }

    [HttpPost]
    public Staff Post([FromBody] Staff value)
    {
        return value;
    }
}