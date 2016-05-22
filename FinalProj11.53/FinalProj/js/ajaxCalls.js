
function AthleteAuthenticate(request, successCB, errorCB) {

    var dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'WebService.asmx/GetAthleteInfo',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successCB,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB
    }) // end of ajax call
}

function sendAthleteEdit(request, successEditAth, errorCB) {

    var dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'WebService.asmx/UpdateAthlete',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successEditAth,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB
    }) // end of ajax call
}

function sendAgentEdit(request, successEditAg, errorCB) {

    var dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'WebService.asmx/UpdateAgent',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successEditAg,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB
    }) // end of ajax call
}
function sendTeamEdit(request, successEditTe, errorCB) {

    var dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'WebService.asmx/UpdateTeam',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successEditTe,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB
    }) // end of ajax call
}
function TeamAuthenticate(request, successTeamInfo, errorCB2) {

    var dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'WebService.asmx/GetTeamInfo',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successTeamInfo,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB2
    }) // end of ajax call
}

function AgentAuthenticate(request, successAgentInfo, errorCB2) {

    var dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'WebService.asmx/GetAgentInfo',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successAgentInfo,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB2
    }) // end of ajax call
}



function GetTeam() {
    $.ajax({ // ajax call starts
        url: 'WebService.asmx/GetAllTeams',        // server side web service method
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8',
        success: successTeam,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB
    });
}

function GetAgent() {
    $.ajax({ // ajax call starts
        url: 'WebService.asmx/GetAllagents',        // server side web service method
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8',
        success: successAgent,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB
    });
}

function sendAthReg(request, successAthleteReg, errorCB) {

    var dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'WebService.asmx/InsertAthlete',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successAthleteReg,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB
    }) // end of ajax call
}

function sendTeamReg(request, successAR, errorCB) {

    var dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'WebService.asmx/Insertteam',   // server side web service method
        data: dataString,// the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successAR,               // data.d id the Variable data contains the data we get from serverside
        error: errorCB
    }) // end of ajax call
}

function sendAgentReg(request, successAgentR, errorCB) {

    var dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'WebService.asmx/InsertAgent',   // server side web service method
        data: dataString,// the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successAgentR,               // data.d id the Variable data contains the data we get from serverside
        error: errorCB
    }) // end of ajax call
}
function GetAthleteVideo(request, successGetVideo, errorCB2) {

var dataString = JSON.stringify(request);

            $.ajax({ // ajax call starts
                url: 'WebService.asmx/GetAthletesVideos',   // server side web service method
                data: dataString,                          // the parameters sent to the server
                type: 'POST',                              // can be also GET
                dataType: 'json',                          // expecting JSON datatype from the server
                contentType: 'application/json; charset = utf-8', // sent to the server
                success: successGetVideo,                // data.d id the Variable data contains the data we get from serverside
                error: errorCB
            }) // end of ajax call
}

function InsertNewVideo(request, successVideoInsert, errorCB2) {

            var dataString = JSON.stringify(request);

            $.ajax({ // ajax call starts
                url: 'WebService.asmx/InsertNewVideo',   // server side web service method
                data: dataString,                          // the parameters sent to the server
                type: 'POST',                              // can be also GET
                dataType: 'json',                          // expecting JSON datatype from the server
                contentType: 'application/json; charset = utf-8', // sent to the server
                success: successVideoInsert,                // data.d id the Variable data contains the data we get from serverside
                error: errorCB
            }) // end of ajax call
}


function SendAthleteStats(requestDataString) {
    var dataObj = JSON.parse(requestDataString);
    
    $.ajax({ // ajax call starts
        url: 'WebService.asmx/InsertNewVideo',   
        data: dataString,                          
        type: 'POST',                              
        dataType: 'json',                          
        contentType: 'application/json; charset = utf-8', 
        success: function(res){console.log(res)},                
        error: function(err){console.log(err); alert(err);}
    });

}
