using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Sprite open_door_image;
    public int level;
    
    public void OpenDoor()
    {
        string str = "Level" + SceneManager.GetActiveScene().buildIndex + "Finished";
        PlayerPrefs.SetInt(str, 1);
        GetComponent<SpriteRenderer>().sprite = open_door_image;
        //load scene
        FindObjectOfType<SceneTransition>().LoadLevel(level);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && Unlocked())
            FindObjectOfType<PlayerMovement>().SetOverlapDoor(this.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && Unlocked())
            FindObjectOfType<PlayerMovement>().SetOverlapDoor(null);
    }

    private bool Unlocked()
    {
        if (transform.childCount > 1 && transform.GetChild(1).gameObject.activeSelf)
            return false;
        return true;
    }
}