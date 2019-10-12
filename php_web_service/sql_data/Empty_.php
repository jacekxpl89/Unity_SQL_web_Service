<?php




 class Empty_ implements Sql_interface
 {
    private $name="empty";
    public $Id;
    public $Data;
      public function __construct($Id,$Data)
        {
          $this->Id = $Id;
          $this->Data =$Data;
        }
        public function Select()
        {
            echo('[]');
        }
        public function Update()//
        {
            echo('empty');
        }
        public function Insert()
        {
            echo('empty');
        }
        public function Delete()
        {
          echo('empty');
        }
       
 }
?>