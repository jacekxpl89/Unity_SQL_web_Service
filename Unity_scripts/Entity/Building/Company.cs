using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
public class Company : Building
{
   

    public async Task Refresh_Data()
    {
       // compontes = await SQL_Load.Load_DB<Data_Company>("Company",E_id);
       // Refresh_observable(compontes);
    }
    public async void Deleiver(GameObject car,GameObject companyb,int products)
    {
        await this.Refresh_Data();
        await  companyb.GetComponent<Company>().Refresh_Data();
        Car c = car.GetComponent<Car>();
        GameObject car_model = car.transform.GetChild(0).gameObject;
        Vector3 poz1 = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        Vector3 poz2 = new Vector3(companyb.transform.position.x, 0, companyb.transform.position.z);
       

        c.Add_action(new Walk(car_model, poz1, poz2));
       c.Add_action(new DeliveredProducts(companyb, products));
       c.Add_action(new Walk(car_model, poz2, poz1));


        c.Start_actions();


   
     
    }

    public void Start()
    {
       
      
    }

    public override void Load_params()
    {
            E_id = 3;
            E_name = "Company";
            E_hp = 50;
            E_maxhp = 50;
            E_attack = 0;
            E_range = 10;
            E_type = EnityType.Building;
            E_folder = "Entity/Buildings/Company";
            B_type = E_Build_type.house;
        }



        public override GameObject Get_new_object(Vector3 poz)
        {
            Load_params();
            return Get_Instance<Company>(poz);
        }
   
    

    public override async void Add_class_attributes(GameObject temp)
    {
        GameObject gui = Instantiate(Resources.Load<GameObject>("Gui/Gui_Company"), temp.transform);
        gui.transform.position = temp.transform.position + new Vector3(0,25, 0);

        Company company = temp.GetComponent<Company>();

      //  company.Add_observable(gui.GetComponent<Gui_building_icon>());

        float random = Random.rotation.y * 100;
        temp.transform.eulerAngles = new Vector3(0, random, 0);

        temp.gameObject.name = company.E_name;
        
        company.Refresh_Data();
    }


    public override GameObject Get_new_objectSQL(object sqldata,object data2)
    {
        Load_params();
        //compontes = (Data_Company)sqldata;
     //   E_name = compontes.name;
     //   E_id = compontes.id;
     //   E_attack = compontes.money;
      //  string[] v = compontes.location.Split(',');
        //Vector3 newpoz =  new Vector3(int.Parse(v[0]), int.Parse(v[1]), int.Parse(v[2]));
        return Get_Instance<Company>(new Vector3(0,0,0));
    }

    public static GameObject Find_Company(string name)
    {
        foreach(Transform t in GameObject.Find("budynki").transform)
        {
            if(t.name.Contains(name))
            {
                return t.gameObject;
            }
        }
        return null;
    }

}

