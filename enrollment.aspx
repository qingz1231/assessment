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
    <script src="js/enroll.js"></script>
</head>

<body>
    <!--header-->
    <section style="background-color: blue;min-height: 250px;width: 100%;">

    </section>

    <section class="text-center" style="padding:5% 30%;">
        <h1>Enrollment</h1>

        <div class="text-left">
            <%--<div class="form-group">
                <label>Name</label>
                <input id="txtName" type="text" class="form-control p-2">
            </div>

            <div class="form-group">
                <label>IC</label>
                <input id="txtIc" type="number" class="form-control p-2">
            </div>

            <div class="form-group">
                <label>Phone</label>
                <input id="txtPhone" type="tel" class="form-control p-2">
            </div>

            <div class="form-group">
                <label>Email</label>
                <input id="txtEmail" type="email" class="form-control p-2">
            </div>--%>

            <div class="form-group">
                <label>Result</label><br>
                <input id="resultImage" type="file" >
            </div>

           <button class="btn btn-block btn-primary btn-lg" onclick="getText()">Submit</button>
   

    
          
        </div>



    </section>







</body>
<script src="js/common.js"></script>
</html>
