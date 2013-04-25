<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="RegExAppeal.WebApp._Default" %>
	<%@ Register namespace="RegExAppeal.WebControls" tagPrefix="ps" assembly="RegExAppeal.WebControls" %>
	<%@ Register src="~/WebControls/GameBoard.ascx" tagPrefix="ps" tagName="GameBoard" %>
	<%@ Register src="~/WebControls/Keyboard.ascx" tagPrefix="ps" tagName="Keyboard" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>
	
	<ps:GameBoard runat="server" ID="gameBoard" />
	<hr />
	<ps:Keyboard runat="server" ID="keyboard" />

</asp:Content>
