$(document).ready(function () {
    $(".ratingStar").click(function () {
        if (!$(this).hasClass("noClick")) {
            $(this).css("color", "#fb4c29");
            $(this).css("transition", "0.5s all");
            $(this).attr("checkedValue", "true");
            if ($(this).attr("id") === "ContentPlaceHolder1_starOneRating") {
                $("#ContentPlaceHolder1_starTwoRating").css("color", "#716969");
                $("#ContentPlaceHolder1_starTwoRating").css("transition", "0.5s all");
                $("#ContentPlaceHolder1_starThreeRating").css("color", "#716969");
                $("#ContentPlaceHolder1_starFourRating").css("color", "#716969");
                $("#ContentPlaceHolder1_starFiveRating").css("color", "#716969");
                $("#ContentPlaceHolder1_starThreeRating").css("transition", "0.5s all");
                $("#ContentPlaceHolder1_starFourRating").css("transition", "0.5s all");
                $("#ContentPlaceHolder1_starFiveRating").css("transition", "0.5s all");

            }
            if ($(this).attr("id") === "ContentPlaceHolder1_starTwoRating") {
                $("#ContentPlaceHolder1_starOneRating").css("color", "#fb4c29");
                $("#ContentPlaceHolder1_starOneRating").css("transition", "0.5s all");
                $("#ContentPlaceHolder1_starThreeRating").css("color", "#716969");
                $("#ContentPlaceHolder1_starFourRating").css("color", "#716969");
                $("#ContentPlaceHolder1_starFiveRating").css("color", "#716969");
                $("#ContentPlaceHolder1_starThreeRating").css("transition", "0.5s all");
                $("#ContentPlaceHolder1_starFourRating").css("transition", "0.5s all");
                $("#ContentPlaceHolder1_starFiveRating").css("transition", "0.5s all");
            }
            if ($(this).attr("id") === "ContentPlaceHolder1_starThreeRating") {
                $("#ContentPlaceHolder1_starOneRating").css("color", "#fb4c29");
                $("#ContentPlaceHolder1_starTwoRating").css("color", "#fb4c29");
                $("#ContentPlaceHolder1_starOneRating").css("transition", "0.5s all");
                $("#ContentPlaceHolder1_starTwoRating").css("transition", "0.5s all");
                $("#ContentPlaceHolder1_starFourRating").css("color", "#716969");
                $("#ContentPlaceHolder1_starFiveRating").css("color", "#716969");
            }
            if ($(this).attr("id") === "ContentPlaceHolder1_starFourRating") {
                $("#ContentPlaceHolder1_starOneRating").css("color", "#fb4c29");
                $("#ContentPlaceHolder1_starTwoRating").css("color", "#fb4c29");
                $("#ContentPlaceHolder1_starThreeRating").css("color", "#fb4c29");
                $("#ContentPlaceHolder1_starFiveRating").css("color", "#716969");
                $("#ContentPlaceHolder1_starOneRating").css("transition", "0.5s all");
                $("#ContentPlaceHolder1_starTwoRating").css("transition", "0.5s all");
                $("#ContentPlaceHolder1_starThreeRating").css("transition", "0.5s all");
                $("#ContentPlaceHolder1_starFiveRating").css("transition", "0.5s all");
            }
            if ($(this).attr("id") === "ContentPlaceHolder1_starFiveRating") {
                $("#ContentPlaceHolder1_starOneRating").css("color", "#fb4c29");
                $("#ContentPlaceHolder1_starTwoRating").css("color", "#fb4c29");
                $("#ContentPlaceHolder1_starThreeRating").css("color", "#fb4c29");
                $("#ContentPlaceHolder1_starFourRating").css("color", "#fb4c29");
                $("#ContentPlaceHolder1_starOneRating").css("transition", "0.5s all");
                $("#ContentPlaceHolder1_starTwoRating").css("transition", "0.5s all");
                $("#ContentPlaceHolder1_starThreeRating").css("transition", "0.5s all");
                $("#ContentPlaceHolder1_starFourRating").css("transition", "0.5s all");
            }
        }
    });
});