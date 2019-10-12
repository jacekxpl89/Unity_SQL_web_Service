using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gui_Select_Product : MonoBehaviour
{




    public List<GameObject> List_from = new List<GameObject>();
    public List<GameObject> List_to = new List<GameObject>();
    public List<Data_item_stack> Output;

    public GameObject content_A;
    public GameObject content_B;
    public Button send;
    public Button exit;
    
    public async void Start()
    {
        content_A = this.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject;
        content_B = this.transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).gameObject;
        send = this.transform.GetChild(3).GetComponent<Button>();
        exit = this.transform.GetChild(4).GetComponent<Button>();
        send.onClick.AddListener(() => Send());
        exit.onClick.AddListener(() => { this.gameObject.SetActive(false); Refresh_Lists(); } );

        gameObject.SetActive(false);
    }

   public void Send()//odsyla liste do guideleiver
    {

        if (List_to.Count != 0 && List_to != null)
        {
            foreach (var p in List_to)
            {
                if(p.GetComponent<Gui_item>().data_item_stack != null)
                {
                    Output.Add(p.GetComponent<Gui_item>().data_item_stack);

                }
              
            }
        }
        gameObject.SetActive(false);
    }


    public async void New_Select(Data_player_building d1,List<Data_item_stack> output)
    {
        Refresh_Lists();
        this.Output = output;
        List<Data_item_stack> Data = await SQL_Manager.Select<Data_item_stack>("Item_list", d1.Id_list,true);
       
        foreach (var d in Data)
        {
            GameObject item = new Gui_item().Get_new_objectSQL(d,null);
            item.transform.parent = content_A.transform;
            item.GetComponent<Gui_item>().Button.onClick.AddListener(() => Select_Company(item));
            List_from.Add(item);
        } 

        
    }
    void Select_Company(GameObject temp)//przezuca przedmioty miedzy okienkami
    {
       if(List_from.Contains(temp))
        {
            List_from.Remove(temp);
            List_to.Add(temp);
            temp.transform.parent = content_B.transform;
        }
       else
        {
            List_to.Remove(temp);
            List_from.Add(temp);
            temp.transform.parent = content_A.transform;
        }
       
    }
    public void Refresh_Lists()
    {
        Output.Clear();
        int childs = content_A.transform.childCount;
        List_from.Clear();
        List_to.Clear();    
        for (int i = childs - 1; i >= 0; i--)
        {
            Destroy(content_A.transform.GetChild(i).gameObject);
        }
        childs = content_B.transform.childCount;
        for (int i = childs - 1; i >= 0; i--)
        {
            Destroy(content_B.transform.GetChild(i).gameObject);
        }
    }
  



}
