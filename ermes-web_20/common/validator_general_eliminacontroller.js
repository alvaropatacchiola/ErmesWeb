var error_general = false;
var codice_generle;
var id_generle;
var tipoStrumento_generale;
function elimina_controller(gruppo, codice, id485,codiceOK,tipoStrumento) {
    error_general = true;
    notification['confirm'] = delete_controller + " " + gruppo + "-" + codice + "?";
    notification['annulla'] = annulla_impianto;
    codice_generle = codiceOK;
    id_generle = id485;
    tipoStrumento_generale = tipoStrumento;
}
function myFunction() {
    window.location.href = "eliminacontroller_query.aspx?codice_generale=" + codice_generle + "&id485=" + id_generle + "&tipoStrumento=" + tipoStrumento_generale;
}