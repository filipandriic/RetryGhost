using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            BackHome();
    }
    public void BackHome()
    {
        FindObjectOfType<SceneTransition>().LoadLevel(0);
    }
}
