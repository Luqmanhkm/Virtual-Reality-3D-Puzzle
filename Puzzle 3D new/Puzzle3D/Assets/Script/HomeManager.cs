using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HomeManager : MonoBehaviour
{
    [SerializeField] Button playBtn = null;
    // [SerializeField] Button exitBtn = null;
    // Start is called before the first frame update
    void Start()
    {
        playBtn.onClick.AddListener(()=>moveToGame(KeyString.SCENE_PUZZLE));
        // exitBtn.onClick.AddListener(()=>Application.Quit());
    }

    private void moveToGame(string _sceneName){
        SceneManager.LoadScene(_sceneName);
    }
}
