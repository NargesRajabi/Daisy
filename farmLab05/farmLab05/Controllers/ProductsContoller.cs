using farmLab05.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace farmLab05.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsContoller: ControllerBase
{
    private readonly IConfiguration _configuration;

    public ProductsContoller(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    [Route("GetAllProducts")]
    public Response GetAllProducts()
    {
        SqlConnection con = new SqlConnection(_configuration.GetConnectionString("FarmCon").ToString());
        Response response = new Response();
        Application apl = new Application();
        response = apl.GetAllProducts(con);
        return response;
    }

    [HttpGet]
    [Route("GetAllProductsByID/{id}")]

    public Response GetAllProductsByID(int id)
    {
        SqlConnection con = new SqlConnection(_configuration.GetConnectionString("FarmCon").ToString());
        Response response = new Response();
        Application apl = new Application();
        response = apl.GetAllProductsByID(con, id);
        return response;
    }

    [HttpPost]
    [Route("AddProducts")]
    public Response AddPeople(Products products)
    {
        SqlConnection con = new SqlConnection(_configuration.GetConnectionString("FarmCon").ToString());
        Response response = new Response();
        Application apl = new Application();
        response = apl.AddProducts(con, products);
        return response;
    }

    [HttpPut]
    [Route("UpdateProducts")]
    public Response UpdateProducts(Products products)
    {
        SqlConnection con = new SqlConnection(_configuration.GetConnectionString("FarmCon").ToString());
        Response response = new Response();
        Application apl = new Application();
        response = apl.UpdateProducts(con, products);
        return response;
    }

    [HttpDelete]
    [Route("DeleteProducts/{id}")]
    public Response DeleteProducts(int id)
    {
        SqlConnection con = new SqlConnection(_configuration.GetConnectionString("FarmCon").ToString());
        Response response = new Response();
        Application apl = new Application();
        response = apl.DeleteProducts(con, id);
        return response;
    }
}
