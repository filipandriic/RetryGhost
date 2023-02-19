using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator animator;

    public void LoadLevel(int level)
    {
        StartCoroutine(LoadScene(level));
    }

    private IEnumerator LoadScene(int level)
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(level);
    }
}
