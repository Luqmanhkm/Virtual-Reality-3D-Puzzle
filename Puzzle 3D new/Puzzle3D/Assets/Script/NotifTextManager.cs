using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifTextManager : MonoBehaviour
{
    [SerializeField] private GameObject textBenar;
    [SerializeField] private GameObject textSalah;
    [SerializeField] private GameObject textCaraBermain;
    // Start is called before the first frame update
    void Start()
    {
        textBenar.SetActive(false);
        textSalah.SetActive(false);
        popUpTextCaraBermain();
    }

    // Update is called once per frame
    public void popUptextBenar()
    {
        textBenar.SetActive(true);
        StartCoroutine(textCoroutine());
    }

    public void popUptextSalah()
    {
        textSalah.SetActive(true);
        StartCoroutine(textCoroutine());
    }

    public void popUpTextCaraBermain()
    {
        textCaraBermain.SetActive(true);
        StartCoroutine(textCoroutine());
    }

    IEnumerator textCoroutine()
    {
        yield return new WaitForSeconds(3);
        textBenar.SetActive(false);
        textSalah.SetActive(false);
        textCaraBermain.SetActive(false);
    }
}
