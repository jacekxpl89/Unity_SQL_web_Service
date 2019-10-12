<?php




 class Deliver implements Sql_interface
 {
    private $name="Deliver";
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
            'Id_b1'=>$row['Id_b1'],
            'Id_b2'=>$row['Id_b2'],
            'Id_list'=>$row['Id_list'],
            'Date'=>$row['Date']
        );
        array_push($posts_arr['content'],$post_item);
         } 
         return $posts_arr;
        }
        public function Update()
        {
         
            return Query::run($request);
        }
        public function Insert()
        {
            $request = "INSERT INTO ".$this->name."(Id_b1,Id_b2,Id_list,Date)
            VALUES (".$this->Data['Id_b1'].",".$this->Data['Id_b2'].",".
            $this->Data['Id_list'].",'".$this->Data['Date']."')";

            return Query::run($request);
        }
        public function Delete()
        {
            $request = "DELETE FROM ".$this->name." WHERE Id = ".$this->Id;
           
            return Query::run($request);
        }
       
 }
?>