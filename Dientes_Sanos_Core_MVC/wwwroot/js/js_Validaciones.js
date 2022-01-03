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

function AnadirFilaPresup() {
   
    var a = $("#MODEL_PRESUPUESTO_PRE_COD").val();
    var b = $("#Nom_Pac").val();
    var c = $("#MODEL_PRESUPUESTO_PRE_COD_ODON").val();
    $("#tblTratamiento tbody").append("<tr><td>" + a + "</td><td>" + b + "</td><td>" + c + "</td></tr>");
    $("#MODEL_PRESUPUESTO_PRE_COD").val('');
    $("#Nom_Pac").val('');
    $("#MODEL_PRESUPUESTO_PRE_COD_ODON").val('');
}

function ValidadEdad(RepPacVal, EdadVal) {

    // Accedemos al botón
    var RepresentanteValidacion = document.getElementById(RepPacVal);
    var EdadValidacion = $('#' + EdadVal).val(); // Obtenemos el Valor del campo Edad
    //console.log(EdadValidacion);
    if (EdadValidacion >= 18) { // Validamos si es mayor o menor
        // evento para el input Deshabilitado
        console.log("Mayor de edad");
        $('#' + RepPacVal).attr("readonly", true); // Deshabilitado
        document.getElementById(RepPacVal).value = "";
    }
    else if (EdadValidacion < 18) {
        console.log("Menor de edad");
        // evento para el input Habilitar
        $('#' + RepPacVal).attr("readonly", false); // Habilitado
    }
}

function SeleccionDentadura() {
    var selectedVal = document.getElementById("MODEL_PRESUPUESTO_PRE_DEN_PAC").value;
    if (selectedVal == "DENTADURA TEMPORAL") {
        selectedVal = "TEMPORAL"
    }
    else if (selectedVal == "DENTADURA ADULTA") {
        selectedVal = "ADULTA"
    }
    //alert(selectedVal);
    console.log(selectedVal)
    $.ajax(
        {
            type: "POST",
            dataType: "json",
            url: "/Presupuesto/Get_Pieza_Lista",
            data: { 'PIE_DENT': selectedVal },
            success:
                function (resul) {
                    //  resul = JSON.stringify(resul);
                    // VACIAMOS EL DropDownList
                    $("#MODEL_PRESUPUESTO_PRE_PIE_DEN").empty();
                    //AÑADIMOS UN NUEVO label CON EL NOMBRE DEL ELEMENTO SELECCIONADO
                    var mOptions = `<option value="">ESCOGA UNA PIEZA DENTAL ${$("#MODEL_PRESUPUESTO_PRE_PIE_DEN option:selected").text()}</option>`;
                    // CONSTRUIMOS EL DropDownList A PARTIR DEL RESULTADO Json(data)
                    console.log(resul)
                    $.each(resul, function (index, row) {
                        mOptions += `<option value="${row.piE_ID}">${row.piE_PIEZA}</option>`;
                    });
                    $("#MODEL_PRESUPUESTO_PRE_PIE_DEN").append(mOptions)
                    console.log(mOptions)
                }, error:
                function (e) {
                    alert("ERROR: " + e.message);
                }
        });
};

function SeleccionTratamiento() {
    var selectedVal = document.getElementById("MODEL_PRESUPUESTO_PRE_TRA_PAC").value;
    console.log(selectedVal)
    $.ajax(
        {
            type: "POST",
            dataType: "json",
            url: "/Presupuesto/Get_Valor_Tratamiento",
            data: { 'TRA_CONCEPTO': selectedVal },
            success:
                function (resul) {
                    console.log(resul)
                    var mPRE_VAL_PRE = "";
                    var mPRE_VAL_POR = "";
                    var mPRE_VAL_DES = "";
                    var mPRE_VAL_SUB = "";
                    $.each(resul, function (index, row) {
                        mPRE_VAL_PRE += row.trA_VALOR;
                        mPRE_VAL_POR += row.trA_POR_DESC;
                        mPRE_VAL_DES += row.trA_DESC;
                        mPRE_VAL_SUB += row.trA_TOTAL;
                    });
                    $("#MODEL_PRESUPUESTO_PRE_VAL_PRE").val(mPRE_VAL_PRE).text();
                    $("#MODEL_PRESUPUESTO_PRE_VAL_POR").val(mPRE_VAL_POR).text();
                    $("#MODEL_PRESUPUESTO_PRE_VAL_DES").val(mPRE_VAL_DES).text();
                    $("#MODEL_PRESUPUESTO_PRE_VAL_SUB").val(mPRE_VAL_SUB).text();
                }, error:
                function (e) {
                    alert("ERROR: " + e.message);
                }
        });
};

function ValidadDsctoTrat(PorVal, ValVal, TotVal, DsctVal) {
    // Accedemos al input
    var ValorValidacion = $('#' + ValVal).val(); // Obtenemos el Valor del campo Valor
    var PorcValidacion = $('#' + PorVal).val(); // Obtenemos el Valor del campo Porcentaje
    console.log(PorcValidacion);
    document.getElementById(DsctVal).value = (ValorValidacion * (PorcValidacion / 100)).toFixed();
    document.getElementById(TotVal).value = (ValorValidacion - (ValorValidacion * (PorcValidacion / 100))).toFixed();
}

function Dscto_Trat_Presup() {
    // Accedemos al input
    var ValorValidacion = $("#MODEL_PRESUPUESTO_PRE_VAL_PRE").val(); // Obtenemos el Valor del campo Valor
    var PorcValidacion = $("#MODEL_PRESUPUESTO_PRE_VAL_POR").val(); // Obtenemos el Valor del campo Porcentaje
    var tmpPRE_VAL_DES = (ValorValidacion * (PorcValidacion / 100)).toFixed();
    var tmpPRE_VAL_SUB = (ValorValidacion - (ValorValidacion * (PorcValidacion / 100))).toFixed();
    $("#MODEL_PRESUPUESTO_PRE_VAL_DES").val(tmpPRE_VAL_DES);
    $("#MODEL_PRESUPUESTO_PRE_VAL_SUB").val(tmpPRE_VAL_SUB);
}

function SoloLetras(e) {
    //var charCode = (evt.which) ? evt.which : event.keyCode
    //if (charCode > 31 && (charCode < 48 || charCode > 57))
    //    return true;
    //return false;
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    letras = "áéíóúabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚäëïöüÄËÏÖÜàèìòùÀÈÌÒÙ";
    especiales = [8, 32, 37, 39, 46];

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

function upperCaseInput(a) {
    setTimeout(function () {
        a.value = a.value.toUpperCase();
    }, 1);
}

function LimpiarCampo() {
    var val = document.getElementById("txtPacNom").value;
    var tam = val.length;
    for (i = 0; i < tam; i++) {
        if (!isNaN(val[i]) && val[i] != " ")
            document.getElementById("txtPacNom").value = "";
    }
}