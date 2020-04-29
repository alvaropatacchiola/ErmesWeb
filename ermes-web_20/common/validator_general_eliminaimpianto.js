var error_general = false;
var codice_generle;
function elimina_impianto(gruppo,codice) {
    error_general = true;
    notification['confirm'] = delete_plant + " " + gruppo + "-" + codice + "?";
    notification['annulla'] = annulla_impianto;
    codice_generle = codice
 }
function myFunction(){
    window.location.href = "eliminaimpianto_query.aspx?codice_generale=" + codice_generle;
}