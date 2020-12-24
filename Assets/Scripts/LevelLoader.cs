using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private UIAnimator _uiAnimator;
    private bool _animationEnded = false;
    public Animator transition;

    void update(){
        if (_animationEnded) {
            Debug.Log("ended");
            if (Input.GetKey(KeyCode.A) || (Input.GetTouch(0).phase == TouchPhase.Began)){
                Debug.Log("ended2");

                ChangeScene();
            }
        }
    }
    public void passSheStage(){ 
        _uiAnimator.playAnimation();
        _animationEnded = true;

    }
    public void ChangeScene(){
        StartCoroutine( LoadLevel()) ;
    }

    IEnumerator LoadLevel(){

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }
}
