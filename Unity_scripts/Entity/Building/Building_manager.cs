using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface I_Load_Managers
{
    GameObject Load_object_Sql(object ob1, object ob2);
     void Load(GameObject parent);
}

public class Building_manager : MonoBehaviour , I_Load_Managers
{
   
     public async void Load(GameObject parent)
    {
        List<Data_player_building> buildings = await SQL_Manager.Select<Data_player_building>("Player_building");
        foreach(var data_a in buildings)
        {

           Data_building data_b = await SQL_Manager.Select<Data_building>("Building", data_a.Id_building);
           GameObject temp = Load_object_Sql(data_a,data_b);
           temp.transform.parent = parent.transform;
        }
    }

    public GameObject Load_object_Sql(object ob1, object ob2)
    {
        Data_building datab = (Data_building)ob2;
        if (datab.Id_type == 0)
        {
            return new Shop().Get_new_objectSQL(ob1, ob2);
        }
        if (datab.Id_type == 1)
        {
            return new Factoy().Get_new_objectSQL(ob1, ob2);
        }
        if (datab.Id_type == 2)
        {
            return new House().Get_new_objectSQL(ob1, ob2);
        }
        if (datab.Id_type == 3)
        {
            return new Farm().Get_new_objectSQL(ob1, ob2);
        }
        return null;
    }
}
