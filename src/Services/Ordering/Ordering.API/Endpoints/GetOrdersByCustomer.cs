﻿using Ordering.Application.Orders.Queries.GetOrdersByCustomer;
using Serilog;

namespace Ordering.API.Endpoints;

//- Accepts a customer ID.
//- Uses a GetOrdersByCustomerQuery to fetch orders.
//- Returns the list of orders for that customer.

//public record GetOrdersByCustomerRequest(Guid CustomerId);
public record GetOrdersByCustomerResponse(IEnumerable<OrderDto> Orders);

public class GetOrdersByCustomer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/customer/{customerId}", async (Guid customerId, ISender sender) =>
        {

            Log.Information($"/orders/customer/{customerId} get called");

            var result = await sender.Send(new GetOrdersByCustomerQuery(customerId));

            var response = result.Adapt<GetOrdersByCustomerResponse>();

            Log.Information($"/orders/customer/{customerId} resposne fetched");

            return Results.Ok(response);
        })
        .WithName("GetOrdersByCustomer")
        .Produces<GetOrdersByCustomerResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Orders By Customer")
        .WithDescription("Get Orders By Customer");
    }
}
