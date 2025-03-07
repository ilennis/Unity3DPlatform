using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    private static CharacterManager _instance; // 
    public static CharacterManager Instance // 싱글턴 반들기
    {
        get{
            if(_instance == null) // 인스턴스가 없으면 캐릭터 메니저 신규 인스턴스 추가
            {
                _instance = new GameObject("CharacterManager").AddComponent<CharacterManager>();
            }
            return _instance;
        }
    }
    private Player _player;
    public Player Player
    {
        get { return _player; } // 해당 인스턴스에 플레이어 관리
        set { _player = value; }
    }
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance == this)
                Destroy(gameObject); // 이미 있으면 삭제
        }
        
    }
}
