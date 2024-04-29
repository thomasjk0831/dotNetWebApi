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
  [HttpGet("GetUsers")]

  public IEnumerable<User> GetUsers()
  {
    string sql = @"
    SELECT [UserId],
    [FirstName],
    [LastName],
    [Email],
    [Gender],
    [Active] 
    FROM TutorialAppSchema.Users
    ";
    return _dapper.LoadData<User>(sql);
  }

  [HttpGet("GetUser/{userId}")]

  public User GetUser(int userId)
  {
    string sql = @"
    SELECT [UserId],
    [FirstName],
    [LastName],
    [Email],
    [Gender],
    [Active] 
    FROM TutorialAppSchema.Users
    WHERE UserId = " + userId.ToString();

    return _dapper.LoadDataSingle<User>(sql);
  }

  [HttpPut("EditUser")]

  public IActionResult EditUser(User user)
  {
    string sql = @"
    UPDATE TutorialAppSchema.Users 
    SET [FirstName] = '" + user.FirstName +
    "', [LastName] = '" + user.LastName +
    "', [Email] = '" + user.Email +
    "', [Gender] = '" + user.Gender +
    "', [Active] = '" + user.Active +
    "' WHERE UserId = " + user.UserId.ToString();

    if (_dapper.ExecuteSql(sql))
    {
      return Ok();
    }

    throw new Exception("Failed to update User");

  }

  [HttpPost("AddUser")]

  public IActionResult AddUser(UserToAdd user)
  {
    string sql = @"
    INSERT INTO TutorialAppSchema.Users (
      [FirstName],
      [LastName],
      [Email],
      [Gender],
      [Active] ) 
          VALUES (
           '" + user.FirstName +
          "', '" + user.LastName +
          "', '" + user.Email +
          "', '" + user.Gender +
          "', '" + user.Active +
          "')";

    if (_dapper.ExecuteSql(sql))
    {
      return Ok();
    }

    throw new Exception("Failed to add User");
  }
}

