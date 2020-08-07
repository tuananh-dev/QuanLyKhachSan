

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
        url: '/SEP23Team2/api/' + url,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
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
                        position.append('<tr class="odd gradeX"><td >' + val.TenDoan + '</td><td >' + val.TenTruongDoan + '</td><td >' + tgNhan.getDate() + '-' + (tgNhan.getMonth() + 1) + '-' + tgNhan.getFullYear() + '</td><td >' + tgTra.getDate() + '-' + (tgTra.getMonth() + 1) + '-' + tgTra.getFullYear() + '</td><td >' + ngayGui.getDate() + '-' + (ngayGui.getMonth() + 1) + '-' + ngayGui.getFullYear() + '</td><td style="display:flex;justify-content:center;align-items:center;"><a class="btn btn-info btn-xs" data-id="' + val.MaDoan + '" style="color: lightgray" >Xếp Phòng</a><div class="mdl-spinner mdl-spinner--single-color mdl-js-spinner is-active" style="display: none" id="loading"></div><a class="btn btn-danger btn-xs" data-id="' + val.MaDoan + '">Xóa</a></td ></tr > ');
                        break;
                    case 'KhachHang/LayDanhSachKhachHangTheoMaDoan/' + sessionStorage.getItem('madoan'):
                        var daidien = 'Trống';
                        if (val.NguoiDaiDienCuaTreEm != '0') {
                            daidien = val.NguoiDaiDienCuaTreEm;
                        }
                        if (val.TrangThaiXacNhan) {
                            $('#confirm').css("display", "none");
                            $('#cancel').css("display", "none");
                        }

                        var tgNhan = new Date(val.ThoiGianNhan);
                        var tgTra = new Date(val.ThoiGianTra);
                        position.prepend('<tr class="odd gradeX"><td style="text-align:left"> ' + val.HoVaTen + '</td > <td >' + val.SoDienThoai + '</td> <td >' + val.Email + '</td> <td class="">' + daidien + '</td> <td class="center">' + val.Nhom + '</td> <td class="center">' + val.Sophong + '</td> <td class="center">' + tgNhan.getDate() + '-' + (tgNhan.getMonth() + 1) + '-' + tgNhan.getFullYear() + '</td> <td class="center">' + tgTra.getDate() + '-' + (tgTra.getMonth() + 1) + '-' + tgTra.getFullYear() + '</td></tr > ');
                        break;
                    case 'NhanVien/LayDanhSachDoanDatPhongThanhCong':
                        var tgNhan = new Date(val.ThoiGianNhan);
                        var tgTra = new Date(val.ThoiGianTra);
                        var ngayGui = new Date(val.NgayGui);
                        var color = 'label-warning';
                        var ttxn = 'Đang chờ';
                        if (val.TrangThaiXacNhan) {
                            ttxn = 'Đã Xác Nhận'
                            color = 'label-success';
                        }
                        position.append('<tr class="odd gradeX"><td style="text-align:left" > ' + val.TenTruongDoan + '</td ><td >' + val.TenDoan + '</td><td class="center">' + tgNhan.getDate() + '-' + (tgNhan.getMonth() + 1) + '-' + tgNhan.getFullYear() + '</td><td class="center">' + tgTra.getDate() + '-' + (tgTra.getMonth() + 1) + '-' + tgTra.getFullYear() + '</td><td class="center">' + ngayGui.getDate() + '-' + (ngayGui.getMonth() + 1) + '-' + ngayGui.getFullYear() + '</td><td><label class="label ' + color + '">' + ttxn + '</label></td></tr > ');
                        break;
                    case 'NhanVien/LayDanhSachDoanDatPhongThatBai':

                        var tgNhan = new Date(val.ThoiGianNhan);
                        var tgTra = new Date(val.ThoiGianTra);
                        var ngayGui = new Date(val.NgayGui);
                        position.append('<tr class="odd gradeX" data-id="' + val.MaDoan + '"><td style="text-align:left"> ' + val.TenTruongDoan + '</td><td>' + val.TenDoan + '</td><td class="center">' + tgNhan.getDate() + '-' + (tgNhan.getMonth() + 1) + '-' + tgNhan.getFullYear() + '</td><td class="center">' + tgTra.getDate() + '-' + (tgTra.getMonth() + 1) + '-' + tgTra.getFullYear() + '</td><td class="center">' + ngayGui.getDate() + '-' + (ngayGui.getMonth() + 1) + '-' + ngayGui.getFullYear() + '</td><td class="center"><a class="btn btn-danger btn-xs" data-id="' + val.MaDoan + '"><i class="fa fa-trash-o "></i></a><a class="btn btn-info btn-xs" data-id="' + val.MaDoan + '"><i class="fa fa-arrow-circle-o-right "></i></a></td></tr > ');
                        break;


                }

            });

        },
        error: function (data) {

            if (data.responseJSON.Message == 'Authorization has been denied for this request.') {
                window.location.pathname("/404.cshtml");
            }
        }
    });
}

function loadDataDetail(edit, url, id) {


    $.ajax({
        type: 'GET',
        url: '/SEP23Team2/api/' + url + id,
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
                    //console.log(data.FullName + '' + data.MatKhau + '' + data.HoVaTen + '' + data.SoDienThoai + '' + data.Mail);
                    $(edit.TenTaiKhoan).val(data.UserName);
                    $(edit.MatKhau).val(data.UserPassword);
                    $(edit.HoVaTen).val(data.FullName);
                    $(edit.SoDienThoai).val(data.PhoneNumber);
                    $(edit.Mail).val(data.UserEmailID);
                    break;
                default:
                // code block
            }
        },
        error: function (data) {

            if (data.responseJSON.Message == 'Authorization has been denied for this request.') {
                window.location.pathname("/404.cshtml");
            }
        }
    });
}

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
            var i = 0;
            //sessionStorage.setItem('id', val.ID);
            $.each(data, function (index, val) {
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
                //if (val.GhiChu == null) {
                //    val.GhiChu = '';
                //}
                info.id.append('<tr class="odd gradeX"><td style="text-align:left"><input type="text" style="width:100%" id="hovaten' + i + '" name="hovaten" value="' + val.HoVaTen + '"></td><td class="center"><input type="number" pattern="-?[0-9]*(\.[0-9]+)?" style="text-align:center;width: 50px" id="nhom' + i + '" name="nhom" value="' + val.Nhom + '"></td><td class="center" ><select id="truongdoan' + i + '" name="truongdoan" value="' + val.TruongDoan + '"><option value="true" ' + tdoan + '>Trưởng Đoàn</option><option value="false" ' + tvien + '>Thành Viên</option></select></td><td class="center"><input type="text" style="width: 100%" id="nguoiDD' + i + '" name="nguoiDD" value="' + val.NguoiDaiDienCuaTreEm + '"></td><td class="center"><select id="gioitinh' + i + '" name="gioitinh" value="' + val.GioiTinh + '"><option value="true" ' + gtNam + '>Nam</option><option value="false" ' + gtNu + ' >Nữ</option ></select></td><td><label>' + val.GhiChu + '</label></td><td style="display: none"><input type="text" id="sdt' + i + '" name="sdt" value="' + val.SoDienThoai + '"></td><td style="display: none"><input type="email" id="email' + i + '" name="email" value="' + val.Email + '"></td><td class="center" style="display:none;"><input type="text" id="loaikh' + i + '" name="loaiKH" value="' + val.LoaiKhachHang + '"></td><td class="center" style="display: none"><input type="text" id="diachi' + i + '" name="diachi" value="' + val.DiaChi + '"></td><td class="center" style="display: none"><input type="text" id="id' + i + '" name="id" value="' + val.ID + '"></td><td class="center" style="display: none"><input type="text" id="tgnhan' + i + '" name="tgnhan" value="' + val.ThoiGianNhan + '"></td><td style="display: none" class="center"><input type="text" id="tgtra' + i + '" name="tgtra" value="' + val.ThoiGianTra + '"></td><td class="center" style="display: none"><input type="text" id="madoan' + i + '" name="madoan" value="' + val.MaDoan + '"></td><td style="display: none" class="center"><input type="text" id="isdelete' + i + '" name="isdelete" value="' + val.IsDelete + '"></td><td class="center" style="display: none"><input type="text" id="trangthaidatphong' + i + '" name="trangthaidatphong" value="' + val.TrangThaiDatPhong + '"></td><td style="display: none" class="center"><input type="text" id="idphong' + i + '" name="idphong" value="' + val.IDPhong + '"></td><td style="display: none" class="center"><input type="text" id="trangthaixacnhan' + i + '" name="trangthaixacnhan" value="' + val.TrangThaiXacNhan + '"></td></tr>');


                i++
            })

            sessionStorage.setItem('length', i);
        },
        error: function (data) {

            if (data.responseJSON.Message == 'Authorization has been denied for this request.') {
                window.location.pathname("/404.cshtml");
            }
        }
    })
}
function loadDSPhong(url) {
    $.ajax({
        type: 'GET',
        url: '/SEP23Team2/api/' + url,
        dataType: 'json',
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
        },
        headers: {
            'content-type': 'application/json',
            'data-type': 'json',
        },
        success: function (data) {

            for (i = 1; i < 10; i++) {
                $.each(data, function (index, val) {
                    var color = "bg-success";
                    var info = "Số Phòng: " + val.SoPhong + "\r\nLoại Phòng: " + val.LoaiPhong + "\r\nGiá: " + val.Gia + "\r\n";
                    if (val.TrangThai == -1) {
                        color = "bg-default";
                    } else if (val.TrangThai == 0) {
                        color = "bg-warning";
                    }
                    if (val.SoPhong.charAt(0) == '' + i) {
                        $('#row' + i).append('<button class="info-box ' + color + '" style="border:none;outline:none;cursor:pointer;font-weight: 700;font-size: 25px;height:36px;min-height:0;display: flex;justify-content: center;align-items: center;"> ' + val.SoPhong + '</button> ');
                    }
                })

            }
        },
        error: function (data) {

            if (data.responseJSON.Message == 'Authorization has been denied for this request.') {
                window.location.pathname("/404.cshtml");
            }
        }
    })
}

function addData(info, dataInput) {
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
        success: function (data) {
            $(info.modal).modal('hide');
            Swal.fire(
                'Thêm Thành Công!',
                '',
                'success'
            )
            loadData(info.id, info.urlLoad);

        }, error: function (data) {
            $(info.modal).modal('hide');
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: data.responseJSON.Message
            }).then(value => {
                window.location.reload();
            })
        }

    })
}

function editData(info, dataInput) {
    $.ajax({
        url: '/SEP23Team2/api/' + info.url,
        method: 'PUT',
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
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

        },
        error: function (data) {
            $(info.modal).modal('hide');
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: data.responseJSON.Message
            })
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
                url: '/SEP23Team2/api/' + info.url + dataInput,
                method: 'DELETE',
                beforeSend: function (xhr) {
                    xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
                    xhr.setRequestHeader("contentType", "application/json;charset=UTF-8");
                },
                headers: { 'content-type': 'application/json', 'data-type': 'json' },
                success: function (data, textStatus, xhr) {

                    loadData(info.id, info.urlLoad);
                },
                error: function (data) {

                    if (data.responseJSON.Message == 'Authorization has been denied for this request.') {
                        window.location.pathname("/404.cshtml");
                    }
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

//function deleteDoan(info) {
//    Swal.fire({
//        title: 'Bạn có chắc muốn Xóa?',
//        text: "Bạn sẽ không thể quay lại!",
//        icon: 'warning',
//        showCancelButton: true,
//        confirmButtonColor: '#F08080',
//        cancelButtonColor: '#d3d3d3',
//        confirmButtonText: 'Có, Tôi muốn Xóa!',
//        cancelButtonText: 'Hủy'
//    }).then((result) => {
//        if (result.value) {

//            $.ajax({
//                url: '/SEP23Team2/api/' + info.url,
//                method: 'DELETE',
//                beforeSend: function (xhr) {
//                    xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
//                    xhr.setRequestHeader("contentType", "application/json;charset=UTF-8");
//                },
//                headers: { 'content-type': 'application/json', 'data-type': 'json' },
//                success: function (data, textStatus, xhr) {

//                    loadData(info.id, info.urlLoad);
//                }
//            })
//            Swal.fire(
//                'Đã Xóa!',
//                '',
//                'success'
//            )
//        }
//    })
//}

function XepPhong(info, url, dataId) {
    $.ajax({
        type: 'GET',
        url: '/SEP23Team2/api/' + url + dataId,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
        },
        headers: { 'data-type': 'json' },
        success: function (data) {
            Swal.fire(
                'Success!',
                '',
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
            loadData(info.id, info.urlLoad);

        }
    })

}

function XepPhongTatCa(info, url) {
    $.ajax({
        type: 'GET',
        url: '/SEP23Team2/api/' + url,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
        },
        headers: { 'data-type': 'json' },
        success: function (data) {
            var str = data.split('-');
            var tc = str[0];
            var tb = str[1];
            Swal.fire(
                'Success!',
                'Thành Công: ' + tc + '   Thất Bại: ' + tb,
                'success'
            ).then(value => {
                $('#xepall').css("display", "block");
                $('#loadingAll').css("display", "none");
                loadData(info.id, info.urlLoad);
            })
            
        },
        error: function (data) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: data.responseJSON.Message
            }).then(value => {
                $('#xepall').css("display", "block");
                $('#loadingAll').css("display", "none");
                loadData(info.id, info.urlLoad);
            })
            

        }
    })
   

}

function HuyXacNhanXepPhong(url, dataInput) {
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
                url: '/SEP23Team2/api/' + url + dataInput,
                method: 'GET',
                beforeSend: function (xhr) {
                    xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
                },
                headers: { 'content-type': 'application/json', 'data-type': 'json' },
                success: function (data, textStatus, xhr) {
                    Swal.fire(
                        'Đã Xóa!',
                        '',
                        'success'
                    ).then(val => {
                        sessionStorage.removeItem('role');
                        sessionStorage.removeItem('accessToken');
                        sessionStorage.removeItem('fullname');
                        window.location.pathname = "/TrangChu.cshtml";
                    })



                }
            })

        }
    })
}

function formatNumber(num) {
    return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,') + " VND";
}

function XacNhanDatPhong() {
    $.ajax({
        type: 'GET',
        url: '/SEP23Team2/api/KhachHang/XacNhanDatPhong/' + sessionStorage.getItem('madoan'),
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));

        },
        headers: { 'data-type': 'json' },
        dataType: 'json',
        success: function (data) {
            console.log(data);
            Swal.fire(
                'Xác Nhận Đặt Phòng Thành Công!',
                '!',
                'success'
            ).then(val => {
                location.reload();
            })

        },
        error: function (data) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: data.responseJSON.Message
            })
            loadData(info.id, info.urlLoad);
        }
    })
}

function XepPhongThuNghiem(url, dataInput) {
    $.ajax({
        url: '/SEP23Team2/api/' + url,
        method: 'POST',
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
        },
        headers: { 'Content-Type': 'application/json' },
        data: JSON.stringify(dataInput),
        success: function (data) {
            //$(info.modal).modal('hide');
            Swal.fire(
                'Success!',
                '',
                'success'
            ).then(val => {
                window.location.pathname = "/SEP23Team2/Views/NhanVienViews/DatPhongThatBai/DatPhongThatBai.cshtml";
            })


        }, error: function (data) {
            console.log(data);
            swal.fire(
                'Oop...!',
                data.responseJSON.Message,
                'error'
            ).then(() => {
                $('#luu').css('display', 'block');
                $('#loading').css('display', 'none');
                window.location.reload();
            })

        }

    })
}

