using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
public class Gui_select_building : MonoBehaviour
{
    public GameObject Content;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public List<Data_building> Data = new List<Data_building>();
    public void Start()
    {
        Content = transform.GetChild(1).GetChild(0).GetChild(0).gameObject;
        button1 = transform.GetChild(2).GetChild(0).GetComponent<Button>();
        button2 = transform.GetChild(2).GetChild(1).GetComponent<Button>();
        button3 = transform.GetChild(2).GetChild(2).GetComponent<Button>();
        button4 = transform.GetChild(2).GetChild(3).GetComponent<Button>();

        button1.onClick.AddListener(() => Load_Content(E_Build_type.house));
        button2.onClick.AddListener(() => Load_Content(E_Build_type.shop));
        button3.onClick.AddListener(() => Load_Content(E_Build_type.factory));
        button4.onClick.AddListener(() => Load_Content(E_Build_type.farm));
    }


    public void Load_building(Gui_building_icon icon)
    {
        GameObject temp = null;
        Data_player_building data = new Data_player_building() { Id = 0, Id_building = 0, Id_list = 0, Id_player = 0, Location ="0,0,0" };
        if (icon.Data.Id_type == 0)
        {
            temp= new Shop().Get_new_objectSQL(data, icon.Data);
        }
        if (icon.Data.Id_type == 1)
        {
            temp= new Factoy().Get_new_objectSQL(data, icon.Data);
        }
        if (icon.Data.Id_type == 2)
        {
            temp= new House().Get_new_objectSQL(data, icon.Data);
        }
        if (icon.Data.Id_type == 3)
        {
            temp = new Farm().Get_new_objectSQL(data, icon.Data);
        }
        if (temp!=null)
        {

            GameObject budynki = GameObject.Find("budynki");
            if(budynki is null)
            {
                budynki =new GameObject("budynki");
            }

            temp.transform.parent = budynki.transform; 
            Acction a1 = new A_place(temp);
            Acction a2 = new A_send_to_DB(temp, icon.Data);
            temp.GetComponent<Entity>().Add_action(a1);
            temp.GetComponent<Entity>().Add_action(a2);
            temp.GetComponent<Entity>().Start_actions();

        }
     
    }
    public async void Load_Content(E_Build_type type)
    {
        await Load_List(type);
        Refresh();
    }

    async Task Load_List(E_Build_type type)
    {
      List<Data_building> temp = await SQL_Manager.Select<Data_building>("Building");
        foreach(var d in temp)
        {
            if(d.Id_type==(int)type)
            {
                Data.Add(d);
            }
        }
    }
    public void Refresh()
    {
        for(int i=Content.transform.childCount-1;i>=0;i--)
        {
            Destroy(Content.transform.GetChild(i).gameObject);
        }
        foreach(var d in Data)
        {
            GameObject temp = new Gui_building_icon().Get_new_objectSQL(d,null);
            temp.transform.parent = Content.transform;
           temp.GetComponent<Gui_building_icon>().Button.onClick.AddListener(() => Load_building(temp.GetComponent<Gui_building_icon>()));
        }
        Data.Clear();

    }
}
