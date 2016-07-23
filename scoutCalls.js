var AthleteSportType = { Soccer: 1, BasketBall: 2, HandBall: 3 };

function wireLoginPage() {
    localStorage.clear();
    p1 = document.getElementById("userName").value;
    p2 = document.getElementById("password").value;
    types = document.getElementsByName('type');
    for (var i = 0; i < types.length; i++) {
        if (types[i].checked) {
            p3 = types[i].value;
        }
    }

    if (p1 && p2 != null) {
        var request = {
            name: p1,
            pass: p2
        }

    }

    switch (p3) {
        case "Athlete":
            AthleteAuthenticate(request, s1, errorCB2);
            break;
        case "Agent":
            AgentAuthenticate(request, s2, errorCB2);
            break;
        case "Scout":
            TeamAuthenticate(request, s3, errorCB2);
            break;

    }
}

function typecheck() {
    check = localStorage.getItem("type");
    switch (check) {
        case "Athlete":
            window.location = "athProf.html";
            break;
        case "Agent":
            window.location = "agentProf.html";
            break;
        case "Team":
            window.location = "teamProf.html";
            break;
    }
}

function s1(results) {
    localStorage.clear();
    localStorage.setItem("type", p3);
    var userObj = JSON.parse(results.d);
    if (userObj.Id != 0) {
        localStorage.Id = userObj.Id;
        localStorage.pass = userObj.Password;
        localStorage.firstName = userObj.First_name;
        localStorage.lastName = userObj.Last_name;
        localStorage.sportID = userObj.SportID;
        localStorage.dob = userObj.Dob;
        localStorage.phone = userObj.Phone;
        localStorage.Email = userObj.Email;
        localStorage.hight = userObj.Hight
        localStorage.weight = userObj.Weight;
        localStorage.city = userObj.City;
        localStorage.agentName = userObj.AgentName;
        localStorage.teamName = userObj.TeamName;
        localStorage.isGolaey = userObj.IsGoaley;
        localStorage.sex = userObj.Sex;
        window.location = "athProf.html";

    } else {
        alert("No user or Incorect credentials,please try again");
    }
}

function AthleteIsGoaly()
{
    if (typeof localStorage.isGolaey === 'undefined'
        || localStorage.isGolaey == 'undefined'
        || localStorage.isGolaey==null)
        return false;
    return localStorage.isGolaey=='true';
}
function GetAthleteId()
{
    return localStorage.Id;
}


function GetAthleteType() {
    //AthleteSportType = { Soccer: 1, BasketBall: 2, HandBall: 3 };
    if (localStorage.sportID == "1") {
        return AthleteSportType.Soccer;
    }
    else if (localStorage.sportID == "2") {
        return AthleteSportType.BasketBall;
    }
    else if (localStorage.sportID == "3") {
        return AthleteSportType.HandBall;
    }
}

function writeAthlete() {
    $("#TopAtName").text(localStorage.firstName + " " + localStorage.lastName);
    $("#name").text(localStorage.firstName + " " + localStorage.lastName);
    $("#sex").text(localStorage.sex);
    if (localStorage.sportID == "1") {
        $("#sport").text("Soccer")
    }
    if (localStorage.sportID == "2") {
        $("#sport").text("Basketball")
    }
    if (localStorage.sportID == "3") {
        $("#sport").text("Handball")
    }
    $("#height").text(localStorage.hight);
    $("#weight").text(localStorage.weight);
    $("#city").text(localStorage.city);
    $("#team").text(localStorage.teamName);
    $("#phone").text(localStorage.phone);
    $("#email").text(localStorage.Email);
    $("#agent").text(localStorage.agentName);
}

function writeProfTemp() {
    $("#TopAtName").text(localStorage.firstName_temp + " " + localStorage.lastName_temp);
    $("#name").text(localStorage.firstName_temp + " " + localStorage.lastName_temp);
    $("#sex").text(localStorage.sex_temp);
    if (localStorage.sportID_temp == "1") {
        $("#sport").text("Soccer")
    }
    if (localStorage.sportID_temp == "2") {
        $("#sport").text("Basketball")
    }
    if (localStorage.sportID_temp == "3") {
        $("#sport").text("Handball")
    }
    $("#height").text(localStorage.hight_temp);
    $("#weight").text(localStorage.weight_temp);
    $("#city").text(localStorage.city_temp);
    $("#team").text(localStorage.teamName_temp);
    $("#phone").text(localStorage.phone_temp);
    $("#email").text(localStorage.Email_temp);
    $("#agent").text(localStorage.agentName_temp);
}

function s2(results) {
    localStorage.clear();
    localStorage.setItem("type", p3);
    var userObj = JSON.parse(results.d);
    if (userObj.LicenceNumber != "0") {
        localStorage.licenceNum = userObj.LicenceNumber;
        localStorage.pass = userObj.Password;
        localStorage.firstName = userObj.First_name;
        localStorage.lastName = userObj.Last_name;
        localStorage.dob = userObj.Dob;
        localStorage.phone = userObj.Phone;
        localStorage.eMail = userObj.Email;
        localStorage.city = userObj.City;
        window.location = "agentProf.html";

    } else {
        alert("No user or Incorect credentials,please try again");

    }
}

function writeAgent() {
    $("#TopAgName").text(localStorage.firstName + ' ' + localStorage.lastName);
    $("#AgName").text(localStorage.firstName + ' ' + localStorage.lastName);
    $("#License").text(localStorage.licenceNum);
    $("#AgPhone").text(localStorage.phone);
    $("#AgCity").text(localStorage.city);
    $("#AgMail").text(localStorage.eMail);
}

function s3(results) {
    localStorage.clear();
    localStorage.setItem("type", p3);
    var userObj = JSON.parse(results.d);
    if (userObj.TeamNumber != 0) {
        localStorage.TeamNumber = userObj.TeamNumber;
        localStorage.pass = userObj.Password;
        localStorage.firstName = userObj.First_name;
        localStorage.lastName = userObj.Last_name;
        localStorage.teamName = userObj.Team_name;
        localStorage.role = userObj.Role;
        localStorage.phone = userObj.Phone;
        localStorage.Email = userObj.Email;
        localStorage.city = userObj.City;
        window.location = "teamProf.html";

    } else {
        alert("No user or Incorect credentials,please try again");
    }
}

function writeTeam() {
    $("#Team").text(localStorage.teamName);
    $("#ConName").text(localStorage.firstName + ' ' + localStorage.lastName);
    $("#role").text(localStorage.role);
    $("#TePhone").text(localStorage.phone);
    $("#TeCity").text(localStorage.city);
    $("#TeMail").text(localStorage.Email);
}

function regAth() {
    if (document.getElementById("termCheck").checked != true) {
        alert("You didn't agree to our terms!");
        return;
    }
    v1 = document.getElementById("email").value;
    v2 = document.getElementById("password").value;
    v3 = document.getElementById("l_name").value;
    v4 = document.getElementById("f_name").value;
    v5 = document.getElementById("phone").value;
    v6 = document.getElementById("city").value;
    v7 = document.getElementById("height").value;
    v8 = document.getElementById("weight").value;
    v9 = document.getElementById("branch").value;

    if (document.getElementById("teamCheck").value == "not-chosen") {
        v10 = "0"
    }
    else {
        v10 = document.getElementById("teamCheck").value;
    }
    if (document.getElementById("agentCheck").value == "not-chosen") {
        v11 = "0"
    }
    else {
        v11 = document.getElementById("agentCheck").value;
    }
    v12 = document.getElementById("datepicker").value;
    if (document.getElementById("sex").checked == false) {
        v13 = "male";
    }
    else {
        v13 = "female";
    };
    if (document.getElementById("goaly").checked == false) {
        v14 = false;
    }
    else {
        v14 = true;
    };

    if (v1 && v2 && v3 && v4 && v5 && v6 && v7 && v8 && v9 && v12 && v13 && v14 != null) {
        request = {
            eMail: v1,
            pass: v2,
            lastName: v3,
            firstName: v4,
            phone: v5,
            sportName: v9,
            dob: v12,
            sex: v13,
            hight: v7,
            weight: v8,
            city: v6,
            isGoaley: v14,
            agentName: v11,
            teamName: v10
        }
    }
    else {
        alert("Please enter all fields required!")
    }

    sendAthReg(request, successAthReg, errorCB);

}

function successAthReg(results) {
    alert("Congratulation you have been added!");
    window.location = "index.html";

}
function editdath() {

    $("#f_name").text(localStorage.firstName);
    $("#l_name").text(localStorage.lastName);
    $("#height").text(localStorage.hight);
    $("#weight").text(localStorage.weight);
    $("#teamCheck").text(localStorage.teamName);
    $("#phone").text(localStorage.phone);
    $("#email").text(localStorage.Email);
    $("#password").text(localStorage.pass);

}
function editdag() {
    $("#f_name").text(localStorage.firstName);
    $("#l_name").text(localStorage.lastName);
    $("#phone").text(localStorage.phone);
    $("#email").text(localStorage.eMail);
    $("#password").text(localStorage.pass);

}

function editTeam() {
    $("#f_name").text(localStorage.firstName);
    $("#l_name").text(localStorage.lastName);
    $("#phone").text(localStorage.phone);
    $("#email").text(localStorage.Email);
    $("#password").text(localStorage.pass);
}


function updateAthleteInfo() {
    v7 = localStorage.Id;
    if (document.getElementById("email").value == "") {
        v1 = localStorage.Email;
    }
    else {
        v1 = document.getElementById("email").value
    }
    if (document.getElementById("password").value == "") {
        v2 = localStorage.pass;
    }
    else {
        v2 = document.getElementById("password").value
    }
    if (document.getElementById("f_name").value == "") {
        v3 = localStorage.firstName;
    }
    else {
        v3 = document.getElementById("f_name").value
    }
    if (document.getElementById("l_name").value == "") {
        v4 = localStorage.lastName;
    }
    else {
        v4 = document.getElementById("l_name").value
    }
    if (document.getElementById("phone").value == "") {
        v5 = localStorage.phone;
    }
    else {
        v5 = document.getElementById("phone").value
    }
    if (document.getElementById("city").value == "") {
        v6 = localStorage.city;
    }
    else {
        v6 = document.getElementById("city").value
    }
    if (document.getElementById("height").value == "") {
        v9 = localStorage.hight
    }
    else {
        v9 = document.getElementById("height").value
    }
    if (document.getElementById("weight").value == "") {
        v8 = localStorage.weight;
    }
    else {
        v8 = document.getElementById("weight").value
    }
    if (v1 && v2 && v3 && v4 && v5 && v6 != null) {
        request = {
            athleteID: v7,
            eMail: v1,
            lastNAme: v4,
            firstName: v3,
            phone: v5,
            city: v6,
            pass: v2,
            hight: v9,
            weight: v8
        }

    }
    else {
        alert("Please enter all fields required!")
    }
    sendAthleteEdit(request, successEditAthlete, errorCB);
}

function successEditAthlete() {
    localStorage.Email = v1;
    localStorage.pass = v2;
    localStorage.firstName = v3;
    localStorage.lastName = v4;
    localStorage.phone = v5;
    localStorage.city = v6;
    localStorage.hight = v9;
    localStorage.weight = v8;
    alert("You have been updated");
    window.location = "athProf.html";
}
function updateAgentInfo() {
    v1 = document.getElementById("email").value;
    v2 = localStorage.licenceNum;
    v3 = document.getElementById("f_name").value;
    v4 = document.getElementById("l_name").value;
    v5 = document.getElementById("phone").value;
    v6 = document.getElementById("city").value;
    if (v1 == "") {
        v1 = localStorage.eMail;
    }

    if (v3 == "") {
        v3 = localStorage.firstName;
    }
    if (v4 == "") {
        v4 = localStorage.lastName;
    }
    if (v5 == "") {
        v5 = localStorage.phone;
    }
    if (v6 == " ") {
        v6 = localStorage.city;
    }
    if (v1 && v2 && v3 && v4 && v5 && v6 != null) {
        request = {
            eMail: v1,
            lastNAme: v4,
            firstName: v3,
            phone: v5,
            city: v6,
            agentNum: v2
        }

    }
    else {
        alert("Please enter all fields required!")
    }
    sendAgentEdit(request, successEditAgent, errorCB);
}

function successEditAgent() {
    localStorage.Email = v1;
    localStorage.firstName = v3;
    localStorage.lastName = v4;
    localStorage.phone = v5;
    localStorage.city = v6;
    alert("You have been updated");
    window.location = "agentProf.html";
}

function updateTeamInfo() {
    v7 = localStorage.TeamNumber;
    v1 = document.getElementById("email").value;
    v3 = document.getElementById("f_name").value;
    v4 = document.getElementById("l_name").value;
    v5 = document.getElementById("phone").value;
    v6 = document.getElementById("city").value;
    if (v1 == "") {
        v1 = localStorage.Email;
    }

    if (v3 == "") {
        v3 = localStorage.firstName;
    }
    if (v4 == "") {
        v4 = localStorage.lastName;
    }
    if (v5 == "") {
        v5 = localStorage.phone;
    }
    if (v6 == "") {
        v6 = localStorage.city;
    }

    if (v1 && v3 && v4 && v5 && v6 && v7 != null) {
        request = {
            eMail: v1,
            lastNAme: v4,
            firstName: v3,
            phone: v5,
            city: v6,

            teamNum: v7
        }

    }
    else {
        alert("Please enter all fields required!")
    }
    sendTeamEdit(request, successEditTeam, errorCB);

}
function successEditTeam() {
    localStorage.Email = v1;
    localStorage.firstName = v3;
    localStorage.lastName = v4;
    localStorage.phone = v5;
    localStorage.city = v6;
    alert("You have been updated");
    window.location = "teamProf.html";
}

function registerAgent() {
    v1 = document.getElementById("email").value;
    v2 = document.getElementById("f_name").value;
    v3 = document.getElementById("l_name").value;
    v4 = document.getElementById("phone").value;
    v5 = document.getElementById("city").value;
    v6 = document.getElementById("datepicker").value;
    v7 = document.getElementById("number").value;
    v8 = document.getElementById("pass").value;

    if (document.getElementById("termCheck").checked != true) {
        alert("You didn't agree to our terms!");
        return;
    }
    if (v1 && v2 && v3 && v4 && v5 && v7 != null) {
        request = {
            eMail: v1,
            lastName: v3,
            firstName: v2,
            phone: v4,
            city: v5,
            dob: v6,
            agentNum: v7,
            pass: v8
        }

    }
    else {
        alert("Please enter all fields required!")
    }

    sendAgentReg(request, successAgentReg, errorCB);
}

function successAgentReg(results) {
    alert("Congratulation you have been added!");
    window.location = "index.html";

}

function regTeam() {
    if (document.getElementById("termCheck").checked != true) {
        alert("You didn't agree to our terms!");
        return;
    }

    v1 = document.getElementById("email").value;
    v2 = document.getElementById("f_name").value;
    v3 = document.getElementById("l_name").value;
    v4 = document.getElementById("phone").value;
    v5 = document.getElementById("city").value;
    if (document.getElementById("teamName").value == null) {
        v6 = "No Team"
    }
    else {
        v6 = document.getElementById("teamName").value;
    }
    v7 = document.getElementById("role").value;
    v8 = document.getElementById("pass").value;


    if (v1 && v2 && v3 && v4 && v5 && v6 && v7 && v8 != null) {
        request = {
            eMail: v1,
            lastName: v3,
            firstName: v2,
            phone: v4,
            city: v5,
            teamName: v6,
            pass: v8,
            role: v7
        }

    }
    else {
        alert("Please enter all fields required!")
    }


    sendTeamReg(request, successTeamReg, errorCB);
}

function successTeamReg() {
    alert("Congratulation you have been added!");
    window.location = "index.html";

}
function listTeam() {
    GetTeam(successTeam);
}

function listAgent() {
    GetAgent(successAgent, errorCB);
}

function successTeam(teamRes) {
    $('#teamCheck').empty();
    teamRes = $.parseJSON(teamRes.d);
    $('#teamCheck').append("<option selected value = 'not-chosen'>Choose your Team</option>");

    for (var i = 0; i < teamRes.length; i++) {

        var o = new Option(teamRes[i], teamRes[i]);
        /// jquerify the DOM object 'o' so we can use the html method
        $(o).html(teamRes[i]);
        $("#teamCheck").append(o);
    }

}



function successAgent(agentRes) {
    $('#agentCheck').empty();
    agentRes = $.parseJSON(agentRes.d);
    $('#agentCheck').append("<option selected value = 'not-chosen'>Choose your Agent</option>");

    for (var i = 0; i < agentRes.length; i++) {
        var o = new Option(agentRes[i], agentRes[i]);
        /// jquerify the DOM object 'o' so we can use the html method
        $(o).html(agentRes[i]);
        $("#agentCheck").append(o);

    }

}

function AddVideo() {
    var request = {
        athleteID: localStorage.Id,
        desc: Mdesc,
        date: Mdate,
        url: Mlink
    }
    InsertNewVideo(request, successVideoInsert, errorCB2);

}

function successVideoInsert() {
    alert("Video Insreted!")
    window.location = "Videos.html";
}

function GetVid(look) {
    if (look == 0) {
        var request = {
            athleteID: localStorage.Id
        }
    } else {
        var request = {
            athleteID: localStorage.Id_temp
        }
    }
    
    videoflag = true;
    GetAthleteVideo(request, successGetVideo, errorCB2);

}

function successGetVideo(results) {
    if (videoflag) {
        if (!$.trim(results)) {
            var userObj = JSON.parse(results.d);
            for (var i = 0; i < userObj.length; i++) {
                temp = userObj[i].VideoURL.split("/");
                youtubeID = temp[temp.length - 1].split("=");
                one = '<a href="' + userObj[i].VideoURL + '" data-toggle="lightbox" data-gallery="youtubevideos" class="col-sm-4">'
             + '<img src="//i1.ytimg.com/vi/' + youtubeID[1] + '/mqdefault.jpg" class="img-responsive"></a>';
                $("#videosDis").append(one);
            }
            videoflag = false;
        } else {
            alert("You had not uploaded videos yet :(")
        }
    }
}


function errorCB(e) {
    alert("I caught the exception : failed in AjaxArrFunc \n The exception message is : " + e.responseText);
}

function errorCB2(e) {
    alert("I caught the exception : failed in AjaxArrFunc \n The exception message is : " + e.responseText);
}

function GetMyTeamName()
{
    return localStorage.teamName;
}

function searchSuccess(resutls) {
    athleteList = $.parseJSON(resutls.d);
    namesonly = [];
    var temparr;
    for (var i = 0; i < athleteList.length; i++) {
        namesonly.push(athleteList[i].First_name + ' ' + athleteList[i].Last_name)
    }
    $("#inputName").autocomplete({
        source: namesonly
    });
}

function ShowFeed() {
    ShowFeedAjax(ShowFeedSuccess, errorCB)
}
function ShowFeedAjax(ShowFeedSuccess, errorCB) {


    $.ajax({ // ajax call starts
        url: 'WebService.asmx/GetFeed',   // server side web service method
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: ShowFeedSuccess,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB2
    }) // end of ajax call
}
function ShowFeedSuccess(data) {
    if (data != "") {
        var feedArr = JSON.parse(data.d);
        for (var i = 0; i < feedArr.length; i++) {
            if (feedArr[i].youtube != "") {
                youtubeLink = feedArr[i].youtube;
                $("#feedHead").append('<div class="panel-heading">' + feedArr[i].name + '</div>'
                + '<div class="panel-body">' + feedArr[i].description + '  ,<a href="' + youtubeLink +
                '" target="_blank">YouTube Link</a></div>');
            } else {
                $("#feedHead").append('<div class="panel-heading">' + feedArr[i].name + '</div>'
                + '<div class="panel-body">' + feedArr[i].description + '</div>');
            }
        }
    } else {
        $('#feedHead').append("Error in Feed,please refresh the page");
    }
}
