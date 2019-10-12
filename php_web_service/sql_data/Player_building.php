<?php




 class Player_building implements Sql_interface
 {
    private $name="player_building";
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
            'Id_building'=>$row['Id_building'],
            'Id_player'=>$row['Id_player'],
            'Location'=>$row['Location'],
            'Id_list'=>$row['Id_list'],
        );
        array_push($posts_arr['content'],$post_item);
         } 
         return $posts_arr;
        }
        public function Update()
        {
            $request = "UPDATE ".$this->name." SET Location = '".$this->Data['Location']."',Cost=".$this->Data['Cost']
            .",Id_building=".$this->Data['Id_building'].",Id_player=".$this->Data['Id_player'].
            " WHERE Id=".$this->Id;
            return Query::run($request);
        }
        public function Insert()
        {
            $value = " VALUES (".$this->Data['Id_building'].","
            .$this->Data['Id_player'].",'".$this->Data['Location']."',".$this->Data['Id_list'].")";
           $request ="INSERT INTO ".$this->name."(Id_building,Id_player,Location,Id_list)".$value;
          Query::run($request);

           $request ="Select Id FROM player_building WHERE Location = '".$this->Data['Location']."'";
           $result = Query::run($request);
           while($row = $result->fetch(PDO::FETCH_ASSOC))
           {
                  echo $row['Id'];
           }
         
        }
        public function Delete()
        {
            $request = "DELETE FROM ".$this->name." WHERE Id = ".$this->Id;
            return Query::run($request);
        }
       
 }
?>