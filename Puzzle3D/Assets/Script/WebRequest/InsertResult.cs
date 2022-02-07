using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InsertResult : MonoBehaviour
{
    public TMP_InputField InputUsername;
    public TimerManager TimerManager;
    public PuzzleManager PuzzleManager;
    public Button simpanBtn;
    int xScore = 10;
    int xTime = 50;
    // Start is called before the first frame update
    void Awake()
    {
        this.gameObject.SetActive(false);
        simpanBtn.onClick.AddListener(Simpan);
    }

    // Update is called once per frame
    void Simpan()
    { 
        if(InputUsername.text == ""|| InputUsername.text == null){

        }else{
            AddResult (InputUsername.text, TimerManager.totalTime, PuzzleManager.correctCompareCount);
            this.gameObject.SetActive(false);
        }
    }

    public void AddResult(string username, float time, int score){
        WWWForm form = new WWWForm ();
        form.AddField ("addUsername", username);
        //rules scoreMax = 100; 
        float _finalScore = (score*xScore) + (time/xTime);
        _finalScore = _finalScore >= 100?100:_finalScore;
        form.AddField ("addTime", time.ToString());
        form.AddField ("addScore", _finalScore.ToString());

        WWW www = new WWW(WebRequestEndPoint.getURL(WebRequestEndPoint.INSERT_RESULT), form);
    }
}
