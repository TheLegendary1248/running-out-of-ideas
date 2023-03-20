using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Controls the end goal behavoiur. Simple as that
public class EndGoal : MonoBehaviour
{
    ///<summary>The length of the level end animation time. Effectively scales said animation too</summary>
    public static float EndAnimationTime = 0.75f;
    Coroutine reachedEndAnim;
    public AudioSource aud;
    public SpriteRenderer spr;
    public string Next;
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
        Vector3 entryPos = Player.singleton.transform.position;
        Player.singleton.YieldToEnd();
        float interpol = 0f;
        while(interpol < 1f)
        {
            interpol = (Time.unscaledTime - timestamp) / EndAnimationTime;
            //Animate the player smoothly entering exit
            Player.singleton.transform.position = Vector3.Lerp(entryPos, transform.position, interpol * interpol);
            //Hand control back
            yield return new WaitForEndOfFrame();
        }
        Player.singleton.gameObject.SetActive(false);
        aud.Play();
        timestamp = Time.unscaledTime;
        Material material = spr.material;
        interpol = 0f;
        while (interpol < 1f)
        {
            interpol = (Time.unscaledTime - timestamp) / EndAnimationTime;
            //Animate the player smoothly entering exit
            material.SetFloat("_Range", interpol / 2f);
            //Hand control back
            yield return new WaitForEndOfFrame();
        }
        //Call level exit
    }
}
