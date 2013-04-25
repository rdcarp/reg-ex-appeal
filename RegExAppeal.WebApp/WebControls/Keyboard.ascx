<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Keyboard.ascx.cs" Inherits="RegExAppeal.WebApp.WebControls.Keyboard" %>
<asp:Repeater runat="server" ID="rptRows">
	<HeaderTemplate>
		<div>
	</HeaderTemplate>
	<ItemTemplate>
		<asp:Repeater runat="server" ID="rptLetters">
			<ItemTemplate>
				<ps:CharacterButton runat="server" ID="charButton" OnClick="charButton_Click"/>
			</ItemTemplate>
		</asp:Repeater>
	</ItemTemplate>
	<SeparatorTemplate>
		<br />
	</SeparatorTemplate>
	<FooterTemplate>
		</div>
	</FooterTemplate>
</asp:Repeater>