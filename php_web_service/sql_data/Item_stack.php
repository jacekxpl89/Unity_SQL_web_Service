<?php
 class Item_stack implements Sql_interface
 {
    private $name="item_stack";
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
        
         $request="Select * FROM ".$this->name.
         " WHERE Id = ".$this->Id;

         $post_arr = array();
         $posts_arr['content']= array();
         $result = Query::run($request);
         while($row = $result->fetch(PDO::FETCH_ASSOC))
         {
        $post_item = array(
            'Id'=>$row['Id'],
            'Id_list'=>$row['Id_list'],
            'Id_item'=>$row['Id_item'],
            'Amount'=>$row['Amount']
        );
        array_push($posts_arr['content'],$post_item);
         } 
         return $posts_arr;
        }
        public function Update()
        {
            $request = "UPDATE ".$this->name." SET Id_list = ".$this->Data['Id_list'].
            ",Id_item=".$this->Data['Id_item'].",Amount =".$this->Data['Amount'].
             " WHERE Id = ".$this->Id;
           
            return Query::run($request);
        }
        public function Insert()
        {
            $value = " VALUES (".$this->Data['Id_list'].","
             .$this->Data['Id_item'].",".$this->Data['Amount'].")";
            $request ="INSERT INTO ".$this->name."(Id_list,Id_item,Amount)".$value;
           
            return Query::run($request);
        }
        public function Delete()
        {
            $request = "DELETE FROM ".$this->name." WHERE Id = ".$this->Id;
            return Query::run($request);
        }
       
 }
?>