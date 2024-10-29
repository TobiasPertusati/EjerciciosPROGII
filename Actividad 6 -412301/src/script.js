let turnos = []; // Inicializa el arreglo de turnos
const hamburger = document.querySelector("#toggle-btn");

hamburger.addEventListener("click",function() {
    document.querySelector("#sidebard").classList.toggle("expand");
});

function mostrarSection(seccionId) {
    const secciones = document.querySelectorAll("section");
    secciones.forEach((section) => {
        section.style.display = "none";
    });
    document.getElementById(seccionId).style.display = "block";
}


document.getElementById("formNuevoTurno").addEventListener("submit", function (e) {
    e.preventDefault();
    const nuevoTurno = {
        id: 0,
        fecha: document.getElementById("fecha").value,
        hora: document.getElementById("hora").value,
        cliente: document.getElementById("cliente").value
    };
    
    // Validación del turno
    if (validarTurno(nuevoTurno)) {
        turnos.push(nuevoTurno);
        alert("Turno registrado con éxito");
        showSection("tablaTurnos");
        mostrarTurnos();
    } else {
        alert("Datos de turno no válidos");
    }
});

function validarTurno(turno) {
    const fechaTurno = new Date(turno.fecha);
    const fechaHoy = new Date();
    return fechaTurno > fechaHoy && fechaTurno <= new Date(fechaHoy.setDate(fechaHoy.getDate() + 45));
}



function mostrarTurnos() {
    const tbody = document.getElementById("tablaTurnosContent");
    tbody.innerHTML = "";
    turnos.forEach(turno => {
        const row = `<tr>
                        <td>${turno.id}</td>
                        <td>${turno.fecha}</td>
                        <td>${turno.hora}</td>
                        <td>${turno.cliente}</td>
                     </tr>`;
        tbody.innerHTML += row;
    });
}


async function cargarTurnos() {
    try {
        const response = await fetch("/api/Todos_los_turnos");
        if (response.ok) {
            const data = await response.json();
            mostrarTurnosClientes(data);
        }
    } catch (error) {
        console.error("Error al cargar turnos:", error);
    }
}

function mostrarTurnosClientes(turnos) {
    const tbody = document.getElementById("tablaTurnosCliente");
    tbody.innerHTML = "";
    turnos.forEach(turno => {
        const row = `<tr>
                        <td>${turno.cliente}</td>
                        <td>${turno.totalTurnos}</td>
                     </tr>`;
        tbody.innerHTML += row;
    });
}



/* <tr>
<td><i class="fab fa-angular fa-lg text-danger me-3"></i> <strong>Lavado de
        cabello</strong></td>
<td>$3000</td>
<td>
    Si
</td>
<td><span class="badge bg-label-primary me-1">Active</span></td>
<td>
    <div class="dropdown">
        <button type="button" class="btn p-0 dropdown-toggle"
            data-bs-toggle="dropdown">
            <i class="bi bi-three-dots-vertical" style="color: white;"></i>
        </button>
        <div class="dropdown-menu">
            <a class="dropdown-item" href="javascript:void(0);">
                <i class="bi bi-pencil-square"></i> Editar</a>
            <a class="dropdown-item" href="javascript:void(0);">
                <i class="bi bi-trash"></i> Deshabilitar</a>
        </div>
    </div>
</td>
</tr> */