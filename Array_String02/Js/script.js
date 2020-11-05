//1) while
let diapasone1 = parseInt(prompt("Enter first number of diapasone: "));
let diapasone2 = parseInt(prompt("Enter second number of diapasone: "));

let res = 0;
while (++diapasone1 < diapasone2) {
    res += diapasone1;
}
console.log(res);

//2) for
/*let number1 = parseInt(prompt("Enter first number: "));
let number2 = parseInt(prompt("Enter second number: "));
let res = 1;
let max;
if (number1 < number2)
    max = number2;
else
    max = number1;
for (let index = 1; index <= max; index++) {
    if (number1 % index == 0 && number2 % index == 0)
        res = index;
}
console.log(res);*/

//3) for
/*let number = parseInt(prompt("Enter number: "));

for (let index = 1; index <= number; index++) {
    if (number % index == 0)
        console.log(index);
}*/

//4) do while
/*let number = parseInt(prompt("Enter number: "));
let res = 0;
do {
    number = parseInt(number / 10);
    res++;
} while (number != 0);
console.log(res);*/

//5) for
/*let number;
let positive = 0, negative = 0, zero = 0;
for (let index = 0; index < 10; index++) {
    number = parseInt(prompt(`Enter number#${index+1}: `));
    if (number > 0)
        positive++;
    else if (number < 0)
        negative++;
    else
        zero++;
}
console.log("positive: " + positive);
console.log("negative: " + negative);
console.log("zero: " + zero);*/

//6) do while
/*let cont;
do {
    let number1 = parseInt(prompt("Enter first number: "));
    let action = prompt("Enter action:\n/\n*\n+\n-");
    let number2 = parseInt(prompt("Enter second number: "));
    if (action == '/')
        console.log(number1 / number2);
    else if (action == '*')
        console.log(number1 * number2);
    else if (action == '+')
        console.log(number1 + number2);
    else if (action == '-')
        console.log(number1 - number2);
    cont = prompt("Continue?(OK/Cancel)");
} while (cont != null);*/

//7) for
/*let number1 = prompt("Enter number: ");
let moves = parseInt(prompt("Enter count of moves: "));
for (let index = 0; index < moves; index++) {
    let temp = number1[0];
    number1 = number1.replace(temp, "");
    number1 += temp;
}
console.log(number1);*/

//8) do while
/*let cont;
const arr = ["Понеділок", "Вівторок", "Середа", "Четвер", "П'ятниця", "Субота", "Неділя"];
let i = 0;
do {
    if (i == arr.length)
        i = 0;
    cont = prompt(arr[i] + ". Дізнатись про наступний день?");
    i++;
} while (cont != null);*/

//9) for
/*let table="";
for (let first = 2; first <= 9; first++) {
    for (let second = 1; second <= 10; second++) {
        table += first.toString() + " * " + second.toString() + " = " + first * second + "\n";

    }
    prompt(table);
    table = "";
}*/

//10) do while
/*let min = 0, max = 100;
let answer;
do {
    answer = prompt("Ваше число більше, менше чи рівне " + parseInt((max + min) / 2) + "?(>/</==)");
    if (answer == '>')
        min = parseInt((max + min) / 2);
    else if (answer == '<')
        max = parseInt((max + min) / 2);
    else
        prompt("Ура! Число вгадано!");
} while (answer != "==");*/