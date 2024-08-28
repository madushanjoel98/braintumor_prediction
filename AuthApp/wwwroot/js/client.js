const baseUrl = 'http://localhost:5140/';

$(document).ready(function () {
    $("#resultcard").hide();
    loadData();

 $("#tpr").submit(function (e) { 
    e.preventDefault();
    predictData();
 });
});

async function sendRequest(data, endpoint, method) {
    // Replace with your actual base URL

    try {
        const response = await fetch(baseUrl + endpoint, {
            method: method,
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data) // Convert data to JSON string
        });

        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }

        const result = await response.json();
        return result;
    } catch (error) {
        return {
            status: error.message,
            statusText: error.message,
            error: error
        };
    }
}
// $select.append(
//     $('<option></option>').val(option.value).text(option.text)
// );

function loadData() {
    //pgen 
    var $locationselector = $('#tloc');
    var $tugrade = $('#tugrade');
    var $pgen = $('#pgen');

    $.ajax({
        type: "post",
        url: "api/getlocation",
        dataType: "json",
        headers: {
            'Content-Type': 'application/json'
        },
        success: function (response) {
            console.log(response);
            var loca = response.data.tumorLocations;
            var grade = response.data.tumorstype;
            var genders = response.data.genders;
            console.log(loca);

            loca.forEach(element => {
                $locationselector.append(
                    $('<option></option>').val(element).text(element)
                );
            });


            grade.forEach(element => {
                $tugrade.append(
                    $('<option></option>').val(element).text(element)
                );
            });
            genders.forEach(element => {
                $pgen.append(
                    $('<option></option>').val(element).text(element)
                );
            });



        }
    });


}

function predictData() {
    var locationselector = $('#tloc').val();
    var tugrade = $('#tugrade').val();
    var pgen = $('#pgen').val();
    var age = $("#age").val();
    var tsize = $("#tsize").val();

    var data = {
        "location": locationselector,
        "size__cm_": tsize,
        "type": tugrade,
        "gender": pgen,
        "patient_Age": age
    };
    
    console.log(data);

    $.ajax({
        type: "POST",
        url: "api/tumor",
        dataType: "json",
        data: JSON.stringify(data),
        headers: {
            'Content-Type': 'application/json'
        },
        success: function(response) {
            console.log(response);
            $("#resultcard").show(1000);
            $("#res").html(response.data.result);
        },
        error: function(xhr, status, error) {
            console.error("Error:", error);
            console.error("Status:", status);
            console.error("Response:", xhr.responseText);
            message("Fail",xhr.responseText,"error");
            // Display user-friendly error message
            $("#resultcard").hide();
            $("#res").html("An error occurred while processing your request. Please try again.");
        }
    });
}
function  loadpage(page) {
    $("#body").load(page);
    
  }

  function message(title,message,type) {
    Swal.fire({
        title: title,
        text: message,
        icon: type,
        customClass: {
            container: 'swal-light-container',
            popup: 'bg-light',
            title: 'swal-light-title',
            content: 'swal-light-content'
        }
      });


    }