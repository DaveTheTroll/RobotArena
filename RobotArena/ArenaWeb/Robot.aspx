<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Robot.aspx.cs" Inherits="ArenaWeb.RobotPage" %>

<%@ Register Src="~/RobotProperties.ascx" TagPrefix="uc1" TagName="RobotProperties" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:RobotProperties runat="server" ID="RobotProperties" />
    <asp:Button ID="ButtonDelete" runat="server" Text="Delete" OnClick="ButtonDelete_Click" />
    <br />
    <asp:TextBox ID="TextBoxName" runat="server" />
    <asp:Button ID="ButtonName" runat="server" Text="Change" OnClick="ButtonName_Click" />
</asp:Content>
