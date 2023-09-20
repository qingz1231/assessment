<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckStatus.aspx.cs" Inherits="assessment.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <div class="form-group">
    <label>Enter IC</label>
    <asp:TextBox ID="txtIC" class="form-control p-2" runat="server"></asp:TextBox>
    <asp:Button class="btn btn-block btn-primary btn-lg" ID="sendBtn" runat="server" OnClick="sendBtn_Click" Text="Send" />
       <br />
    <label>Enter Code</label>
    <asp:TextBox ID="txtCode" class="form-control p-2" runat="server"></asp:TextBox>
    <asp:Button class="btn btn-block btn-secondary btn-lg" ID="submitBtn" runat="server" OnClick="submitBtn_Click" Text="Submit" />
</div>
        <asp:Label ID="lblErrorMessage" runat="server" Visible="false" ForeColor="Red"></asp:Label>
    </form>
    <div>
        <asp:Label ID="lblApplicationId" runat="server" Visible="false"></asp:Label>
        <br />
        <asp:Label ID="lblApplicantName" runat="server" Visible="false"></asp:Label>
        <br />
        <asp:Label ID="lblStatus" runat="server" Visible="false"></asp:Label>
        <br />
        <asp:Image ID="imgResult" runat="server" Visible ="false" />
    </div>
</body>
</html>
