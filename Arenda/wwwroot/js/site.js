function addrow() {
    var nodet = document.createElement('tr');
    var node = document.createElement('td');
    node.innerHTML = "<input type='text' name='1'>";
    document.getElementById('table').appendChild(nodet);
    nodet.appendChild(node);
    localStorage.addrow();
}
function deleterow(tableID) {
    var table = document.getElementById('table');
    var rowCount = table.rows.length;
    if (rowCount>9)
    table.deleteRow(rowCount - 1);
}
function addrow1() {
    var nodet = document.createElement('tr');
    var node = document.createElement('td');
    node.innerHTML = "<input type='text' name='2'>";
    node.innerHTML = "<input type='text' name='3'>";
    node.innerHTML = "<input type='text' name='4'>";
    node.innerHTML = "<input type='text' name='5'>";
    document.getElementById('table1').appendChild(nodet);
    nodet.appendChild(node);
    localStorage.addrow();
}
function deleterow1(tableID) {
    var table = document.getElementById('table1');
    var rowCount = table.rows.length;
    if (rowCount > 1)
        table.deleteRow(rowCount - 1);
}
function ChangeText(id) {
    switch (id) {
        case "0":
            document.getElementById("text").innerHTML = "План 0-ого этажа";
            document.getElementById("image").src = "../SVG/0 этаж.jpg";
            break;
        case "1":
            document.getElementById("text").innerHTML = "План 1-ого этажа";
            document.getElementById("image").src = "../SVG/1 этаж.jpg";
            break;
        case "2":
            document.getElementById("text").innerHTML = "План 2-ого этажа";
            document.getElementById("image").src = "../SVG/2 этаж.jpg";
            break;
        case "3":
            document.getElementById("text").innerHTML = "План 3-ого этажа";
            document.getElementById("image").src = "../SVG/3 этаж.jpg";
            break;
        case "4":
            document.getElementById("text").innerHTML = "План 4-ого этажа";
            document.getElementById("image").src = "../SVG/4 этаж.jpg";
            break;
        case "5":
            document.getElementById("text").innerHTML = "План 5-ого этажа";
            document.getElementById("image").src = "../SVG/5 этаж.jpg";
            break;
        case "6":
            document.getElementById("text").innerHTML = "План 6-ого этажа";
            document.getElementById("image").src = "../SVG/6 этаж.jpg";
            break;
}   
}
function ChangeTextAdvert(id) {
    switch (id) {
        case "0":
            document.getElementById("text").innerHTML = "План 0-ого этажа";
            document.getElementById("image").src = "../AdvertisingSVG/0этаж.svg";
            break;
        case "1":
            document.getElementById("text").innerHTML = "План 1-ого этажа";
            document.getElementById("image").src = "../AdvertisingSVG/1этаж.svg";
            break;
        case "2":
            document.getElementById("text").innerHTML = "План 2-ого этажа";
            document.getElementById("image").src = "../AdvertisingSVG/2этаж.svg";
            break;
        case "3":
            document.getElementById("text").innerHTML = "План 3-ого этажа";
            document.getElementById("image").src = "../AdvertisingSVG/3этаж.svg";
            break;
        case "4":
            document.getElementById("text").innerHTML = "План 4-ого этажа";
            document.getElementById("image").src = "../AdvertisingSVG/4этаж.svg";
            break;
        case "5":
            document.getElementById("text").innerHTML = "План 5-ого этажа";
            document.getElementById("image").src = "../AdvertisingSVG/5этаж.svg";
            break;
    }
}

