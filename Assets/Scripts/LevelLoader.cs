using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public bool loadNextLevel = true;

    public void LoadNextScene(){ 
        StartCoroutine( LoadLevel(SceneManager.GetActiveScene().buildIndex + 1) );
    }

    public void RestartScene(){ 
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadExpecificSceneByIndex(int index){
        StartCoroutine(LoadLevel(index));
    }

    IEnumerator LoadLevel(int index){
        if ( SceneManager.GetActiveScene().buildIndex != 0){
            yield return new WaitForSeconds(1.9f);
        }

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(index);

    }



}
