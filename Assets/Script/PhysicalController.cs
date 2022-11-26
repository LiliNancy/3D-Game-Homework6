using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalController : ActionManager
{
     
    SSAction PhysicalMove;
    public void Start()
    {   
    }
    public void Physicalmove(GameObject b){
        PhysicalMove = PhysicalAction.GetSSAction(b.GetComponent<DickAction>().speed);
        this.RunAction(b,PhysicalMove,this);
    }
    public void Update()
    {
    }
}
