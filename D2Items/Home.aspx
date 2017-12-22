<%@ Page Language="C#" MasterPageFile="~/D2.master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="D2Items.Home" %>
<%@ MasterType VirtualPath="~/D2.master" %>
<%@ Import Namespace="System.Data" %>

<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolder">
    <div class="content-block row">
        <div class="col-md-4">
        <asp:TextBox ID="nameTB" runat="server" Placeholder="Name" /><br />

        <asp:DropDownList runat="server" ID="classDDL" AutoPostBack="true">
            <asp:ListItem Text="Class"></asp:ListItem>
            <asp:ListItem Text="Amazon"></asp:ListItem>
            <asp:ListItem Text="Assassin"></asp:ListItem>
            <asp:ListItem Text="Barbarian"></asp:ListItem>
            <asp:ListItem Text="Druid"></asp:ListItem>
            <asp:ListItem Text="Necromancer"></asp:ListItem>
            <asp:ListItem Text="Paladin"></asp:ListItem>
            <asp:ListItem Text="Sorceress"></asp:ListItem>
        </asp:DropDownList><br />

        <asp:CheckBox runat="server" ID="ladderCB" Text="Ladder Only?" AutoPostBack="true" /><br />
        <br />

        <asp:Label runat="server" Text="Rarity" /><br />
        <asp:RadioButtonList runat="server" ID="rarityRadioList" AutoPostBack="true">
            <asp:ListItem Text="Unique" Value="3" style="color:orange;"></asp:ListItem>
            <asp:ListItem Text="Set" Value="4" style="color:green;"></asp:ListItem>
            <asp:ListItem Text="Runeword" Value="5" Selected="True" style="color:orange;"></asp:ListItem>
        </asp:RadioButtonList><br />

        <asp:Panel runat="server" ID="qualityPanel" Visible="false">
            <asp:Label ID="Label1" runat="server" Text="Quality" /><br />
            <asp:RadioButtonList runat="server" ID="qualityRadioList" AutoPostBack="true">
                <asp:ListItem Text="Normal" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Exceptional" Value="1"></asp:ListItem>
                <asp:ListItem Text="Elite" Value="2"></asp:ListItem>
            </asp:RadioButtonList><br />
        </asp:Panel>

        <asp:Label runat="server" Text="Sockets" /><br />
        <UC:IntRangePicker ID="socketsDDL" runat="server" Max="6" Width="75" AutoPostBack="true"/><br />

        <asp:Label runat="server" Text="Level Range" /><br />
        <UC:IntRangePicker ID="minLvlDDL" runat="server" Max="89" Width="75" AutoPostBack="true" />
        <UC:IntRangePicker ID="maxLvlDDL" runat="server" Max="89" Width="75" AutoPostBack="true" /><br />

        <asp:Label runat="server" Text="Strength Range" /><br />
        <asp:TextBox ID="minStrTB" runat="server" Width="75" MaxLength="3" Placeholder="0" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" />
        <asp:TextBox ID="maxStrTB" runat="server" Width="75" MaxLength="3" Placeholder="300" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" /><br />

        <asp:Label runat="server" Text="Dexterity Range" /><br />
        <asp:TextBox ID="minDexTB" runat="server" Width="75" MaxLength="3" Placeholder="0" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" />
        <asp:TextBox ID="maxDexTB" runat="server" Width="75" MaxLength="3" Placeholder="300" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" /><br />

        <asp:Label runat="server" Text="Base Type" Width="20%" /><br />
        <UC:BaseTypePicker ID="baseTypePicker" runat="server" InitialValue="0" InitialText="Select" IncludeInitialItem="true" AutoPostBack="true" />
        

        <asp:Panel runat="server" ID="runesPanel" CssClass="d2divider">
            <div style="margin-top: 10px;">
                <UC:RunePicker runat="server" ID="runePicker1" AutoPostBack="true" InitialText="Rune 1" IncludeInitialItem="true" InitialValue="0" Width="85" OnSelectedIndexChanged="runePicker1_SelectedIndexChanged" />
                <UC:RunePicker runat="server" ID="runePicker2" AutoPostBack="true" InitialText="Rune 2" IncludeInitialItem="true" InitialValue="0" Width="85" Visible="false" OnSelectedIndexChanged="runePicker2_SelectedIndexChanged" />
                <UC:RunePicker runat="server" ID="runePicker3" AutoPostBack="true" InitialText="Rune 3" IncludeInitialItem="true" InitialValue="0" Width="85" Visible="false" OnSelectedIndexChanged="runePicker3_SelectedIndexChanged" />
                <UC:RunePicker runat="server" ID="runePicker4" AutoPostBack="true" InitialText="Rune 4" IncludeInitialItem="true" InitialValue="0" Width="85" Visible="false" />
            </div>
        </asp:Panel>

        <br />
        <asp:Label runat="server" Text="Mods:" /><br />
        <UC:ModPicker runat="server" ID="modPicker1" InitialText="None" IncludeInitialItem="true" InitialValue="0" AutoPostBack="true" /><br />
        <UC:ModPicker runat="server" ID="modPicker2" InitialText="None" IncludeInitialItem="true" InitialValue="0" AutoPostBack="true" /><br />
        <UC:ModPicker runat="server" ID="modPicker3" InitialText="None" IncludeInitialItem="true" InitialValue="0" AutoPostBack="true" /><br />
        <UC:ModPicker runat="server" ID="modPicker4" InitialText="None" IncludeInitialItem="true" InitialValue="0" AutoPostBack="true" /><br />
    
        <asp:Button runat="server" ID="submitButton" Text="Submit" OnClick="submitButton_Click" />
        <asp:Button runat="server" ID="clearButton2" Text="Clear Fields" OnClick="clearButton_Click" /><br />
        <br />
    </div>
    <div class="col-md-8">
        <asp:ListView runat="server" ID="ItemList" OnPagePropertiesChanging="ItemList_PagePropertiesChanging">

            <LayoutTemplate>
                <div runat="server" id="ItemPlaceholder"></div>
        
                <asp:DataPager runat="server" ID="ItemsPager" PageSize="5" PagedControlID="ItemList">
                  <Fields>
                    <asp:NumericPagerField ButtonType="Link" ButtonCount="10" PreviousPageText="<-" NextPageText="->" />
                  </Fields>
                </asp:DataPager>
            </LayoutTemplate>
    
            <ItemTemplate>
                <div id="Div1" runat="server" class="inner-block" style="overflow: auto; overflow-y: hidden; margin: 8px 0px 5px 3px;">
                    <div style="border-bottom: 1px solid #d2e6fc;"></div>
                    <asp:Label ID="Label2" runat="server" CssClass="d2font" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></asp:Label>
                    <br />
                    <div id="ItemListDiv" class="col-md-4">
                        <asp:Label ID="Label8" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BaseType1") %>'></asp:Label>
                        <asp:Label ID="Label10" runat="server" Text='<%# " or " + DataBinder.Eval(Container.DataItem, "BaseType2") %>' 
                            Visible='<%# DataBinder.Eval(Container.DataItem, "BaseType2") != null %>'></asp:Label>
                        <asp:Label ID="Label11" runat="server" Text='<%# " or " + DataBinder.Eval(Container.DataItem, "BaseType3") %>' 
                            Visible='<%# DataBinder.Eval(Container.DataItem, "BaseType3") != null %>'></asp:Label>
                        <br />
                        <asp:Panel runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "Rune1") != null %>'>
                            <asp:Label ID="Label9" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Rune1") + " " + DataBinder.Eval(Container.DataItem, "Rune2") + " " + DataBinder.Eval(Container.DataItem, "Rune3") + " " + 
                                    DataBinder.Eval(Container.DataItem, "Rune4") + " " + DataBinder.Eval(Container.DataItem, "Rune5") + " " + DataBinder.Eval(Container.DataItem, "Rune6")  %>' ForeColor="DarkViolet"></asp:Label>
                            <br />
                        </asp:Panel>
                        <asp:Label ID="Label4" runat="server" Text='<%# "Str: " + DataBinder.Eval(Container.DataItem, "Str") %>'></asp:Label>
                        <br/>
                        <asp:Label ID="Label5" runat="server" Text='<%# "Dex: " + DataBinder.Eval(Container.DataItem, "Dex") %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label3" runat="server" Text='<%# "Level: " + DataBinder.Eval(Container.DataItem, "Lvl") %>' ForeColor="DarkRed" Font-Bold="true"></asp:Label>
                        <br/>
                        <asp:Panel runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "Ladder") %>'>
                            <asp:Label ID="Label7" runat="server" Text="Ladder Only" ForeColor="DarkOrange" Font-Bold="true"></asp:Label>
                            <br />
                        </asp:Panel>
                        <asp:Panel runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "Class") != null %>'>
                            <asp:Label ID="Label6" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Class") %>'></asp:Label>
                        </asp:Panel>
                    </div>
                    <div id="ModsListDiv" class="col-md-8 text-center">
                        <asp:ListView runat="server" ID="ModsList" DataSource='<%# DataBinder.Eval(Container.DataItem, "ModsList") %>'>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></asp:Label>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name").ToString() == "To Skill" || DataBinder.Eval(Container.DataItem, "Name").ToString() == "To Skill Charge" ? DataBinder.Eval(Container.DataItem, "Skill") : DataBinder.Eval(Container.DataItem, "ModValue1") %>' 
                                    Visible='<%# ((double)(DataBinder.Eval(Container.DataItem, "ModValue1")) != 0) %>'></asp:Label>
                                <asp:Label runat="server" Text='<%# " - " + DataBinder.Eval(Container.DataItem, "ModValue2") %>' 
                                    Visible='<%# ((double)(DataBinder.Eval(Container.DataItem, "ModValue2")) != 0) %>'></asp:Label>
                                <br />
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </div>
            </ItemTemplate>
            <EmptyDataTemplate>
                There are no items with these filters
            </EmptyDataTemplate>
        </asp:ListView>
        </div>
    </div>
</asp:Content>