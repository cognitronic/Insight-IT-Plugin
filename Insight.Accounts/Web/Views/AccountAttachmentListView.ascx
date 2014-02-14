<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountAttachmentListView.ascx.cs" Inherits="Insight.Accounts.Web.Views.AccountAttachmentListView" %>
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
                <table style="padding: 10px 0px 10px 0px; margin-right: 400px; width: 500px;">
                    <tr>
                        <td style="padding: 0px 0px 10px 20px;" valign="top">
                            <table class="detailTable" valign="top">
                                <tr>
                                    <td>
                                        <span>File Name: </span>
                                        <span class="lightBlue">
                                            <%# Eval("FileName") %> 
                                        </span>
                                    </td>
                                    <td>
                                        <span>Title: </span>
                                        <span class="lightBlue">
                                            <%# Eval("Title") %> 
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Account Name: </span>
                                        <span class="lightBlue">
                                            <idea:Label 
                                            runat="server" 
                                            ID="lblDetailAccountName">
                                            </idea:Label>
                                        </span>
                                    </td>
                                    <td>
                                        
                                    </td>
                                </tr>
                            </table>
                             <idea:LinkButton
                            runat="server"
                            ID="lbDetailViewItem"
                            itemname='<%# Eval("title") %>'
                            itemid='<%# Eval("id").ToString() %>'
                            OnClick="ViewItemClicked">
                                <asp:Image
                                runat="server"
                                ID="imgEditLastName"
                                ImageUrl="~/images/zoom.png" />
                                View
                            </idea:LinkButton>
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
            NoMasterRecordsText="No contacts found.">
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
                    DataField="ID" 
                    HeaderText="ID" 
                    SortExpression="ID"
                    UniqueName="ID">
                        <ItemTemplate>
                            <%# Eval("ID")%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="FileName" 
                    HeaderText="File" 
                    SortExpression="FileName"
                    UniqueName="FileName">
                        <ItemTemplate>
                            <a href='<%#Eval("FullPath") %>' target="_blank">
                                <%# Eval("FileName")%>
                            </a>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="Title" 
                    HeaderText="Title" 
                    SortExpression="Title"
                    UniqueName="Title">
                        <ItemTemplate>
                            <%# Eval("Title")%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="AccountID" 
                    HeaderText="Account" 
                    SortExpression="AccountID"
                    UniqueName="AccountID">
                        <ItemTemplate>
                            <idea:Label
                            runat="server"
                            ID="lblAccount">
                            </idea:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn
                    HeaderStyle-Width="20px">
                        <ItemTemplate>
                            <idea:LinkButton
                            runat="server"
                            ID="lbEdit"
                            OnClick="ViewItemClicked"
                            itemname='<%# Eval("Title") %>'
                            itemid='<%# Eval("ID").ToString() %>'>
                                <asp:Image
                                runat="server"
                                ID="imgEdit"
                                ToolTip="Edit Attachment"
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

