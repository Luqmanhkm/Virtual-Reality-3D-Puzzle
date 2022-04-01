using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultBangun : MonoBehaviour
{
    public string [] resultsData;
    [SerializeField] private GameObject prefabContentResults;
    [SerializeField] private Transform containerContent;
    [SerializeField] private Button btnResults;
    [SerializeField] private Button btnKembali;
    [SerializeField] private GameObject panelResults;

    private void Awake(){
        btnResults.onClick.AddListener(onClickResultsButton);
        btnKembali.onClick.AddListener(onClickKembaliButton);
        panelResults.SetActive(false);
    }
    public void onClickKembaliButton(){
        panelResults.SetActive(false);
    }
    public void onClickResultsButton(){
        destroyChildOfContainerContent();
        StartCoroutine(loadResults());
    }
    IEnumerator loadResults()
    {
        WWW results = new WWW (WebRequestEndPoint.getURL(WebRequestEndPoint.GET_RESULT));
        yield return results;
        string resultsDataString = results.text;
        resultsData = resultsDataString.Split (';');
        Debug.Log(resultsData);
        for(int i=0;i<resultsData.Length-1;i++){
            string _no = (i+1).ToString();
            string _nama = GetValueData(resultsData[i], "username:");
            string _score = GetValueData(resultsData[i], "score:");

            var content = Instantiate(prefabContentResults, containerContent);
            var contentResult = content.GetComponent<ContentResult>();
            if(contentResult != null){

                contentResult.setContentResult(_no,_nama,_score);
            }
        }

        panelResults.SetActive(true);
    }

    private void destroyChildOfContainerContent(){
        int count = containerContent.transform.childCount;
        for(int i = count- 1; i>=0;i--){
            Destroy(containerContent.transform.GetChild(i).gameObject);
        }
    }
    string GetValueData(string data, string index) {
        string value = data.Substring (data.IndexOf(index)+index.Length);
        if(value.Contains("|")){
            value = value.Remove (value.IndexOf("|"));
        }
        return value;
    }
}
