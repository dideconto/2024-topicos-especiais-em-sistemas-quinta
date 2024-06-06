import { useEffect, useState } from "react";
import { Produto } from "../../../models/Produto";

function ProdutoListar() {
  const [produtos, setProdutos] = useState<Produto[]>([]);

  useEffect(() => {
    fetch("http://localhost:5124/produto/listar/")
      .then((resposta) => resposta.json())
      .then((produtos: Produto[]) => {
        setProdutos(produtos);
      });
  }, []);

  function cadastrarProduto() {
    const produto: Produto = {
      nome: "Macarrão",
      descricao: "Comida",
      quantidade: 150,
      valor: 15,
    };

    fetch("http://localhost:5124/produto/cadastrar/", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(produto),
    })
      .then((resposta) => resposta.json())
      .then((produto: Produto) => {
        console.log(produto);
      });
  }

  return (
    <div>
      <button onClick={cadastrarProduto}>Cadastrar Produto</button>
      <h1>Listar Produtos</h1>
      <table border={1}>
        <thead>
          <tr>
            <th>#</th>
            <th>Nome</th>
            <th>Descrição</th>
            <th>Valor</th>
            <th>Quantidade</th>
            <th>Criado Em</th>
          </tr>
        </thead>
        <tbody>
          {produtos.map((produto) => (
            <tr>
              <td>{produto.id}</td>
              <td>{produto.nome}</td>
              <td>{produto.descricao}</td>
              <td>{produto.valor}</td>
              <td>{produto.quantidade}</td>
              <td>{produto.criadoEm}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default ProdutoListar;
