<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="assessment.aspx.cs" Inherits="assessment.assessment" %>


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

</head>

<body>
  <!--header-->
  <section style="background-color: blue;min-height: 250px;width: 100%;">

  </section>

  <section class="text-center" style="padding:5% 15%;">
    <h1>Assessment</h1>




    <style>
      .option-box {
        text-align: center;
        width: 25%;
        background-color: white;
        padding: 2% 3%;
        margin: 2% 2%;
        border: 2px solid #F5F5F5;
        cursor: pointer;
      }

      .option-box:hover,
      .option-box.selected {
        border: 2px solid #0080B2;
        color: #0080B2;
      }


      .hide {
        display: none;
      }

      .animated {
        -webkit-animation-duration: 0.5s;
        animation-duration: 0.5s;
        -webkit-animation-fill-mode: both;
        animation-fill-mode: both;
      }

      .fadeIn {
        -webkit-animation-name: fadeIn;
        animation-name: fadeIn;
      }

      .btn-page-control {
        border: none !important;
        height: 100%;
        width: 100%;
        transition: background-color 0.3s ease;
        font-size: 20px;
      }

      .btn-page-control:hover {
        background-color: black;
        color: white;
      }

      .page-item {
        min-height: 40vh;
      }
    </style>

    <div class="d-flex flex-row">
      <div class="col-lg-1">
        <button class="btn-page-control hide" id="btn-prev">
          <i class="tf-ion-chevron-left"></i>
        </button>
      </div>
      <div class="page-item animated fadeIn col-lg-10">
        <p>Question: Select the details of Assessment</p>

        <div class="text-left">
          <div class="form-group">
            <label>Select Programme</label>
            <select id="ddlProgramme" class="custom-select" fdprocessedid="6c1wdj">
              <option value="Diploma">Diploma</option>
              <option value="Bachelor Degree">Bachelor Degree</option>
            </select>
          </div>

          <div class="form-group">
            <label>Select Course</label>
            <select id="ddlCourse" class="custom-select" fdprocessedid="6c1wdj">
              <!--based on selected programme, onchange-->
              <option>Diploma in Computer Science</option>
              <option>Diploma in Software Engineering</option>
              <option>Diploma in Information Security</option>
              <option>Diploma in Information Technology</option>
            </select>
          </div>

          <div class="form-group">
            <label>Select Qualification to evaluate</label>
            <select id="ddlQualification" class="custom-select" fdprocessedid="6c1wdj">
              <option>SPM/O-level</option>
              <option>UEC</option>
            </select>
          </div>

        </div>
      </div>

      <div id="basicQualification" class="page-item animated fadeIn col-lg-10 hide">
        <div id="questionRow">
          <div class="form-group">
            <label class="question">You have a minimum grade of in 3 relevant subjects</label>
            <div class="subs" style="display: flex; flex-direction: row; flex-wrap: wrap;justify-content: center;">
              <div class="option-box" data-value="true">True</div>
              <div class="option-box" data-value="false">False</div>
            </div>
          </div>
          <div class="form-group">
            <label class="question">You have succesfully achieve a minimum grade of C in Math</label>
            <div class="subs" style="display: flex; flex-direction: row; flex-wrap: wrap;justify-content: center;">
              <div class="option-box" data-value="true">True</div>
              <div class="option-box" data-value="false">False</div>
            </div>
          </div>
          <div class="form-group">
            <label class="question">You have succefully achieve a minimum grade of C in additional math</label>
            <div class="subs" style="display: flex; flex-direction: row; flex-wrap: wrap;justify-content: center;">
              <div class="option-box" data-value="true">True</div>
              <div class="option-box" data-value="false">False</div>
            </div>
          </div>
        </div>

        <button type="submit" class="btn btn-block btn-primary btn-lg" onclick="getResult()">Get Result</button>

        <div id="questionTemplate" style="display:none">
          <div class="form-group">
            <label class="question">Question</label>
            <div class="subs" style="display: flex; flex-direction: row; flex-wrap: wrap;justify-content: center;">
              <div class="option-box" data-value="true">True</div>
              <div class="option-box" data-value="false">False</div>
            </div>
          </div>
        </div>
      </div>

      



      <div class="col-lg-1">
        <button class="btn-page-control" id="btn-next">
          <i class="tf-ion-chevron-right"></i>
        </button>
      </div>


    </div>



  </section>


</body>
<script src="js/common.js"></script>

</html>