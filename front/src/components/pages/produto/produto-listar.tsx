import { useEffect } from "react";
import "./styles.css";

//Consultar os produtos da API e exibir na tela
// - Resolver o problema de CORS (API)
// - Como exibir uma array na tela utilizando React

function ProdutoListar() {
  //Executar algum código no carregamento do componente
  useEffect(() => {
    console.log("O componente foi carregado...");

    //FETCH ou AXIOS
    fetch("https://viacep.com.br/ws/80020010/json/")
      .then((resposta) => resposta.json())
      .then((cep) => {
        console.log(cep.logradouro);
      });
  }, []);

  return (
    <div>
      <h1>Listar Produtos</h1>
    </div>
  );
}

export default ProdutoListar;
