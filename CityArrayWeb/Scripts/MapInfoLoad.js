window.onload = function () {
    var Latitude = document.getElementById("Latitude").innerHTML;
    var Longitude = document.getElementById("Longitude").innerHTML;
    showMap(Latitude, Longitude);
}

function showMap(Latitude, Longitude) {
    var googleLatLong = new google.maps.LatLng(Latitude, Longitude);

    var mapOptions = {
        zoom: 8,
        center: googleLatLong
    };

    var mapDiv = document.getElementById("map");
    var map = new google.maps.Map(mapDiv, mapOptions);

    var marker = new google.maps.Marker({ position: googleLatLong });
    marker.setMap(map);
}