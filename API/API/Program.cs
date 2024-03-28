using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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
app.MapPost("/produto/cadastrar", () =>
    "Cadastro de produtos");

//EXERCÍCIOS
//1) Cadastrar um produto 
//a) Pela URL
//b) Pelo corpo
//2) Remoção do produto
//3) Alteração do produto

app.Run();