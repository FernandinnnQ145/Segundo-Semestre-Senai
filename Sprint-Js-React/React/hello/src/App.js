
import './App.css';
import Titulo from './componentes/Titulo/Titulo';
import CardEvento from './componentes/CardEvento/CardEvento'

function App() {
  return (
    <div className="App">
      <h1>Hello react</h1>
    <Titulo texto="Fernando"/>


    <CardEvento tituloCard="Evento sobre React" textoCard="Evento bacana e divertido, muito interativo" nomeBotao="Entra"/>
    <CardEvento tituloCard="Evento C#" textoCard="AAAAAAAAA" nomeBotao="Entra logo"/>
    <CardEvento tituloCard="Banco de dados" textoCard="Pao" nomeBotao="Entra"/>
    <CardEvento tituloCard="Evento HTML5" textoCard="Evento bacana e divertido, muito interativo" nomeBotao="Entra"/>
    </div>
  );
}

export default App;
