//foreach - Nao retorna 
const somar = (x,y) => {
    return x+y
}

// console.log(  somar(50,10));


//Uma maneira de fazer
// const dobro = (x) =>{
//     return x*2
// }


//Outra maneira
// const dobro = numero => numero*2;
// console.log(  dobro(50));


// //Mais uma maneira
// const boaTarde = () => {console.log("Boa Tarde")}
// boaTarde();



const convidados =
[
    {nome: "Carlos", idade: 36},
    {nome: "Eduardo", idade: 19},
    {nome: "sla", idade: 1000},
    {nome: "mesa", idade: 1},
];


convidados.forEach((p) => {
    console.log(`${p.nome} convidado`);
    
})