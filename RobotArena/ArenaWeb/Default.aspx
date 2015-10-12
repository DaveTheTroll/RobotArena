<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ArenaWeb._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
            </hgroup>
            <p>
              Welcome to <b>The Arena</b>
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <ul>
        <li><a href="Arena.asmx">Arena Service</a></li>
        <li><a href="ArenaList.aspx">Arena List</a></li>
        <li><a href="SVGTest.aspx">SVG Test</a></li>
        <li><a href="WhoAmI.aspx">Who am I?</a></li>
    </ul>
</asp:Content>
