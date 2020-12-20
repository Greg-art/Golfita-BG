using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;


    public void ChangeScene(){
        StartCoroutine( LoadLevel("Fase Teste")) ;
    }

    IEnumerator LoadLevel(string levelName){

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelName);


    }
}
