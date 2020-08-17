﻿
//orther function
function formatNumber(num) {
    return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,') + " VND";
}
function checkSession() {
    $('.nameuser').html(sessionStorage.getItem('fullname'));
    var role = '';
    switch (sessionStorage.getItem('role')) {
        case 'nv':
            role = 'Nhân Viên'
            break;
        case 'ql':
            role = 'Quản Lý'
            break;

    }

    $('#roleuser').html(role);

    //console.log("hello")
}
//Xem Them Xoa Sua
function loadData(url, callback) {

    return $.ajax({
        type: 'GET',
        url: '/SEP23Team2/api/' + url,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
        },
        headers: {
            'content-type': 'application/json',
            'data-type': 'json',
        }

    }).done(callback).fail(function (jqXHR, textStatus, errorThrown) {
        if (jqXHR.responseJSON.Message == 'Authorization has been denied for this request.') {
            window.location.href = "/SEP23Team2/404.cshtml";
        }
    })

}

function loadDataWithID(url, id, callback) {
    return $.ajax({
        type: 'GET',
        url: '/SEP23Team2/api/' + url + id,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
        },
        headers: {
            'content-type': 'application/json',
            'data-type': 'json',
        }
    }).done(callback).fail(function (jqXHR, textStatus, errorThrown) {
        if (jqXHR.responseJSON.Message == 'Authorization has been denied for this request.') {
            window.location.href = "/SEP23Team2/404.cshtml";
        }
    })
}

function addData(info, dataInput) {
    return $.ajax({
        type: 'POST',
        url: '/SEP23Team2/api/' + info.url,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
        },
        headers: {
            'content-type': 'application/json',
            'data-type': 'json',
        },
        data: JSON.stringify(dataInput),
    }).done(function (data) {
        Swal.fire(
            'Thêm Thành Công!',
            '',
            'success'
        ).then(() => {
            window.location.reload();
        })

    }).fail(function (jqXHR, textStatus, errorThrown) {
        if (jqXHR.responseJSON.Message == 'Authorization has been denied for this request.') {
            window.location.href = "/SEP23Team2/404.cshtml";
        }
    })
}

function editData(url, dataInput) {
    $.ajax({
        url: '/SEP23Team2/api/' + url,
        method: 'PUT',
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
        },
        headers: { 'content-type': 'application/json', 'data-type': 'json' },
        data: JSON.stringify(dataInput),
    }).done(function (data) {
        Swal.fire(
            'Chỉnh Sửa Thành Công!',
            '',
            'success'
        ).then(() => {
            window.location.reload();
        })

    }).fail(function (jqXHR, textStatus, errorThrown) {
        if (jqXHR.responseJSON.Message == 'Authorization has been denied for this request.') {
            window.location.href = "/SEP23Team2/404.cshtml";
        }
    })
}

function deleteData(info) {

    Swal.fire({
        title: 'Bạn có chắc muốn Xóa?',
        text: "Bạn sẽ không thể quay lại!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#F08080',
        cancelButtonColor: '#d3d3d3',
        confirmButtonText: 'Có, Tôi muốn Xóa!',
        cancelButtonText: 'Hủy'
    }).then((result) => {
        if (result.value) {

            $.ajax({
                url: '/SEP23Team2/api/' + info.url + info.ID,
                method: 'DELETE',
                beforeSend: function (xhr) {
                    xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
                },
                headers: { 'content-type': 'application/json', 'data-type': 'json' },
            }).done(function (data) {
                Swal.fire(
                    'Đã Xóa!',
                    '',
                    'success'
                ).then(() => {
                    window.location.reload();
                })
            }).fail(function (jqXHR, textStatus, errorThrown) {
                if (jqXHR.responseJSON.Message == 'Authorization has been denied for this request.') {
                    window.location.href = "/SEP23Team2/404.cshtml";
                }
            })

        }
    })

}
//End


//View xemchitiet
function loadDSKHTheoMaDoan(info, id) {
    $.ajax({
        type: 'GET',
        url: '/SEP23Team2/api/' + info.url + id,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
        },
        headers: { 'content-type': 'application/json', 'data-type': 'json' },
        dataType: 'json',
        success: function (data) {
            var tgNhan = new Date(data[0].ThoiGianNhan);
            var tgTra = new Date(data[0].ThoiGianTra);
            var str = 'Từ <span style="font-size: 18px;font-weight:700;">' + tgNhan.getDate() + '-' + (tgNhan.getMonth() + 1) + '-' + tgNhan.getFullYear() + '</span>&nbsp;&nbsp; Đến <span style="font-size: 18px;font-weight:700;">' + '' + tgTra.getDate() + '-' + (tgTra.getMonth() + 1) + '-' + tgTra.getFullYear() + '</span>';
            $('#thoigian').html(str)
            var i = 0;
            $.each(data, function (index, val) {
                var bg = '';
                var tvien = '';
                var tdoan = '';
                var gtNam = '';
                var gtNu = '';
                if (val.TruongDoan) {
                    tdoan = 'selected';
                    tvien = '';
                } else {
                    tvien = 'selected';
                    tdoan = '';
                }

                if (val.GioiTinh) {
                    gtNam = 'selected';
                    gtNu = '';
                } else {
                    gtNu = 'selected';
                    gtNam = '';
                }
                if (val.GhiChu != null) {
                    bg = 'background-color: #e0c187;';
                }

                info.id.append('<tr class="odd gradeX" style="' + bg + '"><td style="text-align:left"><input type="text" style="width:100%" id="hovaten' + i + '" name="hovaten" value="' + val.HoVaTen + '"></td><td class="center"><input type="number" pattern="-?[0-9]*(\.[0-9]+)?" style="text-align:center;width: 50px" id="nhom' + i + '" name="nhom" value="' + val.Nhom + '"></td><td class="center" ><select id="truongdoan' + i + '" name="truongdoan" value="' + val.TruongDoan + '"><option value="true" ' + tdoan + '>Trưởng Đoàn</option><option value="false" ' + tvien + '>Thành Viên</option></select></td><td class="center"><input type="text" style="width: 100%" id="nguoiDD' + i + '" name="nguoiDD" value="' + val.NguoiDaiDienCuaTreEm + '"></td><td class="center"><select id="gioitinh' + i + '" name="gioitinh" value="' + val.GioiTinh + '"><option value="true" ' + gtNam + '>Nam</option><option value="false" ' + gtNu + ' >Nữ</option ></select></td><td><label>' + val.GhiChu + '</label></td><td style="display: none"><input type="text" id="sdt' + i + '" name="sdt" value="' + val.SoDienThoai + '"></td><td style="display: none"><input type="email" id="email' + i + '" name="email" value="' + val.Email + '"></td><td class="center" style="display:none;"><input type="text" id="loaikh' + i + '" name="loaiKH" value="' + val.LoaiKhachHang + '"></td><td class="center" style="display: none"><input type="text" id="diachi' + i + '" name="diachi" value="' + val.DiaChi + '"></td><td class="center" style="display: none"><input type="text" id="id' + i + '" name="id" value="' + val.ID + '"></td><td class="center" style="display: none"><input type="text" id="tgnhan' + i + '" name="tgnhan" value="' + val.ThoiGianNhan + '"></td><td style="display: none" class="center"><input type="text" id="tgtra' + i + '" name="tgtra" value="' + val.ThoiGianTra + '"></td><td class="center" style="display: none"><input type="text" id="madoan' + i + '" name="madoan" value="' + val.MaDoan + '"></td><td style="display: none" class="center"><input type="text" id="isdelete' + i + '" name="isdelete" value="' + val.IsDelete + '"></td><td class="center" style="display: none"><input type="text" id="trangthaidatphong' + i + '" name="trangthaidatphong" value="' + val.TrangThaiDatPhong + '"></td><td style="display: none" class="center"><input type="text" id="idphong' + i + '" name="idphong" value="' + val.IDPhong + '"></td><td style="display: none" class="center"><input type="text" id="trangthaixacnhan' + i + '" name="trangthaixacnhan" value="' + val.TrangThaiXacNhan + '"></td></tr>');


                i++
            })

            sessionStorage.setItem('length', i);
        },
        error: function (data) {

            if (data.responseJSON.Message == 'Authorization has been denied for this request.') {
                window.location.pathname("/SEP23Team2/404.cshtml");
            }
        }
    })
}

//Load DS phong View Nhanvien
//function loadDSPhong(url) {
//    $.ajax({
//        type: 'GET',
//        url: '/SEP23Team2/api/' + url,
//        dataType: 'json',
//        beforeSend: function (xhr) {
//            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
//        },
//        headers: { 'content-type': 'application/json', 'data-type': 'json' }
//    }).done((data) => {
//        for (i = 1; i < 10; i++) {
//            $('#row' + i).empty();
//            $.each(data, function (index, val) {
//                var color = "bg-success";
//                if (val.TrangThai == -1) {
//                    color = "bg-default";
//                } else if (val.TrangThai == 0) {
//                    color = "bg-warning";
//                } else if (val.TrangThai == 2) {
//                    color = "bg-primary";
//                }
//                if (val.SoPhong.charAt(0) == '' + i) {

//                    $('#row' + i).append('<button class="info-box ' + color + '" style="border:none;outline:none;cursor:pointer;font-weight: 700;font-size: 25px;height:36px;min-height:0;display: flex;justify-content: center;align-items: center;" data-id="' + val.ID + '" value="' + val.SoPhong + '"> ' + val.SoPhong + '</button> ');
//                }
//            })

//        }
//    }).fail(function (jqXHR, textStatus, errorThrown) {
//        if (jqXHR.responseJSON.Message == 'Authorization has been denied for this request.') {
//            window.location.href = "/SEP23Team2/404.cshtml";
//        }
//    })
//}

//Load DS Phong trống View Nhanvien/Datphongthatbai/xemchitiet
function loadDSPhongTrong(info, dataInput) {
    $.ajax({
        type: 'POST',
        url: '/SEP23Team2/api/' + info.url,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
        },
        headers: {
            'content-type': 'application/json',
            'data-type': 'json',
        },
        data: JSON.stringify(dataInput),
    }).done((data) => {
        info.id.empty();
        $.each(data, function (index, val) {
            var row = val.split('-');
            info.id.append('<h3 style="display: block;margin-left: 15px;" class="floor">Phòng loại ' + row[0] + ': trống ' + row[1] + ' phòng' + '</h3>');
        })
        $('#dsphongtrongModal').modal('show');
    }).fail(function (jqXHR, textStatus, errorThrown) {
        if (jqXHR.responseJSON.Message == 'Authorization has been denied for this request.') {
            window.location.href = "/SEP23Team2/404.cshtml";
        } else if (jqXHR.responseJSON.Message == 'An error has occurred.'){
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Thông tin không hợp lệ !'
            })
        }
    })
}


//Xep Phong
function XepPhong(ID) {
    $.ajax({
        type: 'GET',
        url: '/SEP23Team2/api/NhanVien/DatPhongChoTungDoan/' + ID,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
        },
        headers: { 'content-type': 'application/json', 'data-type': 'json' },
    }).done((data) => {
        Swal.fire(
            'Success!',
            '',
            'success'
        ).then(() => {
            window.location.reload();
        })
    }).fail(function (jqXHR, textStatus, errorThrown) {
        if (jqXHR.responseJSON.Message == 'Authorization has been denied for this request.') {
            window.location.href = "/SEP23Team2/404.cshtml";
        }
        console.log(jqXHR.responseJSON.Message);
    })

}

function XepPhongTatCa() {
    $.ajax({
        type: 'GET',
        url: '/SEP23Team2/api/NhanVien/DatPhongChoNhieuDoan',
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
        },
        headers: { 'content-type': 'application/json', 'data-type': 'json' }
    }).done((data) => {
        var str = data.split('-');
        var tc = str[0];
        var tb = str[1];
        Swal.fire(
            'Hoàn Tất!',
            'Thành Công: ' + tc + '   Thất Bại: ' + tb,
            'success'
        ).then(value => {
            $('#xepall').css("display", "block");
            $('#loadingAll').css("display", "none");
            window.location.reload();
        })
    }).fail(function (jqXHR, textStatus, errorThrown) {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: jqXHR.responseJSON.Message
        }).then(value => {
            $('#xepall').css("display", "block");
            window.location.reload();
        })
    })


}

function HuyXacNhanXepPhong() {
    Swal.fire({
        title: 'Bạn có chắc muốn Xóa?',
        text: "Bạn sẽ không thể quay lại!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#F08080',
        cancelButtonColor: '#d3d3d3',
        confirmButtonText: 'Có, Tôi muốn Xóa!',
        cancelButtonText: 'Hủy'
    }).then((result) => {
        if (result.value) {
            $('#cancel').css("display", "none");
            $('#loadingcancel').css("display", "block");
            $.ajax({
                url: '/SEP23Team2/api/KhachHang/HuyDatPhong/' + sessionStorage.getItem('madoan'),
                method: 'GET',
                beforeSend: function (xhr) {
                    xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
                },
                headers: { 'content-type': 'application/json', 'data-type': 'json' }
            }).done(() => {
                Swal.fire(
                    'Đã Xóa!',
                    '',
                    'success'
                ).then(val => {
                    sessionStorage.removeItem('role');
                    sessionStorage.removeItem('accessToken');
                    sessionStorage.removeItem('fullname');
                    window.location.href = "/SEP23Team2/TrangChu.cshtml";
                })
            }).fail(function (jqXHR, textStatus, errorThrown) {
                if (jqXHR.responseJSON.Message == 'Authorization has been denied for this request.') {
                    window.location.href = "/SEP23Team2/404.cshtml";
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: jqXHR.responseJSON.Message
                    })
                }

            })

        }
    })
}

function XacNhanDatPhong() {
    $.ajax({
        type: 'GET',
        url: '/SEP23Team2/api/KhachHang/XacNhanDatPhong/' + sessionStorage.getItem('madoan'),
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));

        },
        headers: { 'content-type': 'application/json', 'data-type': 'json' },
    }).done(() => {
        Swal.fire(
            'Xác Nhận Đặt Phòng Thành Công!',
            '',
            'success'
        ).then(val => {
            window.location.reload();
        })
    }).fail(function (jqXHR, textStatus, errorThrown) {
        if (jqXHR.responseJSON.Message == 'Authorization has been denied for this request.') {
            window.location.href = "/SEP23Team2/404.cshtml";
        } else {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: jqXHR.responseJSON.Message
            })
        }

    })
}

function XepPhongThuNghiem(dataInput) {
    $.ajax({
        url: '/SEP23Team2/api/NhanVien/DatPhongThuNghiem',
        method: 'POST',
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
        },
        headers: { 'content-type': 'application/json', 'data-type': 'json' },
        data: JSON.stringify(dataInput)
    }).done(() => {
        Swal.fire(
            'Success!',
            '',
            'success'
        ).then(val => {
            window.location.pathname = "/SEP23Team2/Views/NhanVienViews/DatPhongThatBai/DatPhongThatBai.cshtml";
        })
    }).fail(function (jqXHR, textStatus, errorThrown) {
        if (jqXHR.responseJSON.Message == 'Authorization has been denied for this request.') {
            window.location.href = "/SEP23Team2/404.cshtml";
        } else {
            swal.fire(
                'Oop...!',
                jqXHR.responseJSON.Message,
                'error'
            ).then(() => {
                $('#luu').css('display', 'block');
                $('#loading').css('display', 'none');
                window.location.reload();
            })
        }

    })
}

function KhachHangNhanTraPhong(url, dataInput, callback) {
    return $.ajax({
        type: 'POST',
        url: '/SEP23Team2/api/' + url,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
        },
        headers: { 'content-type': 'application/json', 'data-type': 'json' },
        data: JSON.stringify(dataInput)
    }).done(callback).fail(function (jqXHR, textStatus, errorThrown) {
        if (jqXHR.responseJSON.Message == 'Authorization has been denied for this request.') {
            window.location.href = "/SEP23Team2/404.cshtml";
        } else {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: jqXHR.responseJSON.Message
            }).then(value => {
                window.location.reload();
            })
        }

    })
}


//function loadData(idList, url) {
//    var position = $(idList);

//    $.ajax({
//        type: 'GET',
//        url: '/SEP23Team2/api/' + url,
//        beforeSend: function (xhr) {
//            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
//        },
//        headers: {
//            'content-type': 'application/json',
//            'data-type': 'json',
//        },
//        success: function (data) {
//            position.empty();

//            $.each(data, function (index, val) {
//                switch (url) {
//                    case 'Quanly/LayDanhSachTienIch':
//                        position.prepend('<tr class="odd gradeX"><td>' + val.TenTienIch + '</td><td >' + val.MoTa + '</td><td class="center"><a class="btn btn-tbl-edit btn-xs" data-id="' + val.ID + '" ><i class="fa fa-pencil" style="color: lightgray"></i></a><a class="btn btn-tbl-delete btn-xs" data-id="' + val.ID + '"><i class="fa fa-trash-o "></i></a></td></tr>');

//                        break;
//                    case 'Quanly/LayDanhSachDichVu':
//                        var tien = formatNumber(val.Gia);
//                        position.prepend('<tr class="odd gradeX"><td >' + val.TenDichVu + '</td><td >' + tien + '</td><td >' + val.MoTa + '</td><td class="center"><a class="btn btn-tbl-edit btn-xs" data-id="' + val.ID + '" ><i class="fa fa-pencil" style="color: lightgray"></i></a><a class="btn btn-tbl-delete btn-xs" data-id="' + val.ID + '"><i class="fa fa-trash-o "></i></a></td></tr>');
//                        break;
//                    case 'Quanly/LayDanhSachPhong':
//                        var tien = formatNumber(val.Gia);
//                        var tt = "Trống";
//                        var label = "";
//                        if (val.TrangThai == '0') {
//                            tt = "Đang Chờ"
//                            label = "label-warning"
//                        } else if (val.TrangThai == '1') {
//                            tt = "Đang sử dụng"
//                            label = "label-success"
//                        }
//                        position.prepend('<tr class="odd gradeX"><td class="center">' + val.MaPhong + '</td><td class="center">' + val.SoPhong + '</td><td class="center">' + val.LoaiPhong + '</td><td class="center">' + tien + '</td><td class="center"><span class="label label-sm ' + label + '" style="background-color:#cddadb; ">' + tt + '</span></td><td class="center"><a class="btn btn-tbl-edit btn-xs btn-edit" data-id="' + val.ID + '"><i class="fa fa-pencil" style="color: lightgray"></i></><a class="btn btn-tbl-delete btn-xs btn-delete" data-id="' + val.ID + '"><i class="fa fa-trash-o "></i></a></td></tr>');
//                        break;
//                    case 'Quanly/LayDanhSachTaiKhoan':
//                        position.prepend('<tr class="odd gradeX"><td style="text-align: left;max-width: 150px">' + val.UserName + '</td><td >' + val.UserPassword + '</td><td >' + val.FullName + '</td><td >' + val.PhoneNumber + '</td><td >' + val.UserEmailID + '</td><td class="center"><a class="btn btn-tbl-edit btn-xs" data-id="' + val.ID + '"><i class="fa fa-pencil" style="color: lightgray"></i></a><a class="btn btn-tbl-delete btn-xs" data-id="' + val.ID + '"><i class="fa fa-trash-o "></i></a></td></tr>');
//                        break;
//                    case 'NhanVien/LayDanhSachDoan':
//                        var tgNhan = new Date(val.ThoiGianNhan);
//                        var tgTra = new Date(val.ThoiGianTra);
//                        var ngayGui = new Date(val.NgayGui);
//                        position.append('<tr class="odd gradeX"><td >' + val.TenDoan + '</td><td >' + val.TenTruongDoan + '</td><td >' + tgNhan.getDate() + '-' + (tgNhan.getMonth() + 1) + '-' + tgNhan.getFullYear() + '</td><td >' + tgTra.getDate() + '-' + (tgTra.getMonth() + 1) + '-' + tgTra.getFullYear() + '</td><td >' + ngayGui.getDate() + '-' + (ngayGui.getMonth() + 1) + '-' + ngayGui.getFullYear() + '</td><td style="display:flex;justify-content:center;align-items:center;"><a class="btn btn-info btn-xs" data-id="' + val.MaDoan + '" style="color: lightgray" >Xếp Phòng</a><div class="mdl-spinner mdl-spinner--single-color mdl-js-spinner is-active" style="display: none;margin-right: 10px" id="loading"></div><a class="btn btn-danger btn-xs" data-id="' + val.MaDoan + '">Xóa</a></td ></tr > ');
//                        break;


//                    case 'KhachHang/LayDanhSachKhachHangTheoMaDoan/' + sessionStorage.getItem('madoan'):
//                        var daidien = 'Trống';
//                        var bg = '';
//                        if (val.NguoiDaiDienCuaTreEm != '0') {
//                            daidien = val.NguoiDaiDienCuaTreEm;
//                        }
//                        if (val.TrangThaiXacNhan) {
//                            $('#confirm').css("display", "none");
//                            $('#cancel').css("display", "none");
//                        }

//                        var tgNhan = new Date(val.ThoiGianNhan);
//                        var tgTra = new Date(val.ThoiGianTra);
//                        position.prepend('<tr class="odd gradeX ' + bg + '"><td style="text-align:left"> ' + val.HoVaTen + '</td > <td >' + val.SoDienThoai + '</td> <td >' + val.Email + '</td> <td class="">' + daidien + '</td> <td class="center">' + val.Nhom + '</td> <td class="center">' + val.Sophong + '</td> <td class="center">' + tgNhan.getDate() + '-' + (tgNhan.getMonth() + 1) + '-' + tgNhan.getFullYear() + '</td> <td class="center">' + tgTra.getDate() + '-' + (tgTra.getMonth() + 1) + '-' + tgTra.getFullYear() + '</td></tr > ');
//                        break;
//                    case 'NhanVien/LayDanhSachDoanDatPhongThanhCong':
//                        var tgNhan = new Date(val.ThoiGianNhan);
//                        var tgTra = new Date(val.ThoiGianTra);
//                        var ngayGui = new Date(val.NgayGui);
//                        var color = 'label-warning';
//                        var ttxn = 'Đang chờ';
//                        if (val.TrangThaiXacNhan) {
//                            ttxn = 'Đã Xác Nhận'
//                            color = 'label-success';
//                        }
//                        position.append('<tr class="odd gradeX"><td style="text-align:left" > ' + val.TenTruongDoan + '</td ><td >' + val.TenDoan + '</td><td class="center">' + tgNhan.getDate() + '-' + (tgNhan.getMonth() + 1) + '-' + tgNhan.getFullYear() + '</td><td class="center">' + tgTra.getDate() + '-' + (tgTra.getMonth() + 1) + '-' + tgTra.getFullYear() + '</td><td class="center">' + ngayGui.getDate() + '-' + (ngayGui.getMonth() + 1) + '-' + ngayGui.getFullYear() + '</td><td><label class="label ' + color + '">' + ttxn + '</label></td></tr > ');
//                        break;
//                    case 'NhanVien/LayDanhSachDoanDatPhongThatBai':

//                        var tgNhan = new Date(val.ThoiGianNhan);
//                        var tgTra = new Date(val.ThoiGianTra);
//                        var ngayGui = new Date(val.NgayGui);
//                        position.append('<tr class="odd gradeX" data-id="' + val.MaDoan + '"><td style="text-align:left"> ' + val.TenTruongDoan + '</td><td>' + val.TenDoan + '</td><td class="center">' + tgNhan.getDate() + '-' + (tgNhan.getMonth() + 1) + '-' + tgNhan.getFullYear() + '</td><td class="center">' + tgTra.getDate() + '-' + (tgTra.getMonth() + 1) + '-' + tgTra.getFullYear() + '</td><td class="center">' + ngayGui.getDate() + '-' + (ngayGui.getMonth() + 1) + '-' + ngayGui.getFullYear() + '</td><td class="center"><a class="btn btn-danger btn-xs" data-id="' + val.MaDoan + '"><i class="fa fa-trash-o "></i></a><a class="btn btn-info btn-xs" data-id="' + val.MaDoan + '"><i class="fa fa-arrow-circle-o-right "></i></a></td></tr > ');
//                        break;
//                    case 'NhanVien/LayDSLichSuDichVu':
//                        var ngayGui = new Date(val.NgayGoiDichVu);
//                        position.prepend('<tr class="odd gradeX"><td> ' + val.SoPhong + '</td><td>' + val.HoVaTenKhachHang + '</td><td>' + val.TenDichVu + '</td><td>' + ngayGui.getDate() + '-' + (ngayGui.getMonth() + 1) + '-' + ngayGui.getFullYear() + '</td><td>' + val.GhiChu + '</td><td class="center"><a class="btn btn-tbl-delete btn-xs" data-id="' + val.ID + '"><i class="fa fa-trash-o "></i></a></td></tr > ');

//                        break;

//                    case 'NhanVien/LayDanhSachPhong':
//                        position.prepend('<option value="' + val.ID + '"> ' + val.SoPhong + '</option>');
//                        break;
//                    case 'NhanVien/LayDanhSachDichVu':
//                        position.prepend('<option value="' + val.ID + '" >' + val.TenDichVu + '&nbsp;&nbsp;&nbsp;' + ' +' + formatNumber(val.Gia) + '</option>');
//                        break;

//                }

//            });

//        },
//        error: function (data) {

//            if (data.responseJSON.Message == 'Authorization has been denied for this request.') {
//                window.location.pathname("/SEP23Team2/404.cshtml");
//            }
//        }
//    });
//}

//Load DS Loai Phong View QuanLy/Xemloaiphong
//function LoadDSLoaiPhong(idList, url) {
//    $.ajax({
//        type: 'GET',
//        url: '/SEP23Team2/api/' + url,
//        beforeSend: function (xhr) {
//            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
//        },
//        headers: { 'content-type': 'application/json', 'data-type': 'json' },
//        dataType: 'json',
//        success: function (data) {
//            $(idList).empty();
//            var i = 0;
//            $.each(data, function (index, val) {
//                $(idList).append('<tr class="odd gradeX"><td class="center"><label value="' + val.LoaiPhong + '">Phòng Loại ' + val.LoaiPhong + '</label></td><td class="center"><input type="number" pattern="-?[0-9]*(\.[0-9]+)?" style="text-align:center;width: 125px" id="gia' + i + '" name="gia" value="' + val.Gia + '"></td></tr>');
//                i++

//            })

//            //sessionStorage.setItem('length', i);
//        },
//        error: function (data) {

//            if (data.responseJSON.Message == 'Authorization has been denied for this request.') {
//                window.location.pathname("/SEP23Team2/404.cshtml");
//            }
//        }
//    })
//}


//function LayThongTinPhong(info, id) {
//    $.ajax({
//        type: 'GET',
//        url: '/SEP23Team2/api/' + info.url + id,
//        beforeSend: function (xhr) {
//            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
//        },
//        headers: { 'content-type': 'application/json', 'data-type': 'json' },
//        success: function (data) {

//            switch (info.url) {
//                case 'NhanVien/LayDanhSachTenKhachHangChungPhong/':
//                    $(info.idLoad).empty();
//                    $.each(data, function (index, val) {
//                        $(info.idLoad).append('<option value="' + val.ID + '">' + val.HoVaTen + '</option>');
//                    })
//                    break;
//                case 'NhanVien/DanhSachKhachHangChungPhongDichVuPhong/':
//                    $(info.idLoad).empty();
//                    $.each(data, function (index, val) {
//                        $(info.idLoad).append('<option value="' + val.ID + '">' + val.HoVaTen + '</option>');
//                    })
//                    break;
//                case 'NhanVien/LayThongTinChiPhiPhong/':
//                    $(info.idCMND).empty();
//                    $(info.idNguoiDaiDien).empty();
//                    $(info.idDichVu).empty();

//                    $(info.idCMND).val(data[1]);
//                    $(info.idCMND).html(data[1]);
//                    $(info.idNguoiDaiDien).val(data[0]);
//                    $(info.idNguoiDaiDien).html(data[0]);
//                    for (i = 2; i < data.length - 1; i++) {
//                        $(info.idDichVu).append('<li>' + data[i] + '</li>');
//                    }
//                    $(info.idDichVu).append('<li>Tổng Tiền: ' + data[data.length - 1] + '</li>');
//                    console.log(data);


//                    break;

//            }

//        },
//        error: function (data) {

//            if (data.responseJSON.Message == 'Authorization has been denied for this request.') {
//                window.location.pathname("/404.cshtml");
//            }
//        }
//    })
//}


//function editAllLoaiPhong(info, dataInput) {
//    $.ajax({
//        url: '/SEP23Team2/api/' + info.url,
//        method: 'PUT',
//        beforeSend: function (xhr) {
//            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
//        },
//        headers: { 'content-type': 'application/json', 'data-type': 'json' },
//        data: JSON.stringify(dataInput),
//        success: function () {






//        },
//        error: function (data) {

//            Swal.fire({
//                icon: 'error',
//                title: 'Oops...',
//                text: data.responseJSON.Message
//            })
//        }

//    }).done(() => {
//        Swal.fire(
//            'Chỉnh Sửa Thành Công!',
//            '',
//            'success'
//        ).then(() => {
//            window.location.reload();
//        })
//    }).fail(function (jqXHR, textStatus, errorThrown) {
//        if (jqXHR.responseJSON.Message == 'Authorization has been denied for this request.') {
//            window.location.href = "/SEP23Team2/404.cshtml";
//        }
//    })
//}


