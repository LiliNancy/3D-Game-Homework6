using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToAction : SSAction
{
    public int speed;
    static DiskFactory fc;
    private MoveToAction(){}
    public static MoveToAction GetSSAction(int speed){
        MoveToAction action = ScriptableObject.CreateInstance<MoveToAction>();
        action.speed = speed;
        return action;
    }
    // Start is called before the first frame update
    public override void Start()
    {
        fc = Singleton<DiskFactory>.Instance;
        this.transform.gameObject.GetComponent<Rigidbody>().isKinematic=true;
    }

    // Update is called once per frame
    public override void Update()
    {
        //this.transform.position = Vector3.MoveTowards(this.transform.position,target,speed*Time.deltaTime);
        if(fc.statue==1)transform.Translate(new Vector3(0,-1,0)*speed*Time.deltaTime);
        if(this.transform.position.y<-7){
            fc.FreeDisk(this.transform.gameObject);
            this.destory = true;
            this.callback.SSActionEvent(this);
        }
    }
    public override void FixedUpdate(){

    }
}    
