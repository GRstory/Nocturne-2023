using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    private static SavePoint _instance;
    public GameObject player;
    private int savePart = 0;
    private int savePoint = 0;
    public static List<Vector3> savePosition = new List<Vector3>() { };

    public static SavePoint Instance
    {
        get {
            if(!_instance){
                _instance = FindObjectOfType(typeof(SavePoint)) as SavePoint;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }
    
    private void Awake() {

        if (_instance == null){
            _instance = this;
        }
        else if (_instance != this){
            Destroy(gameObject);
        }
        
        savePosition.Add(new Vector3(23, 0.5f, 89.5f)); //파트1 리스폰
        savePosition.Add(new Vector3(23, 0.5f, 72.5f)); //파트1 -세이브포인트
        savePosition.Add(new Vector3(2, 0, 0)); //파트2 리스폰
        savePosition.Add(new Vector3(3, 0, 0)); //파트2 세이브포인트
        savePosition.Add(new Vector3(0, 0, 0)); //파트3 리스폰
        savePosition.Add(new Vector3(0, 5, 32.25f)); //파트3 세이브포인트
        savePosition.Add(new Vector3(0, 0.5f, -150)); //파트4 리스폰
        savePosition.Add(new Vector3(-3.5f, 1, 0)); //파트4 세이브포인트1
        savePosition.Add(new Vector3(6, 0, 0)); //파트4 세이브포인트2
        savePosition.Add(new Vector3(6, 0, 0)); //파트End
    }
    public void UpdateSave(){
        savePoint = GameManager.Instance.SAVE_POINT;
        savePart = GameManager.Instance.SAVE_PART;
    }

    public void GoSavePoint(){
        UpdateSave();
        //for(int i=0; i < GameManager.Instance.savePoint; i++) Debug.Log(savePosition[i]);
        Debug.Log(savePosition[0]);
        transform.position = savePosition[savePoint];
    }


}
