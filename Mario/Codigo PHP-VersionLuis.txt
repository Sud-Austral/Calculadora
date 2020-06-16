<?php

function distance($lat1, $lon1, $lat2, $lon2, $unit) {
 
  $theta = $lon1 - $lon2;
  $dist = sin(deg2rad($lat1)) * sin(deg2rad($lat2)) +  cos(deg2rad($lat1)) * cos(deg2rad($lat2)) * cos(deg2rad($theta));
  $dist = acos($dist);
  $dist = rad2deg($dist);
  $miles = $dist * 60 * 1.1515;
  $unit = strtoupper($unit);
 
  if ($unit == "K") {
    return ($miles * 1.609344);
  } else if ($unit == "N") {
      return ($miles * 0.8684);
    } else {
        return $miles;
      }
}

global $distancia;
$distancia = 0;

if(isset($_POST['actualizar'])){

$fp = fopen('https://raw.githubusercontent.com/Sud-Austral/Calculadora/master/BaseDatos/airports.dat','r');
if (!$fp) {echo 'ERROR: No ha sido posible abrir el archivo. Revisa su nombre y sus permisos.'; exit;}
 
$loop = 0; 
while (!feof($fp)) { 
$line = fgets($fp); 
$field[$loop] = explode (',', $line);

if($_POST['inicio'] == str_replace('"', '', $field[$loop][1])){
  $lat1 = $field[$loop][6];
  $lon1 = $field[$loop][7];
}
if($_POST['destino'] == str_replace('"', '', $field[$loop][1])){
  $lat2 = $field[$loop][6];
  $lon2 = $field[$loop][7];
}
$fp++; 
}
fclose($fp);

$distancia = distance($lat1, $lon1, $lat2, $lon2, "K");

echo "Distancia de ".$_POST['inicio']." a ".$_POST['destino']." :  ".$distancia." Kilómetros  &nbsp; <br><br>";
$Total = round( $distancia * 0.32 / 1000,0);
$TotalPagar = $Total * 80;
echo "Carbono producido :  ".$Total."<br><br>";
echo "Total a pagar :  ".$TotalPagar."<br><br>";
echo '<p onclick="alert('.$TotalPagar.')">Hola</p>';

echo '<br>';
echo '<a class="checkout-button button alt wc-forward" href="https://pruebaparacomerce.azurewebsites.net/?page_id=7&add-to-cart=75&quantity='.$Total.'">Pagar 100%</a>';
echo '<br>';
echo '<a class="checkout-button button alt wc-forward" href="https://pruebaparacomerce.azurewebsites.net/?page_id=7&add-to-cart=74&quantity='.$Total.'">Pagar 50%</a>';
echo '<br>';
echo '<a class="checkout-button button alt wc-forward" href="https://pruebaparacomerce.azurewebsites.net/?page_id=7&add-to-cart=73&quantity='.$Total.'">Pagar 20%</a>';


}
?>