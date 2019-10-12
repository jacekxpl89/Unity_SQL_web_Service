<?php




 class Reset implements Sql_interface
 {
    private $name="reset";
    public $Id;
    public $Data;
      public function __construct($Id,$Data)
        {
          $this->Id = $Id;
          $this->Data =$Data;
        }
        public function Select()
        {
        return null;
        }
        public function Update()
        {
            return null;
        }
        public function Insert()
        {
            return null;
        }
        public function Delete()
        {
          
          
             $request = "DELETE FROM  deliver";
             Query::run($request);
             $request = "DELETE FROM  item_stack";
             Query::run($request);
             $request = "DELETE FROM  player_building";
             Query::run($request);
             $request = "DELETE FROM  list";
             Query::run($request);
           
          
        }
       
 }
?>