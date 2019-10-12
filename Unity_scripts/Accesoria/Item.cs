using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int id;
    public string name;
    public int price;
    public int weght;







    public void Set_Params(Item i)
    {
        this.id = i.id;
        this.name = i.name;
        this.price = i.price;
        this.weght = i.weght;
    }




}
