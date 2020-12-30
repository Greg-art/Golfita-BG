using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIAnimator : MonoBehaviour
{

    public bool animationIsHappening = false;
    void Start()
    {
        LeanTween.moveLocal(gameObject, new Vector3(18000, 750, 0), 0f);
        LeanTween.scaleX(gameObject, 0.1f, 0);
        LeanTween.scaleY(gameObject, 0.1f, 0);


    }

    public void playAnimation(){
        StartCoroutine(Anima());
    }

    IEnumerator Anima()
    {
        animationIsHappening = true;
        LeanTween.moveLocal(gameObject, new Vector3(0, 750, 0), 0.5f);


        yield return new WaitForSeconds(0.5f);
        LeanTween.scaleX(gameObject, 1f, 1f);
        LeanTween.scaleY(gameObject, 1f, 1f);
        LeanTween.rotateZ(gameObject, 180f, 0.5f);

        yield return new WaitForSeconds(0.5f);
        LeanTween.rotateZ(gameObject, 360f, 0.5f);

        yield return new WaitForSeconds(1f);
        LeanTween.moveLocal(gameObject, new Vector3(-18000, 750, 0), 0.5f);

        yield return new WaitForSeconds(0.3f);
        animationIsHappening = false;
    }
}
