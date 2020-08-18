$(document).ready(function () {
    flatpickr("#daterange", {
        mode: "range",
        "onOpen": function (selectedDates, dateStr, instance) {
            instance.setDate(instance.input.value, false);
        }
    });
    flatpickr("#datechange", {
        mode: "range",
        "onOpen": function (selectedDates, dateStr, instance) {
            instance.setDate(instance.input.value, false);
        }
    });
});