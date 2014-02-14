<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EquipmentPropertiesView.ascx.cs" Inherits="Insight.Accounts.Web.Views.EquipmentPropertiesView" %>
<%@ Register tagPrefix="idea" namespace="IdeaSeed.Web.UI" assembly="IdeaSeed.Web" %>
<%@ Register tagPrefix="idea" namespace="Insight.Web.Controls" assembly="Insight.Web" %>
<%@ Register tagPrefix="idea" namespace="Insight.Accounts.Web.Controls" assembly="Insight.Accounts" %>
<%@ Register tagPrefix="telerik" namespace="Telerik.Web.UI" assembly="Telerik.Web.UI"  %>
<div runat="server" id="divHeader" class="propertypagecontent">
    <div>
        <h2>
            <idea:Label
            runat="server"
            ID="lblPropertiesTitle">
            </idea:Label>
        </h2>
    </div>
    <hr />
    <table>
        <tr>
            <td class="propertypagecells">
                <span>ID:</span>
                <span>
                    <idea:Label
                    class="orange"
                    runat="server"
                    ID="lblID">
                    </idea:Label>
                </span>
            </td>
            <td>
                <span><b>Account:</b></span>
                <div>
                    <idea:AccountsDDL
                    Skin="Windows7"
                    runat="server"
                    ID="ddlAccount">
                    </idea:AccountsDDL>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="rfvAccount"
                    ErrorMessage="<br />Please select an account"
                    InitialValue=""
                    ControlToValidate="ddlAccount"
                    Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </td>
        </tr>
        <tr>
            <td class="propertypagecells">
                <span><b>Name:</b></span>
                <div>
                    <idea:TextBox
                    Skin="Windows7"
                    runat="server"
                    ID="tbName"
                    Width="325px">
                    </idea:TextBox>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="rfvName"
                    ErrorMessage="<br />Please enter a name"
                    InitialValue=""
                    ControlToValidate="tbName"
                    Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </td>
            <td>
                <span>IP Address:</span>
                <div>
                    <idea:TextBox
                    Skin="Windows7"
                    runat="server"
                    ID="tbIPAddress"
                    Width="325px">
                    </idea:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td class="propertypagecells">
                <span>Username:</span>
                <div>
                    <idea:TextBox
                    Skin="Windows7"
                    runat="server"
                    ID="tbUsername"
                    Width="325px">
                    </idea:TextBox>
                </div>
            </td>
            <td>
                <span>Password:</span>
                <div>
                    <idea:TextBox
                    Skin="Windows7"
                    runat="server"
                    ID="tbPassword"
                    Width="325px">
                    </idea:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td class="propertypagecells">
                <span>Model:</span>
                <div>
                    <idea:TextBox
                    Skin="Windows7"
                    runat="server"
                    ID="tbModel"
                    Width="325px">
                    </idea:TextBox>
                </div>
            </td>
            <td>
                <span>Physical Location:</span>
                <div>
                    <idea:TextBox
                    Skin="Windows7"
                    runat="server"
                    ID="tbPhysicalLocation"
                    Width="325px">
                    </idea:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td class="propertypagecells">
                <span><b>Equipment Type:</b></span>
                <div>
                    <idea:EquipmentTypesDDL
                    runat="server"
                    Skin="Windows7"
                    ID="ddlEquipmentType">
                    </idea:EquipmentTypesDDL>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="rfvIndustryTye"
                    ErrorMessage="<br />Please select industry type"
                    InitialValue=""
                    ControlToValidate="ddlEquipmentType"
                    Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </td>
            <td>
                <span>Purchase Date:</span>
                <div>
                    <telerik:RadDatePicker 
                    ID="tbPurchaseDate"
                    MinDate="1/1/1900"
                    Calendar-FastNavigationSettings-EnableTodayButtonSelection="true"
                    Skin="Vista"
                    runat="server">
                        <DateInput 
                        ID="diPurchaseDate"
                        runat="server"
                        DateFormat="MM/dd/yyyy">
                        </DateInput>
                    </telerik:RadDatePicker>
                </div>
            </td>
        </tr>
        <tr>
            <td class="propertypagecells">
                <span>Support Expiration Date:</span>
                <div>
                    <telerik:RadDatePicker 
                    ID="tbSupportExpirationDate"
                    MinDate="1/1/1900"
                    Calendar-FastNavigationSettings-EnableTodayButtonSelection="true"
                    Skin="Vista"
                    runat="server">
                        <DateInput 
                        ID="diSupportExpirationDate"
                        runat="server"
                        DateFormat="MM/dd/yyyy">
                        </DateInput>
                    </telerik:RadDatePicker>
                </div>
            </td>
            <td>
                <span>Warranty Expiration Date:</span>
                <div>
                    <telerik:RadDatePicker 
                    ID="tbWarrantyExpirationDate"
                    MinDate="1/1/1900"
                    Calendar-FastNavigationSettings-EnableTodayButtonSelection="true"
                    Skin="Vista"
                    runat="server">
                        <DateInput 
                        ID="diWarrantyExpirationDate"
                        runat="server"
                        DateFormat="MM/dd/yyyy">
                        </DateInput>
                    </telerik:RadDatePicker>
                </div>
            </td>
        </tr>
        <tr>
            <td class="propertypagecells">
                <span>Key Functions:</span>
                <div>
                    <idea:TextBox
                    Skin="Windows7"
                    runat="server"
                    TextMode="MultiLine"
                    Height="50px"
                    ID="tbKeyFunctions"
                    Width="325px">
                    </idea:TextBox>
                </div>
            </td>
            <td>
                <span>Warranty Notes:</span>
                <div>
                    <idea:TextBox
                    Skin="Windows7"
                    runat="server"
                    TextMode="MultiLine"
                    Height="50px"
                    ID="tbWarrantyNote"
                    Width="325px">
                    </idea:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td class="propertypagecells">
                <span>Other Info:</span>
                <div>
                    <idea:TextBox
                    Skin="Windows7"
                    runat="server"
                    TextMode="MultiLine"
                    ID="tbOtherInfo"
                    Height="50px"
                    Width="325px">
                    </idea:TextBox>
                </div>
            </td>
            <td>
                <span>Date Created:</span>
                <span>
                    <idea:Label
                    class="orange"
                    runat="server"
                    ID="lblDateCreated" />
                </span><br />
                <span>Last Updated:</span>
                <span>
                    <idea:Label
                    class="orange"
                    runat="server"
                    ID="lblLastUpdated" />
                </span><br />
            </td>
        </tr>
    </table>
</div>
<hr />

