<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="GroupPage.aspx.cs" Inherits="GroupPage"  MasterPageFile="~/Admin/AdminMasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>VIKO EIF TimeTable Admin panel - Groups</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="breadcrumbContent" runat="server">
    Groups
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
<div class="col-md-4">
    <div class="panel panel-default">
      <div class="panel-heading">
        <h3 class="panel-title">Add group</h3>
      </div>
      <div class="panel-body">
            <div class="form-group">
                <label class="control-label">Group code</label>
                <asp:TextBox ID="groupCodeTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label">Group title</label>
                <asp:TextBox ID="groupTitleTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="addGroupHelperLabel" runat="server" Text=""></asp:Label>
            </div>
            <div class="form-actions text-right pal">
                <asp:Button ID="insertButton" runat="server" Text="Add group" CssClass="btn btn-primary" OnClick="insertButton_Click"/>
            </div>
      </div>
    </div>
</div>
<div class="col-md-4">
    <div class="panel panel-default">
         <div class="panel-heading">
            <h3 class="panel-title">Delete group</h3>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <label class="control-label">Select groups which want delete</label>
                <asp:ListBox ID="groupsToDeleteListBox" runat="server" CssClass="form-control" SelectionMode="Multiple" Height="150px"></asp:ListBox>
            </div>
            <div class="form-actions text-right pal">
                <asp:Button ID="deleteButton" runat="server" Text="Delete" CssClass="btn btn-primary" OnClick="deleteButton_Click"/>
            </div>
        </div>
     </div>
</div>
<div class="col-md-4">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Update group</h3>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <label class="control-label">Select group to update</label>
                <asp:DropDownList ID="groupsToUpdateDropDownList" runat="server" CssClass="form-control" OnSelectedIndexChanged="groupsToUpdateDropDownList_SelectedIndexChanged" AutoPostBack="true" EnableViewState="true"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label class="control-label">Group code</label>
                <asp:TextBox ID="groupCodeToUpdateTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label">Group title</label>
                <asp:TextBox ID="groupTitleToUpdateTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="updateHelpLabel" runat="server" Text=""></asp:Label>
            </div>
            <div class="form-actions text-right pal">
                <asp:Button ID="updateButton" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="updateButton_Click" />
            </div>
        </div>
    </div>
</div>
</asp:Content>
