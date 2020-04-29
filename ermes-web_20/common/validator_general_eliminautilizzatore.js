var error_general = false;
var codice_generle;
function elimina_user(id_utilizzatore, nome_utilizzatore) {
    error_general = true;
    notification['confirm'] = delete_user + " " + nome_utilizzatore + " ?";
    notification['annulla'] = annulla_impianto;
    codice_generle = id_utilizzatore
}
function myFunction() {
    window.location.href = "eliminauser_query.aspx?codice_generale=" + codice_generle;
}