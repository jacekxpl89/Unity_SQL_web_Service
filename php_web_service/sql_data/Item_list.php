<?php




 class Item_list implements Sql_interface
 {
    private $name="list";
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
            $post_arr = array();
            $posts_arr['content']= array();
         if( $this->Id!="null")
         {
            $request = "SELECT * FROM Item_stack WHERE Id_list = ".$this->Id;
            $result = Query::run($request);
           
            while($row = $result->fetch(PDO::FETCH_ASSOC))
            {
               $post_item = array(
                   'Id'=>$row['Id'],
                   'Id_list'=>$row['Id_list'],
                   'Id_item'=>$row['Id_item'],
                   'Amount'=>$row['Amount'],
           );
           array_push($posts_arr['content'],$post_item);
         }
     
         } 
         return $posts_arr;
        }
        public function Update()//
        {
            $request = "UPDATE ".$this->name." SET Name = '".$this->Data['Name']."'".
            " WHERE Id=".$this->Id;
            return Query::run($request);
        }
        public function Insert()
        {
            $request = "INSERT INTO ".$this->name."(Name)
            VALUES ('".$this->Data['Name']."')";
            Query::run($request);
            $request ="Select Id From list WHERE Name = '".$this->Data['Name']."'";
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