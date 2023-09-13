
const diploma = [
    "You have successfully passed the subject of Sejarah (History) and Bahasa Malaysia (Malay Language)Did you pass sejarah and Bahasa Malaysia"
]


const spm_olevel = [
    "You have a minimum grade of in 3 relevant subjects",//basic
    "You have succesfully achieve a minimum grade of C in Math",//math
    "You have succefully achieve a minimum grade of C in additional math"//math
]

const uec = [
    "You have achieved a minimum grade of B in 3 relevant subjects",//basic
    "You have achieved a minimum grade of B in one math subject"//math
]

const diplomaCourse = [
    "Diploma in Computer Science",
    "Diploma in Software Engineering",
    "Diploma in Information Security",
    "Diploma in Information Technology"
]

const degreeCourse = [
    "Bachelor Degree in Software Engineering"
]

const diplomaQualification = [
    "SPM/O-level",
    "UEC"
]


let currentPage = 0;


const elements = document.querySelectorAll('.option-box');
elements.forEach(function (element) {
    element.addEventListener('click', function (event) {

        var parentElement = event.target.parentNode;
        var previousSelected = parentElement.querySelector('.selected');

        if (previousSelected != null) {
            previousSelected.classList.remove('selected')
        }
        this.classList.add('selected')
    });

});


const options = document.querySelectorAll('.option-box');

var courseArray;
document.getElementById("ddlProgramme").addEventListener('change', function () {


    var courseList = document.getElementById("ddlCourse");
    var courseArray;
    courseList.innerHTML = "";
    if (this.value == "Diploma") {
        courseArray = diplomaCourse;
    }

    else {
        courseArray = degreeCourse;
    }

    for (var i = 0; i < courseArray.length; i++) {
        var option = document.createElement("option");
        option.text = courseArray[i];
        courseList.add(option);
    }


})

//first page always assessment detail
//mid pages are dynamic based on first page options
//last page always result page
pages = document.getElementsByClassName("page-item");
const element = document.querySelector('.page-item#basicQualification');

document.getElementById("btn-prev").addEventListener('click', function () {
    pages[currentPage].classList.add('hide')
    currentPage -= 1;

    //if previos page is first page, previous button is hidden
    if (currentPage == 0) {
        this.classList.add('hide')
    }
    //if next page is not last page, show next button
    if (currentPage != pages.length - 1) {
        document.getElementById("btn-next").classList.remove('hide')
    }
    pages[currentPage].classList.remove('hide')

})

document.getElementById("btn-next").addEventListener('click', function () {
    pages[currentPage].classList.add('hide')
    currentPage += 1;
    //if next page is not first page, show previous button
    if (currentPage != 0) {
        document.getElementById("btn-prev").classList.remove('hide')
    }

    //if next page reach last page, next button is hideen
    if (currentPage == pages.length - 1) {
        this.classList.add('hide')
    }

    pages[currentPage].classList.remove('hide')
})


document.getElementById("ddlQualification").addEventListener('change', function () {
    var questionArray;
    if (this.value == diplomaQualification[0]) {
        questionArray = spm_olevel;
    }

    else if (this.value == diplomaQualification[1]) {
        questionArray = uec;
    }


    var questionRow = $('#questionRow');


    document.getElementById('questionRow').innerHTML = "";

    var questionTemplate = $('#questionTemplate');


    for (i = 0; i < questionArray.length; i++) {
        questionTemplate.find('.question').text(questionArray[i]);
        questionRow.append(questionTemplate.html());
    }

    var options = document.querySelectorAll('.option-box');
    options.forEach(function (element) {
        element.addEventListener('click', function (event) {

            var parentElement = event.target.parentNode;
            var previousSelected = parentElement.querySelector('.selected');

            if (previousSelected != null) {
                previousSelected.classList.remove('selected')
            }
            this.classList.add('selected')
        });

    });
})

function getResult() {
    var totalQuestion = document.getElementById('questionRow').getElementsByClassName('form-group').length;
    var totalTrue = document.querySelectorAll('.option-box.selected[data-value="true"]').length;
    var resultAssessment = document.getElementById('resultAssessment')
    var resultReason = document.getElementById('resultReason')

    document.getElementById('resultProgramme').innerHTML = document.getElementById('ddlCourse').value;

    if (totalQuestion > totalTrue) {
        resultAssessment.innerHTML = "Rejected"
        resultReason.innerHTML = "Basic Qualification not met"
    }

    else {
        var inputParameter = document.getElementById('ddlCourse').value
        $.ajax({
            type: "POST",
            url: "assessment.aspx/MyCSharpFunction", // Name of the WebMethod
            data: JSON.stringify({ inputParameter: inputParameter }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                // Handle the response from the server
                var result = response.d;



                if (result < 5) {
                    resultAssessment.innerHTML = "Approved (High)"
                    resultReason.innerHTML = "N/A"
                }
                else if (result < 10) {
                    resultAssessment.innerHTML = "Approved (Medium)"
                    resultReason.innerHTML = "N/A"
                }

                else if (result < 20) {
                    resultAssessment.innerHTML = "Approved (Low)"
                    resultReason.innerHTML = "N/A"
                }

                else {
                    resultAssessment.innerHTML = "Rejected"
                    resultReason.innerHTML = result;

                }
            },
            error: function (error) {
                alert("Error: " + error.responseText);
            }
        });
    }

}
























