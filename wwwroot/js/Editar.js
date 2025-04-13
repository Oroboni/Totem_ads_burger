document.addEventListener("DOMContentLoaded", function () {
    let counter = 0;
    const counterLabel = document.getElementById("counter");
    const decreaseButton = document.getElementById("decreaseButton");
    const increaseButton = document.getElementById("increaseButton");

    decreaseButton.addEventListener("click", function () {
        if (counter > 0) counter--;
        counterLabel.textContent = counter;
    });

    increaseButton.addEventListener("click", function () {
        counter++;
        counterLabel.textContent = counter;
    });
});
