<?php




 class Player_car implements Sql_interface
 {
    private $name="player_car";
    public $Id;
    public $Data;
      public function __construct($Id,$Data)
        {
          $this->Id = $Id;
          $this->Data =$Data;
        }
        public function Select()
        {
            $request;
         if( $this->Id!="null")
         {
            $request = "SELECT * FROM ".$this->name." WHERE Id=".$this->Id;
         }
         else
         {
            $request = "SELECT * FROM ".$this->name;
         }
         $post_arr = array();
         $posts_arr['content']= array();
         $result = Query::run($request);
         while($row = $result->fetch(PDO::FETCH_ASSOC))
         {
        $post_item = array(
            'Id'=>$row['Id'],
            'Id_player_building'=>$row['Id_player_building'],
            'Id_car'=>$row['Id_car'],
        );
        array_push($posts_arr['content'],$post_item);
         } 
         return $posts_arr;
        }
        public function Update()
        {
            $request = "UPDATE ".$this->name." SET ,Id_player_building=".$this->Data['Id_player_building'].
            ",Id_car=".$this->Data['Id_car'].
            " WHERE Id=".$this->Id;
            return Query::run($request);
        }
        public function Insert()
        {
            $value = " VALUES (".$this->Data['Id_player_building'].","
            .$this->Data['Id_car'].")";
           $request ="INSERT INTO ".$this->name."(Id_player_building,Id_car)".$value;
            return Query::run($request);
        }
        public function Delete()
        {
            $request = "DELETE FROM ".$this->name." WHERE Id = ".$this->Id;
            return Query::run($request);
        }
       
 }
?>