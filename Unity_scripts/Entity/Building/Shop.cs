using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Building
{
 



    public void Start()
    {

    }

    public override void Load_params()
    {
        E_id = 0;
        E_name = "";
        Id_i1 = 2;
        time = 3;
        E_hp = 50;
        E_maxhp = 50;
        E_attack = 0;
        E_range = 10;
        E_type = EnityType.Building;
        E_folder = "Entity/Buildings/Shop";
        B_type = E_Build_type.shop;
    }



    public override GameObject Get_new_object(Vector3 poz)
    {
        Load_params();
        return Get_Instance<Factoy>(poz);
    }



    public override async void Add_class_attributes(GameObject temp)
    {
        //miejsce an interfacje etc
    }


    public override GameObject Get_new_objectSQL(object dataa, object datab)
    {
         
        Load_params();
        B_data_player_building = (Data_player_building)dataa;
        B_data_building = (Data_building)datab;

        E_name = B_data_building.Name;
        E_id = B_data_player_building.Id;
        E_model_Id = B_data_building.Id_model;
         string[] v = B_data_player_building.Location.Split(',');
         Vector3 newpoz = new Vector3(int.Parse(v[0]), int.Parse(v[1]), int.Parse(v[2]));
      
        return Get_Instance<Shop>(newpoz);
    }




}
