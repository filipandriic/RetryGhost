using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int needed_coins;
    public GameObject level_lock;
    public void Unlock()
    {
        if (FindObjectOfType<Chest>().GetCoinNumber() == needed_coins)
            level_lock.SetActive(false);
    }

    public int GetNeededCoins()
    {
        return needed_coins;
    }
}
