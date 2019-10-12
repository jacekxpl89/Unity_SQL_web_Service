using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Gui_building_click:Observalbe
{

      public TextMeshProUGUI Name;
      public GameObject Panel;
      public Data_player_building Data;
      public Data_building Datab;
    public int Id;
    private async void Start()
    {
        Panel = transform.GetChild(0).gameObject;
        Name = transform.GetChild(1).GetComponent<TextMeshProUGUI>();


        Panel.GetComponent<Image>().color = new Color(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f),0.4f);
        Name =transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        Panel.GetComponent<Button>().onClick.AddListener(() =>Show_building_interface());
        Data = transform.parent.parent.GetComponent<Building>().B_data_player_building;
        Datab = transform.parent.parent.GetComponent<Building>().B_data_building;
        Set_position();
        Refresh(Datab);
    }



    public void Set_position()
    {

        if (transform.parent.GetComponent<BoxCollider>())
        {
            Vector3 parent_poz = transform.parent.transform.position;
            float y = transform.parent.GetComponent<BoxCollider>().bounds.size.y;
            transform.position = parent_poz + new Vector3(0, y * 1.5f, 0);
        }

    }
    public override async void Refresh(object obj)
    {
        Data_building d1 = (Data_building)obj;
        Name.text = d1.Name;
    }

    private void FixedUpdate()  
    {
        transform.rotation = Camera.main.transform.rotation;
    }

   public async void Show_building_interface()
    {
        Building b = transform.parent.transform.parent.GetComponent<Building>();
        Gui_main.Close_other_windows(Gui_main.gui_Building_Interface.gameObject);
        Gui_main.gui_Building_Interface.Load_new_data(b);
    }
}
