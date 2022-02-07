using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TentangManager : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(()=>moveToGame(KeyString.SCENE_TENTANG));
    }

    private void moveToGame(string _sceneName){
        SceneManager.LoadScene(_sceneName);
    }
}
