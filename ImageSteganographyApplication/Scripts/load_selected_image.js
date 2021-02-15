

function loadSelectedImage() {
    var file = document.getElementById('image_upload').files[0];
    var reader = new FileReader();
    reader.onload = function (e) {
        $('.img-responsive').attr('src', e.target.result);
        var image = document.createElement("img");
        image.src = e.target.result;
    }
    reader.readAsDataURL(file);
}

