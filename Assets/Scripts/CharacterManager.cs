using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    private static CharacterManager _instance; // 
    public static CharacterManager Instance // �̱��� �ݵ��
    {
        get{
            if(_instance == null) // �ν��Ͻ��� ������ ĳ���� �޴��� �ű� �ν��Ͻ� �߰�
            {
                _instance = new GameObject("CharacterManager").AddComponent<CharacterManager>();
            }
            return _instance;
        }
    }
    private Player _player;
    public Player Player
    {
        get { return _player; } // �ش� �ν��Ͻ��� �÷��̾� ����
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
                Destroy(gameObject); // �̹� ������ ����
        }
        
    }
}
