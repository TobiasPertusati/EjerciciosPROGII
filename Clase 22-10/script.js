// Problema 4.8:
// Desarrollar un programa JavaScript que genere aleatoriamente 100 números enteros y los guarde en
// un arreglo unidimensional. A continuación, calcula y muestra por separado la media de los valores
// positivos y la de los valores negativos.

function procesar(){
    let contador = 0
    let CantPos = 0;
    let CantNeg = 0;
    let AcuPos = 0;
    let AcuNeg = 0;
    let array = [];

    while (contador < 100) {
        let numero = Math.random() * 100 ;
        numero = numero -50;
        array.push(numero)
        if (numero < 0) {
            CantNeg ++;
            AcuNeg += numero;
        }
        else{
            CantPos ++;
            AcuPos += numero;
        }
        contador ++;
    }
    alert("La cantidad de numeros negativos es: " + CantNeg  + "y su media es: " + AcuNeg/CantNeg)
    alert("La cantidad de numeros positivos es: " + CantPos  + "y su media es: " + AcuPos/CantPos)
    array.forEach(element => {
        console.log(element)
    });

}