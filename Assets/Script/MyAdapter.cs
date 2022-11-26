using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActionAdapter{
    void HitDisk(GameObject obj ,int i);
}

public class MyAdapter : MonoBehaviour,IActionAdapter
{
    //MyController mcl;
    MoveActionController mac;
    PhysicalController phc;
    // Start is called before the first frame update
    void Start()
    {
        //mcl = SDirector.getInstance().currentScenceController as MyController;
        //mcl.ma=this;
        mac = gameObject.AddComponent<MoveActionController>() as MoveActionController;
        phc = gameObject.AddComponent<PhysicalController>() as PhysicalController;
    }
    // Update is called once per frame
    void Update()
    {   
    }
    public void HitDisk(GameObject obj ,int i){
        if(i==1){
            mac.Movetoground(obj);
        }
        else{
            phc.Physicalmove(obj);
        }
    }
}
