<?php

include 'main/Database.php';
class Query extends Database {

public static function run($sql) {
return parent::getInstance()->getConn()->query($sql);
}
}

?>