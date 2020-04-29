Public Class eliminacontroller_query
    Inherits lingua

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim codice_impianto As String = ""
        Dim id_impianto As String = ""
        Dim tipoStrumento_impianto As String = ""
        Dim risultato_query As Boolean
        Dim risultato_queryINT As Integer = 0
        Dim query As New query
        Dim temporaneo_id As String = ""

        codice_impianto = Page.Request("codice_generale")
        id_impianto = Page.Request("id485")
        tipoStrumento_impianto = Page.Request("tipoStrumento")

        temporaneo_id = Str(Val(id_impianto))
        temporaneo_id = temporaneo_id.Replace(" ", "")
        Dim id_string As String = Format(Val(temporaneo_id), "00")


        If (codice_impianto = "128718") Or (codice_impianto = "912601") Then
            risultato_query = True
        Else
            risultato_query = query.delete_strumenti_codice(codice_impianto, id_impianto)
            Select Case tipoStrumento_impianto
                Case "max5" 'Replace(nome_impanto, " ", "£") 
                    risultato_queryINT = query.delete_log_max5(codice_impianto, id_string, temporaneo_id)
                Case "LDtower"
                    risultato_queryINT = query.delete_log_tower(codice_impianto, id_string, temporaneo_id)
                Case "Tower"
                    risultato_queryINT = query.delete_log_tower(codice_impianto, id_string, temporaneo_id)
                'items_tower(riga, check_connected)
                Case "LD"
                    risultato_queryINT = query.delete_log_ld(codice_impianto, id_string, temporaneo_id)
                'items_ld(riga, check_connected)
                Case "LDDT"
                    risultato_queryINT = query.delete_log_ld(codice_impianto, id_string, temporaneo_id)
                'items_ld(riga, check_connected)
                Case "LDD4"
                    risultato_queryINT = query.delete_log_ld4(codice_impianto, id_string, temporaneo_id)
                'items_ld(riga, check_connected)
                Case "LDMA"
                    risultato_queryINT = query.delete_log_ldma(codice_impianto, id_string, temporaneo_id)
                Case "LDLG"
                    risultato_queryINT = query.delete_log_ldlg(codice_impianto, id_string, temporaneo_id)
                Case "LDS"
                    risultato_queryINT = query.delete_log_ld(codice_impianto, id_string, temporaneo_id)                'items_lds(riga, check_connected)
                Case "LD4"
                    risultato_queryINT = query.delete_log_ld4(codice_impianto, id_string, temporaneo_id)
                Case "WD"
                    risultato_queryINT = query.delete_log_wd(codice_impianto, id_string, temporaneo_id)
                Case "WH"
                    risultato_queryINT = query.delete_log_wh(codice_impianto, id_string, temporaneo_id)
                Case "LTB"
                    risultato_queryINT = query.delete_log_ltb(codice_impianto, id_string, temporaneo_id)
                Case "LTA"
                    risultato_queryINT = query.delete_log_lta_ltu_ltd(codice_impianto, id_string, temporaneo_id)
                Case "LTD"
                    risultato_queryINT = query.delete_log_lta_ltu_ltd(codice_impianto, id_string, temporaneo_id)
                Case "LTU"
                    risultato_queryINT = query.delete_log_lta_ltu_ltd(codice_impianto, id_string, temporaneo_id)
            End Select
        End If

        If risultato_query Then
            Master.create_master_page()
            Master.manage_sidebar_top()
            Response.Redirect("eliminaController.aspx?result=1&niente=0")
        Else
            Response.Redirect("eliminaController.aspx?result=2&niente=0")
        End If
    End Sub

End Class