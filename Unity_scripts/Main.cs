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

          Building_man.Load(new GameObject("budynki")); //wczytuje budynki SQL

        GameObject car = new Car().Get_new_object(new Vector3(0, 0, 0)); //wczytuje autko
       

     

      



    }


    

}
