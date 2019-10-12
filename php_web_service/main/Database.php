<?php
  
  class Database{
      private $host='localhost';
      private $db_name='rts';
      private $username='root';
      private $password='';
      private $_connection;
      private static $_instance; //The single instance
      private function __construct() {
		$this->conncect();
		}
    
    public function getConn() {
		return $this->_connection;
    }
    

    public static function getInstance() {
		if(!self::$_instance) { // If no instance then make one
			self::$_instance = new self();
		}
		return self::$_instance;
    }
    

    public function conncect()
     {
    try
    {
     $this->_connection = new PDO(
     'mysql:host='.$this->host.';'.
     'dbname='.$this->db_name,
      $this->username,$this->password);
     
 
     $this->_connection->setAttribute(PDO::ATTR_ERRMODE,PDO::ERRMODE_EXCEPTION);
    }catch(PDOException $e)
    {
        echo 'Conn eror'.$e->getMessage();
    }
     }

  }

?>
