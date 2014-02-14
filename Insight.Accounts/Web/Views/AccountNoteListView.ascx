<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountNoteListView.ascx.cs" Inherits="Insight.Accounts.Web.Views.AccountNoteListView" %>
<%@ Register tagPrefix="idea" namespace="IdeaSeed.Web.UI" assembly="IdeaSeed.Web" %>
<%@ Register tagPrefix="telerik" namespace="Telerik.Web.UI" assembly="Telerik.Web.UI"  %>
<div runat="server" id="divAddressList" class="propertypagecontent">
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
        <asp:DataList
        runat="server"
        ID="dlNotes"
        Width="100%"
        RepeatColumns="3">
            <ItemTemplate>
                <div style="padding: 10px 0px 10px 0px; margin-right: 30px;">
                    <div>
                        <span>Title: </span>
                        <span class="lightBlue"><%# Eval("Title") %> </span>
                    </div>
                    <div>
                        <span>Note: </span>
                        <span class="lightBlue"><%# Eval("Body") %> </span>
                    </div>
                    <div>
                        <idea:LinkButton
                        runat="server"
                        ID="lbEditNote"
                        itemname='<%# Eval("Title") %>'
                        itemid='<%# Eval("ID").ToString() %>'
                        OnClick="ViewItemClicked">
                            <asp:Image
                            runat="server"
                            ID="imgEditNote"
                            ImageUrl="~/images/pencil.png" />
                            Edit
                        </idea:LinkButton>
                    </div>
                </div>
                    <%--<hr />--%>
            </ItemTemplate>
        </asp:DataList>
        <telerik:RadGrid
        runat="server"
        ID="rgList"
        AllowPaging="True"
        AutoGenerateColumns="false"
        AllowSorting="True" 
        GridLines="None" 
        Width="100%"
        ShowStatusBar="true"
        OnNeedDataSource="NeedDataSource"
        OnItemCommand="ItemCommand"
        ShowFooter="true"
        EnableEmbeddedSkins="false"
        Skin="Insight">
            <ClientSettings EnableRowHoverStyle="true">
            </ClientSettings>
            <MasterTableView 
            DataKeyNames="ID"
            CommandItemDisplay="None"
            EnableNoRecordsTemplate="true"
            NoMasterRecordsText="No addresses for account found.">
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
                    DataField="Title" 
                    HeaderText="Title" 
                    SortExpression="Title"
                    UniqueName="Title">
                        <ItemTemplate>
                            <%# Eval("Title")%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="Body" 
                    HeaderText="Note" 
                    SortExpression="Body"
                    UniqueName="Body">
                        <ItemTemplate>
                            <%# Eval("Body") %>
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
                                ToolTip="View Note"
                                ImageUrl="~/images/zoom.png"
                                Style="border: none;" />
                            </idea:LinkButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <PagerStyle Mode="NextPrevAndNumeric"  AlwaysVisible="true" Position="Bottom" />
            </MasterTableView>
        </telerik:RadGrid>
    </div>
</div>
<br />