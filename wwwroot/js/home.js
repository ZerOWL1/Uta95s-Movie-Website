//hamburger button
$(document).ready(function () {
    $(".hamburger").click(function () {
        let button = document.getElementById("button-nav");
        //button.style.background = '#0078F2';
        button.style.background = '#252525';
        $(".hamburger").toggleClass("is-active");
    });


    $(".hamburger").click(function () {
        if ($(".hamburger").hasClass("is-active")) {
            let button = document.getElementById("button-nav");
            button.style.background = 'none';
            button.style.background = '#252525';
        }
    });


    //li hover
    $(".li1").hover(function () {
        $(".hr-nav1").addClass("active");
    },
        function () {
            $(".hr-nav1").removeClass("active");
        }
    );

    $(".li2").hover(function () {
        $(".hr-nav2").addClass("active");
    },
        function () {
            $(".hr-nav2").removeClass("active");
        }
    );
    $(".li3").hover(function () {
        $(".hr-nav3").addClass("active");
    },
        function () {
            $(".hr-nav3").removeClass("active");
        }
    );
    $(".li4").hover(function () {
        $(".hr-nav4").addClass("active");
    },
        function () {
            $(".hr-nav4").removeClass("active");
        }
    );
    $(".li5").hover(function () {
        $(".hr-nav5").addClass("active");
    },
        function () {
            $(".hr-nav5").removeClass("active");
        }
    );
    $(".li6").hover(function () {
        $(".hr-nav6").addClass("active");
    },
        function () {
            $(".hr-nav6").removeClass("active");
        }
    );


    //check cate-mobile
    $(".li2").click(function () {
        console.log("li 2 clicked");
        let cateM = document.getElementById("cate-Mobile");
        cateM.style.transform = "translateX(0)";
    });

    $(".cate-mobile-header").click(function () {
        console.log("cate-mobi clicked");
        let cateM = document.getElementById("cate-Mobile");
        cateM.style.transform = "translateX(101%)";
    });


    //overlay click
    $("#overlay").click(function () {
        let button = document.getElementById("button-nav");
        button.style.background = '#252525';
        $("#button-nav").removeClass("is-active");
    });

    /*trailer*/
    $(".play-video").click(function () {
        $(".trailer").addClass('active');
    });

    $(".close-trailer").click(function () {
        $(".trailer").removeClass('active');
    });

    /*owl slider top 3 random*/
    $('#top3_random_slide').owlCarousel({
        margin: 5,
        items: 2,
        dots: false,
        loop: true,
        autoplay: true,
        autoplayHoverPause: true,
        responsive: {
            500: {
                items: 3
            },
            1280: {
                items: 5
            },
            1600: {
                items: 6
            }
        }
    });

    /*movie*/
    let navText = ["<i class='bx bx-chevron-left'></i>", "<i class='bx bx-chevron-right'></i>"];
    $('.movie-slide').owlCarousel({
        items: 2,
        dots: false,
        loop: true,
        autoplay: true,
        nav: true,
        navText: navText,
        margin: 15,
        responsive: {
            500: {
                items: 2
            },
            1280: {
                items: 5
            },
            1600: {
                items: 6
            }
        }
    });
});

