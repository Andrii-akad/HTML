class Country {
    constructor(name, cap, lan, set, nez, area) {
        this.name = name;
        this.cap = cap;
        this.lan = lan;
        this.set = set;
        this.nez = nez;
        this.area = area;
    }
};

function FillInfo(obj) {
    cap.innerText = obj.cap;
    lan.innerText = obj.lan;
    set.innerText = obj.set;
    nez.innerText = obj.nez;
    area.innerText = obj.area;
}

let uc = new Country("Україна", "Київ", "Українська", "Парламентсько-президентська республіка", "24 серпня 1991", "603 628 км??");
let ger = new Country("Німеччина", "Берлин", "мова германии", "устрій германии", "дата незалежності германии", "площа германии");
let french = new Country("Франція", "Париж", "мова франції", "устрій франції", "дата незалежності франції", "площа франції");
let aus = new Country("Австрія", "Канберра", "мова австрвлії", "устрій австрвлії", "дата незалежності австрвлії", "площа австрвлії");
let bolg = new Country("Болгарія", "София", "мова болгарії", "устрій болграії", "дата незалежності болграії", "площа болграії");

let message = "Виберіть країну:\nУкраїна\nНімеччина\nФранція\nАвстрія\nБолгарія"

let name = prompt(message);
document.querySelector(".country").innerHTML = name;

let cap = document.querySelector(".cap");
let lan = document.querySelector(".lan");
let set = document.querySelector(".set");
let nez = document.querySelector(".nez");
let area = document.querySelector(".area");

if (name.toUpperCase() === uc.name.toUpperCase()) {
    FillInfo(uc);
}
else if (name.toUpperCase() == ger.name.toUpperCase()) {
    FillInfo(ger);
}
else if (name.toUpperCase() == french.name.toUpperCase()) {
    FillInfo(french);
}
else if (name.toUpperCase() == aus.name.toUpperCase()) {
    FillInfo(aus);
}
else if (name.toUpperCase() == bolg.name.toUpperCase()) {
    FillInfo(bolg);
}
