<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="SubgroupsPage.aspx.cs" Inherits="Admin_SubgroupsPage" MasterPageFile="~/Admin/AdminMasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>VIKO EIF TimeTable Admin panel - Subgroups</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="breadcrumbContent" runat="server">
    Subgroups
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
<div class="col-md-4">
    <div class="panel panel-default">
      <div class="panel-heading">
        <h3 class="panel-title">Add subgroup</h3>
      </div>
      <div class="panel-body">
            <div class="form-group">
                <label class="control-label">Subgroup title</label>
                <asp:TextBox ID="subGroupTitleTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="addSubgroupHelperLabel" runat="server" Text=""></asp:Label>
            </div>
            <div class="form-actions text-right pal">
                <asp:Button ID="insertButton" runat="server" Text="Add subgroup" CssClass="btn btn-primary" OnClick="insertButton_Click"/>
            </div>
      </div>
    </div>
</div>
<div class="col-md-4">
    <div class="panel panel-default">
         <div class="panel-heading">
            <h3 class="panel-title">Delete subgroup</h3>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <label class="control-label">Select subgroups, which want delete</label>
                <asp:ListBox ID="subGroupsToDeleteListBox" runat="server" CssClass="form-control" SelectionMode="Multiple" Height="150px"></asp:ListBox>
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
            <h3 class="panel-title">Update subgroup</h3>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <label class="control-label">Select subgroup to update</label>
                <asp:DropDownList ID="subGroupsToUpdateDropDownList" runat="server" CssClass="form-control" OnSelectedIndexChanged="subGroupsToUpdateDropDownList_SelectedIndexChanged" AutoPostBack="true" EnableViewState="true"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label class="control-label">Subgroup title</label>
                <asp:TextBox ID="subGroupTitleToUpdateTextBox" runat="server" CssClass="form-control"></asp:TextBox>
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