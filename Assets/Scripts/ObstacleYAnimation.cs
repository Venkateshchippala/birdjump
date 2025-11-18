using UnityEngine;
using System.Collections;

public class ObstacleYAnimation : MonoBehaviour
{
    [SerializeField] float animationTime = 2f;

    void OnEnable()
    {
        StartCoroutine(StartAnimationAfterFrame());
    }

    IEnumerator StartAnimationAfterFrame()
    {
        yield return null;   // wait 1 frame (IMPORTANT!)

        MoveZigZag();
    }

    void MoveZigZag()
    {
        float startY = transform.localPosition.y;
        Debug.Log("Corrected startY : " + startY);

        float endY = startY <= -200 ? 250 : -250;

        iTween.MoveTo(gameObject, iTween.Hash(
            "y", endY,
            "time", animationTime,
            "islocal", true,
            "easetype", iTween.EaseType.easeInOutSine,
            "looptype", iTween.LoopType.pingPong
        ));
    }
}
