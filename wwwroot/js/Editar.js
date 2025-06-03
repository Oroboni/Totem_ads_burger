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

function load(){
    const savedCart = localStorage.getItem("cart");
    if (savedCart) {
        cart = JSON.parse(savedCart);
        cartCount = cart.length;
        totalPrice = cart.reduce((sum, item) => sum + parseFloat(item.totalItemPrice), 0);
        document.getElementById("cart-count").innerText = cartCount;
        document.getElementById("total-price").innerText = totalPrice.toFixed(2);
    }
}