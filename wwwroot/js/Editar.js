const decreaseButtons = document.querySelectorAll('#decreaseButton');
const increaseButtons = document.querySelectorAll('#increaseButton');
const counters = document.querySelectorAll('#counter');

decreaseButtons.forEach((button, index) => {
    button.addEventListener('click', () => {
        let count = parseInt(counters[index].textContent);
        if (count > 0) {
            count--;
            counters[index].textContent = count;
        }
    });
});

increaseButtons.forEach((button, index) => {
    button.addEventListener('click', () => {
        let count = parseInt(counters[index].textContent);
        count++;
        counters[index].textContent = count;
    });
});

function voltar() {
    window.history.back();
}