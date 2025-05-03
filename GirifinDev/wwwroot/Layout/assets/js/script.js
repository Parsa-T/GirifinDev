document.getElementById('read-more-btn').addEventListener('click', function(event) {
    event.preventDefault();
    document.getElementById('popup').style.display = 'flex';
});

document.getElementById('close-btn').addEventListener('click', function() {
    document.getElementById('popup').style.display = 'none';
});


document.getElementById('hamberger').addEventListener('click', function() {
    var navUl = document.querySelector('.menu-ham');
    navUl.classList.toggle('transform-full');
});