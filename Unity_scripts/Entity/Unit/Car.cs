using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Unit
{

    public Data_car data_car;
    public Data_player_car data_player_car;
    public E_acctions e_Acctions;
    public override GameObject Get_new_object(Vector3 poz)
    {
        Load_params();
        return Get_Instance<Car>(poz);
    }

    public void Start()
    {
     
    }

    public override void Load_params()
    {
        E_id = 0;
        E_name = "Car";
        E_hp = 40;
        E_maxhp = 40;
        E_attack = 0;
        E_range = 10;
        E_type = EnityType.Unit;
        E_folder = "Entity/Units/Car";
        U_speed = 33;
        U_type = Unit_type.vechicle;
    }
   



    public override GameObject Get_new_objectSQL(object dataa,object datab)
    {
        Load_params();
      ///  data = (Data_Car)dataa;
      //  this.E_name = data.name;
     //   this.U_speed = data.speed;
      //  this.E_id = data.id;
        return Get_Instance<Car>(new Vector3(0,0,0));
    }

    public override void Add_class_attributes(GameObject temp)
    {

    }

    
}
