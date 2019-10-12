using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gui_items_panel : MonoBehaviour
{
    public List<Item> Items;

    public GameObject Content;
    public Button Bclose;

    public void Start()
    {
        Content = transform.GetChild(0).GetChild(0).gameObject;
        Bclose = transform.GetChild(0).GetChild(1).GetComponent<Button>();

        Bclose.onClick.AddListener(() => ButtnActive(false));

     
        
        gameObject.SetActive(false);
    }


    public void ButtnActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public void Load_Items(string json)
    {
        
       
    }



      void Clear_Items()
    {
        if(Content)
        {
            int childs = Content.transform.childCount;
            for (int i = childs - 1; i >= 0; i--)
            {
                Destroy(Content.transform.GetChild(i).gameObject);
            }
        }
           
    }

    void Add_Item(Item item)
    {
        GameObject new_item = Resources.Load<GameObject>("GUI/Item");
        GameObject temp = Instantiate(new_item, Content.transform);
        temp.GetComponent<Gui_item>().Refresh(item);
    }

    public async void Load_Company_products(int List_Id)
    {
        gameObject.SetActive(true);
        Clear_Items();
        List<Data_item_stack> products = await SQL_Manager.Select<Data_item_stack>("Item_list", List_Id,true);
        foreach(var p in products)
        {
            GameObject item = new Gui_item().Get_new_objectSQL(p,null);
            item.transform.parent = Content.transform;
        }
        
    }


}
