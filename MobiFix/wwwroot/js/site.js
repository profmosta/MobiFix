




const num1 = document.getElementById("price");
const num2 = document.getElementById("cost");
const net = document.getElementById("net");
const num3 = document.getElementById("paid");
const unpaid = document.getElementById("unpaid");



function sum() {
    const price = parseInt(num1.value);
    const cost = parseInt(num2.value);
    const paid = parseInt(num3.value);


    net.value = price - cost;
    unpaid.value = price - paid;

}
    num1.addEventListener("change", sum);
    num2.addEventListener("change", sum);
    num3.addEventListener("change", sum);