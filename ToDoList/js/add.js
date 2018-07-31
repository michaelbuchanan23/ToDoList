//add tasks for a user
"option strict"

function create() {

    //creating our task instance from the data that is passed in
    var task = {
        //Greg makes this a 0 because it will create the id number for us as a primary key with the controller
        Id: 0,
        Name: document.getElementById("pName").value,
        Completed: false,
    };

    //creating the task based on the information we put in the task variable above
    $.post("http://localhost:49997/Lists/Create/", task)
        .done(function (resp) {
            console.log(resp);
        });
}