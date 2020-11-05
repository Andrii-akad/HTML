function RectangleArea(length, width = length) {
    return length * width;
}

console.log(RectangleArea(5));

function Time(hours, minutes, seconds) {
    return seconds + minutes * 60 + hours * 3600;
}

console.log(Time(5, 36, 45));

function SecondsToLong(seconds) {
    let hours = 0, minutes = 0;
    let zeroHours = "0", zeroMinutes = "0", zeroSeconds = "0";
    while (seconds / 3600 >= 1) {
        hours++;
        seconds -= 3600;
    }
    if (hours >= 10)
        zeroHours = "";
    while (seconds / 60 >= 1) {
        minutes++;
        seconds -= 60;
    }
    if (minutes >= 10)
        zeroMinutes = "";
    if (seconds >= 10)
        zeroSeconds = "";
    return `${zeroHours}${hours}:${zeroMinutes}${minutes}:${zeroSeconds}${seconds}`;
}

console.log(SecondsToLong(7777));

class Marker {
    constructor(color, ink) {
        this.color = color;
        if (ink <= 100 && typeof (ink) == 'number')
            this.ink = ink;
        else
            this.ink = 100;
    }

    Print(text) {
        let res = '';
        if (this.ink > 0) {
            for (let index = 0; index < text.length; index++) {
                if (this.ink > 0) {
                    res += text[index];
                    if (text[index] != ' ')
                        this.ink -= 0.5;
                }
            }
        }
        let obj = document.createElement('div');
        obj.innerHTML = `<h1 style="color:${this.color}">${res}</h1>`
        document.body.appendChild(obj);
    }
}

class SuperMarker extends Marker {
    constructor(color, ink) {
        super(color, ink);
    }
    FillUp(count) {
        if (typeof (count) == 'number')
            this.ink += count;
        if (this.ink > 100)
            this.ink = 100;
    }
}

/*let m = new Marker('black', 30);
m.Print('Marker lo8lr;dk jr ljrijijoijreijoigj eroigjoi jo');
m.Print('Marker lo8lr;dk jr ljrijijoijreijoigj eroigjoi jrio');
console.log("Ink in simpleM = " + m.ink);

let sm = new SuperMarker('blue', 20);
sm.Print('SuperMarker dusfh iushfiudhf isduh iuh iu');
sm.Print('SuperMarker dusfh iushfiudhf isduh iuh iu');
sm.FillUp(12020);
sm.Print("SuperMarker filled up");
console.log("Ink in superM = " + sm.ink);*/

let receipt = [{ name: 'bubbie', count: 3, price: 14.5 }, { name: 'milk', count: 2, price: 22.3 }, { name: 'bread', count: 1, price: 17.7 },
{ name: 'eggs', count: 15, price: 1.4 }, { name: 'meat', count: 1, price: 57 }];
function PrintReceipt(receipt) {
    let text = `Receipt`;

    let obj = document.createElement('div');
    obj.innerHTML = `<h1>${text}</h1>`
    obj.style.textAlign = "center";
    document.body.appendChild(obj);
    receipt.forEach(element => {
        let text = `${element.name} --> ${element.count} шт --> ${element.price} грн`;
        let obj = document.createElement('div');
        obj.innerHTML = `<h1>${text}</h1>`;
        obj.style.marginLeft = "10%";
        document.body.appendChild(obj);
    });
    text = `To pay: ${Sum(receipt)}грн`;
    obj = document.createElement('div');
    obj.innerHTML = `<h1>${text}</h1>`
    obj.style.marginLeft = "10%";
    document.body.appendChild(obj);
}

function Sum(receipt) {
    let sum = 0;
    receipt.forEach(element => {
        sum += element.price * element.count;

    });
    return sum;
}

function GetGold(receipt) {
    let max = 0;
    receipt.forEach(element => {
        if (element.price * element.count > max)
            max = element.price * element.count;
    });
    return receipt.find(x => x.price * x.count == max);
}

function GetAverage(receipt) {
    let goods = 0;
    receipt.forEach(element => {
        goods += element.count;
    });
    return Sum(receipt) / goods;
}

PrintReceipt(receipt);

let text = `The most price good: ${GetGold(receipt).name}`;

let obj = document.createElement('div');
obj.innerHTML = `<h1>${text}</h1>`
obj.style.textAlign = "center";
document.body.appendChild(obj);

text = `The average price of goods: ${GetAverage(receipt).toFixed(2)} грн`;

obj = document.createElement('div');
obj.innerHTML = `<h1>${text}</h1>`
obj.style.textAlign = "center";
document.body.appendChild(obj);