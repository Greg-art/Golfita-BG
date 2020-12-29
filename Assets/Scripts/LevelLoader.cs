using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private UIAnimator _uiAnimator;
    public Animator transition;

    public void passTheStage(){ 
        _uiAnimator.playAnimation();
        StartCoroutine( LoadLevel() );
    }

    public void changeScene(){ 
        StartCoroutine( LoadLevel() );
    }
    IEnumerator LoadLevel(){
        if (SceneManager.GetActiveScene().buildIndex != 0){
            yield return new WaitForSeconds(1.9f);
        }

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void RestartScene(){ 
        StartCoroutine(ResetScene());
    }
    IEnumerator ResetScene(){

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
