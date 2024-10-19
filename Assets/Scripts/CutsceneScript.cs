using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneScript : MonoBehaviour
{
    public Image image;  
    public List<Sprite> frames; 
    public float delayInSeconds = 0.5f;  
    public Sprite finalFrame;

    void Start()
    {
        StartCoroutine(PlayCutscene());
    }

    IEnumerator PlayCutscene()
    {
        foreach (var frame in frames)
        {
            yield return new WaitForSeconds(delayInSeconds);
            image.sprite = frame;
        }

        yield return new WaitForSeconds(3);

        image.sprite = finalFrame;

        yield return WaitForKeyPress();

        Debug.Log("test");
        SceneManager.LoadScene("Landscape_felix");
    }

    IEnumerator WaitForKeyPress()
    {
        while (!Input.anyKey)
        {
            yield return null;
        }
    }
}
