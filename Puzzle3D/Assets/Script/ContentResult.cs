using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ContentResult : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtNo;
    [SerializeField] private TextMeshProUGUI txtName;
    [SerializeField] private TextMeshProUGUI txtTime;
    // Start is called before the first frame update
    public void setContentResult(string _no, string _name, string _time){
        txtNo.SetText(_no);
        txtName.SetText(_name);
        txtTime.SetText(_time);
    }
}
