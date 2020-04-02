<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MultiRecordQueryWithCustomGridView.aspx.cs" Inherits="WebApp.ExercisePages.MultiRecordQueryWithCustomGridView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h1> Multi Record Query with Custom GridView</h1>
    <div class="offset-2">
        <asp:Label ID="Label1" runat="server" Text="Select a team: "></asp:Label>&nbsp;&nbsp;   
        <asp:DropDownList ID="List01" runat="server"></asp:DropDownList>&nbsp;&nbsp;
        <asp:Button ID="Fetch" runat="server" Text="Fetch" 
             CausesValidation="false" OnClick="Fetch_Click"/>
        <br /><br />
        <asp:Label ID="MessageLabel" runat="server" ></asp:Label>
        <br />
        
        <asp:Label ID="TeamInfoLabel" runat="server" Font-Size="XX-Large" Width="100%" CssClass="text-center"></asp:Label>
        <asp:GridView ID="TeamInfo" runat="server"
            AutoGenerateColumns="False"
            CssClass="table table-striped" GridLines="Horizontal"
            BorderStyle="None">

      
            
            <Columns>


                <asp:TemplateField HeaderText="Coach" Visible="True">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="Coach" runat="server" 
                            Text='<%# Eval("Coach") %>'></asp:Label>
                        
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Assistant Coach" Visible="True">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="AssistantCoach" runat="server" 
                            Text='<%# Eval("AssistantCoach") %>'></asp:Label>
                        
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Wins" Visible="True">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="Wins" runat="server" 
                            Text='<%# Eval("Wins") == null ? "N/A" : Eval("Wins") %>'></asp:Label>
                        
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Losses" Visible="True">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="Losses" runat="server" 
                            Text='<%# Eval("Losses") == null ? "N/A" : Eval("Losses") %>'></asp:Label>
                        
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>
        
        <br /><br />
        <asp:Label ID="RosterLabel" runat="server" Font-Size="XX-Large" Width="100%" CssClass="text-center"></asp:Label>
        <asp:GridView ID="List02" runat="server" 
            AutoGenerateColumns="False"
             CssClass="table table-striped" GridLines="Horizontal"
             BorderStyle="None" AllowPaging="True" OnPageIndexChanging="List02_PageIndexChanging" PageSize="5" OnSelectedIndexChanged="List02_SelectedIndexChanged">

            <Columns>
                <%--<asp:CommandField SelectText="View" ShowSelectButton="True" 
                    ButtonType="Button" CausesValidation="false"></asp:CommandField>--%>
                <asp:TemplateField HeaderText="Name" Visible="True">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="Name" runat="server" 
                            Text='<%# Eval("PlayerName") %>'></asp:Label>
                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Age">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <%-- this is where your reference to the data on your
                              record is placed--%>
                        <asp:Label ID="Age" runat="server" 
                            Text='<%# Eval("Age") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Gender">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                     <ItemTemplate>
                        <asp:Label ID="Gender" runat="server" 
                            Text='<%# Eval("Gender") %>'></asp:Label>
                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Medical Alert">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                     <ItemTemplate>
                        <asp:Label ID="MedicalAlert" runat="server" 
                            Text='<%# Eval("MedicalAlertDetails") %>'></asp:Label>
                        
                    </ItemTemplate>
                </asp:TemplateField>

                <%--<asp:TemplateField HeaderText="Wins">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                     <ItemTemplate>
                        <asp:Label ID="Wins" runat="server" 
                            Text='<%# Eval("Wins") == null ? "each" : Eval("Wins") %>'></asp:Label>
                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Losses">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                     <ItemTemplate>
                        <asp:Label ID="Losses" runat="server" 
                            Text='<%# Eval("Losses") == null ? "each" : Eval("Losses") %>'></asp:Label>
                        
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
            <EmptyDataTemplate>
                No data available at this time
            </EmptyDataTemplate>
            <PagerSettings FirstPageText="Start" LastPageText="End" Mode="NumericFirstLast" PageButtonCount="3" />
        </asp:GridView>
    </div>
</asp:Content>
