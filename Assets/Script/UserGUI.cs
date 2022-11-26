using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUserAction{
    int StartGame();
    int Pause();
    int GameOver();
    int ScoreCount();
    void setmode(int m);
}
public class UserGUI : MonoBehaviour
{
    private IUserAction action;
    int score = 0;
    float time = 30;
    GUIStyle style,bigstyle;
    string gameMessage = "";
    int statue=3;
    void Start()
    {
        action = SDirector.getInstance().currentScenceController as IUserAction;
        style = new GUIStyle();
        style.normal.textColor = Color.white;
        style.fontSize = 70;

        bigstyle = new GUIStyle();
        bigstyle.normal.textColor = Color.black;
        bigstyle.fontSize = 20;
    }
    void OnGUI(){
        GUI.Box(new Rect(10,10,120,140), "Menu");
        if(GUI.Button(new Rect(20,40,100,20), "运动模式")){
            if(statue==3){
                statue = action.StartGame();
                time = 30;
                score = 0;
                gameMessage = "";
                action.setmode(1);
            }
        }
        if(GUI.Button(new Rect(20,70,100,20), "物理模式")){
            if(statue==3){
                statue = action.StartGame();
                time = 30;
                score = 0;
                gameMessage = "";
                action.setmode(0);
            }
        }
        if(GUI.Button(new Rect(20,100,100,20), "暂停")){
            statue = action.Pause();
        }
        GUI.Label(new Rect(370, 200, 180, 200), gameMessage,style);
        GUI.Label(new Rect(Screen.width - 150,10,100,50), "Time: " + time, bigstyle);
        GUI.Label(new Rect(Screen.width - 150,30,100,50), "Score: " + score, bigstyle);
    }
    void Update()
    {
        score = action.ScoreCount();
        if(time<=0) {
            if(score>80) gameMessage="You Win!!!";
            else gameMessage="Game Over";
            statue = action.GameOver();
            time=0;
        }
        if(statue==1) time-=Time.deltaTime;
    }
}
