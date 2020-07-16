$(document).ready(function () {

})

function loadTienIch() {
    var mota = $('#dsmota');

    $.ajax({
        type: 'GET',
        url: '/api/Quanly/LayDanhSachTienIch',
        dataType: 'json',
        success: function (data) {
            mota.empty();

            $.each(data, function (index, val) {

                mota.prepend('<tr class="odd gradeX"><td class="center">' + val.TenTienIch + '</td><td class="center">' + val.MoTa + '</td><td class="center"><a class="btn btn-tbl-edit btn-xs" data-id="' + val.ID + '" ><i class="fa fa-pencil"></i></a><a class="btn btn-tbl-delete btn-xs" data-id="' + val.ID + '"><i class="fa fa-trash-o "></i></a></td></tr>');

            });

        }
    });
}