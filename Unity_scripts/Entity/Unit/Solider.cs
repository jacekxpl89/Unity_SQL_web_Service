using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solider : Unit
{
    public override GameObject Get_new_object(Vector3 poz)
    {
        Start();
        return Get_Instance<Solider>(poz);
    }

    public override void Load_params()
    {
        throw new System.NotImplementedException();
    }


  


   
    private void Start()
    {
        E_id = 1;
        E_name = "Solider";
        E_hp =40;
        E_maxhp = 40;
        E_attack = 8;
        E_range = 10;
        E_type = EnityType.Unit;
        E_folder = "Entity/Units/Solider";
        U_speed = 8;
        U_type = Unit_type.solider;
    }

    

    public override void Add_class_attributes(GameObject temp)
    {

    }

    public override GameObject Get_new_objectSQL(object sqldata, object sqldatab)
    {
        throw new System.NotImplementedException();
    }

    
}
