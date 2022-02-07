using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(()=>moveToGame(KeyString.SCENE_HOME));
    }

    private void moveToGame(string _sceneName){
        SceneManager.LoadScene(_sceneName);
    }
}
