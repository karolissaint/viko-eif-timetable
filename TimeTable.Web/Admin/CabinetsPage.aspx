<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="CabinetsPage.aspx.cs" Inherits="Admin_CabinetsPage" MasterPageFile="~/Admin/AdminMasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>VIKO EIF TimeTable Admin panel - Cabinets</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="breadcrumbContent" runat="server">
    Cabinets
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
<div class="col-md-4">
    <div class="panel panel-default">
      <div class="panel-heading">
        <h3 class="panel-title">Add cabinet</h3>
      </div>
      <div class="panel-body">
            <div class="form-group">
                <label class="control-label">Cabinet code</label>
                <asp:TextBox ID="titleTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="addHelperLabel" runat="server" Text=""></asp:Label>
            </div>
            <div class="form-actions text-right pal">
                <asp:Button ID="insertButton" runat="server" Text="Add cabinet" CssClass="btn btn-primary" OnClick="insertButton_Click"/>
            </div>
      </div>
    </div>
</div>
<div class="col-md-4">
    <div class="panel panel-default">
         <div class="panel-heading">
            <h3 class="panel-title">Delete cabinet</h3>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <label class="control-label">Select cabinets, which want delete</label>
                <asp:ListBox ID="deleteListBox" runat="server" CssClass="form-control" SelectionMode="Multiple" Height="150px"></asp:ListBox>
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
            <h3 class="panel-title">Update cabinet</h3>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <label class="control-label">Select cabinet to update</label>
                <asp:DropDownList ID="updateDropDownList" runat="server" CssClass="form-control" OnSelectedIndexChanged="updateDropDownList_SelectedIndexChanged" AutoPostBack="true" EnableViewState="true"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label class="control-label">Subgroup title</label>
                <asp:TextBox ID="titleToUpdateTextBox" runat="server" CssClass="form-control"></asp:TextBox>
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