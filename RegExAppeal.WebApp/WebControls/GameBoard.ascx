<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GameBoard.ascx.cs" Inherits="RegExAppeal.WebApp.WebControls.GameBoard" %>

<asp:Repeater runat="server" ID="rptWords">
	<HeaderTemplate>
		<ul>
	</HeaderTemplate>
	<ItemTemplate>
			<li>
				<asp:Repeater runat="server" ID="rptCharacters">
					<ItemTemplate>
							<ps:CharacterButton runat="server" ID="character" CommandName="UpdateLetter" OnCommand="characterButton_Command" OnClick="characterButton_CharacterButtonClicked" />
					</ItemTemplate>
				</asp:Repeater>
			</li>
	</ItemTemplate>
	<FooterTemplate>
		</ul>
	</FooterTemplate>
</asp:Repeater>