﻿//API/TienIch
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

function loadDataDetail(edit, url, id) {


    $.ajax({
        type: 'GET',
        url: '/api/' + url + id,
        headers: { 'content-type': 'application/json', 'data-type': 'json' },
        dataType: 'json',
        success: function (data) {
            switch (url) {
                case 'Quanly/LayTienIch?ID=':
                    $(edit.mota).val(data.MoTa);
                    $(edit.tenTienIch).val(data.TenTienIch);
                    break;
                case 'QuanLy/LayDichVu?ID=':
                    $(edit.mota).val(data.MoTa);
                    $(edit.tenDV).val(data.TenDichVu);
                    $(edit.gia).val(data.Gia);
                    break;
                default:
                // code block
            }
        }
    });
}

function loadDSPhong(ids, url) {
    $.ajax({
        type: 'GET',
        url: '/api/' + url,
        dataType: 'json',
        success: function (data) {
            $.each(data, function (index, val) {
                var color = "lightgreen";
                var info = "Số Phòng: " + val.SoPhong + "\r\nLoại Phòng: " + val.LoaiPhong + "\r\nGiá: " + val.Gia + "\r\n";
                if (val.TrangThai) {
                    color = "white";
                }

                if (val.SoPhong.charAt(0) == '1') {
                    ids.row1.append('<button style="margin: 0 5px 5px 0;border: 1px solid;border-radius: 2px;width:65px;height:65px;background-color:' + color + ';display:flex;justify-content:center;align-items:center;" title="' + info + '">' + val.SoPhong + ' </button>');
                }
                if (val.SoPhong.charAt(0) == '2') {
                    ids.row2.append('<button style="margin: 0 5px 5px 0;border: 1px solid;border-radius: 2px;width:65px;height:65px;background-color:' + color + ';display:flex;justify-content:center;align-items:center;" title="' + info + '">' + val.SoPhong + ' </button>');
                }
                if (val.SoPhong.charAt(0) == '3') {
                    ids.row3.append('<button style="margin: 0 5px 5px 0;border: 1px solid;border-radius: 2px;width:65px;height:65px;background-color:' + color + ';display:flex;justify-content:center;align-items:center;" title="' + info + '">' + val.SoPhong + ' </button>');
                }
                if (val.SoPhong.charAt(0) == '4') {
                    ids.row4.append('<button style="margin: 0 5px 5px 0;border: 1px solid;border-radius: 2px;width:65px;height:65px;background-color:' + color + ';display:flex;justify-content:center;align-items:center;" title="' + info + '">' + val.SoPhong + ' </button>');
                }
                if (val.SoPhong.charAt(0) == '5') {
                    ids.row5.append('<button style="margin: 0 5px 5px 0;border: 1px solid;border-radius: 2px;width:65px;height:65px;background-color:' + color + ';display:flex;justify-content:center;align-items:center;" title="' + info + '">' + val.SoPhong + ' </button>');
                }
                if (val.SoPhong.charAt(0) == '6') {
                    ids.row6.append('<button style="margin: 0 5px 5px 0;border: 1px solid;border-radius: 2px;width:65px;height:65px;background-color:' + color + ';display:flex;justify-content:center;align-items:center;" title="' + info + '">' + val.SoPhong + ' </button>');
                }
                if (val.SoPhong.charAt(0) == '7') {
                    ids.row7.append('<button style="margin: 0 5px 5px 0;border: 1px solid;border-radius: 2px;width:65px;height:65px;background-color:' + color + ';display:flex;justify-content:center;align-items:center;" title="' + info + '">' + val.SoPhong + ' </button>');
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