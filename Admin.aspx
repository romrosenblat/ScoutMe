<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td><div>
    
        <asp:Label ID="Label1" runat="server" Text="Remove Athletes"></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="athleteID" DataSourceID="DS_Athletes">
            <Columns>
                <asp:BoundField DataField="athleteID" HeaderText="athleteID" InsertVisible="False" ReadOnly="True" SortExpression="athleteID" />
                <asp:BoundField DataField="first_name" HeaderText="first_name" SortExpression="first_name" />
                <asp:BoundField DataField="last_name" HeaderText="last_name" SortExpression="last_name" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <br />
    
    </div></td>
                <td>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Remove Agents"></asp:Label>
                            <br />

                    <asp:GridView ID="GridView2" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="agentNum" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:BoundField DataField="agentNum" HeaderText="agentNum" ReadOnly="True" SortExpression="agentNum" />
                            <asp:BoundField DataField="first_name" HeaderText="first_name" SortExpression="first_name" />
                            <asp:BoundField DataField="last_name" HeaderText="last_name" SortExpression="last_name" />
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bgroup33_prodConnectionString %>" SelectCommand="SELECT DISTINCT [agentNum], [first_name], [last_name] FROM [Agent]"></asp:SqlDataSource>

                </td>
                <td>
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="Remove Teams"></asp:Label>
                    <br />
                    <asp:GridView ID="GridView3" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="teamNum" DataSourceID="DS_Teams">
                        <Columns>
                            <asp:BoundField DataField="first_name" HeaderText="first_name" SortExpression="first_name" />
                            <asp:BoundField DataField="last_name" HeaderText="last_name" SortExpression="last_name" />
                            <asp:BoundField DataField="teamNum" HeaderText="teamNum" InsertVisible="False" ReadOnly="True" SortExpression="teamNum" />
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>

                        <asp:SqlDataSource ID="DS_Teams" runat="server" ConnectionString="<%$ ConnectionStrings:bgroup33_prodConnectionString %>" SelectCommand="SELECT DISTINCT [first_name], [last_name], [teamNum] FROM [Teams]"></asp:SqlDataSource>

                </td>

            </tr>
        </table>
        <asp:SqlDataSource ID="DS_Athletes" runat="server" ConnectionString="<%$ ConnectionStrings:bgroup33_prodConnectionString %>" SelectCommand="SELECT DISTINCT [athleteID], [first_name], [last_name] FROM [Athlete]"></asp:SqlDataSource>
    </form>
</body>
</html>
