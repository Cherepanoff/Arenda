var Name = document.getElementById('2');
var names;
function toLocal() {
    names = Name.innerHTML;
    localStorage.setItem('names', names)
}
if (localStorage.getItem('names')) {
    name.innerHTML = localStorage.getItem('names');
}