var listOfObjects = [];

$('.btn-success').on('click', function () {
    $("#" + this.id).toggleClass('btn-success btn-dannger');
    var arr = $(this).val().split(';');
    var game = {
        SelectedBet: arr[0],
        GameID: arr[1],
        BetKoeficent: arr[2],
        Team1: arr[3],
        Team2: arr[4],
        SpecialOffer: this.id.split('-')[1],
        SpecialOfferFactor: arr[5]
    };
    var removeElement = false;
    var newList = [];
    var previouslySelectedBet = 0;
    var preivouslySelectedGameID = 0;
    var temp = game;
    var counter = 0;
    if (game.SpecialOffer === "1")
        game.BetKoeficent = game.BetKoeficent * game.SpecialOfferFactor;
    if (game.SpecialOffer === "1") {
        listOfObjects.forEach(function (element) {
            if (element.BetKoeficent >= 1.1) {
                counter++;
            }
        });
    }

    listOfObjects.forEach(function (element) {
        if (element.SelectedBet === game.SelectedBet && element.GameID === game.GameID && element.BetKoeficent === game.BetKoeficent && element.Team1 === game.Team1 && element.Team2 === game.Team2 && element.SpecialOffer === game.SpecialOffer) {
            removeElement = true;
        }
        else if (element.GameID === game.GameID) {
            previouslySelectedBet = element.SelectedBet;
            previouslySelectedBetID = element.GameID;
            previouslySelectedBetTopOffer = element.SpecialOffer;
            $("#" + previouslySelectedBet + "_" + previouslySelectedBetID + "-" + previouslySelectedBetTopOffer).toggleClass('btn-success btn-dannger');
        }
        else {
            newList.push(element);
        }
    });
    listOfObjects = newList;
    if (removeElement === false) {
        listOfObjects.push(game);
    }
    $('#tabbleID').empty();
    listOfObjects.forEach(function (element) {
        $('#tabbleID').append("<tr id='row" + element.SelectedBet + "_" + element.GameID + "_" + element.SpecialOffer.toString() + "'><td>" + element.Team1 + "</td><td>" + element.Team2 + "</td><td>" + element.SelectedBet + "</td><td>" + element.BetKoeficent + "</td><td><button class='btn-dannger'>X</button></td></tr>");
        $("#row" + element.SelectedBet + "_" + element.GameID + "_" + element.SpecialOffer.toString() + "").click(function () {
            $('#row' + element.SelectedBet + "_" + element.GameID + "_" + element.SpecialOffer.toString()).remove();
            console.log("#" + element.SelectedBet + "_" + element.GameID + "_" + element.SpecialOffer.toString());
            $("#" + element.SelectedBet + "_" + element.GameID + "-" + element.SpecialOffer.toString()).toggleClass('btn-success btn-dannger');
            var br = 0;
            var removeElement = false;
            var newList = [];
            var previouslySelectedBet = 0;
            var preivouslySelectedGameID = 0;
            var temp = game;
            var counter = 0;
            if (game.SpecialOffer === 1)
                game.BetKoeficent = game.BetKoeficent * game.SpecialOfferFactor;
            if (game.SpecialOffer === 1) {
                listOfObjects.forEach(function (element) {
                    if (element.BetKoeficent >= 1.1) {
                        counter++;
                    }
                });
            }

            listOfObjects.forEach(function (element2) {
                if (element2.SelectedBet === element.SelectedBet && element2.GameID === element.GameID && element2.BetKoeficent === element.BetKoeficent && element2.Team1 === element.Team1 && element2.Team2 === element.Team2 && element2.SpecialOffer === element.SpecialOffer) {
                    removeElement = true;
                }
                else if (element2.GameID === element.GameID) {
                    previouslySelectedBet = element2.SelectedBet;
                    previouslySelectedBetID = element2.GameID;
                    previouslySelectedBetTopOffer = element2.SpecialOffer;
                    $("#" + previouslySelectedBet + "_" + previouslySelectedBetID + "-" + previouslySelectedBetTopOffer).toggleClass('btn-success btn-dannger');
                }
                else {
                    newList.push(element2);
                }
            });
            listOfObjects = newList;
            if (removeElement === false) {
                listOfObjects.push(game);
            }
        }
        );

    });
    var sum = 1;
    listOfObjects.forEach(function (element) {
        sum *= element.BetKoeficent;
    });
    $("#koeficinet").val(sum.toString());
    $("#expectedPayout").val(($("#betValue").val() * 0.95) * $("#koeficinet").val());
});
$("#betValue").on('change', function () {
    $("#expectedPayout").val(($("#betValue").val() * 0.95) * $("#koeficinet").val());
});
$("#submitButton").on('click', function () {
    /**/
    if ($("#betValue").val() > 0) {

        var data = {
            betValue: $("#betValue").val(),
            koeficientValue: $("#koeficinet").val(),
            expectedPayout: $("#expectedPayout").val(),
            listOfSelectedPairs: listOfObjects
        };
        var counter = 0;
        var hasSpecialOffer = false;
        debugger
        listOfObjects.forEach(function (element) {
            if (element.SpecialOffer === "1")
                hasSpecialOffer = true;
            if (element.BetKoeficent >= 1.1 && element.SpecialOffer === "0") {
                counter++;
            }
        });
        if (counter < 5 && hasSpecialOffer === true) {
            alert("For Special Offers you need To have atlest 5 pairs with coeficient 1.1 or more");
        }
        else {
            location.href = 'Tickets/Create?data=' + JSON.stringify(data);
        }
    }
    else {
        alert("Payment is to low");
    }
});

