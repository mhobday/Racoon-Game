using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> windows;
    public List<GameObject> doors; 
    void Start()
    {
        windows = new List<GameObject>(GameObject.FindGameObjectsWithTag("Window"));
        doors = new List<GameObject>(GameObject.FindGameObjectsWithTag("Door"));
        int totalDollars = SaveLoad.currentData.totalDollars;

        if(totalDollars > 100){
            foreach(GameObject window in windows)
            {
                WindowScript w = window.GetComponent(typeof(WindowScript)) as WindowScript;
                w.close();
            }
        }

        if(totalDollars > 300){    
            foreach(GameObject door in doors)
            {
                DoorScript d = door.GetComponent(typeof(DoorScript)) as DoorScript;
                d.locked = true;
            }
        }    
            

    }
}
