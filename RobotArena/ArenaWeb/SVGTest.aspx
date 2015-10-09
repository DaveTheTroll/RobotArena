<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SVGTest.aspx.cs" Inherits="ArenaWeb.SVGTest" %>

<%@ Register TagPrefix="svg" Assembly="ArenaWeb" Namespace="SVGControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function go() {
            setInterval(function () { tick() }, 125);
            }

        theta = 0

        function tick() {
            myText = document.getElementById("myText");
            myText.textContent = theta;
            myText.setAttribute("transform", "translate(102 215) scale(2) rotate(R)".replace("R", theta));
            theta++;
            if (theta >= 180)
                theta = theta -= 360;
        }
    </script>
</head>
<body onload="go()">
    <div style="border:2px solid darkGreen; background:YellowGreen">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Timer runat="server" OnTick="Unnamed1_Tick" Interval="100" Enabled="true"></asp:Timer>
                <asp:HiddenField ID="HiddenFieldRotation" runat="server" Value="0" />
                <svg:Panel runat="server" ID="svgPanel" Width="400" Height="200">
                    <svg:Rectangle runat="server" ID="svgRect" X="200" Y="100" Fill="#52B848" Stroke="#000000" StrokeMiterLimit="10" Width="80" Height="59" />
                    <svg:Rectangle runat="server" ID="svgRect2" X="200" Y="100" Fill="Orange" Stroke="Beige" Rotation="30" />
                    <svg:Text runat="server" ID="svgText" X="100" Y ="50">HELLO World!</svg:Text>
                    <svg:Circle runat="server" ID="svgCircle" X="40" Y="45" Radius="3" Fill="YellowGreen" Stroke="SaddleBrown" />
                </svg:Panel>
                </ContentTemplate>
        </asp:UpdatePanel>
    </form>
        </div>
    <div style="border:2px solid black">
        <svg version="1.1" id="mySvg" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" width="300px" height="300px" viewBox="0 0 300 300" enable-background="new 0 0 300 300" xml:space="preserve">
        <rect x="19" y="37" fill="#52B848" stroke="#000000" stroke-miterlimit="10" width="80" height="59" id="greenBlock" />
        <rect x="168" y="53" fill="#E61E25" stroke="#000000" stroke-miterlimit="10" width="80" height="59"/>
        <rect id="rc" x="35" y="179" fill="#DFE21D" stroke="#000000" stroke-miterlimit="10" width="227" height="81"/>
        <text id="myText" transform="translate(102 215) scale(2) rotate(30)" font-family="'Consolas'" font-size="12" id="textBlock">TESTING</text>
    </svg>
        </div>
</body>
</html>
