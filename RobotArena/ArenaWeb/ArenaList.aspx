<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArenaList.aspx.cs" Inherits="ArenaWeb.ArenaListPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:BulletedList ID="BulletedListArena" runat="server" DisplayMode="HyperLink">
    </asp:BulletedList>
    <asp:Button ID="ButtonAddArena" runat="server" Text="Add Arena" OnClick="ButtonAddArena_Click" />
</asp:Content>

