function ChangeCulture(lang) {
    $.ajax({
        type: "POST",
        url: '/Home/ChangeCulture',
        dataType: 'json',
        data: {
            lang: lang
        },
        success: function () {
            window.location.reload();
        }
    });
}

