using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour
{
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(TeleportBackToSpawn());
        }
    }

    IEnumerator TeleportBackToSpawn()
    {
        audio.Play();

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("TightRope(lvl 2)");
    }
}
