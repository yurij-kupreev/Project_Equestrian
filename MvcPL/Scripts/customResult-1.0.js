function OnSuccess(data) {
    var results = $('#athleteResult');
    results.empty();
    results.append("<legend>" + data[0].AthleteName + " results</legend>")

    var table = document.createElement("table");
    table.setAttribute("class", "table table-striped table-hover");

    var tableHead = document.createElement("thead");
    var headRow = document.createElement("tr");
    var headCell1 = document.createElement("th");
    headCell1.appendChild(document.createTextNode("Place"));
    headRow.appendChild(headCell1);
    var headCell2 = document.createElement("th");
    headCell2.appendChild(document.createTextNode("Points"));
    headRow.appendChild(headCell2);
    var headCell3 = document.createElement("th");
    headCell3.appendChild(document.createTextNode("AthleteName"));
    headRow.appendChild(headCell3);
    var headCell4 = document.createElement("th");
    headCell4.appendChild(document.createTextNode("CompetitionTitle"));
    headRow.appendChild(headCell4);
    var headCell5 = document.createElement("th");
    headCell5.appendChild(document.createTextNode("CompetitionProgram"));
    headRow.appendChild(headCell5);

    tableHead.appendChild(headRow);
    table.appendChild(tableHead);

    var tableBody = document.createElement("tbody");

    for (var i = 0; i < data.length; i++) {
        var row = document.createElement("tr");
        var cell1 = document.createElement("td");
        cell1.appendChild(document.createTextNode(data[i].Place));
        row.appendChild(cell1);
        var cell2 = document.createElement("td");
        cell2.appendChild(document.createTextNode(data[i].Points));
        row.appendChild(cell2);
        var cell3 = document.createElement("td");
        cell3.appendChild(document.createTextNode(data[i].AthleteName));
        row.appendChild(cell3);
        var cell4 = document.createElement("td");
        cell4.appendChild(document.createTextNode(data[i].CompetitionTitle));
        row.appendChild(cell4);
        var cell5 = document.createElement("td");
        cell5.appendChild(document.createTextNode(data[i].CompetitionProgram));
        row.appendChild(cell5);
        tableBody.appendChild(row);
    }
    table.appendChild(tableBody);

    results.append(table);
}