scroll = document.querySelector('.toTop');

console.log(scroll);
console.log("test");

window.addEventListener('scroll',e =>{

    if(window.pageYOffset >500){
    
        scroll.style.display='block';
    }else {
        scroll.style.display='none';
    }

});

function scrolltoTop(){
    window.scrollTo({ top: 0, behavior: 'smooth' });
}



scroll.addEventListener('click', e => {

    scrolltoTop();
});