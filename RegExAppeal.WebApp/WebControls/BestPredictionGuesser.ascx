<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BestPredictionGuesser.ascx.cs" Inherits="RegExAppeal.WebApp.WebControls.BestPredictionGuesser" %>
<%@ Import Namespace="RegExAppeal.Domain" %>

Possible Answers
<asp:Repeater runat="server" ID="rptAnswers">
	<ItemTemplate>
		<%# ((Answer)Container.DataItem).Value %>
	</ItemTemplate>
</asp:Repeater>

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

