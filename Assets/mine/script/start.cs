using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public AudioSource startbgm;
   // public AudioSource stopbgm;
    public void playgame()
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {

       // stopbgm.Pause(); 
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(1);
    }

    public void sfx()
    { 
        startbgm.Play();
    }
}
