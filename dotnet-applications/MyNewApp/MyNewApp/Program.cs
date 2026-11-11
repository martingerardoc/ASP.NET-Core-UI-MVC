using Microsoft.AspNetCore.Http.HttpResults;    
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var todos = new List<Todo>();

app.MapGet("/todos", () => todos);

app.MapGet("/todos/{id}", Results<Ok<Todo>, NotFound>(int id)=>
    {
        var targetTodo = todos.SingleOrDefault(t => id == t.Id);
        return targetTodo is null 
        ? TypedResults.NotFound() 
        : TypedResults.Ok(targetTodo);
});

app.Run();

public record Todo(
    int Id,
    string Title,
    bool IsCompleted
);