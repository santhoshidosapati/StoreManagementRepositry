<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Supervisor.aspx.cs" Inherits="StoreManagement.Aspx.Supervisor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        SuperMarket
    </title>
    <link href="../Jquery/jquery-ui.min.css" rel="stylesheet" type="text/css" />
    <link href="../Choseen/chosen.min.css" rel="stylesheet" type="text/css" />
    <link href="../Css/StyleSheet1.css" rel="stylesheet" type="text/css" />
    <script src="../Jquery/external/jquery/jquerry.js" type="text/javascript"></script>
    <script src="../Jquery/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Choseen/chosen.jquery.min.js" type="text/javascript"></script>
    <script src="../Js/Example.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="title" >
        
    </div>
    <div id="tabs">
      <ul>
        <li><a href="#Sales">Sales</a></li>
        <li><a href="#Items">Items</a></li>
    
      </ul>
      <div id="Sales">
           <div>
               <input type="button" id="btnSale" value="Sell" class="button" />
           </div>
           <div class="Dialog">
                <span>
                    <asp:Label ID="lblId" runat="server" Text="Id" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtId" runat="server" CssClass="text" ReadOnly="true"></asp:TextBox>
                </span>
                <span>
                    <asp:Label ID="lblItem" runat="server" Text="Item"  CssClass="label"></asp:Label>
                    <asp:DropDownList ID="ddlItem" runat="server" CssClass="chosen">
                    </asp:DropDownList>
                </span>
                <span>
                    <asp:Label ID="lblQuant" runat="server" Text="Quantity"  CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtQuant" runat="server"></asp:TextBox>
                </span>
                <span>
                    <asp:Label ID="lblPrice" runat="server" Text="Price"  CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtPrice" runat="server" ReadOnly="true"></asp:TextBox>
                </span>
                <span>
                    <input type="button" id="btnSubmit" value="Submit" class="button" />
                </span>
           </div>
      </div>
      <div id="Items">
            
      </div>
    </div>
    </form>
</body>
</html>
