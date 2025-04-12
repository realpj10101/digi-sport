using api.Controllers.Helpers;
using api.DTOs;
using api.Interfaces;
using api.Models;
using api.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace api.Controllers;

public class UserController(IUserRepository userRepository) : BaseApiController
{
    [HttpPost("register")] // List<AppUser> appUsers = await _collection.Find(new BsonDocument()).ToListAsync(cancellationToken);
    public async Task<ActionResult<LoggedInDto>> Register(AppUser userInput, CancellationToken cancellationToken)
    {
        if (userInput.Password != userInput.ConfirmPassword)
            return BadRequest("Your passwords do not match!");

        LoggedInDto? loggedInDto = await userRepository.RegisterAsync(userInput, cancellationToken);

        if (loggedInDto is null)
            return BadRequest("This email is already taken.");

        return Ok(loggedInDto);
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoggedInDto>> Login(LoginDto userInput, CancellationToken cancellationToken)
    {
        LoggedInDto? loggedInDto = await userRepository.LoginAsync(userInput, cancellationToken);
        
        if (loggedInDto is null)
            return BadRequest("Invalid Credentials.");

        return loggedInDto;
    }
}



















// [HttpPost("register")]
    // public async Task<ActionResult<LoggedInDto>> Create(Customer customerInput, CancellationToken cancellationToken)
    // {
    //     LoggedInDto? loggedInDto = await _customerRepository.CreateAsync(customerInput, cancellationToken);
    //     
    //     if (loggedInDto is null)
    //         return BadRequest("Email has already been registered");
    //
    //     return loggedInDto;
    // }


    // [HttpGet]
    // public ActionResult<List<LoggedInDto>> GetAll()
    // {
    //     List<Customer> customers = _collection.Find(new BsonDocument()).ToList();
    //
    //     if (customers.Count == 0)
    //     {
    //         return NoContent();
    //     }

        // LoggedInDto loggedInDto = new(
        //     Name: customers[0].Name,
        //     Age: customers[0].Age
        // );
        //
        // LoggedInDto loggedInDto1 = new(
        //     Name: customers[1].Name,
        //     Age: customers[1].Age
        // );
        //
        // LoggedInDto loggedInDto2 = new(
        //     Name: customers[2].Name,
        //     Age: customers[2].Age
        // );

        // List<LoggedInDto> loggedInDtos = [];
        //
        // foreach (var customer in customers)
        // {
        //     LoggedInDto loggedInDto = new(
        //         Name: customer.Name,
        //         Age: customer.Age
        //     );
        //
        //     loggedInDtos.Add(loggedInDto);
        // }
        //
        // return loggedInDtos;

        // List<MemberDto> memberDtos = [];
        //
        // foreach (Customer customer in customers)
        // {
        //     MemberDto memberDto = new MemberDto(
        //         Name: customer.Name,
        //         Age: customer.Age,
        //         City: customer.City,
        //         Country: customer.Country
        //     );
        //
        //     memberDtos.Add(memberDto);
        // }
        //
        // return memberDtos;
//     }
// }

// // Get / Read
// [HttpGet]
// public ActionResult<List<Customer>> GetAll()
// {
//     List<Customer> customers = _collection.Find(new BsonDocument()).ToList();
//
//     if (customers.Count == 0)
//     {
//         return NoContent();
//     }
//
//     return customers;
// }
//
// [HttpGet("get-by-username/{userInput}")]
// public ActionResult<Customer> GetByUserName(string userInput)
// {
//     Customer customer = _collection.Find(doc => doc.Name == userInput).FirstOrDefault();
//
//     if (customer is null)
//     {
//         return NotFound("Username not found.");
//     }
//     
//     return customer;
// }
//
// // Update / put
// [HttpPut("update/{userId}")]
// public ActionResult<UpdateResult> UpdateUserById(string userId, Customer userInput)
// {
//     UpdateDefinition<Customer> updateCustomer = Builders<Customer>.Update
//         .Set(doc => doc.Email, userInput.Email)
//         .Set(doc => doc.Name, userInput.Name);
//
//     return _collection.UpdateOne(doc => doc.Id == userId, updateCustomer);
// }
//
// [HttpDelete("delete/{userId}")]
// public ActionResult<DeleteResult> DeleteUserById(string userId)
// {
//     Customer customer = _collection.Find(doc => doc.Id == userId).FirstOrDefault();
//
//     if (customer is null)
//     {
//         return NotFound("User not found.");
//     }
//     
//      return _collection.DeleteOne(doc => doc.Id == userId);