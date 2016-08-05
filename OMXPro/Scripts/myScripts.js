

(function (document, window, $) {

    // Script for search input

    $(function () {
        $(".search-header >a").on("click", function () {
            $(".site-search").fadeIn(500);
            $(".site-search").removeAttr("style");
            $("header-icons-box").fadeOut(500);
            $("#header-icons-box").css("display", "none");

        });

        $(".close").on("click", function () {
            $(".site-search").fadeOut(500);
            $(".site-search").css("display", "none");
            $("#header-icons-box").fadeIn(500);
            $("#header-icons-box").css("display", "inline-block");

        });

    });

    //script for main carousel
    $(function () {
        $('.sliderTop').slick({
            dots: false,
            autoplay: true,
            autoplaySpeed: 8000,
            mobileFirst: true,
        });
    });
    //Script for Freatured product slick slider

    $(function () {
        $(".slider").slick({
            slidesToShow: 4,
            slidesToScroll: 1,
            autoplay: true,
            autoplaySpeed: 1500,
            prevArrow: '.slider-container .btnleft',
            nextArrow: '.slider-container .btnright',
        });
    });

    //News List and Events
    $(function () {
        $(".sliderEvents").slick({
            slidesToShow: 1,
            slidesToScroll: 1,
            autoplay: true,
            autoplaySpeed: 3000,
            prevArrow: '.events-container .btnleft',
            nextArrow: '.events-container .btnright',
        });
    });


})(document, window, jQuery);

