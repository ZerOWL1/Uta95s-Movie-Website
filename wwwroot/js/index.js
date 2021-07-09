// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function Ticker(elem) {
    elem.lettering();
    this.done = false;
    this.cycleCount = 5;
    this.cycleCurrent = 0;
    this.chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!#$%^&*()-_=+{}|[]\\;\':"<>?,./`~'.split('');
    this.charsCount = this.chars.length;
    this.letters = elem.find('span');
    this.letterCount = this.letters.length;
    this.letterCurrent = 0;

    this.letters.each(function () {
        var $this = $(this);
        $this.attr('data-orig', $this.text());
        $this.text('-');
    });
}

Ticker.prototype.getChar = function () {
    return this.chars[Math.floor(Math.random() * this.charsCount)];
};

Ticker.prototype.reset = function () {
    this.done = false;
    this.cycleCurrent = 0;
    this.letterCurrent = 0;
    this.letters.each(function () {
        var $this = $(this);
        $this.text($this.attr('data-orig'));
        $this.removeClass('done');
    });
    this.loop();
};

Ticker.prototype.loop = function () {
    var self = this;

    this.letters.each(function (index, elem) {
        var $elem = $(elem);
        if (index >= self.letterCurrent) {
            if ($elem.text() !== ' ') {
                $elem.text(self.getChar());
                $elem.css('opacity', Math.random());
            }
        }
    });

    if (this.cycleCurrent < this.cycleCount) {
        this.cycleCurrent++;
    } else if (this.letterCurrent < this.letterCount) {
        var currLetter = this.letters.eq(this.letterCurrent);
        this.cycleCurrent = 0;
        currLetter.text(currLetter.attr('data-orig')).css('opacity', 1).addClass('done');
        this.letterCurrent++;
    } else {
        this.done = true;
    }

    if (!this.done) {
        requestAnimationFrame(function () {
            self.loop();
        });
    } else {
        setTimeout(function () {
            self.reset();
        }, 750);
    }
};

$words = $('.word');

$words.each(function () {
    var $this = $(this),
        ticker = new Ticker($this).reset();
    $this.data('ticker', ticker);
});


//SwipperJS
var swiper = new Swiper('.swiper-container', {
    effect: 'coverflow',
    grabCursor: true,
    centeredSlides: true,
    slidesPerView: 'auto',
    coverflowEffect: {
        rotate: 20,
        stretch: 0,
        depth: 200,
        modifier: 1,
        slideShadows: true
    },
    loop: true,
    autoplay: {
        delay: 2500,
        disableOnInteraction: false
    },
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev'
    },
    mousewheel: {
        invert: true
    }
    //                pagination: {
    //                    el: '.swiper-pagination'  //indicators
    //                }
});


//AOS
AOS.init({
    duration: 1500 //global duration
});


//popup
function togglePopup() {
    document.getElementById("popup-1")
        .classList.toggle("active");
}
//form login
const loginText = document.querySelector(".title-text .login");
const loginForm = document.querySelector("form.login");
const loginBtn = document.querySelector("label.login");
const signupBtn = document.querySelector("label.signup");
const signupLink = document.querySelector("form .signup-link a");

signupBtn.onclick = (() => {
    loginForm.style.marginLeft = "-50%";
    //loginText.style.marginLeft = "-50%";
});

loginBtn.onclick = (() => {
    loginForm.style.marginLeft = "0%";
    //loginText.style.marginLeft = "0%";
});

signupLink.onclick = (() => {
    signupBtn.click();
    return false;
});


//scroll down js
window.addEventListener("scroll", function () {
    var header = document.querySelector("header");
    header.classList.toggle("sticky", window.scrollY > 0);
});

//show passwords
function checkPass() {
    var pass = document.getElementById("passwords");
    if (pass.type === "password") {
        pass.type = "text";
    } else {
        pass.type = "password";
    }
}

//page Loader
var setTime;
function loadPage() {
    var body = document.getElementById('body');
    setTime = setTimeout(showPage, 4500);
    body.style.background = 'none';
}
function showPage() {
    document.getElementById("load-page").style.display = "none";
    document.getElementById("page-body").style.display = "block";
}


//animate background
let stars = document.getElementById('star');
let half_moon = document.getElementById('halfmoon');
let cloud = document.getElementById('cloud');
let grass2 = document.getElementById('grass2');
let tree = document.getElementById('tree');
let grass1 = document.getElementById('grass1');
let screen = document.getElementById('screen');
let people = document.getElementById('people');
let grass3 = document.getElementById('grass3');

//window scroll events
window.addEventListener('scroll',
    function () {
        let value = window.scrollY;
        if (value < 450) {
            stars.style.left = value * 0.3 + 'px';
            cloud.style.left = value * 0.25 + 'px';
            half_moon.style.marginTop = value / 15 + '%';
            grass2.style.marginTop = value / 5 + 'px';
            tree.style.marginTop = value / 3 + 'px';
        }
        console.log(value);
    });

//opacity for .people
$(document).ready(function () {
    $(window).scroll(function () {
        if ($(this).scrollTop() > 50) {
            $("#people").css({ "opacity": "0" });
        } else {
            $("#people").css({ "opacity": "1" });
        }
    });
});