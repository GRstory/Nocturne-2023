using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    public void Awake() {
        talkData = new Dictionary<int, string[]>();

        GenrateData();
    }

    public void GenrateData(){
        //talkData.Add(num, new String[] {"대사1", "대사2"});
        talkData.Add(9999, new string[] {"testing 1-1", "testing 1-2", "testing 1-3", "testing 1-4"});
        talkData.Add(9998, new string[] {"testing 2-1", "testing 2-2", "testing 2-3", "testing 2-4"});
        talkData.Add(9997, new string[] {"testing 3-1", "testing 3-2", "testing 3-3", "testing 3-4"});
        talkData.Add(9996, new string[] {"testing 4-1", "testing 4-2", "testing 4-3", "testing 4-4"});

        //인게임 NPC 영어 대사는  + 1000
        talkData.Add(1000, new string[] {"젠장.. 또 실패야…", "하.. 고양이야 지금은 조금 바빠서 나중에", "이런 생활이 계속될순 없어…"});
        talkData.Add(2000, new string[] {"Damn it. It's a failure again…", "Sigh... Cat, I'm a little busy right now, so later", "I can't go on living like this..."});
        talkData.Add(1001, new string[] {"....."});
        talkData.Add(2001, new string[] {"....."});

        talkData.Add(1300, new string[] {"넌 뭐야?", "공원을 나가고 싶은거야?", "저리가 임마"});
        talkData.Add(1301, new string[] {"저쪽으로 가보렴", "아 치킨먹고싶다 ", "2580...."});
        talkData.Add(1302, new string[] {"....."});
        talkData.Add(2300, new string[] {"What are you?", "Do you want to go out of the park?", "Go away"});
        talkData.Add(2301, new string[] {"Go over there", "Oh, I want to eat chicken", "2580...."});
        talkData.Add(3302, new string[] {"....."});

    }

    public string GetTalk(int id, int index){
        try{
            return talkData[id][index];
        }
        catch{
            GetComponent<Interaction>().dialogIndex = -1;
            return ".....";
        }
        
    }
}
