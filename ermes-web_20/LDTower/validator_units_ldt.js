﻿$("#save_unit_ldtower_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_unit_ldtower_new').next('p').remove();


    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;
});