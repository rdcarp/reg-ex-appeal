<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BestPredictionGuesser.ascx.cs" Inherits="RegExAppeal.WebApp.WebControls.BestPredictionGuesser" %>

<%= SuggestionsToList %> most likely letters
<asp:Repeater runat="server" ID="rptLetters">
	<HeaderTemplate>
		<ol>
	</HeaderTemplate>
	<ItemTemplate>
		<li>
			<asp:Literal runat="server" ID="lit" />
		</li>
	</ItemTemplate>
	<FooterTemplate>
		</ol>
	</FooterTemplate>
</asp:Repeater>