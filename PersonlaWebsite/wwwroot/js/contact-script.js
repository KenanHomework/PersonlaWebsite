const name = document.querySelector("#name");
const nameCode = document.querySelector("#name-code");

const email = document.querySelector("#email")
const emailCode = document.querySelector("#email-code");
const emailValid = document.querySelector('#email-valid-code')

const message = document.querySelector("#message");
const messageCode = document.querySelector("#message-code");
const count = document.querySelector("#count");

name.value = "John Doe";
email.value = "jo@hnd.oe";
message.value = "Hello World";

name.oninput = function () {
    console.log(name.value)
    nameCode.innerText = name.value;
}

email.onkeyup = function () {
    emailCode.innerText = email.value;
    emailValid.innerText = isValidEmail(email.value);
}

message.onkeyup = function () {
    messageCode.innerText = message.value;
    count.innerText = message.value.length;
}

function isValidEmail(email) {
    return /\b[\w\.-]+@[\w\.-]+\.\w{2,4}\b/.test(email) ? "true" : "false";
}