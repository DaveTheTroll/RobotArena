<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RobotProperties.ascx.cs" Inherits="ArenaWeb.RobotProperties" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxyRobot" runat="server" />
<asp:UpdatePanel ID="UpdatePanelRobot" runat="server">
    <ContentTemplate>
        <table>
            <tr><th colspan="2"><asp:Label ID="LabelHandle" runat="server" Text="Handle"/></th></tr>
            <tr><th>Location</th><td><asp:Label ID="LabelLocation" runat="server" Text="(X, Y)"/></td></tr>
            <tr><th>Heading</th><td><asp:Label ID="LabelHeading" runat="server" Text="Heading"/></td></tr>
            <tr><th>Speed</th><td><asp:Label ID="LabelSpeed" runat="server" Text="Speed"/></td></tr>
            <tr><th>Steer</th><td><asp:Label ID="LabelSteer" runat="server" Text="Steer"/></td></tr>
        </table>
        <asp:Timer ID="TimerRobot" runat="server" OnTick="TimerRobot_Tick" Interval="250" Enabled="true" />
        </ContentTemplate>
</asp:UpdatePanel>
<table>
    <tr><th>Speed Demand</th><td><asp:TextBox ID="TextBoxSpeedDemand" runat="server" Text="0"/></td></tr>
    <tr><th>Steer Demand</th><td><asp:TextBox ID="TextBoxSteerDemand" runat="server" Text="0"/></td></tr>
    <tr><th>Colour</th><td><asp:TextBox ID="TextBoxColor" runat="server" Text="0" /></td></tr>
</table>
<asp:HyperLink ID="HyperLinkArena" runat="server" />
