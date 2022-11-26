using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SSActionEventType : int { Started, Competeted }

public interface ISSActionCallback
{
    void SSActionEvent(SSAction source, 
    SSActionEventType events = SSActionEventType.Competeted,
    int intParam = 0, string strParam = null, Object objectParam = null);
}

public class SSAction : ScriptableObject
{
    public bool enable = true;
    public bool destory = false;
    public GameObject gameobject{get;set;}
    public Transform transform{get;set;}
    public ISSActionCallback callback{get;set;}
    // Start is called before the first frame update
    protected SSAction(){}
    public virtual void Start()
    {
        throw new System.NotImplementedException();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        throw new System.NotImplementedException();
    }
    public virtual void FixedUpdate()
    {
        throw new System.NotImplementedException();
    }
}
