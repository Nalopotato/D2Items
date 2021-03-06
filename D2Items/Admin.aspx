﻿<%@ Page Language="C#" MasterPageFile="~/D2.master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="D2Items.Admin" %>
<%@ MasterType VirtualPath="~/D2.master" %>

<asp:Content runat="server" ID="HeaderContent" ContentPlaceHolderID="ContentHeaderPlaceHolder" >
    <div class="section-header row-fluid">
        <h1 class="span8 d2font">Data Entry</h1>
    </div>
</asp:Content>

<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolder">
    <asp:Label runat="server" ID="updateLabel1" Text="" Visible="false" ForeColor="Red" Font-Bold="true" />

    <div class="content-block row">
    <div class="col-md-6">
            <asp:TextBox runat="server" ID="nameTB" Placeholder="Name" />
            <asp:TextBox runat="server" ID="levelTB" Placeholder="Level" />
            <asp:TextBox runat="server" ID="strTB" Placeholder="Strength" />
            <asp:TextBox runat="server" ID="dexTB" Placeholder="Dexterity" />

            <div class="d2divider col-md-12"></div>

            <asp:Panel ID="socketsPanel" runat="server">
                <asp:Label runat="server" Text="Sockets:" Width="15%" />
                <asp:DropDownList runat="server" ID="socketsDDL" Width="75">
                    <asp:ListItem Text="0"></asp:ListItem>
                    <asp:ListItem Text="1"></asp:ListItem>
                    <asp:ListItem Text="2"></asp:ListItem>
                    <asp:ListItem Text="3"></asp:ListItem>
                    <asp:ListItem Text="4"></asp:ListItem>
                    <asp:ListItem Text="5"></asp:ListItem>
                    <asp:ListItem Text="6"></asp:ListItem>
                </asp:DropDownList>
                <br />
            </asp:Panel>

            <UC:BaseTypePicker runat="server" ID="baseTypePicker1" InitialValue="0" InitialText="Base Type 1" IncludeInitialItem="true" />
            <br />
            <UC:BaseTypePicker runat="server" ID="baseTypePicker2" InitialValue="0" InitialText="Base Type 2" IncludeInitialItem="true" />
            <br />
            <UC:BaseTypePicker runat="server" ID="baseTypePicker3" InitialValue="0" InitialText="Base Type 3" IncludeInitialItem="true" />
            <br />

            <UC:SubTypePicker runat="server" ID="subTypePicker" InitialValue="0" InitialText="Item Type" IncludeInitialItem="true" />
            <br />
        
            <div class="d2divider col-md-12"></div>

            <asp:Panel ID="runesPanel" runat="server">
                <asp:Label runat="server" Text="Runes:" /><br />
                <UC:RunePicker runat="server" ID="runePicker1" InitialText="Rune 1" IncludeInitialItem="true" InitialValue="0" Width="75" />
                <UC:RunePicker runat="server" ID="runePicker2" InitialText="Rune 2" IncludeInitialItem="true" InitialValue="0" Width="75" />
                <UC:RunePicker runat="server" ID="runePicker3" InitialText="Rune 3" IncludeInitialItem="true" InitialValue="0" Width="75" />
                <UC:RunePicker runat="server" ID="runePicker4" InitialText="Rune 4" IncludeInitialItem="true" InitialValue="0" Width="75" />
                <UC:RunePicker runat="server" ID="runePicker5" InitialText="Rune 5" IncludeInitialItem="true" InitialValue="0" Width="75" />
                <UC:RunePicker runat="server" ID="runePicker6" InitialText="Rune 6" IncludeInitialItem="true" InitialValue="0" Width="75" />

                <div class="d2divider col-md-12"></div>
            </asp:Panel>

            <asp:Label runat="server" Text="Mods:" /><br />
            <UC:ModPicker runat="server" ID="modPicker1" InitialText="None" IncludeInitialItem="true" InitialValue="0" />
                <asp:TextBox runat="server" ID="modTB1" Placeholder="Value1" Width="75" />
                <asp:TextBox runat="server" ID="modTB1a" Placeholder="Value2" Width="75" />
            <UC:ModPicker runat="server" ID="modPicker2" InitialText="None" IncludeInitialItem="true" InitialValue="0" />
                <asp:TextBox runat="server" ID="modTB2" Placeholder="Value1" Width="75" />
                <asp:TextBox runat="server" ID="modTB2a" Placeholder="Value2" Width="75" />
            <UC:ModPicker runat="server" ID="modPicker3" InitialText="None" IncludeInitialItem="true" InitialValue="0" />
                <asp:TextBox runat="server" ID="modTB3" Placeholder="Value1" Width="75" />
                <asp:TextBox runat="server" ID="modTB3a" Placeholder="Value2" Width="75" />
            <UC:ModPicker runat="server" ID="modPicker4" InitialText="None" IncludeInitialItem="true" InitialValue="0" />
                <asp:TextBox runat="server" ID="modTB4" Placeholder="Value1" Width="75" />
                <asp:TextBox runat="server" ID="modTB4a" Placeholder="Value2" Width="75" />
            <UC:ModPicker runat="server" ID="modPicker5" InitialText="None" IncludeInitialItem="true" InitialValue="0" />
                <asp:TextBox runat="server" ID="modTB5" Placeholder="Value1" Width="75" />
                <asp:TextBox runat="server" ID="modTB5a" Placeholder="Value2" Width="75" />
            <UC:ModPicker runat="server" ID="modPicker6" InitialText="None" IncludeInitialItem="true" InitialValue="0" />
                <asp:TextBox runat="server" ID="modTB6" Placeholder="Value1" Width="75" />
                <asp:TextBox runat="server" ID="modTB6a" Placeholder="Value2" Width="75" />
            <UC:ModPicker runat="server" ID="modPicker7" InitialText="None" IncludeInitialItem="true" InitialValue="0" />
                <asp:TextBox runat="server" ID="modTB7" Placeholder="Value1" Width="75" />
                <asp:TextBox runat="server" ID="modTB7a" Placeholder="Value2" Width="75" />
            <UC:ModPicker runat="server" ID="modPicker8" InitialText="None" IncludeInitialItem="true" InitialValue="0" />
                <asp:TextBox runat="server" ID="modTB8" Placeholder="Value1" Width="75" />
                <asp:TextBox runat="server" ID="modTB8a" Placeholder="Value2" Width="75" />
            <UC:ModPicker runat="server" ID="modPicker9" InitialText="None" IncludeInitialItem="true" InitialValue="0" />
                <asp:TextBox runat="server" ID="modTB9" Placeholder="Value1" Width="75" />
                <asp:TextBox runat="server" ID="modTB9a" Placeholder="Value2" Width="75" />
            <UC:ModPicker runat="server" ID="modPicker10" InitialText="None" IncludeInitialItem="true" InitialValue="0" />
                <asp:TextBox runat="server" ID="modTB10" Placeholder="Value1" Width="75" />
                <asp:TextBox runat="server" ID="modTB10a" Placeholder="Value2" Width="75" />
            <UC:ModPicker runat="server" ID="modPicker11" InitialText="None" IncludeInitialItem="true" InitialValue="0" />
                <asp:TextBox runat="server" ID="modTB11" Placeholder="Value1" Width="75" />
                <asp:TextBox runat="server" ID="modTB11a" Placeholder="Value2" Width="75" />
            <UC:ModPicker runat="server" ID="modPicker12" InitialText="None" IncludeInitialItem="true" InitialValue="0" />
                <asp:TextBox runat="server" ID="modTB12" Placeholder="Value1" Width="75" />
                <asp:TextBox runat="server" ID="modTB12a" Placeholder="Value2" Width="75" />
            <UC:ModPicker runat="server" ID="modPicker13" InitialText="None" IncludeInitialItem="true" InitialValue="0" />
                <asp:TextBox runat="server" ID="modTB13" Placeholder="Value1" Width="75" />
                <asp:TextBox runat="server" ID="modTB13a" Placeholder="Value2" Width="75" />
            <UC:ModPicker runat="server" ID="modPicker14" InitialText="None" IncludeInitialItem="true" InitialValue="0" />
                <asp:TextBox runat="server" ID="modTB14" Placeholder="Value1" Width="75" />
                <asp:TextBox runat="server" ID="modTB14a" Placeholder="Value2" Width="75" />
            <UC:ModPicker runat="server" ID="modPicker15" InitialText="None" IncludeInitialItem="true" InitialValue="0" />
                <asp:TextBox runat="server" ID="modTB15" Placeholder="Value1" Width="75" />
                <asp:TextBox runat="server" ID="modTB15a" Placeholder="Value2" Width="75" />
            <UC:ModPicker runat="server" ID="modPicker16" InitialText="None" IncludeInitialItem="true" InitialValue="0" />
                <asp:TextBox runat="server" ID="modTB16" Placeholder="Value1" Width="75" />
                <asp:TextBox runat="server" ID="modTB16a" Placeholder="Value2" Width="75" />
            <br />
        </div>
        <div class="col-md-6">
            <asp:CheckBox runat="server" ID="ladderCB" Text="Ladder Only?" />
            <br />

            <asp:Label ID="Label1" runat="server" Text="Version:" Width="20%" />
            <asp:DropDownList runat="server" ID="versionDDL">
                <asp:ListItem Text="Any" Value="0"></asp:ListItem>
                <asp:ListItem Text="1.09" Value="9"></asp:ListItem>
                <asp:ListItem Text="1.10" Value="10"></asp:ListItem>
                <asp:ListItem Text="1.11" Value="11"></asp:ListItem>
            </asp:DropDownList>
            <br />

            <asp:Label ID="Label2" runat="server" Text="Class:" Width="20%" />
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
            <br />

            <div class="d2divider col-md-12"></div>

            <asp:RadioButtonList runat="server" ID="qualityRadioList">
                <asp:ListItem Text="Normal" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Exceptional" Value="1"></asp:ListItem>
                <asp:ListItem Text="Elite" Value="2"></asp:ListItem>
            </asp:RadioButtonList>

            <div class="d2divider col-md-12"></div>

            <asp:RadioButtonList runat="server" ID="rarityRadioList" AutoPostBack="true">
                <asp:ListItem Text="White/Gray" Value="0"></asp:ListItem>
                <asp:ListItem Text="Magic" Value="1"  style="color:darkblue;"></asp:ListItem>
                <asp:ListItem Text="Rare" Value="2" style="color:yellow; text-shadow: 0 0 2px #000000;"></asp:ListItem>
                <asp:ListItem Text="Unique" Value="3" style="color:orange;" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Set" Value="4" style="color:green;"></asp:ListItem>
                <asp:ListItem Text="Runeword" Value="5" style="color:orange;"></asp:ListItem>
                <asp:ListItem Text="Crafted" Value="6" style="color:red;"></asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Button runat="server" ID="submitButton" Text="Submit" OnClick="submitButton_Click" />

        </div>
    </div>
</asp:Content>
