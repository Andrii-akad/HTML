document.body.style.background = "url('backphoto.jpg')";
document.body.style.backgroundSize = "cover";
setTimeout(function () {
    let name = prompt('Как тебя зовут?');
    alert('Привет ' + name + '! Рад тебя видеть!');

    let age = prompt('А какого ты года рождения?');
    const dateNow = 2020;
    age = dateNow - age;
    alert('Ого! Тебе уже целых ' + age + '!');

    let square = prompt('А давай сыграем в игру? Введи длину стороны квадрата!(в см)');
    alert('А вот и его периметр! Он равен ' + square * 4 + ' см!');

    let circle = prompt('Сыграем еще раз! Введи длину радиуса окружности!(в см)');
    alert('Удивительно! Ее площадь равна ' + Math.PI * circle ** 2 + ' см!');

    let distance = prompt('Куда едем? Введи сколько км нам нужно намотать.');
    let time = prompt('Таак.. И за сколько часов мы должны столько проехать?');
    alert('Ага.. Так.. мм.. Нужно будет ехать со скоростью ' + (distance / time).toFixed(0) + ' км/ч. Выезжаем!');

    const rate = 0.89;
    let dollars = prompt('Не хочешь побыть безнесменом? Введи свою желаемую зарплату в долларах!');
    alert('В евро это будет вот столько ' + dollars * rate + '!');

    let usd = prompt('Что? Хочешь быть IT-шником? Ну тогда говори свой обьем памяти на флешке!(в ГБ)');
    alert('На твоей флешке поместиться ' + (usd / 0.820).toFixed(1) + ' файлов по 820 МБ. Неплохо.');

    let money = prompt('Фуух! Пора передохнуть. Ну-ка сколько там у тебя в закромах? Пойдем накупим шоколадок!');
    let cost = prompt('Хм.. по чем брать буим?')
    alert('Умм.. люблю шоколадки.. Ты уж прости что сьел все сам :) Сьел все ' + (money / cost).toFixed(0));

    let number = prompt('Время фокусов! Введи трехзначное число!');
    let res = '';
    res += number % 10;;
    let temp = (number / 10 - 0.5).toFixed(0);
    res += temp % 10;
    temp = (temp / 10 - 0.5).toFixed(0);
    res += temp % 10;
    alert('Число наоборот -----> ' + res + '!');

    let num2 = prompt('Просто введи любое число');
    alert('Это число четное? Ответ: ' + (num2 % 2 == 0));
    document.body.style.background = "url('backgif.gif')";
    document.body.style.backgroundSize = "cover";
}, 1000);