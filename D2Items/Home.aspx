<%@ Page Language="C#" MasterPageFile="~/D2.master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="D2Items.Home" %>
<%@ MasterType VirtualPath="~/D2.master" %>

<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolder">
    <asp:Button runat="server" ID="clearButton1" Text="Clear Fields" OnClick="clearButton_Click" />
    <div class="content-block">
        <asp:TextBox ID="nameTB" runat="server" Placeholder="Name" /><br />

        <asp:DropDownList runat="server" ID="classDDL">
            <asp:ListItem Text="Class"></asp:ListItem>
            <asp:ListItem Text="Amazon"></asp:ListItem>
            <asp:ListItem Text="Assassin"></asp:ListItem>
            <asp:ListItem Text="Barbarian"></asp:ListItem>
            <asp:ListItem Text="Druid"></asp:ListItem>
            <asp:ListItem Text="Necromancer"></asp:ListItem>
            <asp:ListItem Text="Paladin"></asp:ListItem>
            <asp:ListItem Text="Sorceress"></asp:ListItem>
        </asp:DropDownList><br />

        <asp:CheckBox runat="server" ID="ladderCB" Text="Ladder Only?" /><br />
        <br />

        <asp:Label runat="server" Text="Rarity" /><br />
        <asp:RadioButtonList runat="server" ID="rarityRadioList" AutoPostBack="true">
            <asp:ListItem Text="Unique" Value="0" style="color:orange;"></asp:ListItem>
            <asp:ListItem Text="Set" Value="1" style="color:green;"></asp:ListItem>
            <asp:ListItem Text="Runeword" Value="2" Selected="True" style="color:orange;"></asp:ListItem>
        </asp:RadioButtonList><br />

        <asp:Panel runat="server" ID="qualityPanel" Visible="false" >
            <asp:Label ID="Label1" runat="server" Text="Quality" /><br />
            <asp:RadioButtonList runat="server" ID="qualityRadioList">
                <asp:ListItem Text="Normal" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Exceptional" Value="1"></asp:ListItem>
                <asp:ListItem Text="Elite" Value="2"></asp:ListItem>
            </asp:RadioButtonList><br />
        </asp:Panel>

        <asp:Label runat="server" Text="Level Range" /><br />
        <uc:IntRangePicker ID="minLvlDDL" runat="server" Max="99" Width="75" />
        <uc:IntRangePicker ID="maxLvlDDL" runat="server" Max="99" Width="75" /><br />

        <asp:Label runat="server" Text="Strength Range" /><br />
        <asp:TextBox ID="minStrTB" runat="server" Width="75" MaxLength="3" />
        <asp:TextBox ID="maxStrTB" runat="server" Width="75" MaxLength="3" />
        <asp:CompareValidator ControlToValidate="minStrTB" runat="server" ErrorMessage="*" Operator="DataTypeCheck" Type="Integer" ></asp:CompareValidator>
        <asp:CompareValidator ControlToValidate="maxStrTB" runat="server" ErrorMessage="*" Operator="DataTypeCheck" Type="Integer" ></asp:CompareValidator><br />

        <asp:Label runat="server" Text="Dexterity Range" /><br />
        <asp:TextBox ID="minDexTB" runat="server" Width="75" MaxLength="3" />
        <asp:TextBox ID="maxDexTB" runat="server" Width="75" MaxLength="3" />
        <asp:CompareValidator ControlToValidate="minDexTB" runat="server" ErrorMessage="*" Operator="DataTypeCheck" Type="Integer" ></asp:CompareValidator>
        <asp:CompareValidator ControlToValidate="maxDexTB" runat="server" ErrorMessage="*" Operator="DataTypeCheck" Type="Integer" ></asp:CompareValidator><br />

        <asp:Label runat="server" Text="Base Type" Width="20%" /><br />
        <UC:BaseTypePicker ID="baseTypePicker" runat="server" InitialValue="0" InitialText="Select" IncludeInitialItem="true" />

        <asp:Panel runat="server" ID="runesPanel">
            <div class="row-fluid"><hr class="span12" /></div>

            <asp:Label runat="server" Text="Runes:" /><br />
            <UC:RunePicker runat="server" ID="runePicker1" InitialText="None" IncludeInitialItem="true" InitialValue="0" Width="75" />
            <UC:RunePicker runat="server" ID="runePicker2" InitialText="None" IncludeInitialItem="true" InitialValue="0" Width="75" />
            <UC:RunePicker runat="server" ID="runePicker3" InitialText="None" IncludeInitialItem="true" InitialValue="0" Width="75" />
            <UC:RunePicker runat="server" ID="runePicker4" InitialText="None" IncludeInitialItem="true" InitialValue="0" Width="75" />
        </asp:Panel>

        <div class="row-fluid"><hr class="span12" /></div>

        <asp:Label runat="server" Text="Mods:" /><br />
        <UC:ModPicker runat="server" ID="modPicker1" InitialText="None" IncludeInitialItem="true" InitialValue="0" /><br />
        <UC:ModPicker runat="server" ID="modPicker2" InitialText="None" IncludeInitialItem="true" InitialValue="0" /><br />
        <UC:ModPicker runat="server" ID="modPicker3" InitialText="None" IncludeInitialItem="true" InitialValue="0" /><br />
        <UC:ModPicker runat="server" ID="modPicker4" InitialText="None" IncludeInitialItem="true" InitialValue="0" /><br />

        <asp:Button runat="server" ID="submitButton" Text="Submit" OnClick="submitButton_Click" />
        <asp:Button runat="server" ID="clearButton2" Text="Clear Fields" OnClick="clearButton_Click" /><br />
        <br />

        <asp:ListView runat="server" ID="ItemList" OnPagePropertiesChanging="ItemList_PagePropertiesChanging">
            <LayoutTemplate>
                <div runat="server" id="ItemPlaceholder"></div>
        
                <asp:DataPager runat="server" ID="ItemsPager" PageSize="20" PagedControlID="ItemList">
                  <Fields>
                    <asp:NumericPagerField ButtonType="Link" ButtonCount="5" />
                  </Fields>
                </asp:DataPager>
            </LayoutTemplate>
    
            <ItemTemplate>
                <asp:HiddenField ID="itemID" runat="server" Value="<%# Container.DataItem.ID %>" />

                <div id="Div1" runat="server" class="inner-block" style="overflow: auto; overflow-y: hidden; max-width: 1400px;">
                    <asp:Label ID="Label2" runat="server" Text='<%# Container.DataItem.Name %>'></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text='<%# Container.DataItem.Lvl %>'></asp:Label>
                    <br/>
                    <asp:Label ID="Label4" runat="server" Text='<%# Container.DataItem.Str %>'></asp:Label>
                    <br/>
                    <asp:Label ID="Label5" runat="server" Text='<%# Container.DataItem.Dex %>'></asp:Label>
                </div>
            </ItemTemplate>
            <EmptyDataTemplate>
                There are no items with these filters
            </EmptyDataTemplate>
        </asp:ListView>
    </div>
</asp:Content>