﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var principal = new js_Principal();

/*CODIGO DE USUARIOS*/
var user = new js_Usuario();
var imageUser = (evt) => {
    user.archivo(evt, "imageUser");
}

/*CODIGO DE PACIENTES*/
var paciente = new js_Paciente();
var imagePaciente = (evt) => {
    paciente.archivo(evt, "imagePaciente");
}

$().ready(()=>{
    let URLactual = window.location.pathname;
    principal.userLink(URLactual);
});