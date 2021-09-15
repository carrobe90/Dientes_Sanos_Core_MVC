function ValidarFecha(idFecNac, idEdad) {
    var ver = $('#' + idFecNac).val();
    var now = new Date();
    var birthdate = new Date($('#' + idFecNac).val()); // Se Procede a calcular en base a la fecha
    var nowyear = now.getFullYear();
    var birthyear = birthdate.getFullYear();
    var age = nowyear - birthyear + 1;
    $('#' + idEdad).val(age);
}

    function SoloNumeros(e) {
        var keynum = window.event ? window.event.keyCode : e.which;
        if ((keynum == 8 || keynum == 48))
            return true;
        if (keynum <= 47 || keynum >= 58) return false;
        return /\d/.test(String.fromCharCode(keynum));
    }

function ValidadEdad(RepPacVal, EdadVal) {
  
            // Accedemos al botón
            var RepresentanteValidacion = document.getElementById(RepPacVal);
            var EdadValidacion = $('#' + EdadVal).val(); // Obtenemos el Valor del campo Edad
            //console.log(EdadValidacion);
            if (EdadValidacion >= 18) { // Validamos si es mayor o menor
                // evento para el input Deshabilitado
                console.log("Mayor de edad");
                RepresentanteValidacion.disabled = true; // Deshabilitado
            }
            else if (EdadValidacion < 18) {
                console.log("Menor de edad");
                // evento para el input Habilitar
                RepresentanteValidacion.disabled = false; // Habilitado
            }
     
}

function SoloLetras(e) {
    //var charCode = (evt.which) ? evt.which : event.keyCode
    //if (charCode > 31 && (charCode < 48 || charCode > 57))
    //    return true;
    //return false;
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    letras = "áéíóúabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚäëïöüÄËÏÖÜàèìòùÀÈÌÒÙ";
    especiales = [8, 32,37, 39, 46];

    tecla_especial = false
    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }
    if (letras.indexOf(tecla) == -1 && !tecla_especial)
        return false;
}

function LimpiarCampo() {
    var val = document.getElementById("txtPacNom").value;
    var tam = val.length;
    for (i = 0; i < tam; i++) {
        if (!isNaN(val[i]) && val[i] != " ")
            document.getElementById("txtPacNom").value = "";
    }
}