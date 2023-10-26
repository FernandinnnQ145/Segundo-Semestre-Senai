let eduardo = {
    nome: "Eduardo",
    idade: 41,
    altura: 1.67
};

eduardo.peso = 89;


let carlos = new Object();

carlos.nome = "Carlos";
carlos.idade = 36;
carlos.sobrenome = "Roque";


let pessoas = [];

pessoas.push(carlos);
pessoas.push(eduardo)

// console.log(pessoas);

pessoas.forEach((n, i) => {
    console.log(`${i + 1}° pessoa: ${n.nome}`);
});