function calcular(e){
    e.preventDefault();
    let nome = document.getElementById("nome").value.trim();//Limpa a string
    let altura = parseFloat(document.getElementById("altura").value);
    let peso = parseFloat(document.getElementById("peso").value);

    if(isNaN(altura) || isNaN(peso) || nome.lenght >= 2) {
        alert('E necessario preencher todos os campos')
        return;
    }



    const imc = calcularImc(peso, altura);
    const situacao = gerarSituacao(imc);
    const pessoa = {
        nome : nome,
        altura : altura,
        peso : peso,
        imc : imc,
        situacao : situacao
    }

    console.log(pessoa)

    function calcularImc(peso, altura){
        return peso / Math.pow(altura, 2);
    }

    function gerarSituacao(imc){
        if(imc < 17){
            return "Magreza Severa"
        }
        else if(imc < 18.5){
            return "Abaixo do peso"
        }
        else if(imc < 24.9){
            return "Normal"
        }
        else if(imc < 29.9){
            return "Acima do peso"
        }
        else if(imc < 34.9){
            return "Obesidade I"
        }
        else if(imc < 39.9){
            return "Obesidade II(Severa)"
        }
        else{
            return "Obesidade III(Morbida)"
        }
    }
}