
//change box sizes with the slider
boxSizeSlider.onchange = function () {
    [].forEach.call(document.querySelectorAll("#images > div"), function (d) {
        d.style.width = boxSizeSlider.value + "px";
        d.style.height = boxSizeSlider.value + "px";
    });
};




