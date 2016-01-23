﻿<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlByTime.ascx.vb" Inherits="FormControls_ctlByTime" %>
<%@ Register src="../UserControls/txtDate.ascx" tagname="txtDate" tagprefix="uc1" %>
<%@ Register src="../UserControls/cmbComboBox.ascx" tagname="cmbComboBox" tagprefix="uc2" %>

    <tr style="height: 30px">
        <td align="right">Interval Time :&nbsp;</td>
        <td colspan="3" align="left">
            <uc2:cmbComboBox ID="cmbIntervalMinute" runat="server" AutoPosBack="true" IsDefaultValue="false"  />
        </td>
    </tr>
    <tr style="height: 30px">
        <td align="right" width="20%" >TimePeroid From :&nbsp;</td>
        <td align="left" width="30%">
            <uc2:cmbComboBox ID="DTimePeroidFrom" runat="server" />
        </td>
        <td style="height: 29px" width="20%" align="right" >TimePeroid To :&nbsp;</td>
        <td style="height: 29px" width="30%" align="left">
            <uc2:cmbComboBox ID="DTimePeroidTo" runat="server" />
        </td>
    </tr>
    <tr style="height: 30px">
        <td style="height: 28px" align="right">Date From :&nbsp;</td>
        <td style="height: 28px" align="left">
            <uc1:txtDate ID="txtDateFrom" runat="server" />
        </td>
        <td style="height: 28px" align="right">Date To :&nbsp;</td>
        <td style="height: 28px" align="left">
            <uc1:txtDate ID="txtDateTo" runat="server" />
        </td>
    </tr>