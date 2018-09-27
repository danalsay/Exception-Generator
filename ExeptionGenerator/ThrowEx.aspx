<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThrowEx.aspx.cs" Inherits="ExeptionGenerator.ThrowEx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>      
    
        <asp:DropDownList ID="ddlExceptions" runat="server" 
                        onselectedindexchanged="ddlExceptions_SelectedIndexChanged"
                        >
                       <asp:ListItem>Select Exception To Throw</asp:ListItem>
      
        </asp:DropDownList>
    </div>
    <asp:Button ID="Button1" runat="server" Text="Submit Exception" />
    
    </form>
</body>
</html>
