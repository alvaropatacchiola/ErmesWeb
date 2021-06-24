
function errorUpdate() {
    $('#save_modifica_account_new').next("div").remove();
    $('#save_modifica_account_new').val("Save Error")
    $('#save_modifica_account_new').after("<div class=\"text-danger small mt-1\">Update Error Try Now</div>");
}
function invalidFileFormat() {
    $('#FileUpload1').next("div").remove();
    $('#FileUpload1').after("<div class=\"text-danger small mt-1\">Invalid file extension</div>");

}
function invalidFileSize() {
    $('#FileUpload1').next("div").remove();
    $('#FileUpload1').after("<div class=\"text-danger small mt-1\">Max size 2Mbyte</div>");

}