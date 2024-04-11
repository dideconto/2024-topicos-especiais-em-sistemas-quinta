using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
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
app.MapGet("/produto/listar", () =>
    produtos);

// GET: http://localhost:5124/produto/buscar/nomedoproduto
app.MapGet("/produto/buscar/{nome}", ([FromRoute] string nome) =>
    {
        for (int i = 0; i < produtos.Count; i++)
        {
            if (produtos[i].Nome == nome)
            {
                //retornar o produto encontrado
                return Results.Ok(produtos[i]);
            }
        }
        return Results.NotFound("Produto não encontrado!");
    }
);

// POST: http://localhost:5124/produto/cadastrar
app.MapPost("/produto/cadastrar", ([FromBody] Produto produto) =>
{
    //Adicionar o objeto dentro da lista
    produtos.Add(produto);
    return Results.Created("", produto);
});

// DELETE: http://localhost:5124/produto/deletar/id
app.MapDelete("/produto/deletar/{id}", ([FromRoute] string id) =>
{
    Produto? produto = produtos.FirstOrDefault(x => x.Id == id);
    if (produto is null)
    {
        return Results.NotFound("Produto não encontrado!");
    }
    produtos.Remove(produto);
    return Results.Ok("Produto deletado!");

});

// PUT: http://localhost:5124/produto/alterar/id
app.MapPut("/produto/alterar/{id}", ([FromRoute] string id,
    [FromBody] Produto produtoAlterado) =>
{
    Produto? produto = produtos.FirstOrDefault(x => x.Id == id);
    if (produto is null)
    {
        return Results.NotFound("Produto não encontrado!");
    }
    produto.Nome = produtoAlterado.Nome;
    produto.Descricao = produtoAlterado.Descricao;
    produto.Valor = produtoAlterado.Valor;
    return Results.Ok("Produto alterado!");

});
app.Run();