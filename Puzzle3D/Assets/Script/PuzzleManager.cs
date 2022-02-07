using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] GameObject popUpLose;
    [SerializeField] GameObject popUpWin;
    [SerializeField] GameObject popUpInsert;
    // [SerializeField] Button loseBtn;
    [SerializeField] TextMeshProUGUI targetToCompareText;
    private bool isGameOver;
    private int targetToCompare;
    public int correctCompareCount=0;
    [Header("Position")]
    [SerializeField] private List<GameObject> puzzle;
    
    private void Awake(){
        randomPuzzlePosition();
    }
    // Start is called before the first frame update
    void Start()
    {
        setActiveLose(false);
        setActiveWin(false);
        setActiveInsert(false);
        targetToCompare = GameObject.FindGameObjectsWithTag(KeyString.TAG_TARGET).Length;
        setVisualCompare();
    }

    // Update is called once per frame
    void Update()
    {
         if(TimerManager.instance.GetTime() <= 0 && !isGameOver){
             setActiveLose(true);
             setActiveInsert(true);
             isGameOver = true;
         }
    }
    private void randomPuzzlePosition(){
        //data yang akan diacak
        List<GameObject> tempPuzzle = puzzle;
        int tempPuzzleCount = tempPuzzle.Count;
        
        //simpan posisi object sebelum dihapus dari list
        List<Vector3> posPuzzle = new List<Vector3>();            
        for(int i=0; i<tempPuzzleCount;i++){
            posPuzzle.Add(new Vector3(tempPuzzle[i].transform.position.x,tempPuzzle[i].transform.position.y,tempPuzzle[i].transform.position.z));
        }    

        //puzzle list diperbarui (kosong)
        puzzle = new List<GameObject>();

        //proses mengacak data
        for(int i=0; i<tempPuzzleCount;i++){
            int randomIndex = Random.Range(0,tempPuzzle.Count);
            puzzle.Add(tempPuzzle[randomIndex]);
            tempPuzzle.Remove(tempPuzzle[randomIndex]);
        }

        //proses set new position
        for(int i=0; i < puzzle.Count ; i++){
            puzzle[i].transform.position = new Vector3(posPuzzle[i].x,puzzle[i].transform.position.y,posPuzzle[i].z); 
        }

    }
    private void setActiveLose(bool _value = false){
        popUpLose.SetActive(_value);
    }

    private void setActiveWin(bool _value = false){
        popUpWin.SetActive(_value);
    }
    private void setActiveInsert(bool _value = false){
        popUpInsert.SetActive(_value);
    }
    // private void moveToGame(string _sceneName){
    //     SceneManager.LoadScene(_sceneName);
    // }

    // fungsinya untuk menampilkan target score
    public void setVisualCompare(){
        targetToCompareText.text = correctCompareCount+"/"+targetToCompare;
    }

    // fungsinya untuk menampilkan score yang sudah selesai
    public void increaseCorrectCompareCount(){
        correctCompareCount++;
    }

    // fungsinya untuk ngecheck score apakah udah sesuai target
    public void checkWin(){
        if(correctCompareCount == targetToCompare){
            Debug.Log("Win");
            TimerManager.instance.PauseTime(true);
            setActiveWin(true);
            setActiveInsert(true);
        }
    }
}
