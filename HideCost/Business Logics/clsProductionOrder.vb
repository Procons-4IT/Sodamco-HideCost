Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Text
Imports System

Public Class clsProductionOrder
    Inherits clsBase
    Private oEditText As SAPbouiCOM.EditText

    Public Sub New()
        MyBase.New()
    End Sub

#Region "Menu Event"
    Public Overrides Sub MenuEvent(ByRef pVal As SAPbouiCOM.MenuEvent, ByRef BubbleEvent As Boolean)
        Select Case pVal.MenuUID
            Case mnu_FIRST, mnu_LAST, mnu_NEXT, mnu_PREVIOUS
            Case mnu_ADD
        End Select
    End Sub
#End Region

#Region "Item Event"
    Public Overrides Sub ItemEvent(ByVal FormUID As String, ByRef pVal As SAPbouiCOM.ItemEvent, ByRef BubbleEvent As Boolean)
        Try
            If pVal.FormTypeEx = frm_ProductionOrder Then
                Select Case pVal.BeforeAction
                    Case True
                        Select Case pVal.EventType

                        End Select
                    Case False
                        Select Case pVal.EventType
                            Case SAPbouiCOM.BoEventTypes.et_FORM_LOAD
                                oForm = oApplication.SBO_Application.Forms.Item(FormUID)
                                Dim oTest As SAPbobsCOM.Recordset
                                Dim strString As String
                                oTest = oApplication.Company.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
                                strString = "Select * from OUSR where USERID=" & oApplication.Company.UserSignature
                                oTest.DoQuery(strString)
                                If oTest.Fields.Item("U_HideAmt").Value = "Y" Then
                                    initializeControls(oForm)
                                    enableControls(oForm, False)
                                End If
                                'Dim oUser As SAPbobsCOM.Users
                                'oUser = oApplication.Company.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUsers)
                                'If oUser.GetByKey(oApplication.Company.UserSignature) Then
                                '    If oUser.UserFields.Fields.Item("U_HidAmtPR").Value = "Y" Then
                                '        initializeControls(oForm)
                                '        enableControls(oForm, False)
                                '    End If
                                'End If
                        End Select
                End Select
            End If
        Catch ex As Exception
            oForm = oApplication.SBO_Application.Forms.ActiveForm()
            oForm.Freeze(False)
            oApplication.Utilities.Message(ex.Message, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
        End Try
    End Sub
#End Region

#Region "Data Events"
    Public Sub FormDataEvent(ByRef BusinessObjectInfo As SAPbouiCOM.BusinessObjectInfo, ByRef BubbleEvent As Boolean)
        Try
            oForm = oApplication.SBO_Application.Forms.Item(BusinessObjectInfo.FormUID)
            Select Case BusinessObjectInfo.BeforeAction
                Case True

                Case False
                    Select Case BusinessObjectInfo.EventType

                    End Select
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "Function"

    Private Sub initializeControls(ByVal oForm As SAPbouiCOM.Form)
        Try
            oApplication.Utilities.AddControls(oForm, "_39", "39", SAPbouiCOM.BoFormItemTypes.it_EDIT, "COPY", 2, 10, "39", "****", 0, 0, 0, False)
            oApplication.Utilities.AddControls(oForm, "_140", "140", SAPbouiCOM.BoFormItemTypes.it_EDIT, "COPY", 2, 10, "39", "****", 0, 0, 0, False)
            oApplication.Utilities.AddControls(oForm, "_41", "41", SAPbouiCOM.BoFormItemTypes.it_EDIT, "COPY", 2, 10, "39", "****", 0, 0, 0, False)
            oApplication.Utilities.AddControls(oForm, "_43", "43", SAPbouiCOM.BoFormItemTypes.it_EDIT, "COPY", 2, 10, "39", "****", 0, 0, 0, False)
            oApplication.Utilities.AddControls(oForm, "_45", "45", SAPbouiCOM.BoFormItemTypes.it_EDIT, "COPY", 2, 10, "39", "****", 0, 0, 0, False)
            oApplication.Utilities.AddControls(oForm, "_47", "47", SAPbouiCOM.BoFormItemTypes.it_EDIT, "COPY", 2, 10, "39", "****", 0, 0, 0, False)
            'oApplication.Utilities.AddControls(oForm, "_29", "29", SAPbouiCOM.BoFormItemTypes.it_EDIT, "COPY", 1, 10, "39", "****", 0, 0, 0, False)


          

            oForm.Items.Item("_39").RightJustified = True
            oEditText = oForm.Items.Item("_39").Specific
            oEditText.IsPassword = True
            oEditText.Value = "abcde"

            oForm.Items.Item("_140").RightJustified = True
            oEditText = oForm.Items.Item("_140").Specific
            oEditText.IsPassword = True
            oEditText.Value = "abcde"

            oForm.Items.Item("_41").RightJustified = True
            oEditText = oForm.Items.Item("_41").Specific
            oEditText.IsPassword = True
            oEditText.Value = "abcde"

            oForm.Items.Item("_43").RightJustified = True
            oEditText = oForm.Items.Item("_43").Specific
            oEditText.IsPassword = True
            oEditText.Value = "abcde"

            oForm.Items.Item("_45").RightJustified = True
            oEditText = oForm.Items.Item("_45").Specific
            oEditText.IsPassword = True
            oEditText.Value = "abcde"

            oForm.Items.Item("_47").RightJustified = True
            oEditText = oForm.Items.Item("_47").Specific
            oEditText.IsPassword = True
            oEditText.Value = "abcde"

            'oForm.Items.Item("_29").RightJustified = True
            'oEditText = oForm.Items.Item("_29").Specific
            'oEditText.IsPassword = True
            'oEditText.Value = "abcde"

            oForm.Items.Item("_39").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, -1, SAPbouiCOM.BoModeVisualBehavior.mvb_False)
            oForm.Items.Item("_140").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, -1, SAPbouiCOM.BoModeVisualBehavior.mvb_False)
            oForm.Items.Item("_41").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, -1, SAPbouiCOM.BoModeVisualBehavior.mvb_False)
            oForm.Items.Item("_43").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, -1, SAPbouiCOM.BoModeVisualBehavior.mvb_False)
            oForm.Items.Item("_45").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, -1, SAPbouiCOM.BoModeVisualBehavior.mvb_False)
            oForm.Items.Item("_47").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, -1, SAPbouiCOM.BoModeVisualBehavior.mvb_False)
            'oForm.Items.Item("_29").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, -1, SAPbouiCOM.BoModeVisualBehavior.mvb_False)
            oForm.Items.Item("39").Width = 1
            oForm.Items.Item("140").Width = 1
            oForm.Items.Item("41").Width = 1
            oForm.Items.Item("43").Width = 1
            oForm.Items.Item("45").Width = 1
            oForm.Items.Item("47").Width = 1

            'oForm.Items.Item("105").Visible = False

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub enableControls(ByVal oForm As SAPbouiCOM.Form, ByVal blnStatus As Boolean)
        Try
            oForm.Items.Item("3").Click(SAPbouiCOM.BoCellClickType.ct_Regular)
            oForm.Items.Item("_39").Enabled = blnStatus
            oForm.Items.Item("_140").Enabled = blnStatus
            oForm.Items.Item("_41").Enabled = blnStatus
            oForm.Items.Item("_43").Enabled = blnStatus
            oForm.Items.Item("_45").Enabled = blnStatus
            oForm.Items.Item("_47").Enabled = blnStatus
            'oForm.Items.Item("_29").Enabled = blnStatus
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

End Class
