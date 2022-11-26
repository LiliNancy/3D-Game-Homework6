using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveActionController : ActionManager
{
    public SSAction MovetoGround;
    static DiskFactory fc;
    protected new void Start()
    {
        fc = Singleton<DiskFactory>.Instance;
    }
    public void Movetoground(GameObject b){
        MovetoGround = MoveToAction.GetSSAction(b.GetComponent<DickAction>().speed);
        this.RunAction(b,MovetoGround,this);
    }
    protected new void Update()
    {
        base.Update();
    }
    protected new void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
