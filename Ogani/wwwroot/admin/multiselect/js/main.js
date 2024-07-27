(function($) {

	"use strict";
	$(".js-select1").select2({
		closeOnSelect: false,
		placeholder: "Seçin",
		allowHtml: true,
		allowClear: true,
		tags: true
	});	
	$(".js-select2").select2({
			closeOnSelect : false,
			placeholder : "Seçin",
			allowHtml: true,
			allowClear: true,
			tags: true
	});

	$('.icons_select2').select2({
		width: "100%",
		templateSelection: iformat,
		templateResult: iformat,
		allowHtml: true,
		placeholder: "Seçin",
		dropdownParent: $( '.select-icon' ),
		allowClear: true,
		multiple: false
	});


	function iformat(icon, badge,) {
		var originalOption = icon.element;
		var originalOptionBadge = $(originalOption).data('badge');
	 
		return $('<span"><i class="fa ' + $(originalOption).data('icon') + '"></i> ' + icon.text + '<span class="badge">' + originalOptionBadge + '</span></span>');
	}

})(jQuery);
