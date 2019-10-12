using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gui_menu : MonoBehaviour
{
    public  Button exit;
    public Button reset;
    public Button add;
    void Start()
    {
        exit.onClick.AddListener(() => Application.Quit());
        reset.onClick.AddListener(()=> Game_reset());
        add.onClick.AddListener(() => Gui_main.Close_other_windows(Gui_main.gui_select_building.gameObject));
    }
    public async void Game_reset()
    {
        await SQL_Manager.Delete("Reset");
        GameObject building = GameObject.Find("budynki");
        Destroy(building);
    }
   
    void Update()
    {
        
    }
}
