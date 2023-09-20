<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="enrollment.aspx.cs" Inherits="assessment.enrollment" %>

<!DOCTYPE html>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
    <script src="plugins/bootstrap/js/bootstrap.min.js"></script>
    <link rel="stylesheet" type="text/css" href="plugins/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="css/animation.css">
    <link rel="stylesheet" type="text/css" href="css/style.css">
    <link rel="stylesheet" type="text/css" href="plugins/themefisherFont/style.css">
    <script src="https://cdnjs.deepai.org/deepai.min.js"></script>
    <script src="js/enroll.js"></script>
</head>

<body>
    <form id="form1" runat="server">
    <!--header-->
    <section style="background-color: blue;min-height: 250px;width: 100%;">

    </section>

    <section class="text-center" style="padding:5% 30%;">
        <h1>Enrollment</h1>

        <div class="text-left">
            <div class="form-group">
                <label>Name</label>
                <asp:TextBox ID="txtName" class="form-control p-2" runat="server"></asp:TextBox>
               
            </div>

            <div class="form-group">
                <label>IC</label>
                <asp:TextBox ID="txtIc" class="form-control p-2" runat="server"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Phone</label>
                <asp:TextBox ID="txtPhone" class="form-control p-2" runat="server"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Email
                </label>
                <asp:TextBox ID="txtEmail" class="form-control p-2" runat="server"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Result</label><br>
                <asp:FileUpload ID="resultImage" runat="server" />
            </div>
            <asp:Button class="btn btn-block btn-primary btn-lg" ID="enrollBtn" runat="server" OnClick="enrollBtn_Click" Text="Submit" />
            <asp:Image ID="enhancedImage" runat="server" style="width:400px;height:auto"/>
            <!---fix image processing fix if got time-->
           <%-- <div class="form-group">
                <label>Result</label><br>
                <input id="resultImage" type="file" >

                <img src="#" id="enhancedImage" style="width:200px;height:auto"/>
            </div>

           <button class="btn btn-block btn-primary btn-lg" onclick="processImage()">Submit</button>--%>
   

    
          
        </div>



    </section>







    </form>







</body>
</html>
