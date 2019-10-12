<?php
 class Item implements Sql_interface
 {
    private $name="item";
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
            'Name'=>$row['Name'],
            'Cost'=>$row['Cost'],
            'Time'=>$row['Time']
        );
        array_push($posts_arr['content'],$post_item);
         } 
         return $posts_arr;
        }
        public function Update()//
        {
            $request = "UPDATE ".$this->name." SET Name = '".$this->Data['Name']."',Price = ".$this->Data['Cost'].
            "WHERE Id=".$this->Id;
            return Query::run($request);
        }
        public function Insert()
        {
            $request = "INSERT INTO ".$this->name."(Name,Cost,Time)
            VALUES ('".$this->Data['Name']."',".$this->Data['Cost'].",".$this->Data['Time'].")";
            return Query::run($request);
        }
        public function Delete()
        {
            $request = "DELETE FROM ".$this->name." WHERE Id = ".$this->Id;
            return Query::run($request);
        }
       
 }
?>