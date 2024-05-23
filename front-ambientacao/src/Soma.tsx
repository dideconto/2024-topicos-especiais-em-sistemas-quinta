import { useState } from "react";

//1 - Exibir o valor do contador no HTML
//2 - Somar os dois números da caixa de texto e exibir
//no navegador

function Soma() {
  const [contador, setContador] = useState(0);
  const [numero1, setNumero1] = useState("");
  const [numero2, setNumero2] = useState("");
  const [resultado, setResultado] = useState(0);
  const [numero, setNumero] = useState(0);
  const [mensagemErro, setMensagemErro] = useState("");

  function imcrementarContador() {
    setContador(contador + 1);
  }

  function escreverNumero1(e: any) {
    setNumero1(e.target.value);
  }

  function somar() {
    setNumero(parseInt(numero1));
    console.log(numero);
    setMensagemErro("Exiba uma mensagem de erro");
    setResultado(parseInt(numero1) + parseInt(numero2));
  }

  return (
    <div>
      <h1>Soma</h1>
      <label>Número 1:</label>
      <input type="text" onChange={escreverNumero1} /> <br />
      <label>Número 2:</label>
      <input
        type="text"
        onChange={(e: any) => {
          setNumero2(e.target.value);
        }}
      />
      <br />
      <button onClick={imcrementarContador}>Contador</button>
      <button onClick={somar}>Somar</button>
      <p>{contador}</p>
      <p>{resultado}</p>
      <p>{mensagemErro}</p>
    </div>
  );
}

export default Soma;
