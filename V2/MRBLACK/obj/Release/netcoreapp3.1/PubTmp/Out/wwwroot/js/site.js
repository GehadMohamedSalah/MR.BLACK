$(".arText").on("keypress", function (event) {
    var arabicAlphabetDigits = /[\u0600-\u06ff]|[\u0750-\u077f]|[\ufb50-\ufc3f]|[\ufe70-\ufefc]|[\u0200]|[\u00A0]/g;
    var key = String.fromCharCode(event.which);
    if (event.keyCode == 8 || event.keyCode == 37 || event.keyCode == 39 || arabicAlphabetDigits.test(key)
        || key == "0" || key == "1" || key == "2" || key == "3" || key == "4" || key == "5" || key == "6" || key == "7" || key == "8" || key == "9" || key == " ") {
        return true;
    }
    return false;
});

$('.arText').on("paste", function (e) {
    e.preventDefault();
});


$(".enText").on("keypress", function (event) {

    var englishAlphabetAndWhiteSpace = /[A-Za-z ]/g;
    var key = String.fromCharCode(event.which);

    if (event.keyCode == 8 || event.keyCode == 37 || event.keyCode == 39 || englishAlphabetAndWhiteSpace.test(key)
        || key == "0" || key == "1" || key == "2" || key == "3" || key == "4" || key == "5" || key == "6" || key == "7" || key == "8" || key == "9" || key == " ") {
        return true;
    }

    return false;
});

$('.enText').on("paste", function (e) {
    e.preventDefault();
});

$(function () {
    $(".close").css("color", "red");
    $(".close").css("font-size", "25px");
});