using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected List<string> users = new List<string>();

    protected IActionResult GetAll(string entityName)
    {
        var data = new List<string> { $"{entityName}1", $"{entityName}2", $"{entityName}3" };
        return Ok(data);
    }

    protected IActionResult GetById(int id, string entityName)
    {
        var data = $"{entityName}{id}";
        return Ok(data);
    }

    protected IActionResult Create(string entity, string actionName)
    {
        return CreatedAtAction(actionName, new { id = 1 }, entity);
    }
    // Adds a user to the list
    public void AddUser(string user)
    {
        if (string.IsNullOrEmpty(user))
        {
            throw new ArgumentException("User cannot be null or empty");
        }
        users.Add(user);
    }

    // Removes a user from the list
    public void RemoveUser(string user)
    {
        if (string.IsNullOrEmpty(user))
        {
            throw new ArgumentException("User cannot be null or empty");
        }
        users.Remove(user);
    }

    // Retrieves all users
    public List<string> GetAllUsers()
    {
        return new List<string>(users);
    }
}

