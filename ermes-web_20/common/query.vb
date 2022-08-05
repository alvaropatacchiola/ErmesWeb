Public Class query
    Public db_data_super As quey_dbTableAdapters.super_userTableAdapter = New quey_dbTableAdapters.super_userTableAdapter
    Public db_data_user As quey_dbTableAdapters.userTableAdapter = New quey_dbTableAdapters.userTableAdapter
    Public db_data_impianto As quey_dbTableAdapters.impianto_newTableAdapter = New quey_dbTableAdapters.impianto_newTableAdapter
    Public db_data_strumenti As quey_dbTableAdapters.strumentiTableAdapter = New quey_dbTableAdapters.strumentiTableAdapter
    Public db_data_log_max5 As quey_dbTableAdapters.logTableAdapter = New quey_dbTableAdapters.logTableAdapter
    Public table_data_log_max5 As ermes_web_20.quey_db.logDataTable = New ermes_web_20.quey_db.logDataTable
    Public table_data_log_tower As ermes_web_20.quey_db.log_towerDataTable = New ermes_web_20.quey_db.log_towerDataTable
    Public table_data_log_ld As ermes_web_20.quey_db.ld_logDataTable = New ermes_web_20.quey_db.ld_logDataTable
    Public table_data_log_ld4 As ermes_web_20.quey_db.ld4_logDataTable = New ermes_web_20.quey_db.ld4_logDataTable
    Public table_data_log_wd As ermes_web_20.quey_db.wd_logDataTable = New ermes_web_20.quey_db.wd_logDataTable
    Public table_data_log_wh As ermes_web_20.quey_db.wh_logDataTable = New ermes_web_20.quey_db.wh_logDataTable
    Public table_data_log_ltb As ermes_web_20.quey_db.ltb_logDataTable = New ermes_web_20.quey_db.ltb_logDataTable
    Public table_data_log_lta_ltu_ltd As ermes_web_20.quey_db.log_lta_ltu_ltdDataTable = New ermes_web_20.quey_db.log_lta_ltu_ltdDataTable
    Public table_data_log_ldma As ermes_web_20.quey_db.log_ldmaDataTable = New ermes_web_20.quey_db.log_ldmaDataTable
    Public table_data_log_ldlg As ermes_web_20.quey_db.log_ldlgDataTable = New ermes_web_20.quey_db.log_ldlgDataTable


    Public db_data_log_ld As quey_dbTableAdapters.ld_logTableAdapter = New quey_dbTableAdapters.ld_logTableAdapter
    Public db_data_log_ld4 As quey_dbTableAdapters.ld4_logTableAdapter = New quey_dbTableAdapters.ld4_logTableAdapter
    Public db_data_log_wd As quey_dbTableAdapters.wd_logTableAdapter = New quey_dbTableAdapters.wd_logTableAdapter
    Public db_data_log_wh As quey_dbTableAdapters.wh_logTableAdapter = New quey_dbTableAdapters.wh_logTableAdapter
    Public db_data_log_ltb As quey_dbTableAdapters.ltb_logTableAdapter = New quey_dbTableAdapters.ltb_logTableAdapter
    Public db_data_log_lta_ltu_ltd As quey_dbTableAdapters.log_lta_ltu_ltdTableAdapter = New quey_dbTableAdapters.log_lta_ltu_ltdTableAdapter

    Public db_data_log_tower As quey_dbTableAdapters.log_towerTableAdapter = New quey_dbTableAdapters.log_towerTableAdapter

    Public db_data_log_ldma As quey_dbTableAdapters.log_ldmaTableAdapter = New quey_dbTableAdapters.log_ldmaTableAdapter
    Public db_data_log_ldlg As quey_dbTableAdapters.log_ldlgTableAdapter = New quey_dbTableAdapters.log_ldlgTableAdapter
    ' api json
    Public db_data_apiJson As quey_dbTableAdapters.webServiceTableAdapter = New quey_dbTableAdapters.webServiceTableAdapter

    ' centurio configurazione
    Public db_data_xml_runtime As centurioQueryTableAdapters.centurioConfigTableAdapter = New centurioQueryTableAdapters.centurioConfigTableAdapter
    Public db_data_xml_probeList As centurioQueryTableAdapters.xmlConfigTableAdapter = New centurioQueryTableAdapters.xmlConfigTableAdapter
    Public db_data_xml_configGlobal As centurioQueryTableAdapters.xmlConfigGlobalTableAdapter = New centurioQueryTableAdapters.xmlConfigGlobalTableAdapter
    ' database serial Number
    Public db_serialNumber As quey_dbTableAdapters.typeSerialNumberTableAdapter = New quey_dbTableAdapters.typeSerialNumberTableAdapter

    ' database serial Number
    Public Function getTypeSerialNumber(ByVal serialNumber As String) As ermes_web_20.quey_db.typeSerialNumberDataTable
        Dim i As Integer
        For i = 0 To 3
            Try
                Return db_serialNumber.GetData(serialNumber)
            Catch ex As Exception

            End Try
        Next

    End Function
    Public Function insertNewSerialPump(ByVal serialNumber As String, ByVal type As String) As Boolean
        Dim result_insert As Integer
        result_insert = db_serialNumber.InsertQuery(Now, serialNumber, CInt(type))
        If result_insert > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function getJSONEnable(ByVal username As String, ByVal password As String, ByVal identificativo As String, ByRef labelAlarm As String) As Boolean
        labelAlarm = ""
        If (db_data_apiJson.GetData(username, password, identificativo).Count > 0) Then
            For Each gdc In db_data_apiJson.GetData(username, password, identificativo)
                labelAlarm = gdc.labelAlarm
                Exit For
            Next
            Return True
        Else
            Return False
        End If
    End Function
    Public Function getJSONData(ByVal username As String, ByVal password As String) As ermes_web_20.quey_db.webServiceDataTable
        Return db_data_apiJson.GetIdentificativoList(username, password)
    End Function

    Public Function getProbeList(ByVal codiceProbe As String) As ermes_web_20.centurioQuery.xmlConfigDataTable

        Dim i As Integer
        For i = 0 To 3

            Try
                ' Return db_data_xml_probeList.GetData(codiceProbe)
                Return db_data_xml_probeList.GetData()
            Catch ex As Exception

            End Try
        Next

    End Function
    Public Function getProbeType(ByVal codiceProbe As String) As ermes_web_20.centurioQuery.xmlConfigDataTable

        Dim i As Integer
        For i = 0 To 3

            Try
                ' Return db_data_xml_probeList.GetData(codiceProbe)
                Return db_data_xml_probeList.GetDataLista()
            Catch ex As Exception

            End Try
        Next

    End Function

    Public Function getRuntimeSchema(ByVal codiceSetpoint As String) As ermes_web_20.centurioQuery.centurioConfigDataTable
        Dim i As Integer
        For i = 0 To 3

            Try
                Return db_data_xml_runtime.GetData(codiceSetpoint)
            Catch ex As Exception

            End Try
        Next
    End Function
    Public Function getConfigGlobal(ByVal idConfig As Integer) As String
        Dim i As Integer
        For i = 0 To 3

            Try
                Dim tabellaRisultato As ermes_web_20.centurioQuery.xmlConfigGlobalDataTable = db_data_xml_configGlobal.GetData(idConfig)
                For Each dc1 In tabellaRisultato
                    Return dc1.xmlVal
                Next
                Return ""
            Catch ex As Exception

            End Try
        Next
        Return ""
    End Function

    Public Function getRuntimeSchemaLanguage(ByVal lingua As String, ByVal codiceSetpoint As String) As ermes_web_20.centurioQuery.centurioConfigDataTable
        Dim i As Integer
        For i = 0 To 3

            Try
                Return db_data_xml_runtime.GetDataBy(codiceSetpoint, lingua)
            Catch ex As Exception

            End Try
        Next
    End Function

    Public Function create_connection() As Boolean
        Try
            db_data_super = New quey_dbTableAdapters.super_userTableAdapter
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Public Function close_connection() As Boolean
        db_data_super.Connection.Close()
    End Function
    Public Function login_super_user(ByVal username As String, ByVal password As String) As ermes_web_20.quey_db.super_userDataTable
        Dim i As Integer
        For i = 0 To 3
            Try
                Return db_data_super.GetData(username, password)
            Catch ex As Exception

            End Try
        Next

    End Function
    Public Function login_super_user_Personalizzazione(ByVal id_super As System.Guid) As ermes_web_20.quey_db.super_userDataTable
        Dim i As Integer
        For i = 0 To 3
            Try
                Return db_data_super.getPersonalizzazione(id_super)
            Catch ex As Exception

            End Try
        Next

    End Function
    Public Function get_mail_super(ByVal mail As String) As ermes_web_20.quey_db.super_userDataTable
        Dim i As Integer
        For i = 0 To 3
            Try

                Return db_data_super.get_data_mail(mail)
            Catch ex As Exception

            End Try
        Next

    End Function

    Public Function update_super_user(ByVal username As String, ByVal password As String, ByVal azienda_persona As String, ByVal mail As String, ByVal id_super As System.Guid, ByVal colorBody As String, ByVal colorSide As String, ByVal colorPrimary As String, ByVal colorLink As String) As Boolean
        Dim update_row As Integer
        update_row = db_data_super.update_super(Now, username, password, azienda_persona, mail, colorBody, colorSide, colorPrimary, colorLink, id_super)
        If update_row > 0 Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function update_super_userLogo(ByVal id_super As System.Guid, ByVal colorBody As String, ByVal colorSide As String, ByVal colorPrimary As String, ByVal colorLink As String, ByVal logo As String, ByVal aziendaPersonalizzazione As String) As Boolean
        Dim update_row As Integer
        update_row = db_data_super.UpdateQueryFile(colorBody, colorSide, logo, colorPrimary, aziendaPersonalizzazione, colorLink, id_super)
        If update_row > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function login_user(ByVal username As String, ByVal password As String) As ermes_web_20.quey_db.userDataTable
        Dim i As Integer
        For i = 0 To 3
            Try
                Return db_data_user.GetData(username, password)
            Catch ex As Exception

            End Try
        Next
    End Function
    Public Function get_impianto_super(ByVal username As String, ByVal password As String) As ermes_web_20.quey_db.impianto_newDataTable
        Dim i As Integer
        For i = 0 To 3
            Try
                Return db_data_impianto.GetData_super(username, password)
            Catch ex As Exception

            End Try
        Next
    End Function
    Public Function get_impianto_user(ByVal username As String, ByVal password As String) As ermes_web_20.quey_db.impianto_newDataTable
        Dim i As Integer
        For i = 0 To 3
            Try
                Return db_data_impianto.GetData_user(username, password)
            Catch ex As Exception

            End Try
        Next
    End Function
    Public Function get_lista_impianti_user(ByVal id_user As String) As ermes_web_20.quey_db.impianto_newDataTable
        Dim i As Integer
        For i = 0 To 3
            Try
                Return db_data_impianto.get_impianto_user(id_user)
            Catch ex As Exception

            End Try
        Next
    End Function

    Public Function get_strumenti_super(ByVal username As String, ByVal password As String) As ermes_web_20.quey_db.strumentiDataTable
        Dim i As Integer

        For i = 0 To 3
            Try
                Return db_data_strumenti.GetData_super(username, password)
            Catch ex As Exception

            End Try
        Next
    End Function
    Public Function get_strumenti_codice(ByVal codice As String, Optional ByVal id_485_impianto As String = "01") As ermes_web_20.quey_db.strumentiDataTable
        Dim i As Integer
        For i = 0 To 3
            Try
                Return db_data_strumenti.get_data_codice(codice, id_485_impianto)
            Catch ex As Exception

            End Try
        Next
    End Function
    Public Function get_strumenti_codice_list(ByVal codice As String) As ermes_web_20.quey_db.strumentiDataTable
        Dim i As Integer
        For i = 0 To 3
            Try
                Return db_data_strumenti.GetNumeroStrumenti(codice)
            Catch ex As Exception

            End Try
        Next
    End Function
    Public Function delete_strumenti_codice(ByVal codice As String, ByVal id485 As String) As Integer
        Dim i As Integer
        For i = 0 To 3
            Try
                Return db_data_strumenti.DeleteQuery(codice, id485)
            Catch ex As Exception

            End Try
        Next
    End Function


    Public Function get_strumenti_user(ByVal username As String, ByVal password As String) As ermes_web_20.quey_db.strumentiDataTable
        Dim i As Integer
        For i = 0 To 3
            Try
                Return db_data_strumenti.GetData_user(username, password)
            Catch ex As Exception

            End Try
        Next
    End Function
    Public Function get_log_max5(ByVal codice As String, ByVal id_485 As String, ByVal id_485_1 As String, ByVal data1 As Date, ByVal data2 As Date) As ermes_web_20.quey_db.logDataTable
        Dim i As Integer
        For i = 0 To 3
            Try
                table_data_log_max5 = db_data_log_max5.GetData(codice, id_485, id_485_1, data1, data2)
                Return table_data_log_max5
            Catch ex As Exception

            End Try
        Next
    End Function
    Public Function delete_log_max5(ByVal codice As String, ByVal id_485 As String, ByVal id_485_1 As String) As Integer
        Dim i As Integer
        For i = 0 To 3
            Try
                Return db_data_log_max5.DeleteQuery(codice, id_485, id_485_1)

            Catch ex As Exception

            End Try
        Next
    End Function

    Public Function get_log_tower(ByVal codice As String, ByVal id_485 As String, ByVal id_485_1 As String, ByVal data1 As Date, ByVal data2 As Date) As ermes_web_20.quey_db.log_towerDataTable
        Dim i As Integer
        For i = 0 To 3
            Try
                table_data_log_tower = db_data_log_tower.GetData(codice, id_485, id_485_1, data1, data2)
                Return table_data_log_tower
            Catch ex As Exception

            End Try
        Next
    End Function
    Public Function delete_log_tower(ByVal codice As String, ByVal id_485 As String, ByVal id_485_1 As String) As Integer
        Dim i As Integer
        For i = 0 To 3
            Try
                Return db_data_log_tower.DeleteQuery(codice, id_485, id_485_1)
            Catch ex As Exception

            End Try
        Next
    End Function

    Public Function get_log_ld(ByVal codice As String, ByVal id_485 As String, ByVal id_485_1 As String, ByVal data1 As Date, ByVal data2 As Date) As ermes_web_20.quey_db.ld_logDataTable
        Dim i As Integer
        For i = 0 To 3
            Try
                table_data_log_ld = db_data_log_ld.GetData(codice, id_485, id_485_1, data1, data2)
                Return table_data_log_ld
            Catch ex As Exception

            End Try
        Next
    End Function
    Public Function delete_log_ld(ByVal codice As String, ByVal id_485 As String, ByVal id_485_1 As String) As Integer
        Dim i As Integer
        For i = 0 To 3
            Try
                Return db_data_log_ld.DeleteQuery(codice, id_485, id_485_1)
            Catch ex As Exception

            End Try
        Next
    End Function

    Public Function get_log_ld4(ByVal codice As String, ByVal id_485 As String, ByVal id_485_1 As String, ByVal data1 As Date, ByVal data2 As Date) As ermes_web_20.quey_db.ld4_logDataTable
        Dim i As Integer
        For i = 0 To 3
            Try
                table_data_log_ld4 = db_data_log_ld4.GetData(codice, id_485, id_485_1, data1, data2)
                Return table_data_log_ld4
            Catch ex As Exception

            End Try
        Next
    End Function
    Public Function delete_log_ld4(ByVal codice As String, ByVal id_485 As String, ByVal id_485_1 As String) As Integer
        Dim i As Integer
        For i = 0 To 3
            Try
                Return db_data_log_ld4.DeleteQuery(codice, id_485, id_485_1)
            Catch ex As Exception

            End Try
        Next
    End Function

    Public Function get_log_wd(ByVal codice As String, ByVal id_485 As String, ByVal id_485_1 As String, ByVal data1 As Date, ByVal data2 As Date) As ermes_web_20.quey_db.wd_logDataTable
        Dim i As Integer
        For i = 0 To 3
            Try
                table_data_log_wd = db_data_log_wd.GetData(codice, id_485, id_485_1, data1, data2)
                Return table_data_log_wd
            Catch ex As Exception

            End Try
        Next
    End Function
    Public Function delete_log_wd(ByVal codice As String, ByVal id_485 As String, ByVal id_485_1 As String) As Integer
        Dim i As Integer
        For i = 0 To 3
            Try
                Return db_data_log_wd.DeleteQuery(codice, id_485, id_485_1)
            Catch ex As Exception

            End Try
        Next
    End Function

    Public Function get_log_wh(ByVal codice As String, ByVal id_485 As String, ByVal id_485_1 As String, ByVal data1 As Date, ByVal data2 As Date) As ermes_web_20.quey_db.wh_logDataTable
        Dim i As Integer
        For i = 0 To 3
            Try
                table_data_log_wh = db_data_log_wh.GetData(codice, id_485, id_485_1, data1, data2)
                Return table_data_log_wh
            Catch ex As Exception

            End Try
        Next
    End Function
    Public Function delete_log_wh(ByVal codice As String, ByVal id_485 As String, ByVal id_485_1 As String) As Integer
        Dim i As Integer
        For i = 0 To 3
            Try
                Return db_data_log_wh.DeleteQuery(codice, id_485, id_485_1)
            Catch ex As Exception

            End Try
        Next
    End Function

    Public Function get_log_ltb(ByVal codice As String, ByVal id_485 As String, ByVal id_485_1 As String, ByVal data1 As Date, ByVal data2 As Date) As ermes_web_20.quey_db.ltb_logDataTable
        Dim i As Integer
        For i = 0 To 3
            Try
                table_data_log_ltb = db_data_log_ltb.GetData(codice, id_485, id_485_1, data1, data2)
                Return table_data_log_ltb
            Catch ex As Exception

            End Try
        Next
    End Function
    Public Function delete_log_ltb(ByVal codice As String, ByVal id_485 As String, ByVal id_485_1 As String) As Integer
        Dim i As Integer
        For i = 0 To 3
            Try
                Return db_data_log_ltb.DeleteQuery(codice, id_485, id_485_1)
            Catch ex As Exception

            End Try
        Next
    End Function

    Public Function get_log_lta_ltu_ltd(ByVal codice As String, ByVal id_485 As String, ByVal id_485_1 As String, ByVal data1 As Date, ByVal data2 As Date) As ermes_web_20.quey_db.log_lta_ltu_ltdDataTable
        Dim i As Integer
        For i = 0 To 3
            Try
                table_data_log_lta_ltu_ltd = db_data_log_lta_ltu_ltd.GetData(codice, id_485, id_485_1, data1, data2)
                Return table_data_log_lta_ltu_ltd
            Catch ex As Exception

            End Try
        Next
    End Function
    Public Function delete_log_lta_ltu_ltd(ByVal codice As String, ByVal id_485 As String, ByVal id_485_1 As String) As Integer
        Dim i As Integer
        For i = 0 To 3
            Try
                Return db_data_log_lta_ltu_ltd.DeleteQuery(codice, id_485, id_485_1)
            Catch ex As Exception

            End Try
        Next
    End Function

    Public Function get_log_ldma(ByVal codice As String, ByVal id_485 As String, ByVal id_485_1 As String) As ermes_web_20.quey_db.log_ldmaDataTable
        Dim i As Integer
        For i = 0 To 3
            Try
                table_data_log_ldma = db_data_log_ldma.GetData(codice, id_485, id_485_1)
                Return table_data_log_ldma
            Catch ex As Exception

            End Try
        Next
    End Function
    Public Function delete_log_ldma(ByVal codice As String, ByVal id_485 As String, ByVal id_485_1 As String) As Integer
        Dim i As Integer
        For i = 0 To 3
            Try
                Return db_data_log_ldma.DeleteQuery(codice, id_485, id_485_1)
            Catch ex As Exception

            End Try
        Next
    End Function

    Public Function get_log_ldlg(ByVal codice As String, ByVal id_485 As String, ByVal id_485_1 As String) As ermes_web_20.quey_db.log_ldlgDataTable
        Dim i As Integer
        For i = 0 To 3
            Try
                table_data_log_ldlg = db_data_log_ldlg.GetData(codice, id_485, id_485_1)
                Return table_data_log_ldlg
            Catch ex As Exception

            End Try
        Next
    End Function
    Public Function delete_log_ldlg(ByVal codice As String, ByVal id_485 As String, ByVal id_485_1 As String) As Integer
        Dim i As Integer
        For i = 0 To 3
            Try
                Return db_data_log_ldlg.DeleteQuery(codice, id_485, id_485_1)
            Catch ex As Exception

            End Try
        Next
    End Function

    Public Function check_user(ByVal username As String, ByVal password As String) As Boolean
        Dim count_super As Integer
        Dim count_user As Integer
        count_super = db_data_super.check_super_user(username, password).Count
        count_user = db_data_super.check_user(username, password).Count
        If count_super = 0 And count_user = 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function check_user_update(ByVal username As String, ByVal password As String, ByVal id_user As System.Guid) As Boolean
        Dim count_super As Integer
        Dim count_user As Integer
        count_super = db_data_super.check_super_user(username, password).Count
        count_user = db_data_super.check_user_update(username, password, id_user).Count
        If count_super = 0 And count_user = 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function check_identificativo(ByVal identificativo As String) As Boolean
        Dim count_identificativo As Integer
        Try
            count_identificativo = db_data_impianto.get_identificativo(identificativo).Count
        Catch ex As Exception
            Return True
        End Try


        If count_identificativo = 0 Then
            Return False
        Else
            Return True
        End If

    End Function
    Public Function get_identificativo(ByVal identificativo As String) As ermes_web_20.quey_db.impianto_newDataTable

        Dim i As Integer
        For i = 0 To 3
            Try
                Return db_data_impianto.GetImpiantoJQ(identificativo)
            Catch ex As Exception

            End Try
        Next
    End Function
    Public Function insert_super_user(ByVal username As String, ByVal password As String, ByVal azienda As String, ByVal mail As String) As Boolean
        Dim result_insert As Integer

        result_insert = db_data_super.Insert_super_user(Now, username, password, azienda, "active", mail, "PErmes", "#f0f1f5", "#202127", "logo.png", "#0fc54f", "#ffffff", "Ermes")
        If result_insert > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function insert_user(ByVal id_user As System.Guid, ByVal id_super As System.Guid, ByVal username As String, ByVal password As String, ByVal setpoint As Boolean, ByVal nome As String) As Boolean
        Dim result_insert As Integer
        result_insert = db_data_user.InsertQuery_user(id_user, id_super, Now, username, password, setpoint, nome)
        If result_insert > 0 Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function get_user_to_super(ByVal id_super As System.Guid) As ermes_web_20.quey_db.userDataTable
        Return db_data_user.get_user_to_super(id_super)
    End Function
    Public Function insert_impianto(ByVal id_super As Guid, ByVal id_user As String, ByVal indirizzo As String, ByVal nome_impianto As String,
                                ByVal descrizione_impianto As String, ByVal identificativo As String, ByVal referente As String, data_gestione As Date,
                                ByVal telefono_referente As String, ByVal mail_referente As String, ByVal modifica_setpoint_user As String, ByVal tipoStrumento As Integer) As Boolean
        Dim result_insert As Integer
        result_insert = db_data_impianto.InsertQuery_impianto(id_super, id_user, nome_impianto, descrizione_impianto, identificativo, referente, "", Now, "", telefono_referente, mail_referente, indirizzo, modifica_setpoint_user, False, tipoStrumento)

        If result_insert > 0 Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function update_impianto(ByVal id_user As String, ByVal indirizzo As String, ByVal nome_impianto As String,
                                ByVal descrizione_impianto As String, ByVal identificativo As String, ByVal referente As String, data_gestione As Date,
                                ByVal telefono_referente As String, ByVal mail_referente As String, ByVal modifica_setpoint_user As String, ByVal alarmMail As Boolean) As Boolean
        Dim result_update As Integer
        Try
            result_update = db_data_impianto.UpdateQuery_impianto(id_user, nome_impianto, descrizione_impianto, referente, "", Now, telefono_referente, mail_referente, indirizzo, modifica_setpoint_user, alarmMail, identificativo)
        Catch ex As Exception
            ' Return True
        End Try


        If result_update > 0 Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function update_user(ByVal id_user As Guid, ByVal utilizzatore As String, ByVal username_utilizzatore As String, ByVal password_utilizzatore As String, ByVal modifica_setpoint_user As Boolean) As Boolean
        Dim result_update As Integer
        result_update = db_data_user.Updateuser(username_utilizzatore, password_utilizzatore, modifica_setpoint_user, utilizzatore, id_user)

        If result_update > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function delete_impianto(ByVal identificativo As String) As Boolean
        Dim result_delete As Integer
        result_delete = db_data_impianto.DeleteQuery_impianto(identificativo)

        If result_delete > 0 Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function delete_user(ByVal id_user As System.Guid) As Boolean
        Dim result_delete As Integer
        result_delete = db_data_user.DeleteUser(id_user)
        If result_delete > 0 Then
            Return True
        Else
            Return False
        End If

    End Function
End Class
