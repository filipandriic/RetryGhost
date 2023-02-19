using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Animator revive_animator;
    public TextMeshProUGUI coin_number_text;
    private int coin_number;
    private bool in_game;

    private void Start()
    {
        if (coin_number_text != null)
            SetCoinNumber(0);
        in_game = true;
    }

    public IEnumerator GameOver()
    {
        in_game = false;
        FindObjectOfType<PlayerMovement>().GameOver();
        revive_animator.Play("ReviveAnimation");
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<Retry>().RetryGame(true);
        in_game = true;
    }

    public void CollectCoin()
    {
        coin_number++;
        SetCoinNumber(coin_number);
    }

    public void PutCoinInChest()
    {
        coin_number--;
        SetCoinNumber(coin_number);
    }

    private void SetCoinNumber(int num)
    {
        coin_number_text.SetText(coin_number.ToString());
    }

    public int GetCoinNumber()
    {
        return coin_number;
    }

    public void SetRespawnPoint(float x, float y)
    {
        FindObjectOfType<Retry>().SetRespawnPoint(new Vector2(x, y));
    }

    public bool InGame()
    {
        return in_game;
    }
}
