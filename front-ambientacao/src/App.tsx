import React from "react";
import Soma from "./Soma";

//1 - Um componente deve ser nomeado com a PRIMEIRA letra
//maiúscula
//2 - Um componente DEVE ser uma função
//3 - Um componente deve retonar APENAS um elemento pai HTML

function App() {
  return (
    <div>
      <Soma />
    </div>
  );
}
//4 - O componente DEVE ser exportado
export default App;
