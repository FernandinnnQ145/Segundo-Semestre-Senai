//filter - retorna um novo array apenas com elementos que atenderam a uma condicao

const numeros = [1,2,5,10,300];
const maior10 = numeros.filter((e) => {
    return e >= 10;

})

// console.log(numeros);
// console.log(maior10);


const comentarios = [
    { comentario: "bla bla bla bla", exibe: true },
    { comentario: "evento foi uma merda", exibe: false },
    { comentario: "Otimo evento", exibe: true },
];

const comentariosOk = comentarios.filter((e) => {
    return e.exibe === true;
})

comentariosOk.forEach((e) => {
    console.log(e.comentario);
})
