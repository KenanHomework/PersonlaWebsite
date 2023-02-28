document.querySelector("#year").innerText = new Date().getFullYear();

const title = document.title.split(' - ')[0].toLowerCase();
console.log(title)
document.querySelector(`#${title}`).classList.add('active');