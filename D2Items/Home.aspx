<%@ Page Language="C#" MasterPageFile="~/D2.master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="D2Items.Home" %>
<%@ MasterType VirtualPath="~/D2.master" %>

<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolder">
    <div class="content-block">
    <div class="col-md-2" style="float:none;">
        <asp:TextBox runat="server" ID="nameTB" Placeholder="Name" />
        <asp:TextBox runat="server" ID="levelTB" Placeholder="Level" />
        <asp:TextBox runat="server" ID="strTB" Placeholder="Strength" />
        <asp:TextBox runat="server" ID="dexTB" Placeholder="Dexterity" />
        <asp:CheckBox runat="server" ID="ladderCB" Text="Ladder Only?" />

        <asp:Label runat="server" Text="Version:" />
        <asp:DropDownList runat="server" ID="versionDDL">
            <asp:ListItem Text="1.09" Value="9"></asp:ListItem>
            <asp:ListItem Text="1.10" Value="10"></asp:ListItem>
            <asp:ListItem Text="1.11" Value="11"></asp:ListItem>
        </asp:DropDownList>

        <asp:Label runat="server" Text="Sockets: " />&nbsp;
        <asp:DropDownList runat="server" ID="socketsDDL">
            <asp:ListItem Text="0"></asp:ListItem>
            <asp:ListItem Text="1"></asp:ListItem>
            <asp:ListItem Text="2"></asp:ListItem>
            <asp:ListItem Text="3"></asp:ListItem>
            <asp:ListItem Text="4"></asp:ListItem>
            <asp:ListItem Text="5"></asp:ListItem>
            <asp:ListItem Text="6"></asp:ListItem>
        </asp:DropDownList>

        <asp:Label runat="server" Text="Item Type: " />
        <UC:ItemTypePicker runat="server" ID="itemTypePicker" />

        <asp:Label runat="server" Text="Class:" />
        <asp:DropDownList runat="server" ID="classDDL">
            <asp:ListItem Text="Any"></asp:ListItem>
            <asp:ListItem Text="Amazon"></asp:ListItem>
            <asp:ListItem Text="Assassin"></asp:ListItem>
            <asp:ListItem Text="Barbarian"></asp:ListItem>
            <asp:ListItem Text="Druid"></asp:ListItem>
            <asp:ListItem Text="Necromancer"></asp:ListItem>
            <asp:ListItem Text="Paladin"></asp:ListItem>
            <asp:ListItem Text="Sorceress"></asp:ListItem>
        </asp:DropDownList>

        <asp:Label runat="server" Text="Runes:" />
        <UC:RunePicker runat="server" ID="runePicker1" InitialText="None" IncludeInitialItem="true" InitialValue="0" />
        <UC:RunePicker runat="server" ID="runePicker2" InitialText="None" IncludeInitialItem="true" InitialValue="0" />
        <UC:RunePicker runat="server" ID="runePicker3" InitialText="None" IncludeInitialItem="true" InitialValue="0" />
        <UC:RunePicker runat="server" ID="runePicker4" InitialText="None" IncludeInitialItem="true" InitialValue="0" />
        <UC:RunePicker runat="server" ID="runePicker5" InitialText="None" IncludeInitialItem="true" InitialValue="0" />
        <UC:RunePicker runat="server" ID="runePicker6" InitialText="None" IncludeInitialItem="true" InitialValue="0" />
    
        <asp:RadioButtonList runat="server" ID="qualityRadioList">
            <asp:ListItem Text="Normal" Value="0" Selected="True"></asp:ListItem>
            <asp:ListItem Text="Exceptional" Value="1"></asp:ListItem>
            <asp:ListItem Text="Elite" Value="2"></asp:ListItem>
        </asp:RadioButtonList>

        <asp:Button runat="server" ID="submitButton" Text="Submit" OnClick="submitButton_Click" />
    </div></div>
</asp:Content>
