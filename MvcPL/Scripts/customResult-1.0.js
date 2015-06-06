function OnSuccess(data) {
    var results = $('#athleteResult'); // получаем нужный элемент
    results.empty(); //очищаем элемент
    results.append("<legend>" + data[0].AthleteName + " results</legend>")
    var table = $("<table></table>").addClass("table table-striped table-hover");
    table.append("<thead></thead>").append("<tr><th>Place</th><th>Points</th><th>"
        + "AthleteName</th><th>CompetitionTitle</th><th>CompetitionProgram</th></tr>")
    table.append("<tbody></tbody");
    for (var i = 0; i < data.length; i++) {
        var row = $("<tr></tr>");
        row.append("<td>" + data[i].Place + "</td>");
        row.append("<td>" + data[i].Points + "</td>");
        row.append("<td>" + data[i].AthleteName + "</td>");
        row.append("<td>" + data[i].CompetitionTitle + "</td>");
        row.append("<td>" + data[i].CompetitionProgram + "</td>");
        table.append(row);
    }
    results.append(table);
}