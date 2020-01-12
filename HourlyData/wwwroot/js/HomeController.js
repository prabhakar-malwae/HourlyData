$(document).ready(function () {
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44373/home/getintervaldata',
        mimeType: 'json',
        success: function (data) {
            $.each(data, function (i, data) {
                var body = "<tr>";
                body += "<td>" + data.Id + "</td>";
                body += "<td>" + data.DeliveryPoint + "</td>";
                body += "<td>" + data.Date + "</td>";
                body += "<td>" + data.TimeSlot + "</td>";
                body += "<td>" + data.SlotValue + "</td>";            
                body += "</tr>";
                $("#example tbody").append(body);
            });
            /*DataTables instantiation.*/
            $("#example").DataTable(
                {
                    dom: 'Bfrtip',
                    buttons: [                       
                        'excel',                                       
                    ]
                }
            );
        },
        error: function () {
            alert('Fail!');
        }
    });
});