const imgDive = document.querySelector('.d-user-avater');
const img = document.querySelector('#photo');
const file = document.querySelector('#file');
const uploadBtn = document.querySelector('#uploadBtn');


//work for image
file.addEventListener('change',function(){
    const choosedFile = this.file[0];

if(choosedFile){
    const reader = new FileReader();
    
    reader.addEventListener('load', function()
         {
             img.setAttribute('src',reader.result);
         });
         
    reader.readAsDataURL(choosedFile);
        }
});