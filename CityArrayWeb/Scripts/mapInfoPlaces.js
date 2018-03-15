var map;
var infoWindow;

window.onload = function () {
    showMap();
}

function showMap() {
    var mapOptions = {
        zoom: 2,
        center: new google.maps.LatLng(20, 20)
    };
    var mapDiv = document.getElementById("map");
    map = new google.maps.Map(mapDiv, mapOptions);

    infoWindow = new google.maps.InfoWindow();

    google.maps.event.addListener(map, 'click', function () {
        infoWindow.close();
    });

    cities.map(function (item, i) {
        LatLng = new google.maps.LatLng(item.Latitude, item.Longitude);
        var marker = new google.maps.Marker({
            map: map,
            position: LatLng,
            title: item.CityName
        });

        google.maps.event.addListener(marker, 'click', function () {
            infoWindow.close();
            infoWindow = new google.maps.InfoWindow();
            var content =
                "<p><b>" + item.CityName + "</b></p>" +
                "<p>" + item.ReviewTitle + "</p>"
            infoWindow.setContent(content);
            infoWindow.open(map, marker);
        });
    });

    wishedCities.map(function (item, i) {
        LatLng = new google.maps.LatLng(item[0], item[1])
        var marker = new google.maps.Marker({
            map: map,
            position: LatLng,
            label: "Name" + i,
            title: "name",
            icon: {
                path: 'http://maps.google.com/mapfiles/ms/icons/green-dot.png',
                strokeColor: "blue",
                scale: 6
            }
        });
        google.maps.event.addListener(marker, 'click', function () {
            infoWindow.close();
            infoWindow = new google.maps.InfoWindow(
                {
                    content: item.CityName
                });
            infoWindow.open(map, marker);
        });
    });
}
