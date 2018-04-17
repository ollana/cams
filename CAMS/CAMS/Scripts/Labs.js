﻿$(document).ready(function () {
        $(".draggable").draggable({
            containment: "#LabErea",
            grid: [20, 20]
        });
    });
SaveComputersLocations = function () {
    var coms = {};
    $(".draggable").each(function () {
        let Computer_Position = $(this).position();
        let Div_Height = parseFloat($(this).parent().css("height"));
        let Div_Width = parseFloat($(this).parent().css("width"));
        let New_Computer_Top = Math.round(Computer_Position.top * 100 / Div_Height);
        let New_Computer_Left = Math.round(Computer_Position.left * 100 / Div_Width);
        coms[$(this).children(2).text()] = New_Computer_Top + '%,' + New_Computer_Left + '%';
    });

    $.ajax({
        url: "/Activities/Update",
        type: 'post',
        data: { computers: coms },
        success: function (data) {
            alert(data);
        }
    });

};