
//Lista global
const listaPessoas = [];//Lista vazia



function calcular(e) {
    e.preventDefault();
    let nome = document.getElementById("nome").value.trim();//Limpa a string
    let altura = parseFloat(document.getElementById("altura").value);
    let peso = parseFloat(document.getElementById("peso").value);

    if (isNaN(altura) || isNaN(peso) || nome.lenght >= 2) {
        alert('E necessario preencher todos os campos')
        return;
    }



    const imc = calcularImc(peso, altura);
    const txtsituacao = gerarSituacao(imc);
    const dataCadastro = new Date();
    const pessoa = {
        nome,
        altura,
        peso,
        imc,
        situacao: txtsituacao,
        dataCadastro : `${dataCadastro.getDate()}/${dataCadastro.getMonth() + 1}/${dataCadastro.getFullYear()}`
    }
    listaPessoas.push(pessoa)

    exibirDados()


}
function calcularImc(peso, altura) {
    return peso / Math.pow(altura, 2);
}

function gerarSituacao(imc) {
    if (imc < 17) {
        return "Magreza Severa"
    }
    else if (imc < 18.5) {
        return "Abaixo do peso"
    }
    else if (imc < 24.9) {
        return "Normal"
    }
    else if (imc < 29.9) {
        return "Acima do peso"
    }
    else if (imc < 34.9) {
        return "Obesidade I"
    }
    else if (imc < 39.9) {
        return "Obesidade II(Severa)"
    }
    else {
        return "Obesidade III(Morbida)"
    }
}

function exibirDados() {
    console.log(listaPessoas)

    //      <tr>
    //     <td data-cell="nome">Thiago Nascimento</td>
    //     <td data-cell="altura">1.78</td>
    //     <td data-cell="peso">67</td>
    //     <td data-cell="valor do IMC">21.1</td>
    //     <td data-cell="classificação do IMC">Normal</td>
    //     <td data-cell="data de cadastro">19/06/2023 21:27</td>
    // </tr>


    let linhas = ''

    listaPessoas.forEach(function (oPessoa) {
        linhas +=
            `<tr>
                <td data-cell="nome">${oPessoa.nome}</td>
                <td data-cell="altura">${oPessoa.altura}</td>
                <td data-cell="peso">${oPessoa.peso}</td>
                <td data-cell="valor do IMC">${oPessoa.imc}</td>
                <td data-cell="classificação do IMC">${oPessoa.situacao}</td>
                <td data-cell="data de cadastro">${oPessoa.dataCadastro}</td>
            </tr>`
    })

    document.getElementById('corpo-tabela').innerHTML = linhas;

}