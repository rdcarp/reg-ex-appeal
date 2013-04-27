<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
	CodeBehind="Default.aspx.cs" Inherits="RegExAppeal.WebApp._Default" %>

<%@ Register Src="~/WebControls/GameBoard.ascx" TagPrefix="ps" TagName="GameBoard" %>
<%@ Register Src="~/WebControls/Keyboard.ascx" TagPrefix="ps" TagName="Keyboard" %>
<%@ Register Src="~/WebControls/BestPredictionGuesser.ascx" TagPrefix="ps" TagName="BestPredictionGuesser" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
	<h2>
		Welcome to ASP.NET!
	</h2>
	<p>
		To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">
			www.asp.net</a>.
	</p>
	<p>
		You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
			title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
	</p>
	<asp:ScriptManager runat="server" />
	<asp:UpdatePanel runat="server" ID="pnl">
		<ContentTemplate>
			<ps:GameBoard runat="server" ID="gameBoard" />
			<hr />
			<ps:BestPredictionGuesser runat="server" ID="prediction" />
			<hr />
			<ps:Keyboard runat="server" ID="keyboard" />
		</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>
