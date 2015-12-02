<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="GroupPage.aspx.cs" Inherits="GroupPage"  MasterPageFile="~/Admin/AdminMasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>VIKO EIF TimeTable Admin panel - Groups</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageTitle" Runat="Server">
    Groups
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
			<div class="row-fluid sortable">
				<div class="box span12">
					<div class="box-header">
						<h2><i class="halflings-icon edit"></i><span class="break"></span>Add Group</h2>
						<div class="box-icon">
							<a href="#" class="btn-setting"><i class="halflings-icon wrench"></i></a>
							<a href="#" class="btn-minimize"><i class="halflings-icon chevron-up"></i></a>
							<a href="#" class="btn-close"><i class="halflings-icon remove"></i></a>
						</div>
					</div>
					<div class="box-content">
						<form class="form-horizontal">
						  <fieldset>
							<div class="control-group">
							  <label class="control-label" for="typeahead">Group code (for example: "IR14B"): </label>
							  <div class="controls">
                                  <asp:TextBox ID="groupCodeTextBox" runat="server" CssClass="span6" MaxLength="5"></asp:TextBox>
							  </div>
							</div>
					        <div class="control-group">
							  <label class="control-label" for="typeahead">Group title (for example: "Išmanieji irenginiai"): </label>
							  <div class="controls">
                                  <asp:TextBox ID="groupTitleTextBox" runat="server" CssClass="span6" MaxLength="40"></asp:TextBox>
							  </div>
							</div>
                              <asp:Label ID="newGroupStatusMessage" runat="server" Text=""></asp:Label>
							<div class="form-actions">
                              <asp:Button ID="insertButton" runat="server" Text="Add new group" CssClass="btn btn-primary" OnClick="insertButton_Click"/>
							</div>
						  </fieldset>
						</form>   

					</div>
				</div><!--/span-->

			</div><!--/row-->


    			<div class="row-fluid sortable">
				<div class="box span12">
					<div class="box-header" data-original-title>
						<h2><i class="halflings-icon edit"></i><span class="break"></span>Delete Group</h2>
						<div class="box-icon">
							<a href="#" class="btn-setting"><i class="halflings-icon wrench"></i></a>
							<a href="#" class="btn-minimize"><i class="halflings-icon chevron-up"></i></a>
							<a href="#" class="btn-close"><i class="halflings-icon remove"></i></a>
						</div>
					</div>
					<div class="box-content">
						<form class="form-horizontal">
						  <fieldset>
							<div class="control-group">
							  <label class="control-label" for="typeahead">Groups: </label>
							  <div class="controls">
                                  <asp:DropDownList id="groupsDropDownList" runat="server"></asp:DropDownList>
							  </div>
							</div>
					        <div class="control-group">
							  <label class="control-label" for="typeahead">Group title (for example: "Išmanieji irenginiai"): </label>
							  <div class="controls">
                                  <asp:TextBox ID="TextBox2" runat="server" CssClass="span6" MaxLength="40"></asp:TextBox>
							  </div>
							</div>
							<div class="form-actions">
                              <asp:Button ID="Button1" runat="server" Text="Add new group" CssClass="btn btn-primary" OnClick="insertButton_Click"/>
							</div>
						  </fieldset>
						</form>   

					</div>
				</div><!--/span-->

			</div><!--/row-->
</asp:Content>
