﻿using Ordering.Application.Orders.Commands.UpdateOrder;
using Ordering.Domain.ValueObjects;
using Serilog;

namespace Ordering.API.Endpoints;

//- Accepts a UpdateOrderRequest.
//- Maps the request to an UpdateOrderCommand.
//- Sends the command for processing.
//- Returns a success or error response based on the outcome.

public record UpdateOrderRequest(OrderDto Order);
public record UpdateOrderResponse(bool IsSuccess);

public class UpdateOrder : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/orders", async (UpdateOrderRequest request, ISender sender) =>
        {

            Log.Information($"/orders UpdateOrder called");

            var command = request.Adapt<UpdateOrderCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateOrderResponse>();

            Log.Information($"/orders UpdateOrder response fetched");

            return Results.Ok(response);
        })
        .WithName("UpdateOrder")
        .Produces<UpdateOrderResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Order")
        .WithDescription("Update Order");
    }
}
