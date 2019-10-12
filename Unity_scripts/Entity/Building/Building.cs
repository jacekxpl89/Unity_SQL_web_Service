using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum E_Build_type
{
   house,shop,factory,farm
}
public abstract class Building : Entity
{
    
    public E_Build_type B_type;
    public Data_player_building B_data_player_building;
    public Data_building B_data_building;
    public int Id_i1;
    public float time;


    public void Start()
    {
       
    }

    public override void Give_attributes(GameObject temp)
    {
        GameObject build = Instantiate(temp.GetComponent<Building>().E_gameobject, temp.transform);
        build.layer = 9;
        build.AddComponent<Rigidbody>();
        build.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        build.GetComponent<Rigidbody>().useGravity = false;
        build.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
        build.transform.position = new Vector3(temp.transform.position.x, 0, temp.transform.position.z);

         GameObject gui_click = Resources.Load<GameObject>("Gui/Gui_building_click");
         Instantiate(gui_click, build.transform);
    }
    public override void Give_class_params(object e1, object e2)
    {
        Building b1 = (Building)e1;
        Building b2 = (Building)e2;
        b2.Id_i1 = b1.Id_i1;
        b2.time = b1.time;
        b2.B_type = b1.B_type;
        b2.B_data_player_building = b1.B_data_player_building; 
        b2.B_data_building = b1.B_data_building; 

    }


    public static GameObject Find(int id)
    {
        foreach(Transform t in GameObject.Find("budynki").transform)
        {
            if(t.GetComponent<Building>().B_data_player_building.Id == id)
            {
                return t.gameObject;
            }
        }
        return null;
    }
  

}
