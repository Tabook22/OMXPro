// Popup effect with Magnific Popup
// http://dimsemenov.com/plugins/magnific-popup/


//pop 2--------------------------------------------
function openPopup2() {
    $.magnificPopup.open({
        items: {
            src: '#popup2',
        },
        mainClass: 'mfp-newspaper'
    });
    $("#pop2").prop("disabled", false);
}
$("#pop2").on("click", function () {
    setTimeout(openPopup2, 2000);
    $(this).prop("disabled", true);
});

//pop 3--------------------------------------------
function openPopup3(){  
	$.magnificPopup.open({    
		items: {      
		src: '#popup3',    
		},     
		mainClass: 'mfp-newspaper'  
    });  
	$("#pop3").prop("disabled", false);
}
$("#pop3").on("click", function(){  
	setTimeout(openPopup3, 2000);  
	$(this).prop("disabled", true);
});

