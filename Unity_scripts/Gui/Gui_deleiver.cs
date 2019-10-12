using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.Networking;
using System;
public class Gui_deleiver : MonoBehaviour
{


    public TMP_Dropdown D_Company_A;
    public TMP_Dropdown D_Company_B;

    public Button D_B_send;
    public Button D_B_select_Products;
    public Button D_B_exit;
    public Button D_B_create;

    public TextMeshProUGUI D_T_costProducts;

    public Gui_Select_Product D_select_Product;


    public Data_player_building building1;
    public Data_player_building building2;

     public List<Data_item_stack> products;
    public async void Start()
    {
        D_Company_A = transform.GetChild(1).transform.GetChild(0).GetComponent<TMP_Dropdown>();
        D_Company_B = transform.GetChild(1).transform.GetChild(1).GetComponent<TMP_Dropdown>();


        D_B_select_Products = transform.GetChild(2).transform.GetChild(0).GetComponent<Button>();
        D_T_costProducts = transform.GetChild(2).transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        D_B_send= transform.GetChild(3).GetComponent<Button>();
        D_B_exit = transform.GetChild(4).GetComponent<Button>();


      
        D_B_send.onClick.AddListener(() => Send());
        D_B_select_Products.onClick.AddListener(() => Select_Products());
        D_B_exit.onClick.AddListener(() => Exit());

        GameObject select = Instantiate(Resources.Load<GameObject>("Gui/Select"), this.transform);
        D_select_Product = select.GetComponent<Gui_Select_Product>();
        Load_data();
    }
   
    public async Task  Send() 
    {
     
         if (building1.Id== building2.Id)
         {
             return;
         }
        gameObject.SetActive(false); //wylacza interface z widoku

        GameObject car = GameObject.Find("Car"); //wczytuje samochod


        print(building1.Location + " " + building2.Location);
         GameObject buildingA = Building.Find(building1.Id);
         GameObject buildingB = Building.Find(building2.Id);
      
        //tworze nowe zamowienie
        Data_item_list new_list = new Data_item_list() { Name = "Order#" + UnityEngine.Random.Range(0, 100000) };
         string list_id = await SQL_Manager.Insert<Data_item_list>("Item_list", new_list);

         Data_deliver order = new Data_deliver();
         order.Id_b1 = building1.Id;
         order.Id_b2 = building2.Id;
         order.Date = DateTime.Now.ToString("MM/dd/yyyy H:mm");
         order.Id_list = int.Parse(list_id);
         await SQL_Manager.Insert<Data_deliver>("Deliver", order);

         //przesylam produkty
      
         foreach (var item in products)
         {
        
             item.Id_list = order.Id_list; //tworze historie zamowieniea
             await SQL_Manager.Insert<Data_item_stack>("Item_stack", item);
        
                
             item.Id_list = building2.Id_list; //zmiana na liste w drugim magazynie
             await SQL_Manager.Update<Data_item_stack>("Item_stack", item.Id,item);


         }
        new A_Deliver(car, buildingA, buildingB, products.Count); //akcja 
    }
    public async void Load_data()//ladowanie nazw firm
     {
       
         List<Data_player_building> C_data = await SQL_Manager.Select<Data_player_building>("Player_building");
         List<Data_building> B_data = await SQL_Manager.Select<Data_building>("Building");
         D_Company_A.ClearOptions();
         D_Company_B.ClearOptions();
         List<TMP_Dropdown.OptionData> companys = new List<TMP_Dropdown.OptionData>();



         foreach(var p in C_data)
         {
            foreach(var b in B_data)
            {
                if(p.Id_building == b.Id)
                {
                    companys.Add(new TMP_Dropdown.OptionData(p.Id.ToString() + "# "+b.Name));
                }
            }
            
         }
         D_Company_A.AddOptions(companys);
         D_Company_B.AddOptions(companys);
     }
   async Task Refresh_Company_data() 
    {
        //wczytywanie zawartosci wybranego budynku
        string p1 = D_Company_A.options[D_Company_A.value].text;
        string p2 = D_Company_B.options[D_Company_B.value].text;

        
        p1 =  p1.Substring(0,p1.LastIndexOf("#"));
        p2 =  p2.Substring(0,p2.LastIndexOf("#"));
      
        building1 = await SQL_Manager.Select<Data_player_building>("Player_building",int.Parse(p1));
        building2 = await SQL_Manager.Select<Data_player_building>("Player_building", int.Parse(p2));

    }
   
    void Exit()
    {
        gameObject.SetActive(false);
    }
  async  void Select_Products()
    {
        await Refresh_Company_data();
        if(building1.Id != building2.Id)
        {
            D_select_Product.New_Select(building1, products);
            D_select_Product.gameObject.SetActive(true);
        }
      
        
    }

}
