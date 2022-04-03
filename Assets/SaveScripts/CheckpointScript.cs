using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    private JsonSaveSystem _sSystem;

    private SaveData _data;

    private GameObject _player;

    private GameObject _sPoint;

    private GameObject[] _allCheckpoints;
    
    private GameObject[] _allBosses;

    public Animator anim;

    private void Awake()
    {
        _allCheckpoints = GameObject.FindGameObjectsWithTag("checkpoints");
        _allBosses = GameObject.FindGameObjectsWithTag("bosses");
        _sPoint = gameObject;
        _player = GameObject.Find("Player");
        _sSystem = new JsonSaveSystem();
        _data = _sSystem.Load();
        if (_data.checkpoints.Length != _allCheckpoints.Length) _data.checkpoints = new bool[_allCheckpoints.Length];
        if (_data.isBossesAlive.Length != _allBosses.Length)
        {
            _data.isBossesAlive = new bool[_allBosses.Length];
            for (int i = 0; i < _data.isBossesAlive.Length; i++)
                _data.isBossesAlive[i] = true;

        }
        ApplyLoad(_data);
    }

    private void Update()
    {
        if (Vector3.Distance(_player.transform.position, _sPoint.transform.position) <= 1.5f)
        {
            anim.SetBool("near", true);
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                for (int i = 0; i < _allCheckpoints.Length; i++)
                    if (_allCheckpoints[i] == gameObject)
                    {
                        anim.SetBool("active", true);
                        _data.checkpoints[i] = true;
                    }
                    else
                    {
                        _allCheckpoints[i].GetComponent<Animator>().SetBool("active", false);
                        _data.checkpoints[i] = false;
                    }

                for (int i = 0; i < _allBosses.Length; i++)
                {
                    print(_allBosses[i].GetComponent<Stats>().health);
                    _data.isBossesAlive[i] = _allBosses[i].GetComponent<Stats>().health > 0;
                }



                _data.player.extraJumpValue = _player.GetComponent<hero>().extraJumpValue;
                _data.player.position = _player.transform.position;
                _sSystem.SaveRestart(_data);
            }
        }
        else
        {
            anim.SetBool("near",false);
        }
/*
        if (Input.GetKeyDown(KeyCode.T))
        {
            _data.player.position = _player.transform.position;
            _sSystem.Save(_data);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            _data = _sSystem.Load();
            ApplyLoad(_data);
        }
*/

        if (Input.GetKeyDown(KeyCode.U))
        {
            _sSystem.SaveRestart(new SaveData());
        }
    }

    private void ApplyLoad(SaveData data)
    {
        for (int i = 0; i < _allCheckpoints.Length; i++)
            _allCheckpoints[i].GetComponent<Animator>().SetBool("active", data.checkpoints[i]);
        
        for (int i = 0; i < _allBosses.Length; i++)
            if(_allBosses[i] != null)
                _allBosses[i].SetActive(_data.isBossesAlive[i]);

        _player.GetComponent<hero>().extraJumpValue = data.player.extraJumpValue;
        GameObject.Find("Player").transform.position = data.player.position;
        if (GameObject.Find("DoubleJump") != null)
            GameObject.Find("DoubleJump").SetActive(data.player.extraJumpValue == 0);
    }
}

