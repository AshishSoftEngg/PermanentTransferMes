Imports AjaxControlToolkit
Partial Class Usercontrol_DeleteConfirmBox
    Inherits System.Web.UI.UserControl
    'Dim _targetcontrol As String
    'Dim _targetcontr As Button
    'Public Property TargetControlId()
    '    Get
    '        Return (_targetcontr.ID)
    '    End Get
    '    Set(ByVal value)
    '        _targetcontrol = value
    '        ConfirmButtonExtender2.TargetControlID = _targetcontr.ID ' _targetcontrol
    '        ModalPopupExtender1.TargetControlID = _targetcontr.ID
    '    End Set
    'End Property

    Public Function TargetControlId(ByVal targetcontrol As Button) As Boolean
        ConfirmButtonExtender2.TargetControlID = targetcontrol.ID
        ModalPopupExtender1.TargetControlID = targetcontrol.ID
    End Function
    'Private Sub abc()
    '    Dim btn As Button
    '    ConfirmButtonExtender2.TargetControlID = btn.Text
    'End Sub

End Class
