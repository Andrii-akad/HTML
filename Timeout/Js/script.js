let promise = new Promise((resolve, reject) => {
    setTimeout(() => {
        console.log(document.querySelector(".spinner"));
        document.body.getElementsByClassName("spinner")[0].style.display = 'none';
        resolve();
    }, 5000);
}).then(() => {
    document.body.getElementsByClassName("main")[0].style.display = 'inline';
})