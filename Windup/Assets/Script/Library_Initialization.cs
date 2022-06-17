using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Library_Initialization : MonoBehaviour
{
    public static List<passive_action> generalPassiveList = new List<passive_action>();
    public static List<equipment> generalEquipmentList = new List<equipment>();


    // Start is called before the first frame update
    void Start()
    {
        //keep library active for info fetching
        DontDestroyOnLoad(this.gameObject);

        GeneratePassiveActions();
        GenerateEquipment();

        //load next scene
        SceneManager.LoadScene(1);
    }

    //used to produce the equipment list used by all Batler agents.
    public void GenerateEquipment()
    {
        generalEquipmentList.Add(new equipment("Debug Talko key",0,generalPassiveList[0],new combat_action(),new combat_action(), new combat_action()));
        generalEquipmentList.Add(new equipment("Guardian's key", 0, generalPassiveList[0], new combat_charge(1, "Windup"), new combat_charge(1, "Windup"), new combat_charge(1, "Windup")));
        generalEquipmentList.Add(new equipment("Guardian's sword", 1, generalPassiveList[0], new combat_clash (1,9, "Risky strike"), new combat_clash(3, 5, "Basic strike"), new combat_clashDefend(2,3,1,3,"Deflect")));
        generalEquipmentList.Add(new equipment("Guardian's shield", 2, generalPassiveList[0], new combat_defend (2,3, "Block"), new combat_defend(2, 3, "Block"), new combat_defend(1, 6, "Risky block")));

    }

    //used to produce the equipment list used by all Batler agents.
    public void GeneratePassiveActions()
    {
        generalPassiveList.Add(new passive_debugTest());
    }

}
