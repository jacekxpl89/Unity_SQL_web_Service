using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird :Animals
{

    public override void Load_params()
    {
        throw new System.NotImplementedException();
    }
    public override void Add_class_attributes(GameObject temp)
    {

    }

    public override GameObject Get_new_object(Vector3 poz)
    {
        Start();
        return Get_Instance<Bird>(poz);
    }

   

    private void Start()
    {
        E_id = 0;
        E_name = "Bird";
        E_hp = 12;
        E_maxhp = 12;
        E_attack = 3;
        E_range = 15;
        E_type = EnityType.Monster;
        E_folder = "Entity/Animals/Bird";
    }

    public override GameObject Get_new_objectSQL(object dataa, object datab)
    {
        throw new System.NotImplementedException();
    }
}
