<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EquipmentListView.ascx.cs" Inherits="Insight.Accounts.Web.Views.EquipmentListView" %>
<%@ Register tagPrefix="idea" namespace="IdeaSeed.Web.UI" assembly="IdeaSeed.Web" %>
<%@ Register tagPrefix="telerik" namespace="Telerik.Web.UI" assembly="Telerik.Web.UI"  %>
<div runat="server" id="divContactList" class="propertypagecontent">
    <div>
        <h2>
            <idea:Label
            runat="server"
            ID="lblListTitle">
            </idea:Label>
        </h2>
    </div>
    <hr />
    <div runat="server" id="divListView">
        <telerik:RadListView
        runat="server"
        AllowPaging="true"
        ID="dlDetails"
        OnNeedDataSource="DetailsNeedDataSource"
        OnItemDataBound="DetailsItemDataBound"
        Width="100%"
        RepeatColumns="0">
            <ItemTemplate>
                <table class="detailTable" valign="top">
                    <tr>
                        <td>
                            <span>Equipment: </span>
                            <span class="lightBlue">
                                <%# Eval("Name")%> 
                            </span>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span>Description: </span>
                            <span class="lightBlue">
                                <%# Eval("Description") %> 
                            </span>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
                <hr />
            </ItemTemplate>
        </telerik:RadListView>
        <telerik:RadGrid
        runat="server"
        ID="rgList"
        AllowPaging="True"
        AutoGenerateColumns="false"
        AllowSorting="True" 
        Width="100%"
        GridLines="None" 
        ShowStatusBar="true"
        OnNeedDataSource="NeedDataSource"
        OnItemCommand="ItemCommand"
        OnItemDataBound="ItemDataBound"
        ShowFooter="true"
        EnableEmbeddedSkins="false"
        Skin="Insight">
            <ClientSettings EnableRowHoverStyle="true">
            </ClientSettings>
            <MasterTableView 
            DataKeyNames="ID"
            CommandItemDisplay="None"
            EnableNoRecordsTemplate="true"
            NoMasterRecordsText="No equipment found.">
                <Columns>
                    <telerik:GridTemplateColumn 
                    UniqueName="CheckBoxTemplateColumn">
                        <HeaderTemplate>
                         <idea:CheckBox 
                         ID="cbSelectAllRows" 
                         style="cursor: default;"
                         OnCheckedChanged="ToggleGridSelectedState" 
                         AutoPostBack="True" 
                         runat="server">
                         </idea:CheckBox>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <idea:CheckBox 
                            ID="cbSelectRow" 
                            itemid='<%# Eval("ID") %>'
                            runat="server">
                            </idea:CheckBox>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="EquipmentType.Name" 
                    HeaderText="Type" 
                    SortExpression="EquipmentType.Name"
                    UniqueName="EquipmentType.Name">
                        <ItemTemplate>
                            <%# Eval("EquipmentType.Name") %> 
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="Name" 
                    HeaderText="Name" 
                    SortExpression="Name"
                    UniqueName="Name">
                        <ItemTemplate>
                            <%# Eval("Name")%> 
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="IPAddress" 
                    HeaderText="IP Address" 
                    SortExpression="IPAddress"
                    UniqueName="IPAddress">
                        <ItemTemplate>
                            <%# Eval("IPAddress")%> 
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="KeyFunctions" 
                    HeaderText="Key Functions" 
                    SortExpression="KeyFunctions"
                    UniqueName="KeyFunctions">
                        <ItemTemplate>
                            <%# Eval("KeyFunctions")%> 
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="WarrantyExpirationDate" 
                    HeaderText="Warranty Expiration" 
                    SortExpression="WarrantyExpirationDate"
                    UniqueName="WarrantyExpirationDate">
                        <ItemTemplate>
                            <%# IdeaSeed.Core.Utils.Utilities.FormatDateForList(Eval("WarrantyExpirationDate"))%> 
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn
                    HeaderText="Other Info"
                    SortExpression="otherinfo"
                    EditFormColumnIndex="1"
                    Groupable="false">
                        <ItemTemplate>
                            <%# Eval("otherinfo") %>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="Account.Name" 
                    HeaderText="Account" 
                    SortExpression="Account.Name"
                    UniqueName="Account.Name">
                        <ItemTemplate>
                            <%# Eval("Account.Name")%> 
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn
                    HeaderText="Location"
                    SortExpression="physicallocationdescription"
                    Groupable="false">
                        <ItemTemplate>
                            <%# Eval("physicallocationdescription") %>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn
                    HeaderStyle-Width="20px">
                        <ItemTemplate>
                            <idea:LinkButton
                            runat="server"
                            ID="lbEdit"
                            OnClick="ViewItemClicked"
                            itemname='<%# Eval("AccountID") %>'
                            itemid='<%# Eval("ID").ToString() %>'>
                                <asp:Image
                                runat="server"
                                ID="imgEdit"
                                ToolTip="View Equipment"
                                ImageUrl="~/images/zoom.png"
                                Style="border: none;" />
                            </idea:LinkButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <PagerStyle Mode="NextPrevAndNumeric" 
                AlwaysVisible="true" 
                Position="Bottom" />
            </MasterTableView>
        </telerik:RadGrid>
    </div>
</div>
<br />
