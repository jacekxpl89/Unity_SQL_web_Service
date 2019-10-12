using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gui_main : MonoBehaviour
{


    public static Gui_items_panel gui_item_panel;
    public static Gui_deleiver gui_deliever;
    public static Gui_select_building gui_select_building;
    public static Gui_building_interface gui_Building_Interface;
    public static Gui_menu gui_menu;
    private void Awake()
    {
        if(!GameObject.Find("GUI")) //singleton
        {
            GameObject gui = new GameObject("GUI");
            gui.AddComponent<Canvas>();
            gui.AddComponent<Gui_main>();
            gui.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            gui.AddComponent<GraphicRaycaster>();
            gui.AddComponent<CanvasScaler>();
            Destroy(this);
        }
    }


    public void Start()
    {
        Set_child();
       
    }
    public static void Close_other_windows(GameObject g)//zamyka wszystkie okna procz podanego w argumencie
    {
        foreach(Transform t in GameObject.Find("GUI").transform)
        {
            if(t!=g && t.name != "menu(Clone)")
            {
                t.gameObject.SetActive(false);
            }
        }
        g.SetActive(true);
    }
    
    public void Set_child()//wczytuje inne interface'y
    {
      
       
         GameObject item_panel = Instantiate(Resources.Load<GameObject>("Gui/ItemsPanel"), this.transform);
         GameObject deliever = Instantiate(Resources.Load<GameObject>("Gui/Deliever"), this.transform);
         GameObject select_building = Instantiate(Resources.Load<GameObject>("Gui/Gui_select_building"));
         GameObject building_interface = Instantiate(Resources.Load<GameObject>("Gui/Building_interface"));
         GameObject menu = Instantiate(Resources.Load<GameObject>("Gui/menu"));
         select_building.transform.parent = this.transform;
         building_interface.transform.parent = this.transform;
         menu.transform.parent = this.transform;

        gui_menu = menu.GetComponent<Gui_menu>();
        gui_item_panel = item_panel.GetComponent<Gui_items_panel>();
        gui_deliever = deliever.GetComponent<Gui_deleiver>();
        gui_select_building = select_building.GetComponent<Gui_select_building>();
        gui_Building_Interface = building_interface.GetComponent<Gui_building_interface>();

        item_panel.gameObject.SetActive(false);
        deliever.gameObject.SetActive(false);
        gui_Building_Interface.gameObject.SetActive(false);
    }
}
