$(document).ready(function () {
    $('#verifyOTP').hide();
    $('#Cpassword').hide();
    $('#submitBtn').hide();
});


$(document).ready(function () {
    $('#sendBtn').click(function () {
        var button = document.getElementById("sendBtn");
        var originalText = button.innerHTML;
        var countdown = 10; // Countdown time in seconds
        $('#verifyOTP').show();
        button.disabled = true;
        var countdownInterval = setInterval(function () {
            countdown--;
            if (countdown <= 0) {
                button.innerHTML = "Resend";
                button.disabled = false;
                clearInterval(countdownInterval);
            } else {
                button.innerHTML = ' ' + countdown + 's';
            }
        }, 1000); // Update every 1 second (1000 milliseconds)
    });
});

$(document).ready(function () {
    $('#verifyBtn').click(function () {
        $('#Cpassword').show();
        $('#submitBtn').show();
    });
});


// Confirm Password Validation

$(document).ready(function () {
    $("#confirmPassword").keyup(function () {
        var pwd = $("#password").val();
        var cpwd = $("#confirmPassword").val();
        var errorElement = $("#showErrorcpwd");

        if (cpwd !== pwd) {
            errorElement.html("Passwords do not match");
            errorElement.css("color", "red");
            return false;
        } else {
            errorElement.html("");
            return true;
        }
    });
});
