using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

//tag for basic api functionality
[ApiController]
//tag for controller route
[Route("[controller]")]
public class UserController : ControllerBase
{
  DataContextDapper _dapper;
  public UserController(IConfiguration config)
  {
    _dapper = new DataContextDapper(config);
  }

  [HttpGet("TestConnection")]

  public DateTime TestConnection()
  {
    return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
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

