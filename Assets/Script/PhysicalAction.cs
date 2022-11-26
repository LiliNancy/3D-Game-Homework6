using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalAction : SSAction
{
    // Start is called before the first frame update
    public float speed;
    Vector3 rec;
    static DiskFactory fc;
    public static PhysicalAction GetSSAction(float speed){
        PhysicalAction action = ScriptableObject.CreateInstance<PhysicalAction>();
        action.speed = speed;
        return action;
    }
    public override void Start()
    {
        fc = Singleton<DiskFactory>.Instance;
        gameobject.GetComponent<Rigidbody>().velocity =  new Vector3(0,0,-speed);
    }
    public override void FixedUpdate()
    {
        if(fc.statue==0||fc.statue==2){
            Rigidbody rigidbody = transform.GetComponent<Rigidbody>();
            rec=rigidbody.velocity;
            rigidbody.velocity = Vector3.zero;
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
        else if(fc.statue==1&&gameobject.GetComponent<Rigidbody>().velocity==Vector3.zero){
            Rigidbody rigidbody = transform.GetComponent<Rigidbody>();
            rigidbody.velocity = rec;
            rigidbody.constraints = RigidbodyConstraints.None;
        }
        if(this.transform.position.y<-7){
            fc.FreeDisk(this.transform.gameObject);
            this.destory = true;
            this.callback.SSActionEvent(this);
        }
    }
}
