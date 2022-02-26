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

function SeleccionFilaPresupuesto() {
    $('tr').removeClass('selected');
    $(this).addClass('selected');
}

function BorrarFilaPresupuesto(event) {
    try {
        let rowSelected = $('tr.selected');
        if (rowSelected.length === 0)
            alert('No hay Seleccionado Ninguna Fila.');
        else {
            $('tr.selected').remove();
            console.log("Fila Eliminada");
            var total_col = 0;
            $("#tblTratamiento tbody").find("tr").each(function (i, el) {

                //Voy incrementando las variables segun la fila ( .eq(0) representa la fila 1 )     
                total_col += parseInt($(this).find("td").eq(11).text());
            });
            $("#SUB_TOT_PRE").val(total_col);
            var tot1 = document.getElementById("SUB_TOT_PRE").value
            var pordscto = document.getElementById("POR_DSCTO_PRE").value
            var tot2 = document.getElementById("TOT_POR_DSCTO_PRE").value;
            var portarj = document.getElementById("POR_TAR_PRE").value
            var tot3 = document.getElementById("TOT_POR_TAR_PRE").value;
            tot2 = (tot1 * (pordscto / 100)).toFixed();
            tot3 = ((tot1 - tot2) * (portarj / 100)).toFixed();
            $("#TOT_POR_DSCTO_PRE").val(tot2);
            $("#TOT_POR_TAR_PRE").val(tot3);
            console.log(tot1, tot2, tot3);
            var suma = parseInt(tot1) - parseInt(tot2) + parseInt(tot3);
            $("#TOT_PAG_PRE").val(suma);
            $("#MODEL_PRESUPUESTO_PRE_DEN_PAC").focus();
            var filCount = $("#tblTratamiento tbody tr").length;
            if (filCount == 0) {
                $('#btnRegistro').attr("disabled", true);
                fila_ana_pre = 1;
            }
        }
    } catch (err) {
        console.error(err);
    }
  
}

var fila_ana_pre = 1;

function Cod_Profe_Presup() {
    // Accedemos al input
    var ValorValidacion = $("#MODEL_PRESUPUESTO_PRE_COD_ODON").val(); // Obtenemos el Valor del campo Valor
    console.log(ValorValidacion);
    var nom_pro = ValorValidacion.substring(5, 20);
    var cod_pro = ValorValidacion.substring(0, 4);
    const options = {
        month: '2-digit',
        day: '2-digit',
        year: 'numeric',
    };
    var hoy = new Date().toLocaleDateString('en-US', options);
    var hoy2 = new Date();
    var fecha = hoy2.getDate() + '-' + (hoy2.getMonth() + 1) + '-' + hoy2.getFullYear();
    currentHours = hoy2.getHours();
    currentHours = ("0" + currentHours).slice(-2);
    currentMinutes = hoy2.getMinutes();
    currentMinutes = ("0" + currentMinutes).slice(-2);
    currentSeconds = hoy2.getSeconds();
    currentSeconds = ("0" + currentSeconds).slice(-2);
    var hora = currentHours + ':' + currentMinutes + ':' + currentHours;
    var fechaYHora = hoy + ' ' + hora;
    $("#ela_fec_pre").val(fechaYHora);
    $("#cod_pro_pre").val(cod_pro);
    $("#nom_pro_pre").val(nom_pro);
}

function AnadirFilaPresup(event) {
    let hasError = false;
    var a = $("#MODEL_PRESUPUESTO_PRE_COD").val();
    var b = $("#Nom_Pac").val();
    var c = $("#MODEL_PRESUPUESTO_PRE_COD_ODON").val();
    var d = $("#Rut_Pac").val();
    var e = $("#MODEL_PRESUPUESTO_PRE_DEN_PAC").val();
    var f = $("#MODEL_PRESUPUESTO_PRE_PIE_DEN").val();
    var g = $("#MODEL_PRESUPUESTO_PRE_TRA_PAC").val();
    var h = $("#MODEL_PRESUPUESTO_PRE_VAL_PRE").val();
    var i = $("#MODEL_PRESUPUESTO_PRE_VAL_POR").val();
    var j = $("#MODEL_PRESUPUESTO_PRE_VAL_DES").val();
    var k = $("#MODEL_PRESUPUESTO_PRE_VAL_SUB").val();
    if ($("#MODEL_PRESUPUESTO_PRE_COD").val() == null || $("#MODEL_PRESUPUESTO_PRE_COD").val().length == 0) {
        console.log("ERROR: MODEL_PRESUPUESTO_PRE_COD");
        hasError = true;
    }
    else if ($("#Nom_Pac").val() == null || $("#Nom_Pac").val().length == 0) {
        console.log("ERROR: Nom_Pac");
        hasError = true;
    }
    else if ($("#MODEL_PRESUPUESTO_PRE_COD_ODON").val() == null || $("#MODEL_PRESUPUESTO_PRE_COD_ODON").val().length == 0) {
        alert('Clínica Equilibrium, Realiza la Selección del Profesional');
        console.log("ERROR: PRE_COD_ODON");
        $("#MODEL_PRESUPUESTO_PRE_COD_ODON").focus();
        hasError = true;
    }
    else if ($("#Rut_Pac").val() == null || $("#Rut_Pac").val().length == 0) {
        console.log("ERROR: Rut_Pac");
        hasError = true;
    }
    else if ($("#MODEL_PRESUPUESTO_PRE_DEN_PAC").val() == null || $("#MODEL_PRESUPUESTO_PRE_DEN_PAC").val().length == 0) {
        alert('Clínica Equilibrium, Realiza la Selección de la Dentadura');
        console.log("ERROR: PRE_DEN_PAC");
        $("#MODEL_PRESUPUESTO_PRE_DEN_PAC").focus();
        hasError = true;
    }
    else if ($("#MODEL_PRESUPUESTO_PRE_PIE_DEN").val() == null || $("#MODEL_PRESUPUESTO_PRE_PIE_DEN").val().length == 0) {
        alert('Clínica Equilibrium, Realiza la Selección de la Pieza Dental');
        console.log("ERROR: PRE_PIE_DEN");
        $("#MODEL_PRESUPUESTO_PRE_PIE_DEN").focus();
        hasError = true;
    }
    else if ($("#MODEL_PRESUPUESTO_PRE_TRA_PAC").val() == null || $("#MODEL_PRESUPUESTO_PRE_TRA_PAC").val().length == 0) {
        alert('Clínica Equilibrium, Realiza la Selección del Tratamiento');
        console.log("ERROR: PRE_TRA_PAC");
        $("#MODEL_PRESUPUESTO_PRE_TRA_PAC").focus();
        hasError = true;
    }
    else {
        hasError = false;
        if ($("#MODEL_PRESUPUESTO_PRE_COD").val() != null && $("#Nom_Pac").val() != null && $("#MODEL_PRESUPUESTO_PRE_COD_ODON").val() != null
            && $("#Rut_Pac").val() != null && $("#MODEL_PRESUPUESTO_PRE_DEN_PAC").val() != null && $("#MODEL_PRESUPUESTO_PRE_PIE_DEN").val() != null
            && $("#MODEL_PRESUPUESTO_PRE_TRA_PAC").val() != null) {
            var cadena = c.substring(5, 20);
            $("#tblTratamiento tbody").append("<tr><td id=" + fila_ana_pre + ">" + fila_ana_pre + "</td><td >" + a + "</td><td>" + b + "</td><td>" + cadena + "</td><td>" + d +
                "</td><td> <input asp-for=MODEL_PRESUPUESTO.PRE_DEN_PAC type=hidden >" + e +
                "</td><td>" + f + "</td><td>" + g + "</td><td>" + h + "</td><td>" + i + "</td><td>" + j + "</td><td>" + k + "</td><td>" +
                "<button type='button' id='btnDelete"+ fila_ana_pre+"' class='btn bg-info btn-block text-light' onclick='BorrarFilaPresupuesto(event)'>ELIMINAR" +
                "</button>" + "</td></tr > ");
            fila_ana_pre++;
            console.log(($("table#tblTratamiento tr:last").index() + 1));
            $("#MODEL_PRESUPUESTO_PRE_DEN_PAC").val('');
            $("#MODEL_PRESUPUESTO_PRE_PIE_DEN").val('');
            $("#MODEL_PRESUPUESTO_PRE_TRA_PAC").val('');
            $("#MODEL_PRESUPUESTO_PRE_VAL_PRE").val('0');
            $("#MODEL_PRESUPUESTO_PRE_VAL_POR").val('0');
            $("#MODEL_PRESUPUESTO_PRE_VAL_DES").val('0');
            $("#MODEL_PRESUPUESTO_PRE_VAL_SUB").val('0');

            var total_col = 0;
            $("#tblTratamiento tbody").find("tr").each(function (i, el) {

                //Voy incrementando las variables segun la fila ( .eq(0) representa la fila 1 )     
                total_col += parseInt($(this).find("td").eq(11).text());
            });
            //Muestro el resultado en el th correspondiente a la columna
            $("#SUB_TOT_PRE").val(total_col);
            var tot1 = document.getElementById("SUB_TOT_PRE").value
            var pordscto = document.getElementById("POR_DSCTO_PRE").value
            var tot2 = document.getElementById("TOT_POR_DSCTO_PRE").value;
            var portarj = document.getElementById("POR_TAR_PRE").value
            var tot3 = document.getElementById("TOT_POR_TAR_PRE").value;
            tot2 = (tot1 * (pordscto / 100)).toFixed();
            tot3 = ((tot1 - tot2) * (portarj / 100)).toFixed();
            $("#TOT_POR_DSCTO_PRE").val(tot2);
            $("#TOT_POR_TAR_PRE").val(tot3);
            console.log(tot1, tot2, tot3);
            var suma = parseInt(tot1) - parseInt(tot2) + parseInt(tot3);
            $("#TOT_PAG_PRE").val(suma);
            $("#MODEL_PRESUPUESTO_PRE_DEN_PAC").focus();
            $('#btnRegistro').attr("disabled", false); 
            hasError = false;
        }
        else {
            hasError = true;
            console.log("ERROR:! NO SE INGRESA NINGUNA FILA");
            event.preventDefault();
        }
        //});
        //else {
        //    hasError = true;
        //    console.log("ERROR:! SOLO SE PERMITE 30 FILAS");
        //    event.preventDefault();
        //}
    }
}

function Guardar_Presupuesto() {
    $.post(
        "Get_Presupuesto",
        $('.formPresupuesto').serialize(),
        (response) => {
            try {
                var item = JSON.parse(response);
                if (item.Code == "Done") {
                    window.location.href = "Index";
                } else {
                    document.getElementById("mensaje").innerHTML = item.Description;
                }
            } catch (e) {
                document.getElementById("mensaje").innerHTML = response;
            }

            console.log(response);
        }
    );
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
                        mOptions += `<option value="${row.piE_PIEZA}">${row.piE_PIEZA}</option>`;
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

function Dscto_Tot_Pag_Presup() {
    // Accedemos al input
    
    if (parseInt($("#POR_DSCTO_PRE").val()) == 0) {
        var ValorValidacion = $("#SUB_TOT_PRE").val(); // Obtenemos el Valor del campo Valor
        var PorcDsctoValidacion = $("#POR_DSCTO_PRE").val(); // Obtenemos el Valor del campo Porcentaje Dscto
        var PorcTarValidacion = $("#POR_TAR_PRE").val(); // Obtenemos el Valor del campo Porcentaje Tarjeta
        var TotPorcValidacion = $("#TOT_POR_DSCTO_PRE").val(); // Obtenemos el Valor del campo Total Porcentaje Dscto
        var TotTarValidacion = $("#TOT_POR_TAR_PRE").val(); // Obtenemos el Valor del campo Total Porcentaje Tarjeta
        var tmpPRE_VAL_DESCT = (ValorValidacion * (PorcDsctoValidacion / 100)).toFixed();
        $("#TOT_POR_DSCTO_PRE").val(tmpPRE_VAL_DESCT);
        TotPorcValidacion = $("#TOT_POR_DSCTO_PRE").val()
        var tmpPRE_VAL_TAR = ((ValorValidacion - TotPorcValidacion) * (PorcTarValidacion / 100)).toFixed();
        console.log(ValorValidacion, TotPorcValidacion ,PorcTarValidacion)
        $("#TOT_POR_TAR_PRE").val(tmpPRE_VAL_TAR);
        var totPag = ValorValidacion - parseInt(tmpPRE_VAL_DESCT) + parseInt(tmpPRE_VAL_TAR);
        $("#TOT_PAG_PRE").val(totPag);
    }
    else if (parseInt($("#POR_DSCTO_PRE").val()) != 0) {
        var ValorValidacion = $("#SUB_TOT_PRE").val(); // Obtenemos el Valor del campo Valor
        var PorcDsctoValidacion = $("#POR_DSCTO_PRE").val(); // Obtenemos el Valor del campo Porcentaje Dscto
        var PorcTarValidacion = $("#POR_TAR_PRE").val(); // Obtenemos el Valor del campo Porcentaje Tarjeta
        var TotPorcValidacion = $("#TOT_POR_DSCTO_PRE").val(); // Obtenemos el Valor del campo Total Porcentaje Dscto
        var TotTarValidacion = $("#TOT_POR_TAR_PRE").val(); // Obtenemos el Valor del campo Total Porcentaje Tarjeta
        var tmpPRE_VAL_DESCT = (ValorValidacion * (PorcDsctoValidacion / 100)).toFixed();
        $("#TOT_POR_DSCTO_PRE").val(tmpPRE_VAL_DESCT);
        TotPorcValidacion = $("#TOT_POR_DSCTO_PRE").val()
        var tmpPRE_VAL_TAR = ((ValorValidacion - TotPorcValidacion) * (PorcTarValidacion / 100)).toFixed();
        console.log(ValorValidacion, TotPorcValidacion, PorcTarValidacion)
        $("#TOT_POR_TAR_PRE").val(tmpPRE_VAL_TAR);
        var totPag = ValorValidacion - parseInt(tmpPRE_VAL_DESCT) + parseInt(tmpPRE_VAL_TAR);
        $("#TOT_PAG_PRE").val(totPag);
    }
}

function Tarjeta_Tot_Pag_Presup() {
    // Accedemos al input
    if (parseInt($("#POR_TAR_PRE").val()) == 0) {
        var ValorValidacion = $("#SUB_TOT_PRE").val(); // Obtenemos el Valor del campo Valor
        var PorcDsctoValidacion = $("#POR_DSCTO_PRE").val(); // Obtenemos el Valor del campo Porcentaje Dscto
        var PorcTarValidacion = $("#POR_TAR_PRE").val(); // Obtenemos el Valor del campo Porcentaje Tarjeta
        var TotPorcValidacion = $("#TOT_POR_DSCTO_PRE").val(); // Obtenemos el Valor del campo Total Porcentaje Dscto
        var TotTarValidacion = $("#TOT_POR_TAR_PRE").val(); // Obtenemos el Valor del campo Total Porcentaje Tarjeta
        var tmpPRE_VAL_DESCT = (ValorValidacion * (PorcDsctoValidacion / 100)).toFixed();
        $("#TOT_POR_DSCTO_PRE").val(tmpPRE_VAL_DESCT);
        TotPorcValidacion = $("#TOT_POR_DSCTO_PRE").val()
        var tmpPRE_VAL_TAR = ((ValorValidacion - TotPorcValidacion) * (PorcTarValidacion / 100)).toFixed();
        console.log(ValorValidacion, TotPorcValidacion, PorcTarValidacion)
        $("#TOT_POR_TAR_PRE").val(tmpPRE_VAL_TAR);
        var totPag = ValorValidacion - parseInt(tmpPRE_VAL_DESCT) + parseInt(tmpPRE_VAL_TAR);
        $("#TOT_PAG_PRE").val(totPag);
    }
    else if (parseInt($("#POR_TAR_PRE").val()) != 0) {
        var ValorValidacion = $("#SUB_TOT_PRE").val(); // Obtenemos el Valor del campo Valor
        var PorcDsctoValidacion = $("#POR_DSCTO_PRE").val(); // Obtenemos el Valor del campo Porcentaje Dscto
        var PorcTarValidacion = $("#POR_TAR_PRE").val(); // Obtenemos el Valor del campo Porcentaje Tarjeta
        var TotPorcValidacion = $("#TOT_POR_DSCTO_PRE").val(); // Obtenemos el Valor del campo Total Porcentaje Dscto
        var TotTarValidacion = $("#TOT_POR_TAR_PRE").val(); // Obtenemos el Valor del campo Total Porcentaje Tarjeta
        var tmpPRE_VAL_DESCT = (ValorValidacion * (PorcDsctoValidacion / 100)).toFixed();
        $("#TOT_POR_DSCTO_PRE").val(tmpPRE_VAL_DESCT);
        TotPorcValidacion = $("#TOT_POR_DSCTO_PRE").val()
        var tmpPRE_VAL_TAR = ((ValorValidacion - TotPorcValidacion) * (PorcTarValidacion / 100)).toFixed();
        console.log(ValorValidacion, TotPorcValidacion, PorcTarValidacion)
        $("#TOT_POR_TAR_PRE").val(tmpPRE_VAL_TAR);
        var totPag = ValorValidacion - parseInt(tmpPRE_VAL_DESCT) + parseInt(tmpPRE_VAL_TAR);
        $("#TOT_PAG_PRE").val(totPag);
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