using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Networking;


public class SQL_Load : MonoBehaviour
{


  


  
  
}

public interface Load_SQL_Data
{
    GameObject Get_new_objectSQL(object sqldata);
}

[System.Serializable]
public class Sql_list<T>
{
    public List<T> content = new List<T>();
}
[System.Serializable]
public class SQL_Data
{

}

[System.Serializable]

public class Data_deliver : SQL_Data
{
    public int Id;
    public int Id_b1;
    public int Id_b2;
    public int Id_list;
    public string Date;
   
}
[System.Serializable]
public class Data_building : SQL_Data
{
    public int Id;
    public string Name;
    public int Cost;
    public int Id_type;
    public int Id_model;
}
[System.Serializable]
public class Data_player_building : SQL_Data
{
    public int Id;
    public int Id_building;
    public int Id_player;
    public string Location;
    public int Id_list;
}
[System.Serializable]
public class Data_player_car : SQL_Data
{
    public int Id;
    public int Id_player_building;
    public int Id_car;
}
[System.Serializable]
public class Data_car : SQL_Data
{
    public int Id;
    public string Name;
    public int Speed;
}
[System.Serializable]
public class Data_player : SQL_Data
{
    public int Id;
    public string Name;
}
[System.Serializable]
public class Data_item : SQL_Data
{
    public int Id;
    public string Name;
    public int Cost;
    public int Time;
}
[System.Serializable]
public class Data_item_stack : SQL_Data
{
    public int Id;
    public int Id_list;
    public int Id_item;
    public int Amount;
}
[System.Serializable]
public class Data_item_list : SQL_Data
{
    public int Id;
    public string Name;
}
