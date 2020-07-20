//API/TienIch
//var layDSTienIch = 'Quanly/LayDanhSachTienIch';
//var themTienIch = 'Quanly/ThemTienIch';
//var suaTienIch = 'Quanly/CapNhatTienIch';
//var xoaTienIch = 'Quanly/XoaTienIch';



function loadData(idList, url) {
    var position = $(idList);

    $.ajax({
        type: 'GET',
        url: '/api/' + url,
        dataType: 'json',
        success: function (data) {
            position.empty();

            $.each(data, function (index, val) {
                if (url == 'Quanly/LayDanhSachTienIch') {
                    position.prepend('<tr class="odd gradeX"><td class="center">' + val.TenTienIch + '</td><td class="center">' + val.MoTa + '</td><td class="center"><a class="btn btn-tbl-edit btn-xs" data-id="' + val.ID + '" ><i class="fa fa-pencil"></i></a><a class="btn btn-tbl-delete btn-xs" data-id="' + val.ID + '"><i class="fa fa-trash-o "></i></a></td></tr>');
                }
                if (url == 'Quanly/LayDanhSachDichVu') {
                    position.prepend('<tr class="odd gradeX"><td class="center">' + val.TenDichVu + '</td><td class="center">' + val.Gia + '</td><td class="center">' + val.MoTa + '</td><td class="center"><a class="btn btn-tbl-edit btn-xs" data-id="' + val.ID + '" ><i class="fa fa-pencil"></i></a><a class="btn btn-tbl-delete btn-xs" data-id="' + val.ID + '"><i class="fa fa-trash-o "></i></a></td></tr>');
                }
                if (url == 'Quanly/LayDanhSachPhong') {
                    var tt = "Trống";
                    if (val.TrangThai) {
                        tt = "Đang sử dụng"
                    }
                    position.prepend('<tr class="odd gradeX"><td class="center">' + val.MaPhong + '</td><td class="center">' + val.SoPhong + '</td><td class="center">' + val.LoaiPhong + '</td><td class="center">' + val.Gia + '</td><td class="center">' + tt + '</td><td class="center"><a class="btn btn-tbl-edit btn-xs btn-edit" data-id="' + val.ID + '"><i class="fa fa-pencil"></i></><a class="btn btn-tbl-delete btn-xs btn-delete" data-id="' + val.ID + '"><i class="fa fa-trash-o "></i></a></td></tr>');
                }
                if (url == 'Quanly/LayDanhSachTaiKhoan') {
                    position.prepend('<tr class="odd gradeX"><td class="center">' + val.TenTaiKhoan + '</td><td class="center">' + val.MatKhau + '</td><td class="center">' + val.HoVaTen + '</td><td class="center">' + val.SoDienThoai + '</td><td class="center">' + val.Mail + '</td><td class="center">' + val.LoaiTaiKhoan + '</td><td class="center"><a class="btn btn-tbl-edit btn-xs" data-id="' + val.ID + '"><i class="fa fa-pencil"></i></a><a class="btn btn-tbl-delete btn-xs" data-id="' + val.ID + '"><i class="fa fa-trash-o "></i></a></td></tr>');
                }
                if (url == 'NhanVien/LayDanhSachDoan') {
                    var tgNhan = new Date(val.ThoiGianNhan);
                    var tgTra = new Date(val.ThoiGianTra);
                    var ngayGui = new Date(val.NgayGui);
                    position.prepend('<tr class="odd gradeX"><td class="center">' + val.TenDoan + '</td><td class="center">' + val.TenTruongDoan + '</td><td class="center">' + tgNhan.getDate() + '-' + (tgNhan.getMonth() + 1) + '-' + tgNhan.getFullYear() + '</td><td class="center">' + tgTra.getDate() + '-' + (tgTra.getMonth() + 1) + '-' + tgTra.getFullYear() + '</td><td class="center">' + ngayGui.getDate() + '-' + (ngayGui.getMonth() + 1) + '-' + ngayGui.getFullYear() + '</td></tr>');
                }
            });

        }
    });
}

function addData(info, dataInput) {
    $.ajax({
        url: '/api/' + info.url,
        method: 'POST',
        headers: { 'content-type': 'application/json', 'data-type': 'json' },
        data: JSON.stringify(dataInput),
        success: function () {
            $(info.modal).modal('hide');
            loadData(info.id, info.urlLoad);

        }

    })
}

function editData(info, dataInput) {
    $.ajax({
        url: '/api/' + info.url,
        method: 'PUT',
        headers: { 'content-type': 'application/json', 'data-type': 'json' },
        data: JSON.stringify(dataInput),
        success: function () {
            $(info.modal).modal('hide');
            loadData(info.id, info.urlLoad);

        }

    })
}

function deleteData(info, dataInput) {
    $.ajax({
        url: '/api/' + info.url,
        method: 'DELETE',
        headers: { 'content-type': 'application/json', 'data-type': 'json' },
        data: JSON.stringify(dataInput),
        success: function (data, textStatus, xhr) {
            $(info.modal).modal('hide');
            loadData(info.id, info.urlLoad);
        }
    })
}