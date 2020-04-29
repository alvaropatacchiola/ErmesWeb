

function enable_Circulation() {
    $("#enable_value_Circulation").show();
}
function disable_Circulation() {
   
    $("#enable_value_Circulation").hide();
}
$("#Circulation_disable").click(function () {
    disable_Circulation();
});
$("#Circulation_enable").click(function () {
    enable_Circulation();
});


$("#save_Circulation_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_Circulation_new').next('p').remove();
   
    
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;
});