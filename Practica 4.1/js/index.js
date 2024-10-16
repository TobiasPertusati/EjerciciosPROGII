//alert('BIENVENIDO A MI SITIO')

function procesar(){
    const $nom = document.getElementById('nombre')
    const $email = document.getElementById('email')
   //const $sug = document.getElementById('sugerencia')
    
    if($nom.value === ''){
        alert('Campo <NOMBRE> es requerido!')
        return;
    }
    let email = $email.value
    if( email.indexOf('@',0 )===-1){
        alert('Campo <EMAIL> no válido!')
        return;
    }


    alert('Se enviaron los datos al servidor!')
}