//lists users and have checkbox to mark as done

"option strict"

function loaded() {
    $.getJSON("http://localhost:49997/Lists/List")
        .done(function (resp) {
            console.log(resp);
            display(resp.Data);
        });
}

function display(tasks) {
    var tbody = $("tbody");
    tbody.html("");
    for (var task of tasks) {
        var tr = $("<tr></tr>");
        tr.append($("<td>" + task.User.Name + "</td>"));
        tr.append($("<td>" + task.Name + "</td>"));
        tr.append($("<td><button class='btn btn-danger' onclick='completed(" + task + ")'>Completed</button></td>"));
        tbody.append(tr);
    }
}

function completed(task) {
    var item = {
        Id: task.Id,
        Name: task.Name,
        Completed: task.Completed
    };

    $.post("http://localhost:49997/Lists/Remove/", item)
        .done(function (resp) {
            console.log(resp);
        });
        
    loaded();
}