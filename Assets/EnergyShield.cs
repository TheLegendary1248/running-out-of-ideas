using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyShield : MonoBehaviour
{

    public GameObject particle;
    public AudioSource src;
    public AudioSource hum;
    public AudioClip[] sfx;
    public bool active = false;
    public float size = 30f;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(active ? PowerDown() : PowerUp());
            active = !active;
        }
    }
    IEnumerator PowerUp()
    {
        const float time = 1f;
        float timestamp = Time.fixedTime + time;
        float range = 0f;
        Vector2 scaleState = new Vector2(size, size);
        src.clip = sfx[0];
        src.Play();
        while(timestamp > Time.fixedTime)
        {
            range = (timestamp - Time.fixedTime) / time;
            transform.localScale = Vector2.Lerp(scaleState,Vector2.zero , range * range);
            yield return new WaitForFixedUpdate();
        }
        transform.localScale = scaleState;
        hum.Play();
    }
    IEnumerator PowerDown()
    {
        const float time = 1f;
        float timestamp = Time.fixedTime + time;
        float range = 0f;
        Vector2 scaleState = new Vector2(size, size);
        hum.Pause();
        src.clip = sfx[1];
        src.Play();
        while (timestamp > Time.fixedTime)
        {
            range = (timestamp - Time.fixedTime) / time;
            transform.localScale = Vector2.Lerp(Vector2.zero,scaleState , range * range);
            yield return new WaitForFixedUpdate();
        }
        transform.localScale = Vector2.zero;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(particle, collision.transform.position, Quaternion.identity);
        Destroy(collision.gameObject);
    }
}
