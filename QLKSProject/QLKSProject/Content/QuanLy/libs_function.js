var EMEmpty = "Thông tin nhập vào không hợp lệ!\r\n";
var EMNumber = " phải là số\r\n";
var EMTwoNumber = " chỉ có 2 chữ số\r\n";
//orther function
function formatNumber(num) {
    return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,') + " VND";
}
function checkSession() {
    if (!sessionStorage.getItem('fullname') && !sessionStorage.getItem('role')) {
        window.location.href = "/SEP23Team2/404.cshtml";
    } else {
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
    }

}

function checkSessionHome() {
    if (sessionStorage.getItem('role')) {
        $('#name').css('display', 'inline');
        $('#dn').css('display', 'none');
        $('.nameuser').html(sessionStorage.getItem('fullname'));
        if (sessionStorage.getItem('role') == 'nv') {
            $('#nv').css('display', 'inline');
            $('#ql').css('display', 'none');
        } else {
            $('#nv').css('display', 'none');
            $('#ql').css('display', 'inline');
        }

    }
}

function isEmpty(str) {

    return (str == '');
}
function isNumber(number) {
    var n = parseInt(number);

    return (n > 0)
}
function isTwoNumber(number) {

    var n = parseInt(number);
    return (n < 100 && n > 0)
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
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: jqXHR.responseJSON.Message
        })
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
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: jqXHR.responseJSON.Message
        })
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
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: jqXHR.responseJSON.Message
        })
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
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: jqXHR.responseJSON.Message
        })
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
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: jqXHR.responseJSON.Message
                })
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
                window.location.href = "/SEP23Team2/404.cshtml";
            }
        }
    })
}

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
        } else if (jqXHR.responseJSON.Message == 'An error has occurred.') {
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




