import { useState } from "react";

//1 - Exibir o valor do contador no HTML
//2 - Somar os dois números da caixa de texto e exibir
//no navegador

function Soma() {
  const [contador, setContador] = useState(0);

  function clicar() {
    setContador(contador + 1);
    console.log(contador);
  }

  return (
    <div>
      <h1>Soma</h1>
      <label>Número 1:</label>
      <input type="text" /> <br />
      <label>Número 2:</label>
      <input type="text" /> <br />
      <button onClick={clicar}>Calcular</button>
    </div>
  );
}

export default Soma;
