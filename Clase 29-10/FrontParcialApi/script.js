const url = 'https://localhost:7223/api/Peliculas';
function getPeliculas() {
    fetch(url)
        .then(response => response.json())
        .then(data => displayPeliculas(data))
        .catch(error => {
            console.error('Error: ', error)
        })
}

function displayPeliculas(data) {
    const tabla = document.getElementById('tabla-cartelera') 
    data.forEach(pelicula => {
        let estreno = pelicula.estreno ? 'Estreno' : 'No Estreno';
        tabla.insertAdjacentHTML('beforeend', `
            <tr>
                <td>${pelicula.id}</td>
                <td>${pelicula.titulo}</td>
                <td>${pelicula.generoNavigation.nombre}</td>
                <td>${estreno}</td>
                <td>
                    <ul>
                        <li><a href="save.html"><i class="bi bi-pencil"></i></a></li>
                        <li><a role="button" onclick="eliminar(1)"></a><i class="bi bi-trash"></i></li>
                    </ul>
                </td>
            </tr>
            `)
    });
}
function eliminar(idPelicula){
    const urlDelete = `https://localhost:7223/api/Peliculas/${idPelicula}`
    fetch(urlDelete,{
        method : 'PUT',
        headers: {
            'Content-Type': 'application/json',  // Indica que el cuerpo de la solicitud está en formato JSON
        }
        //   },
        // body: JSON.stringify({
        //     id:idPelicula
        // })
    })
    .then(response => {
        if (!response.ok) {
          throw new Error('Error al dar de baja el recurso');
        }
        return response.json();  // Procesar la respuesta como JSON
      })
      .then(data => {
        console.log('Elemento actualizado:', data);
      })
      .catch(error => {
        console.error('Hubo un problema con la operación PUT:', error);
      });
   
}


const urlPost = 'https://localhost:7223/api/Peliculas';

document.getElementById('movieForm').addEventListener('submit', function(event) {
    event.preventDefault(); // Evita que el formulario se envíe de la manera tradicional

    const titulo = document.getElementById('titulo').value;
    const director = document.getElementById('director').value;
    const anio = parseInt(document.getElementById('anio').value);
    const idGenero = parseInt(document.getElementById('idGenero').value);
    const estreno = document.getElementById('estreno').value === "true";


    const nuevaPelicula = {
        Titulo: titulo,
        Director: director,
        Anio: anio,
        IdGenero: idGenero,
        Estreno: estreno
    };

    // Llamada a la API para agregar la nueva película
    fetch(urlPost, {
        method: 'POST', // Usamos POST para crear un nuevo recurso
        headers: {
            'Content-Type': 'application/json' // Indica que el cuerpo está en formato JSON
        },
        body: JSON.stringify(nuevaPelicula) // Convertimos el objeto a JSON
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('Error al agregar la película');
        }
        return response.json();
    })
    .then(data => {
        console.log('Película añadida:', data);
        // Puedes agregar lógica para limpiar el formulario o mostrar un mensaje de éxito
        alert('Pelicula added exito')
        document.getElementById('movieForm').reset();
        window.location.href = 'index.html';
    })
    .catch(error => {
        console.error('Hubo un problema con la operación POST:', error);
    });
});

const urlGeneros = 'https://localhost:7223/api/Peliculas/generos';

function getGeneros() {
    fetch(urlGeneros)
        .then(response => {
            if (!response.ok) {
                throw new Error('Error al obtener los géneros');
            }
            return response.json();
        })
        .then(generos => displayGeneros(generos))
        .catch(error => {
            console.error('Hubo un problema con la operación GET:', error);
        });
}

function displayGeneros(generos) {
    const selectGeneros = document.getElementById('idGenero');
    generos.forEach(genero => {
        const option = document.createElement('option');
        option.value = genero.id; // Asumiendo que el objeto de género tiene una propiedad `id`
        option.textContent = genero.nombre; // Asumiendo que el objeto de género tiene una propiedad `nombre`
        selectGeneros.appendChild(option);
    });
}

