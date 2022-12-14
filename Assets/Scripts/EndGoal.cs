using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Controls the end goal behavoiur. Simple as that
public class EndGoal : MonoBehaviour
{
    ///<summary>The length of the level end animation time. Effectively scales said animation too</summary>
    public static float EndAnimationTime = 1f;
    Coroutine reachedEndAnim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            reachedEndAnim = StartCoroutine(AnimateEnd());
        }
    }
    IEnumerator AnimateEnd()
    {
        float timestamp = Time.unscaledTime;
        Vector3 entryPos = Player.s.transform.position;
        Player.s.YieldToEnd();
        float interpol = 0f;
        while(interpol < 1f)
        {
            interpol = (Time.unscaledTime - timestamp) / EndAnimationTime;
            //Animate the player smoothly entering exit
            Player.s.transform.position = Vector3.Lerp(entryPos, transform.position, interpol * interpol);
            //Hand control back
            yield return new WaitForEndOfFrame();
        }
        //Call level exit
    }
}
