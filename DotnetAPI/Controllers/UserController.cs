using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

//tag for basic api functionality
[ApiController]
//tag for controller route
[Route("[controller]")]
public class UserController : ControllerBase
{
  public UserController()
  {

  }

  [HttpGet("GetUsers/{testValue}")]

  public string[] GetUsers(string testValue)
  {
    string[] responseArray = new string[] {
      "hello",
      "world",
      testValue
    };

    return responseArray;
  }


}

