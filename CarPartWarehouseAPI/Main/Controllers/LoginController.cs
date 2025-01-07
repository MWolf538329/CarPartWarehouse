using Logic.Interfaces;
using Logic.Services;
using DAL.DALServices;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace CarPartWarehouseAPI.Controllers;

/// <summary>
/// 
/// </summary>
[Route("/login")]
[ApiController]
public class LoginController : ControllerBase
{
    /// <summary>
    /// Login
    /// </summary>
    /// <param name="databaseContext"></param>
    /// <param name="username">Username</param>
    /// <param name="password">Password</param>
    /// <returns>HTTP response code</returns>
    /// <response code="201">Login was successful.</response>
    /// <response code="400">Bad Request: Username and/or Password are invalid.</response>
    /// <response code="404">Not Found</response>
    [HttpPost("/login/login")]
    public ActionResult Login(DatabaseContext databaseContext, string username, string password)
    {
        ILoginDAL loginDAL = new LoginDAL(databaseContext);
        LoginService loginService = new(loginDAL);

        if (string.IsNullOrWhiteSpace(username))
        {
            return BadRequest("Username can not be empty!");
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            return BadRequest("Password can not be empty!");
        }

        bool success = loginService.Login(username, password);
        if (success)
        {
            return Created();
        }

        return NotFound();
    }

    /// <summary>
    /// Login
    /// </summary>
    /// <param name="databaseContext"></param>
    /// <param name="username">Username</param>
    /// <param name="password">Password</param>
    /// <returns>HTTP response code</returns>
    /// <response code="201">Login was successful.</response>
    /// <response code="400">Bad Request: Username and/or Password are invalid.</response>
    /// <response code="400">Bad Request: User could not be created.</response>
    /// <response code="404">Not Found</response>
    [HttpPost("/login/register")]
    public ActionResult Register(DatabaseContext databaseContext, string username, string password)
    {
        ILoginDAL loginDAL = new LoginDAL(databaseContext);
        LoginService loginService = new(loginDAL);

        if (string.IsNullOrWhiteSpace(username))
        {
            return BadRequest("Username can not be empty!");
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            return BadRequest("Password can not be empty!");
        }

        bool success = loginService.Register(username, password);
        if (success)
        {
            return Created();
        }

        return BadRequest("User could not be created!");
    }
}