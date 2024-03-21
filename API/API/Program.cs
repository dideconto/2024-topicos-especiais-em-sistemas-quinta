var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Produto> produtos = new List<Produto>();
produtos.Add(new Produto("Celular", "IOS"));
produtos.Add(new Produto("Celular", "Android"));
produtos.Add(new Produto("Televisão", "LG"));
produtos.Add(new Produto("Placa de Vídeo", "NVIDIA"));

//Funcionalidades da aplicação - EndPoints
app.MapGet("/produto/listar", () =>
    produtos);

//EXERCÍCIO - Cadastrar produtos dentro da lista
app.MapPost("/produto/cadastrar", () =>
    "Cadastro de produtos");

app.Run();

record Produto(string nome, string descricao);
