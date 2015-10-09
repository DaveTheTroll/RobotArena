<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArenaView.ascx.cs" Inherits="ArenaWeb.ArenaView" %>
<%@ Register assembly="ArenaWeb" namespace="SVGControls" tagprefix="svg" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy" runat="server"></asp:ScriptManagerProxy>
<asp:UpdatePanel ID="UpdatePanelArena" runat="server">
    <ContentTemplate>
        <svg:Panel ID="Panel" runat="server">
        </svg:Panel>
        <asp:Timer ID="TimerArena" runat="server" Interval="100" Enabled="true" OnTick="TimerArena_Tick" />
    </ContentTemplate>
</asp:UpdatePanel>

