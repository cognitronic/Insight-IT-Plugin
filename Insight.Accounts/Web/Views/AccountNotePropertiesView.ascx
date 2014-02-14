<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountNotePropertiesView.ascx.cs" Inherits="Insight.Accounts.Web.Views.AccountNotePropertiesView" %>
<%@ Register tagPrefix="idea" namespace="IdeaSeed.Web.UI" assembly="IdeaSeed.Web" %>
<%@ Register tagPrefix="idea" namespace="Insight.Web.Controls" assembly="Insight.Web" %>
<%@ Register tagPrefix="idea" namespace="Insight.Accounts.Web.Controls" assembly="Insight.Accounts" %>
<%@ Register tagPrefix="telerik" namespace="Telerik.Web.UI" assembly="Telerik.Web.UI"  %>
<div class="propertypagecontent">
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
                <span><b>Title:</b></span>
                <div>
                    <idea:TextBox
                    Skin="Windows7"
                    runat="server"
                    ID="tbTitle"
                    Width="325px">
                    </idea:TextBox>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="rfvTitle"
                    ErrorMessage="<br />Please enter a title"
                    InitialValue=""
                    ControlToValidate="tbTitle"
                    Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </td>
        </tr>
        <tr>
            <td class="propertypagecells">
                <span><b>Note:</b></span>
                <div>
                    <idea:TextBox
                    Skin="Windows7"
                    runat="server"
                    ID="tbNote"
                    TextMode="MultiLine"
                    Height="100px"
                    Width="325px">
                    </idea:TextBox>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="rfvAddress1"
                    ErrorMessage="<br />Please enter note"
                    InitialValue=""
                    ControlToValidate="tbNote"
                    Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </td>
        </tr>
        <tr>
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