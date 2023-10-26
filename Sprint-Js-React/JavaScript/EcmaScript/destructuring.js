const camisaLacoste = {
    descricao: "Camisa Lacoste",
    preco: 399.98,
    tamanho: "G",
    marca: "Lacoste",
    cor: "Azul",
    promo: true,
}

// const descricao = camisaLacoste.descricao;
// const preco = camisaLacoste.preco;

const {descricao, preco, promo} = camisaLacoste;


//Exibicao desse destructuring

// console.log(`
//     Produto: ${descricao}
//     Preco: ${preco}
//     Promocao: ${promo ? "Sim" : "Nao"}
// `);


const evento = {
    dataEvento: new Date(),
    descricaoEvento: "Evento de publicidade",
    titulo: "Senai",
    presenca: true,
    comentario: "Evento vai ser muito divertio sobre informatica, venha!"
}

const {descricaoEvento, dataEvento, presenca} = evento;

console.log(`
    Descricao do evento: ${descricaoEvento}
    Data do evento: ${dataEvento}
    Presenca: ${presenca ? "Confirmado" : "Nao confirmado"}
`);