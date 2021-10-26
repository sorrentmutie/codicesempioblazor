window.faiQualcosa = (argomento1, argomento2) => {
    console.log('Sono in javascript:' + argomento1);
    DotNet.invokeMethodAsync("LibreriaComponenti", "RestituisciArrayAsync")
        .then(dati => {
            console.log(dati);
        });
    return 100;
}

window.sayHello = (mioOggettoDotNet) => {
    console.log(mioOggettoDotNet);
    return mioOggettoDotNet.invokeMethodAsync("Saluta")
        .then(saluto => {
            console.log(saluto);
            return "ciao ciao";
        });
}

window.mostraModale = (id) => {
    $("#" + id).modal('show');
}

window.nascondiModale = (id) => {
    $("#" + id).modal('hide');
}

let map;

window.mostraMappa = (divcontenitore, zoom, centro, markers) => {
    let geocoder = new google.maps.Geocoder();
    geocoder.geocode({ 'address': centro }, function (results, status) {
        if (status === "OK") {
            let center = results[0].geometry.location;
            map = new google.maps.Map(divcontenitore, {
                center: center,
                zoom: zoom,
            });
            if (markers && markers.length > 0) {
                markers.forEach(marker => {
                    const infowindow = new google.maps.InfoWindow({
                        content: '<p>Ciao</p>',
                    });
                    geocoder.geocode({ 'address': marker }, function (res, stat) {
                        if (stat === 'OK') {
                            var mark = new google.maps.Marker({
                                map: map,
                                position: res[0].geometry.location
                            });
                            mark.addListener('click', function () {
                                infowindow.open({
                                    anchor: mark,
                                    map,
                                    shouldFocus: false,
                                });
                            })
                        }
                    })
                });
            }
        }
    });
}


