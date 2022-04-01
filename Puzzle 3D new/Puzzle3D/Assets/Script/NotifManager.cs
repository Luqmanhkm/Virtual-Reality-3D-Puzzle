using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifManager : MonoBehaviour
{
    public static NotifManager instance;
    public AudioClip[] clipAudio;
    List<AudioSource> Suara = new List<AudioSource>();
    public void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Suara.Clear();
        for(int i = 0; i < clipAudio.Length; i++)
        {
            Suara.Add(gameObject.AddComponent<AudioSource>());
            Suara[i].clip = clipAudio[i];
        }
    }

    public void panggilSuara(int i)
    {
        Suara[i].Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
