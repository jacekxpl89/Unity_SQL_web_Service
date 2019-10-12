using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Main : MonoBehaviour
{
    public static Building_manager Building_man;
    public static Mouse_Manager Mouse_man;
    public static Animals_manager Animals_man;
    public static Unit_manager Unit_man;
    public static SQL_Manager sql_manager;
    public static List<GameObject> Objects = new List<GameObject>();
    
    async void Start()
    {

        Building_man = new Building_manager();



  
        Mouse_man = this.GetComponent<Mouse_Manager>();

          Building_man.Load(new GameObject("budynki"));

        GameObject car = new Car().Get_new_object(new Vector3(0, 0, 0));
       

     

      



    }


    

    /* private void Update()
     {
         if(Input.GetKeyDown(KeyCode.R))
         {
             foreach(var obj in Objects)
             {
                 if(obj.GetComponent<Entity>().E_type == EnityType.Building)
                 {
                     obj.GetComponent<Company>().C_Name = "biedra" + Random.Range(0, 100).ToString();
                     obj.GetComponent<Entity>().Refresh(obj.GetComponent<Company>());
                 }
             }
         }
     }*/
}
