using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public int HEALTH = 100;
    public int Q_CAM_INDEX = 0; //쿼터뷰 카메라 번호
    public int TEMP_CAM_MODE = 0; //현재 카메라 모드
    public int GAME_UI = 0; //UI 컨트롤용
    public bool CINEMATIC_UI = false;
    public int SAVE_POINT = 0;
    public int SAVE_PART = 0;
    public List<bool> ACHIEVEMENT = new List<bool>() {false, false, false, false, false, false, false, false, false, false, false, false};
    public List<string> ITEMLIST = new List<string>(){};

    public float TIME_START = 0;
    public float TIME_SLEEP = 0;
    public int TIME_MEOW = 0;
    public int TIME_SCRATCH = 0;
    public float TIME_IDLE = 0;
    public int TIME_DIE = 0;
    public int BGM_INDEX = 0;
    public int BGM_INDEX_B = 0;
    public static GameManager Instance
    {
        get {
            if(!_instance){
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null){
            _instance = this;
        }
        else if (_instance != this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
