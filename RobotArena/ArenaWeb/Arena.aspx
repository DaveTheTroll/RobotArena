<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Arena.aspx.cs" Inherits="ArenaWeb.ArenaPage" %>

<%@ Register Src="~/ArenaView.ascx" TagPrefix="uc1" TagName="ArenaView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ArenaView runat="server" ID="ArenaView" />
    <asp:UpdatePanel ID="UpdatePanelRobotList" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:BulletedList ID="BulletedListRobot" runat="server" DisplayMode="HyperLink" />
            <asp:Timer ID="Timer_RobotList" Interval="1000" Enabled="true" runat="server" OnTick="Timer_RobotList_Tick"/>
        </ContentTemplate>
    </asp:UpdatePanel>
    <hr />
    <asp:Button ID="ButtonAddRobot" runat="server" Text="Add Robot" OnClick="ButtonAddRobot_Click" />
    <asp:Button ID="ButtonClear" runat="server" Text="Clear" OnClick="ButtonClear_Click" />
    <hr />
    <asp:TextBox ID="TextBoxName" runat="server" />
    <asp:Button ID="ButtonName" runat="server" Text="Change" OnClick="ButtonName_Click" />
</asp:Content>
