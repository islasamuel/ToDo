function fncMessage(mensaje, tipo) {
    Swal.fire({
        title: '',
        text: mensaje,
        icon: tipo,
        showCancelButton: false,
        confirmButtonColor: '#28a745',
        confirmButtonText: 'Aceptar',

    })

}

function fncConfirmMessage(titulo, mensaje) {
    return new Promise((resolve) => {
        Swal.fire({
            title: titulo,
            html: mensaje,
            icon: 'question',
            showCancelButton: true,
            confirmButtonColor: '#28a745',
            cancelButtonColor: '#c82333',
            confirmButtonText: 'Aceptar',
            cancelButtonText: 'Cancelar'
        }).then((result) => {
            if (result.isConfirmed) {
                resolve(true);
            } else {
                resolve(false);
            }
        })
    })
}


function fncModificaTareas(idMeta, totalTareas, tareasCompletadas, porcentaje) {
    document.getElementById('lblTareasCompletadas_' + idMeta).innerHTML = 'Tareas completadas ' + tareasCompletadas + '/' + totalTareas
    document.getElementById('lblPorcentaje_' + idMeta).innerHTML = porcentaje + '%'
    document.getElementById('lblProgress_' + idMeta).style.width = porcentaje + '%'

}


