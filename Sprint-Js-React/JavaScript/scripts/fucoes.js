function calcular() {
    event.preventDefault();//Interrompe o subimit do formulario
    let n1 = parseFloat(document.getElementById("numero1").value);
    let n2 = parseFloat(document.getElementById("numero2").value);
    let res = n1 + n2;
    let op = document.getElementById("operacao").value



    if(isNaN(n1) || isNaN(n2)) {
        alert("Preencha todos os campos")
        return;
    }

    if (op == '+') {
        res = soma(n1, n2);

    }

    else if (op == '-') {
        res = subtracao(n1, n2);


    }
    else if (op == '*') {
        res = multiplicacao(n1, n2);
    }
    else if (op == '/') {
        res = divisao(n1, n2);
    }
    else {
        res = "Operacao invalida"
    };

    let xpto = document.getElementById("resultado").innerText = res;



}

function soma(x, y) {
    return (x + y).toFixed(2);
}

function subtracao(x, y) {
    return (x - y).toFixed(2);
}
function multiplicacao(x, y) {
    return (x * y).toFixed(2);
}
function divisao(x, y) {

    if (y == 0) {
        return "Divisao indeterminável"
    }

        return (x / y).toFixed(2);
    

}