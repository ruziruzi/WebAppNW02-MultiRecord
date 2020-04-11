<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exercise9.aspx.cs" Inherits="WebApp.ExercisePages.Exercise9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Exercise 9</h1>
    <div class="offset-2">
        <asp:Label ID="Label1" runat="server" Text="Select A Player "></asp:Label>&nbsp;&nbsp;
        <asp:DropDownList ID="List01" runat="server"></asp:DropDownList>&nbsp;&nbsp;
        <asp:Button ID="ButtonFetch" runat="server" Text="Update/Delete"
            CausesValidation="false" OnClick="Fetch_Click" />
        <asp:Button ID="ButtonAdd" runat="server" Text="Add"
            CausesValidation="false" OnClick="Add_Click" />
        <br /><br />
        <asp:Label ID="MessageLabel1" runat="server"></asp:Label>
    </div>
</asp:Content>
