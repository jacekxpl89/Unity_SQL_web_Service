﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine.Networking;

public delegate void Sql_Acction(string json,GameObject output);
public delegate  void Sql_Acctionlist<T>(string json, List<T> output);
public class SQL_Manager : MonoBehaviour
{

    Sql_Acction acctionn;
    private void Awake()
    {
        if(!GameObject.Find("SQL_Manager"))
        {
            GameObject instance = new GameObject("SQL_Manager");
            instance.AddComponent<SQL_Manager>();
            Main.sql_manager = this;
        }
    }

    public static async Task Update<T>(string table,int id, T newData)
    {
        WWWForm form = new WWWForm();
        form.AddField("Request", "Update");
        form.AddField("Id", id);
        form.AddField("Table", table);
        form.AddField("Data", JsonUtility.ToJson(newData));
        using (WWW www = new WWW("http://localhost/rts_sql/Data.php", form))
        {
            while (www.isDone == false)
            {
                await Task.Delay(1000 / 30);//30 hertz
            }
         //  print(www.text);
        }

    }
    public static async Task<List<T>>Select<T>(string table)
    {
        WWWForm form = new WWWForm();
        form.AddField("Request", "Select");
        form.AddField("Id", "null");
        form.AddField("Table", table);
        form.AddField("Data", "null");
        using (WWW www =new WWW("http://localhost/rts_sql/Data.php", form))
        {
            //begin requenst:
          

            //await until it's done: 
            while (www.isDone == false)
            {
                await Task.Delay(1000 / 30);//30 hertz
            }
            try
            {
                Sql_list<T> comp = JsonUtility.FromJson<Sql_list<T>>(www.text);
                return comp.content;
            }
            catch
            {
                print(www.text+" "+table);
            }

            return new List<T>();
           
        }
    }
    public static async Task<List<T>> Select<T>(string table, int id,bool nul)
    {
        WWWForm form = new WWWForm();
        form.AddField("Request", "Select");
        form.AddField("Id", id);
        form.AddField("Table", table);
        form.AddField("Data", "null");
        using (WWW www = new WWW("http://localhost/rts_sql/Data.php", form))
        {
            while (www.isDone == false)
            {
                await Task.Delay(1000 / 30);
            }
            print(www.text);
            try
            {
                Sql_list<T> comp = JsonUtility.FromJson<Sql_list<T>>(www.text);
                return comp.content;
            }
            catch
            {
                return new List<T>();
            }
           

           
        }
    }
    public static async Task<T> Select<T>(string table,int id) where T : new()
    {
        WWWForm form = new WWWForm();
        form.AddField("Request", "Select");
        form.AddField("Id",id);
        form.AddField("Table", table);
        form.AddField("Data","null");
        using (WWW www = new WWW("http://localhost/rts_sql/Data.php", form))
        {
            //begin requenst:


            //await until it's done: 
            while (www.isDone == false)
            {
                await Task.Delay(1000 / 30);//30 hertz
            }
            try
            {
          
                Sql_list<T> comp = JsonUtility.FromJson<Sql_list<T>>(www.text);
                return comp.content[0];
            }
            catch
            {
               print(www.text);
            }
           
            return new T();

        }
    }
    public static async Task<string> Insert<T>(string table,T newData)
    {
        WWWForm form = new WWWForm();
        form.AddField("Request","Insert");
        form.AddField("Id",0);
        form.AddField("Table", table);
        form.AddField("Data",JsonUtility.ToJson(newData));
   
        using (WWW www = new WWW("http://localhost/rts_sql/Data.php", form))
        {
            while (www.isDone == false)
            {
                await Task.Delay(1000 / 30);//30 hertz
            }
         //   print(JsonUtility.ToJson(newData));
         //   print(www.text);
            return www.text;
        }
        
    }
    public static async Task Delete(string table)
    {
        WWWForm form = new WWWForm();
        form.AddField("Request", "Delete");
        form.AddField("Id", "null");
        form.AddField("Table", table);
        form.AddField("Data", "null");
        using (WWW www = new WWW("http://localhost/rts_sql/Data.php", form))
        {
            while (www.isDone == false)
            {
                await Task.Delay(1000 / 30);//30 hertz
            }
             print(www.text);
        }

    }

    public static async Task Delete<T>(string table, int id)
    {
        WWWForm form = new WWWForm();
        form.AddField("Request", "Delete");
        form.AddField("Id", id);
        form.AddField("Table", table);
        form.AddField("Data", "null");
        using (WWW www = new WWW("http://localhost/rts_sql/Data.php", form))
        {
            while (www.isDone == false)
            {
                await Task.Delay(1000 / 30);//30 hertz
            }
          print(www.text);
        }

    }


}