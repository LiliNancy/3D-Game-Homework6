using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyController : MonoBehaviour,ISceneController,IUserAction
{
    public IActionAdapter ma;
    int Gamestatue = 3;
    float diskNum = (float)0.4;
    public GameObject cam;
    public int score=0;
    int mode;
    public DiskFactory fcc;
    void Awake(){
        SDirector director = SDirector.getInstance();
        director.currentScenceController = this;
        fcc = Singleton<DiskFactory>.Instance;
        ma=gameObject.AddComponent<MyAdapter>() as MyAdapter;
    }
    public void LoadResources(){
    }
    public int StartGame(){
        if(Gamestatue!=3) return Gamestatue;
        fcc.ClearDisk();
        Gamestatue = 1;
        fcc.statue = Gamestatue;
        score = 0;
        return Gamestatue;
    }
    public int GameOver(){
        Gamestatue = 2;
        fcc.statue = Gamestatue;
        return Gamestatue;
    }
    public int Pause(){
        if(Gamestatue!=2&&Gamestatue!=3){
            Gamestatue = 1-Gamestatue;
            fcc.statue = Gamestatue;
        }
        return Gamestatue;
    }
    public void HitDel(){
        if(Input.GetButtonDown("Fire1")){
            Vector3 mp = Input.mousePosition;
            Camera ca;
            if(cam!=null) ca = cam.GetComponent<Camera>();
            else ca = Camera.main;

            Ray ray = ca.ScreenPointToRay(Input.mousePosition);

            RaycastHit[] hits = Physics.RaycastAll(ray);

            foreach(RaycastHit hit in hits){
                hit.transform.gameObject.SetActive(false);
                fcc.FreeDisk(hit.transform.gameObject);
                score+=hit.transform.gameObject.GetComponent<DickAction>().score;
            }
        }
    }
    public int ScoreCount(){
        return score;
    }
    public void setmode(int m){
        mode = m;
    }

    public void PushDisk(){
        GameObject disk=fcc.getDisk();
        ma.HitDisk(disk,mode);
    }
    void Update()
    {
        if(Gamestatue==1) HitDel();
        diskNum+=Time.deltaTime;
        if(diskNum>=0.3&&Gamestatue==1){
            PushDisk();
            diskNum=0;
        }
        
    }
}
