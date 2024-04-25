using System.ComponentModel.DataAnnotations;
using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

//Registrar o serviço de banco de dados
builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();

// List<Produto> produtos = new List<Produto>();
List<Produto> produtos =
[
    new Produto("Celular", "IOS", 5000),
    new Produto("Celular", "Android", 4000),
    new Produto("Televisão", "LG", 2300.5),
    new Produto("Placa de Vídeo", "NVIDIA", 2500),
];

//Funcionalidades da aplicação - EndPoints

// GET: http://localhost:5124/
app.MapGet("/", () => "API de Produtos");

// GET: http://localhost:5124/produto/listar
app.MapGet("/produto/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Produtos.Any())
    {
        return Results.Ok(ctx.Produtos.ToList());
    }
    return Results.NotFound("Não existem produtos na tabela");
});

// GET: http://localhost:5124/produto/buscar/iddoproduto
app.MapGet("/produto/buscar/{id}", ([FromRoute] string id,
    [FromServices] AppDataContext ctx) =>
{
    Produto? produto = ctx.Produtos.Find(id);
    if (produto is null)
    {
        return Results.NotFound("Produto não encontrado!");
    }
    return Results.Ok(produto);
});

// POST: http://localhost:5124/produto/cadastrar
app.MapPost("/produto/cadastrar", ([FromBody] Produto produto,
    [FromServices] AppDataContext ctx) =>
{
    List<ValidationResult> erros = new List<ValidationResult>();
    if (!Validator.TryValidateObject(
        produto, new ValidationContext(produto), erros, true
    ))
    {
        return Results.BadRequest(erros);
    }

    //Não é permitido o cadastro do produto com algum nome já cadastrado
    Produto? produtoEncontrado = ctx.Produtos.FirstOrDefault
        (x => x.Nome == produto.Nome);
    if (produtoEncontrado is null)
    {
        //Adicionar o objeto dentro da tabela no banco de dados
        ctx.Produtos.Add(produto);
        ctx.SaveChanges();
        return Results.Created("", produto);
    }
    return Results.BadRequest("Já existe um produto com o mesmo nome");
});

// DELETE: http://localhost:5124/produto/deletar/id
app.MapDelete("/produto/deletar/{id}", ([FromRoute] string id,
    [FromServices] AppDataContext ctx) =>
{
    Produto? produto = ctx.Produtos.FirstOrDefault(x => x.Id == id);
    if (produto is null)
    {
        return Results.NotFound("Produto não encontrado!");
    }
    ctx.Produtos.Remove(produto);
    ctx.SaveChanges();
    return Results.Ok("Produto deletado!");
});

// PUT: http://localhost:5124/produto/alterar/id
app.MapPut("/produto/alterar/{id}", ([FromRoute] string id,
    [FromBody] Produto produtoAlterado,
    [FromServices] AppDataContext ctx) =>
{
    Produto? produto = ctx.Produtos.Find(id);
    if (produto is null)
    {
        return Results.NotFound("Produto não encontrado!");
    }
    produto.Nome = produtoAlterado.Nome;
    produto.Descricao = produtoAlterado.Descricao;
    produto.Valor = produtoAlterado.Valor;
    ctx.Produtos.Update(produto);
    ctx.SaveChanges();
    return Results.Ok("Produto alterado!");

});
app.Run();