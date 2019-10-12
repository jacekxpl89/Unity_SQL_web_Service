using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Insert : Acction
{
    public Animator animator;
    public string table;
    public A_Insert(GameObject go, object data,string table) : base(go, data)
    {
        A_obj = go;
        B_obj = data;
        this.table = table;

    }

    public async void send()//
    {
        await SQL_Manager.Insert(JsonUtility.ToJson(B_obj), table);
    }
    public override IEnumerator Start_acction()
    {
        done = false;
        send();
        yield return new WaitForSeconds(0.2f);
        done = true;
    }

}
