using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryManager : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(()=>moveToGame(KeyString.SCENE_PUZZLE));
        // exitBtn.onClick.AddListener(()=>Application.Quit());
    }

    private void moveToGame(string _sceneName){
        SceneManager.LoadScene(_sceneName);
    }
}
