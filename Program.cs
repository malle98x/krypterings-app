using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/api/kryptering/kryptera", (string text) => 
{
    if (string.IsNullOrEmpty(text)) return Results.BadRequest("Text kan inte vara tomt.");
    
    string encrypted = new string(text.Select(c => char.IsLetter(c) 
        ? (char)(c + 3) : c).ToArray());

    return Results.Ok(encrypted);
});

app.MapGet("/api/kryptering/avkryptera", (string text) => 
{
    if (string.IsNullOrEmpty(text)) return Results.BadRequest("Text kan inte vara tomt.");
    
    string decrypted = new string(text.Select(c => char.IsLetter(c) 
        ? (char)(c - 3) : c).ToArray());

    return Results.Ok(decrypted);
});

app.Run();