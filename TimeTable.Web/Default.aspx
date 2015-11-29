<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VIKO EIF TimeTable</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css">
    <link href="styles/bootstrap-grid.css" rel="stylesheet" type="text/css" />
    <link href="styles/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">

    <section id="header">
        <div class="container">
            <div class="row">
                <div class="col-md-3">
                     <h1><a href="/">VIKO EIF <span>TimeTable</span></a></h1>
                </div>
                <div class="col-md-9">
                    <div class="filters">
                        <div class="filter">
                            <p><b>Group: </b></p>
                            <asp:DropDownList ID="groupsDropDownList" runat="server"></asp:DropDownList>
                        </div>
                        <div class="filter">
                            <p><b>Subgroup: </b></p>
                            <asp:DropDownList ID="subGroupsDropDownList" runat="server"></asp:DropDownList>
                        </div>
                        <div class="filter">
                            <p><b>Week: </b></p>
                            <asp:DropDownList ID="weeksDropDownList" runat="server"></asp:DropDownList>
                        </div>
                        <button runat="server" id="submitButton" type="submit" title="Search">
                            <i class="fa fa-search"></i>
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <%--<asp:DropDownList ID="cabinetsDropDownList" runat="server"></asp:DropDownList>--%>
    </form>
</body>
</html>
