﻿$(document).ready(function () {
    $(".datepicker").datepicker($.datepicker.regional['he']);
    $("#fromDate").datepicker('option',{
        changeMonth: true,
        changeYear: true,
        onSelect: function (dateText, inst) {
            $("#toDate").removeAttr('disabled');
            $("#toDate").datepicker('option', {
                minDate: dateText
            })
        },
        maxDate: -1
    });
    $("#toDate").datepicker('option',{
        changeMonth: true,
        changeYear: true,
        maxDate: -1,
        onSelect: function (dateText, inst) {
            $("#fromDate").datepicker('option', {
                maxDate: dateText
            })
        } 
    });
    $("#fromTime").timepicker({ 'timeFormat': 'H:i', 'step': '60'});
    $("#toTime").timepicker({ 'timeFormat': 'H:i', 'step': '60'});
    $(".accordion")
        .accordion({
            collapsible: true,
            active: false,
            heightStyle: "content"
        });
    $(".accordion").find('input[type="checkbox"]').on('click', function (e) {
        e.preventDefault();
        e.stopPropagation();
        setTimeout(function () {
            this.checked = !this.checked;
        }.bind(this), 100);
    });
});
CreateReport = function () {
    var LabsId = [];
    var labs = document.getElementsByClassName('form-check-inline')
    for (var i = 0, n = labs.length; i < n; i++) {
        if (labs[i].checked) {
            LabsId.push(labs[i].value);
        }
    }
    $('#LabsIds').attr('value', LabsId.toString());
    var includeWeekends = !document.getElementById("excludeWeekends").checked;
    $('#includeWeekends').attr('value', includeWeekends);
    var allDay = document.getElementById("includeAllDay").checked;
    $('#includeAllDay').attr('value', allDay);
}
CheckboxDep = function (depId) {
    var checkboxesDeps = document.getElementsByClassName(depId);
    for (var i = 0, n = checkboxesDeps.length; i < n; i++) {
        checkboxesDeps[i].checked = document.getElementById(depId).checked;
    }
}
CheckboxAll = function (checked) {
    var deps = document.getElementsByClassName('form-check-label');
    for (var i = 0, n = deps.length; i < n; i++) {
        deps[i].checked = checked;
        CheckboxDep(deps[i].id);
    }
}
Checkbox = function (depId) {
    var checkboxes = document.getElementsByClassName(depId);
    var depCheckbox = document.getElementById(depId);
    for (var i = 0, n = checkboxes.length; i < n; i++) {
        if (!checkboxes[i].checked) {
            depCheckbox.checked = false;
            break;
        }
        depCheckbox.checked = true;
    }
}
AllDay = function () {
    if (document.getElementById("allDay").checked) {
        $("#fromTime").value = '00:00';
        $("#fromTime").attr('disabled', 'disabled');
        $("#toTime").value = '23:59';
        $("#toTime").attr('disabled', 'disabled');
    }
    else {
        $("#fromTime").removeAttr('disabled');
        $("#toTime").removeAttr('disabled');
    }
}
LabDetails = function (labId) {
    var labDetailsDiv = document.getElementById(labId);
    labDetailsDiv.removeAttribute('hidden');
}
DisplayLabReportDetails = function (labId) {
    $("#LabReportDiv").attr('hidden', 'hidden');
    $("#" + labId).removeAttr('hidden');
}
DisplayLabReport = function (labId) {
    $("#LabReportDiv").removeAttr('hidden');
    $("#" + labId).attr('hidden', 'hidden');
}