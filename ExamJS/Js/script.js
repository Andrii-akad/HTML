const url = "https://api.privatbank.ua/p24api/infrastructure?json&tso&address=&city=";
let allCities=[];
document.querySelector(".searchBtn").addEventListener("click", initFetch);
document.querySelector(".userCity").addEventListener("keyup", searchKey);

var input = document.querySelector(".userCity");

input.addEventListener("keyup", function(event) {
  if (event.keyCode === 13) {
    event.preventDefault();
    document.querySelector(".searchBtn").click();
  }
});

function searchKey(){
    var str = document.querySelector(".userCity").value;
    if(str.length>0)
    document.querySelector(".userCity").value = str.replace(str[0],str[0].toUpperCase());
}

function initFetch() {
    fetch(url + document.querySelector(".userCity").value)
        .then((response) => {
            return response.json();
        })
        .then((data) => {
              data.devices.forEach(element=>{
                allCities.push(element.cityUA);
                allCities.push(element.cityRU);
                allCities.push(element.cityEN);
            });
            showCities(data);
        })
}

function showCities(data) {
    document.querySelector(".list-group").innerHTML="";
    let cities = data.devices.map((item) => {
        if (allCities.includes(document.querySelector(".userCity").value)) {
            let cityInfo = document.createElement("li");
            cityInfo.className = "list-group-item";
            var temp = item.fullAddressUa.split(",");
            for (let index = 0; index < temp.length; index++) {
                if(index<3)
                temp.shift();
            }
            let address="";
            temp.forEach(element=>{
                address +=", "+element;
            })

            cityInfo.innerText = item.cityUA  + address
            let btn = document.createElement("button");
            btn.style.marginLeft = "50px";
            btn.style.width="auto"
            btn.className = "btn btn-primary";
            btn.innerText = "Показати на карті";
            btn.addEventListener("click", (btnClick) => {
                initMap(parseFloat(item.latitude), parseFloat(item.longitude));
            });
            cityInfo.append(btn);

            return cityInfo;
        }
    })
    cities.forEach(element => {
        if(element==undefined)
            return;
        document.querySelector(".list-group").append(element);
    });
}

function initMap(longitude = 26.010, latitude=50.121) {
    var uluru = {
        lat: latitude ,
        lng: longitude
    };
    // The map, centered at Uluru
    var map = new google.maps.Map(
        document.getElementById('map'), {
            zoom: 8,
            center: uluru
        });
    // The marker, positioned at Uluru
    var marker = new google.maps.Marker({
        position: uluru,
        map: map
    });
}