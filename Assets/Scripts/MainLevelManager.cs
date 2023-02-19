using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLevelManager : MonoBehaviour
{
    public GameObject level2_lock;
    public GameObject level3_lock;
    public GameObject level4_lock;
    void Start()
    {
        level2_lock.SetActive(PlayerPrefs.GetInt("Level1Finished", 0) == 0);
        level3_lock.SetActive(PlayerPrefs.GetInt("Level2Finished", 0) == 0);
        level4_lock.SetActive(PlayerPrefs.GetInt("Level3Finished", 0) == 0);
    }
}
