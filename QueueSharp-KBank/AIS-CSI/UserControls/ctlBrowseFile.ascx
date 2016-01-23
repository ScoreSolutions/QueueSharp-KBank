<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlBrowseFile.ascx.vb" Inherits="UserControls_ctlBrowseFile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table border="0" cellpadding="0" cellspacing="0" >
    <tr>
        <td  >
            <cc1:AsyncFileUpload ID="FileBrowse" runat="server" FailedValidation="False" UploaderStyle="Modern"   />
        </td>
        <td valign="top">
            <asp:Button ID="Button1" runat="server" Text="Upload" CssClass="formDialog" Width="80px" />
        </td>
    </tr>
</table>

