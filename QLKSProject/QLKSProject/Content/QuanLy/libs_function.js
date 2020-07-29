

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

function loadData(idList, url) {
    var position = $(idList);

    $.ajax({
        type: 'GET',
        url: '/api/' + url,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
            xhr.setRequestHeader("contentType", "application/json;charset=UTF-8");
        },
        headers: {
            'content-type': 'application/json',
            'data-type': 'json',
        },
        success: function (data) {
            position.empty();

            $.each(data, function (index, val) {
                switch (url) {
                    case 'Quanly/LayDanhSachTienIch':
                        position.prepend('<tr class="odd gradeX"><td>' + val.TenTienIch + '</td><td >' + val.MoTa + '</td><td class="center"><a class="btn btn-tbl-edit btn-xs" data-id="' + val.ID + '" ><i class="fa fa-pencil" style="color: lightgray"></i></a><a class="btn btn-tbl-delete btn-xs" data-id="' + val.ID + '"><i class="fa fa-trash-o "></i></a></td></tr>');
                        break;
                    case 'Quanly/LayDanhSachDichVu':
                        var tien = formatNumber(val.Gia);
                        position.prepend('<tr class="odd gradeX"><td >' + val.TenDichVu + '</td><td >' + tien + '</td><td >' + val.MoTa + '</td><td class="center"><a class="btn btn-tbl-edit btn-xs" data-id="' + val.ID + '" ><i class="fa fa-pencil" style="color: lightgray"></i></a><a class="btn btn-tbl-delete btn-xs" data-id="' + val.ID + '"><i class="fa fa-trash-o "></i></a></td></tr>');
                        break;
                    case 'Quanly/LayDanhSachPhong':
                        var tien = formatNumber(val.Gia);
                        var tt = "Trống";
                        var label = "label-warning";
                        if (val.TrangThai) {
                            tt = "Đang sử dụng"
                            label = "label-success"
                        }
                        position.prepend('<tr class="odd gradeX"><td class="center">' + val.MaPhong + '</td><td class="center">' + val.SoPhong + '</td><td class="center">' + val.LoaiPhong + '</td><td class="center">' + tien + '</td><td class="center"><span class="label label-sm ' + label + '">' + tt + '</span></td><td class="center"><a class="btn btn-tbl-edit btn-xs btn-edit" data-id="' + val.ID + '"><i class="fa fa-pencil" style="color: lightgray"></i></><a class="btn btn-tbl-delete btn-xs btn-delete" data-id="' + val.ID + '"><i class="fa fa-trash-o "></i></a></td></tr>');
                        break;
                    case 'Quanly/LayDanhSachTaiKhoan':
                        position.prepend('<tr class="odd gradeX"><td style="text-align: left;max-width: 150px">' + val.UserName + '</td><td >' + val.UserPassword + '</td><td >' + val.FullName + '</td><td >' + val.PhoneNumber + '</td><td >' + val.UserEmailID + '</td><td class="center"><a class="btn btn-tbl-edit btn-xs" data-id="' + val.ID + '"><i class="fa fa-pencil" style="color: lightgray"></i></a><a class="btn btn-tbl-delete btn-xs" data-id="' + val.ID + '"><i class="fa fa-trash-o "></i></a></td></tr>');
                        break;
                    case 'NhanVien/LayDanhSachDoan':
                        var tgNhan = new Date(val.ThoiGianNhan);
                        var tgTra = new Date(val.ThoiGianTra);
                        var ngayGui = new Date(val.NgayGui);
                        position.prepend('<tr class="odd gradeX"><td >' + val.TenDoan + '</td><td >' + val.TenTruongDoan + '</td><td >' + tgNhan.getDate() + '-' + (tgNhan.getMonth() + 1) + '-' + tgNhan.getFullYear() + '</td><td >' + tgTra.getDate() + '-' + (tgTra.getMonth() + 1) + '-' + tgTra.getFullYear() + '</td><td >' + ngayGui.getDate() + '-' + (ngayGui.getMonth() + 1) + '-' + ngayGui.getFullYear() + '</td><td ><a class="btn btn-info btn-xs" data-id="' + val.MaDoan + '" style="color: lightgray" >Xếp Phòng</a><div class="mdl-spinner mdl-spinner--single-color mdl-js-spinner is-active" style="display: none" id="loading"></div></td></tr>');
                        break;
                    case 'KhachHang/LayDanhSachKhachHangTheoMaDoan/' + sessionStorage.getItem('madoan'):
                        var daidien = 'Trống';
                        if (val.NguoiDaiDienCuaTreEm != '0') {
                            daidien = val.NguoiDaiDienCuaTreEm;
                        }
                        sessionStorage.setItem('xacnhan', val.TrangThaiXacNhan);
                        var tgNhan = new Date(val.ThoiGianNhan);
                        var tgTra = new Date(val.ThoiGianTra);
                        position.prepend('<tr class="odd gradeX"><td style="text-align:left"> ' + val.HoVaTen + '</td > <td >' + val.SoDienThoai + '</td> <td >' + val.Email + '</td> <td class="center">' + daidien + '</td> <td class="center">' + val.Nhom + '</td> <td class="center">' + val.IDPhong + '</td> <td class="center">' + tgNhan.getDate() + '-' + (tgNhan.getMonth() + 1) + '-' + tgNhan.getFullYear() + '</td> <td class="center">' + tgTra.getDate() + '-' + (tgTra.getMonth() + 1) + '-' + tgTra.getFullYear() + '</td></tr > ');
                        break;
                    case 'NhanVien/LayDanhSachDoanDatPhongThanhCong':
                        var tgNhan = new Date(val.ThoiGianNhan);
                        var tgTra = new Date(val.ThoiGianTra);
                        var ngayGui = new Date(val.NgayGui);
                        position.prepend('<tr class="odd gradeX"><td style="text-align:left" > ' + val.TenTruongDoan + '</td ><td >' + val.TenDoan + '</td><td class="center">' + tgNhan.getDate() + '-' + (tgNhan.getMonth() + 1) + '-' + tgNhan.getFullYear() + '</td><td class="center">' + tgTra.getDate() + '-' + (tgTra.getMonth() + 1) + '-' + tgTra.getFullYear() + '</td><td class="center">' + ngayGui.getDate() + '-' + (ngayGui.getMonth() + 1) + '-' + ngayGui.getFullYear() + '</td></tr > ');
                        break;

                }

            });

        },
        error: function (data) {

            if (data.responseJSON.Message == 'Authorization has been denied for this request.') {
                window.location.replace("../../../404.html");
            }
        }
    });
}

function loadDataDetail(edit, url, id) {


    $.ajax({
        type: 'GET',
        url: '/api/' + url + id,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
            xhr.setRequestHeader("contentType", "application/json;charset=UTF-8");
        },
        headers: { 'content-type': 'application/json', 'data-type': 'json' },
        dataType: 'json',
        success: function (data) {
            switch (url) {
                case 'Quanly/LayTienIch?ID=':
                    $(edit.mota).val(data.MoTa);
                    $(edit.tenTienIch).val(data.TenTienIch);
                    break;
                case 'QuanLy/LayDichVu?ID=':
                    $("textarea" + edit.moTa).val(data.MoTa);
                    $(edit.tenDV).val(data.TenDichVu);
                    $(edit.gia).val(data.Gia);
                    break;
                case 'Quanly/LayPhong?ID=':
                    var loaiPhong;
                    if (data.LoaiPhong == "1") {
                        loaiPhong = "Phòng Loại 1";
                    }
                    if (data.LoaiPhong == "2") {
                        loaiPhong = "Phòng Loại 2";
                    }
                    if (data.LoaiPhong == "3") {
                        loaiPhong = "Phòng Loại 3";
                    }
                    if (data.LoaiPhong == "4") {
                        loaiPhong = "Phòng Loại 4";
                    }
                    var soLau = data.SoPhong.slice(0, 1);
                    var soPhong = data.SoPhong.slice(1);

                    $(edit.loaiPhong).val(loaiPhong);
                    $(edit.gia).val(data.Gia);
                    $(edit.soLau).val(soLau);
                    $(edit.soPhong).val(soPhong);
                    break;
                case 'Quanly/LayTaiKhoan?ID=':
                    console.log(data.TenTaiKhoan + '' + data.MatKhau + '' + data.HoVaTen + '' + data.SoDienThoai + '' + data.Mail);
                    $(edit.TenTaiKhoan).val(data.TenTaiKhoan);
                    $(edit.MatKhau).val(data.MatKhau);
                    $(edit.HoVaTen).val(data.HoVaTen);
                    $(edit.SoDienThoai).val(data.SoDienThoai);
                    $(edit.Mail).val(data.Mail);
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
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
            xhr.setRequestHeader("contentType", "application/json;charset=UTF-8");
        },
        success: function (data) {
            $.each(data, function (index, val) {
                var color = "bg-success";
                var info = "Số Phòng: " + val.SoPhong + "\r\nLoại Phòng: " + val.LoaiPhong + "\r\nGiá: " + val.Gia + "\r\n";
                if (val.TrangThai) {
                    color = "bg-default";
                }
                switch (val.SoPhong.charAt(0)) {
                    case '1':
                        ids.row1.append('<span class="info-box ' + color + '" style="font-weight: 700;font-size: 30px;display: flex;justify-content: center;align-items: center;">' + val.SoPhong + '</span>');
                        break;
                    case '2':
                        ids.row2.append('<span class="info-box ' + color + '" style="font-weight: 700;font-size: 30px;display: flex;justify-content: center;align-items: center;">' + val.SoPhong + '</span>');
                        break;
                    case '3':
                        ids.row3.append('<span class="info-box ' + color + '" style="font-weight: 700;font-size: 30px;display: flex;justify-content: center;align-items: center;">' + val.SoPhong + '</span>');
                        break;
                    case '4':
                        ids.row4.append('<span class="info-box ' + color + '" style="font-weight: 700;font-size: 30px;display: flex;justify-content: center;align-items: center;">' + val.SoPhong + '</span>');
                        break;
                    case '5':
                        ids.row5.append('<span class="info-box ' + color + '" style="font-weight: 700;font-size: 30px;display: flex;justify-content: center;align-items: center;">' + val.SoPhong + '</span>');
                        break;
                    case '6':
                        ids.row6.append('<span class="info-box ' + color + '" style="font-weight: 700;font-size: 30px;display: flex;justify-content: center;align-items: center;">' + val.SoPhong + '</span>');
                        break;
                    case '7':
                        ids.row7.append('<span class="info-box ' + color + '" style="font-weight: 700;font-size: 30px;display: flex;justify-content: center;align-items: center;">' + val.SoPhong + '</span>');
                        break;
                }
               
                //if (val.SoPhong.charAt(0) == '2') {
                //    ids.row2.append('<button style="margin: 0 5px 5px 0;border: 1px solid;border-radius: 2px;width:65px;height:65px;background-color:' + color + ';display:flex;justify-content:center;align-items:center;" title="' + info + '">' + val.SoPhong + ' </button>');
                //}
                //if (val.SoPhong.charAt(0) == '3') {
                //    ids.row3.append('<button style="margin: 0 5px 5px 0;border: 1px solid;border-radius: 2px;width:65px;height:65px;background-color:' + color + ';display:flex;justify-content:center;align-items:center;" title="' + info + '">' + val.SoPhong + ' </button>');
                //}
                //if (val.SoPhong.charAt(0) == '4') {
                //    ids.row4.append('<button style="margin: 0 5px 5px 0;border: 1px solid;border-radius: 2px;width:65px;height:65px;background-color:' + color + ';display:flex;justify-content:center;align-items:center;" title="' + info + '">' + val.SoPhong + ' </button>');
                //}
                //if (val.SoPhong.charAt(0) == '5') {
                //    ids.row5.append('<button style="margin: 0 5px 5px 0;border: 1px solid;border-radius: 2px;width:65px;height:65px;background-color:' + color + ';display:flex;justify-content:center;align-items:center;" title="' + info + '">' + val.SoPhong + ' </button>');
                //}
                //if (val.SoPhong.charAt(0) == '6') {
                //    ids.row6.append('<button style="margin: 0 5px 5px 0;border: 1px solid;border-radius: 2px;width:65px;height:65px;background-color:' + color + ';display:flex;justify-content:center;align-items:center;" title="' + info + '">' + val.SoPhong + ' </button>');
                //}
                //if (val.SoPhong.charAt(0) == '7') {
                //    ids.row7.append('<button style="margin: 0 5px 5px 0;border: 1px solid;border-radius: 2px;width:65px;height:65px;background-color:' + color + ';display:flex;justify-content:center;align-items:center;" title="' + info + '">' + val.SoPhong + ' </button>');
                //}
            });

        }
    });

}

function addData(info, dataInput) {
    $.ajax({
        type: 'POST',
        url: '/api/' + info.url,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
            xhr.setRequestHeader("contentType", "application/json;charset=UTF-8");
        },
        headers: {
            'content-type': 'application/json',
            'data-type': 'json',
        },
        data: JSON.stringify(dataInput),
        success: function (data) {
            $(info.modal).modal('hide');
            Swal.fire(
                'Thêm Thành Công!',
                '',
                'success'
            )
            loadData(info.id, info.urlLoad);

        }

    })
}

function editData(info, dataInput) {
    $.ajax({
        url: '/api/' + info.url,
        method: 'PUT',
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
            xhr.setRequestHeader("contentType", "application/json;charset=UTF-8");
        },
        headers: { 'content-type': 'application/json', 'data-type': 'json' },
        data: JSON.stringify(dataInput),
        success: function () {
            $(info.modal).modal('hide');
            Swal.fire(
                'Thêm Thành Công!',
                '',
                'success'
            )
            loadData(info.id, info.urlLoad);

        }

    })
}

function deleteData(info, dataInput) {

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
                url: '/api/' + info.url + dataInput,
                method: 'DELETE',
                beforeSend: function (xhr) {
                    xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
                    xhr.setRequestHeader("contentType", "application/json;charset=UTF-8");
                },
                headers: { 'content-type': 'application/json', 'data-type': 'json' },
                success: function (data, textStatus, xhr) {

                    loadData(info.id, info.urlLoad);
                }
            })
            Swal.fire(
                'Đã Xóa!',
                '',
                'success'
            )
        }
    })

}


function XepPhong(url) {
    $.ajax({
        type: 'GET',
        url: '/api/' + url,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
        },
        headers: { 'data-type': 'json' },
        success: function (data) {
            console.log(data);
            Swal.fire(
                'Xếp Phòng Thành Công!',
                '',
                'success'
            )

        },
        error: function (data) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: data.responseJSON.Message
            })

        }
    })

}

function formatNumber(num) {
    return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,') + " VND";
}

function XacNhanDatPhong(info) {
    $.ajax({
        type: 'GET',
        url: '/api/KhachHang/XacNhanDatPhong/' + sessionStorage.getItem('madoan'),
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
            xhr.setRequestHeader("contentType", "application/json;charset=UTF-8");
        },
        headers: { 'content-type': 'application/json', 'data-type': 'json' },
        dataType: 'json',
        success: function (data) {
            console.log(data);
            Swal.fire(
                'Good job!',
                'You clicked the button!',
                'success'
            )
            loadData(info.id, info.urlLoad);
        },
        error: function (data) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: data.responseJSON.Message
            })

        }
    })
}


