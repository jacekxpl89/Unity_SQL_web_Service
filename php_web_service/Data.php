<?php
 header('Access-Control-Allow-Origin: *');
 header('Content-Type: application/json');

 include 'main/Query.php';
 include 'main/sql_interface.php';

include 'sql_data/Building.php';
include 'sql_data/Car.php';
include 'sql_data/Item_stack.php';
include 'sql_data/Item.php';
include 'sql_data/Item_list.php';
include 'sql_data/Player_building.php';
include 'sql_data/Player_car.php';
include 'sql_data/Player.php';
include 'sql_data/Empty_.php';
include 'sql_data/Deliver.php';
include 'sql_data/Reset.php';

 $request_id=$_POST['Request'];//rodzaj zapytania
 $row_id=$_POST['Id'];//id rekordu
 $table=$_POST['Table'];//nazwa tabeli
 $data=$_POST['Data']; //json z zawartoscią do operacji insert


 $object= Set_Object($table,$row_id,json_decode($data,true)); //tworzenie konkretenj klasy ,  line 47


 if($request_id=="Select") //wszystkie klasy dziedziczą interface "SQL_interface" który zawiera metody Select,Insert,Update,Delete
 {
  echo(json_encode($object->Select(), JSON_PRETTY_PRINT));
 }
 if($request_id=="Update")
 {
     $object->Update();
 }
 if($request_id=="Insert")
 {
     $object->Insert(); 
 }
 if($request_id=="Delete")
 {
   $object->Delete();
 }

 function Set_Object($Table,$Id,$Data)
 {
   if($Table=="Building")
   {
    return new Building($Id,$Data);
   }
   if($Table=="Car")
   {
      return new Car($Id,$Data);
   }
   if($Table=="Item")
   {
      return new Item($Id,$Data);
   }
   if($Table=="Item_stack")
   {
      return new Item_stack($Id,$Data);
   }
   if($Table=="Item_list")
   {
      return new Item_list($Id,$Data);
   }
   if($Table=="Player")
   {
      return new Player($Id,$Data);
   }
   if($Table=="Player_car")
   {
      return new Player_car($Id,$Data);
   }
   if($Table=="Player_building")
   {
      return new Player_building($Id,$Data);
   }
   if($Table=="Deliver")
   {
      return new Deliver($Id,$Data);
   }
   if($Table=="Reset")
   {
      return new Reset($Id,$Data);
   }
   return new Empty_($Id,$Data);
 }   
   
    
?>