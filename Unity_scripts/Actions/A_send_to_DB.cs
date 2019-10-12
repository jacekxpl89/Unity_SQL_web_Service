using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
public class A_send_to_DB : Acction
{

    public Animator animator;
    public Data_player_building data_pb;
    public  A_send_to_DB(GameObject go,object data) : base(go, data)
    {
        A_obj = go;
        B_obj = data;
       
       
    }
    async void Send_data()
    {
        Data_item_list data_list = new Data_item_list() { Name = "List#" + Random.Range(1000, 10000) };
        string new_id= await SQL_Manager.Insert<Data_item_list>("Item_list", data_list);
       
        Data_building b = (Data_building)B_obj;
        Vector3 pos = A_obj.transform.position;
        data_pb = new Data_player_building();
        data_pb.Id_building = b.Id;
        data_pb.Id_player = 1;
        data_pb.Id_list = int.Parse(new_id);
        data_pb.Location =Mathf.RoundToInt(pos.x).ToString() + ",0," + Mathf.RoundToInt(pos.z).ToString();

        string building_id = await SQL_Manager.Insert<Data_player_building>("Player_building", data_pb);
       
        A_obj.GetComponent<Building>().B_data_player_building = data_pb;
        A_obj.GetComponent<Building>().B_data_building = b;

        A_obj.GetComponent<Building>().B_data_player_building.Id = int.Parse(building_id);

    }
    public  override IEnumerator Start_acction()
    {

         Send_data();
        done = true;
        yield return null;
    }
   

}
