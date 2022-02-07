using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField] int id=0;
    // Start is called before the first frame update
    public int getID(){
        return id;
    }
}
