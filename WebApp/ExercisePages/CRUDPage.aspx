<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CRUDPage.aspx.cs" Inherits="WebApp.ExercisePages.CRUDPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Player Maintenace</h1>

    <asp:DataList ID="Message" runat="server">
        <ItemTemplate>
            <%# Container.DataItem %>
        </ItemTemplate>
    </asp:DataList>

    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label1" runat="server" Text="Player ID"
                AssociatedControlID="PlayerID">
            </asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:TextBox ID="PlayerID" runat="server" ReadOnly="true">
            </asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label2" runat="server" Text="Guardian"
                AssociatedControlID="GuardianList">
            </asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:DropDownList ID="GuardianList" runat="server" Width="300px">
            </asp:DropDownList>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label3" runat="server" Text="Team"
                AssociatedControlID="TeamList">
            </asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:DropDownList ID="TeamList" runat="server" Width="300px">
            </asp:DropDownList>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label4" runat="server" Text="First Name"
                AssociatedControlID="FirstName">
            </asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:TextBox ID="FirstName" runat="server">
            </asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label5" runat="server" Text="Last Name"
                AssociatedControlID="LastName">
            </asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:TextBox ID="LastName" runat="server">
            </asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label6" runat="server" Text="Age"
                AssociatedControlID="Age">
            </asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:TextBox ID="Age" runat="server">
            </asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label7" runat="server" Text="Gender"
                AssociatedControlID="Gender">
            </asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:TextBox ID="Gender" runat="server" />
        </div>
    </div>
    
    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label8" runat="server" Text="Alberta Healthcare Number"
                AssociatedControlID="AlbertaHealthcareNumber">
            </asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:TextBox ID="AlbertaHealthcareNumber" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label9" runat="server" Text="Medical Alert Details"
                AssociatedControlID="MedicalAlertDetails">
            </asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:TextBox ID="MedicalAlertDetails" runat="server" />
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
        </div>
        <div class="col-md-6 text-left">
            <asp:Button ID="BackButton" runat="server" Text="Back" CausesValidation="false" OnClick="Back_Click" />&nbsp;&nbsp;
            <asp:Button ID="AddButton" runat="server" Text="Add" Onclick="Add_Click"/>&nbsp;&nbsp;
            <asp:Button ID="UpdateButton" runat="server" Text="Update" OnClick="Update_Click" />&nbsp;&nbsp;
            <asp:Button ID="DeleteButton" runat="server" Text="Delete" OnClick="Delete_Click" OnClientClick="return CallFunction();" />
        </div>
    </div>
    <script type="text/javascript">
        function CallFunction() {
            return confirm("Are you sure you wish to delete this record?");
        }
    </script>
</asp:Content>
