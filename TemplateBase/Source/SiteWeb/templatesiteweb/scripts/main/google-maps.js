var myCenter=new google.maps.LatLng(-23.644724399999998,-46.5993676);
var marker;

function initialize()
{
var mapProp = {
  center:myCenter,
  zoom:12,
  mapTypeId:google.maps.MapTypeId.ROADMAP
  };

var map=new google.maps.Map(document.getElementById("googleMap"),mapProp);

var marker=new google.maps.Marker({
  position:myCenter,
  animation:google.maps.Animation.BOUNCE
  });

marker.setMap(map);
var infowindow = new google.maps.InfoWindow({
  content:"<label>Adoce a Vida - Bolos & Doces</label> </br> <span>Ligue: (11) 98451-7934</span>"
  });

infowindow.open(map,marker);
}

google.maps.event.addDomListener(window, 'load', initialize);