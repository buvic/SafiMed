$('a[data-toggle="tab"]').on('hide.bs.tab', function (e) {
    var $old_tab = $($(e.target).attr("href"));
    var $new_tab = $($(e.relatedTarget).attr("href"));

    if ($new_tab.index() < $old_tab.index()) {
        $old_tab.css('position', 'relative').css("right", "0").show();
        $old_tab.animate({ "right": "-100%" }, 300, function () {
            $old_tab.css("right", 0).removeAttr("style");
        });
    }
    else {
        $old_tab.css('position', 'relative').css("left", "0").show();
        $old_tab.animate({ "left": "-100%" }, 300, function () {
            $old_tab.css("left", 0).removeAttr("style");
        });
    }
});

$('a[data-toggle="tab"]').on('show.bs.tab', function (e) {
    var $new_tab = $($(e.target).attr("href"));
    var $old_tab = $($(e.relatedTarget).attr("href"));

    if ($new_tab.index() > $old_tab.index()) {
        $new_tab.css('position', 'relative').css("right", "0");
        $new_tab.animate({ "right": "0" }, 500);
    }
    else {
        $new_tab.css('position', 'relative').css("left", "0");
        $new_tab.animate({ "left": "0" }, 500);
    }
});

$('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
    // your code on active tab shown
});

function setTabText(elem) {
    $("[data]").addClass('hide');
    $("[data='" + elem.attributes['href'].value + "']").removeClass('hide');
}
