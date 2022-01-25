using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour
{
    //public AudioClip impact;
    public bool is_test1_gone = false;
    private AudioSource audioSource;
    public float speed = 0.04f;
    public float delay = 4;
    public float point = 0.7f;
    public float virgule = 0.4f;
    public float waiting = 1;
    public string fullText;
    private string currenText = "";
    private Text UIText;
    // Start is called before the first frame update

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        UIText = GetComponent<Text>();
        StartCoroutine(TextSlower());
    }

    IEnumerator TextSlower()
    {
        for (int i = 0; i < fullText.Length; i++) {
            currenText = fullText.Substring(0, i + 1);
            this.GetComponent<Text>().text = currenText;
            if (fullText[i] == '.')
                yield return new WaitForSeconds(point);
            if (fullText[i] == ',')
                yield return new WaitForSeconds(virgule);
            if (i % 2 == 1)
                audioSource.Play();
            yield return new WaitForSeconds(speed);
        }
        if (currenText == fullText) {
            yield return new WaitForSeconds(delay);
            //GetComponent<Text>().enabled = false;
            UIText.CrossFadeAlpha(0.0f, 0.5f, false);
            yield return new WaitForSeconds(waiting);
            is_test1_gone = true;
        }
    }
}