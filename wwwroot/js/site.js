// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// this block of code is related to the flashBanner that shows on the top of the screen for error messsages and whatnot

var flashBanner = document.getElementById("flashBanner");
var flashBannerClose = document.getElementById("flashBannerClose");

// this closes the banner after 15 seconds
if (flashBanner != null){
    setInterval(function(){
        flashBanner.classList.remove("d-flex");
        flashBanner.classList.add("d-none");
    }, 15000);
}

// this sets an event listener for the banner in case the user wanted to close it with the button
$(flashBannerClose).on("click", function () {
    flashBanner.classList.remove("d-flex");
    flashBanner.classList.add("d-none");
});

//========================================================================================
//========================================================================================