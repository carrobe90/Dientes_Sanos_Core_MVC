class js_Principal {
    userLink(URLactual) {
        let url = "";
        let cadena = URLactual.split("/");
        for (var i = 0; i < cadena.length; i++) {
            if (cadena[i] != "Index") {
                url += cadena[i];
            }
        }
        switch (url) {
            case "UsersRegistro": //AÑADIR UN CASE POR CADA VIEW QUE VAS A USAR PARA SUBIR UNA IMAGEN
                //('change', AQUI VA LA DEFINICION QUE USAS EN EL SITE.JS AL DEFNIR LA CLASE, false);
                document.getElementById('files').addEventListener('change', imageUser, false);
                break;
            case "PacienteRegistro": //AÑADIR UN CASE POR CADA VIEW QUE VAS A USAR PARA SUBIR UNA IMAGEN
                //('change', AQUI VA LA DEFINICION QUE USAS EN EL SITE.JS AL DEFNIR LA CLASE, false);
                document.getElementById('files').addEventListener('change', imagePaciente, false);
                break;
        }
    }
}