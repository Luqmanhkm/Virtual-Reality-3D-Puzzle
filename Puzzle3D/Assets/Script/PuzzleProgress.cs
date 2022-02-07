using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleProgress : MonoBehaviour
{
    // [SerializeField] private GameObject dragObject;
    private GameObject dragObject;
    private Transform initTransform;

    // Vector = x , y , z
    [SerializeField] private int dragSpeed;
    private Vector3 initPosition;
    private Quaternion initRotation;
    private bool isArrived = false, isMouseUp = false, isThrown = false;
    private Vector3 screenPoint, mousePos;
    private Vector3 mousePreviousLocation;
    private Rigidbody rb;
    private float mouseRatioX, mouseRatioY;

    private Vector3 v3Offset;
    private Plane plane;
    private bool ObjectMouseDown = false;
    private GameObject linkedObject;
    int initSpeed;

    private bool isTrueChecked = false;
    // Start is called before the first frame update
    void Start()
    {
        initSpeed = dragSpeed;
        // menentukan posisi awal
        initPosition = transform.position;
        initRotation = transform.rotation;
        linkedObject = gameObject;
        rb = gameObject.GetComponent<Rigidbody>();
        Debug.Log("Start");
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        // untuk jalannya permainan
        if(!ObjectMouseDown){
            if(col.gameObject.tag == KeyString.TAG_TARGET){
                TargetManager idObj = this.GetComponent<TargetManager>();
                TargetManager idTarget = col.gameObject.GetComponent<TargetManager>();
                Debug.Log("idTarget: "+idTarget);
                // menghitung atau check ada berapa idObjecknya dan idTargetya
                if(idObj != null && idTarget != null){
                    // mencocokkan apakah idObj sesuai dengan idTargetnya
                    if(idObj.getID() == idTarget.getID()){
                    // kondisi benar

                    // pemberian posisi pada objet = mengambil posisi target
                    linkedObject.transform.position = idTarget.gameObject.transform.position;
                    NotifManager.instance.panggilSuara(0);
                    NotifTextManager notip = FindObjectOfType<NotifTextManager>();
                    notip.popUptextBenar();
                    PuzzleManager puzzle = FindObjectOfType<PuzzleManager>();
                    if(puzzle != null && !isTrueChecked){
                        isTrueChecked = true;
                        // untuk Objek puzzlenya
                        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                        puzzle.increaseCorrectCompareCount();
                        puzzle.setVisualCompare();
                        puzzle.checkWin();
                    }
                        Debug.Log("Benar");
                    }else{
                        NotifTextManager notip2 = FindObjectOfType<NotifTextManager>();
                        notip2.popUptextSalah();
                        // kondisi salah
                        NotifManager.instance.panggilSuara(1);
                        Debug.Log("Salah");
                    }
                }
            }
        }
    }

    public void ResetPuzzle()
    {
        transform.position = initPosition;
        transform.rotation = initRotation;
    }
}
