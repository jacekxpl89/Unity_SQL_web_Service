using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Gui_building_interface : MonoBehaviour
{

    public Sprite G_img;
    public TextMeshProUGUI G_Name;
    public Gui_item G_item1;
    public Button G_create;
    public Button G_magazin;
    public Button G_deliever;
    public Button G_exit;
    public TextMeshProUGUI G_time;
   public void Start()
    {
        
        G_img = transform.GetChild(1).GetComponent<Sprite>();
        G_Name = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        G_item1 = transform.GetChild(4).GetComponent<Gui_item>();
        G_time = transform.GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>();
        G_create = transform.GetChild(6).GetComponent<Button>();
        G_magazin = transform.GetChild(7).GetComponent<Button>();
        G_deliever = transform.GetChild(8).GetComponent<Button>();
        G_exit = transform.GetChild(9).GetComponent<Button>();


        G_create.onClick.AddListener(() => B_create());
        G_magazin.onClick.AddListener(() => B_Load_Items());
        G_deliever.onClick.AddListener(() => B_deliever());
        G_exit.onClick.AddListener(() => B_exit());
    }


    Building building;
    public async void Load_new_data(Building building)
    {
        gameObject.SetActive(true);

        this.building = building;
        Data_player_building data_player_building = building.B_data_player_building;
        Data_building data_building = await SQL_Manager.Select<Data_building>("Building", data_player_building.Id_building);

        G_Name.text = data_building.Name;
        G_time.text = "Time: "+building.time.ToString()+" Sec";
        G_item1.Refresh(building.Id_i1);
    }
    public void B_exit()
    {
       
        gameObject.SetActive(false);
    }
    public void B_create()
    {
      
        A_load_bar bar = new A_load_bar(building.gameObject, building.time);
        DeliveredProducts dp = new DeliveredProducts(building.transform.GetChild(0).gameObject, 1);
        A_create_new_item item = new A_create_new_item(building.B_data_player_building, building.Id_i1);
        building.Add_action(bar);
        building.Add_action(item);
        building.Add_action(dp);
        building.Start_actions(); 
    }
    public void B_deliever()
    {
        Gui_main.Close_other_windows(Gui_main.gui_deliever.gameObject);
        Gui_main.gui_deliever.Load_data();


    }
    public void B_Load_Items()
    {
        Gui_main.gui_item_panel.Load_Company_products(building.B_data_player_building.Id_list);
    }
 
}
