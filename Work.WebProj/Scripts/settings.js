$(window).scroll(function () {
	if ($(this).scrollTop() > 100) {
		$(".goTop").addClass("show");
	} else {
		$(".goTop").removeClass("show");
	}
});  //goTop按鈕顯示

$(".goTop").click(function () {
	$("html, body").animate({
		scrollTop: $($.attr(this, "href")).offset().top - 108 // fix for fixed header
	}, 500);
	return false;
});  //goTop按鈕點選滑動至頂端

$('[data-toggle="tooltip"]').tooltip();
$('[data-toggle="popover"]').popover();  //BS提示訊息

$(".file-upload input[type='file']").change(function() {
	var file_name = $(this).val().replace(/C:\\fakepath\\/i, '');
	$(this).siblings(".form-control").find("input[type='text']").val(file_name);
});  //檔案上傳按鈕: 顯示檔名 (去除Chrome和IE會出現的fakepath字樣) (測試中)

$(".modal.fit-window").on("show.bs.modal", function() {
	var height = $(window).height() - 200;
	$(this).find(".modal-body").css("max-height", height);
});  //讓popup的高度不要超過螢幕高度 (測試中)

function centerModals(){
  $('.modal.center-window').each(function(i){
    var $clone = $(this).clone().css('display', 'block').appendTo('body');
    var top = Math.round(($clone.height() - $clone.find('.modal-content').height()) / 2);
    top = top > 0 ? top : 0;
    $clone.remove();
    $(this).find('.modal-content').css("margin-top", top);
  });
}
$('.modal.center-window').on('show.bs.modal', centerModals);
$(window).on('resize', centerModals);  //popup上下左右置中 (測試中)