using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSlower : MonoBehaviour
{
    public bool is_test1_gone = false;
    private AudioSource audiosource;
    public float speed = 0.04f;
    public float delay = 4;
    public float point = 0.7f;
    public float comma = 0.4f;
    public string fullText;
    private string currenText = "";

    void Start() {
        audiosource = GetComponent<AudioSource>();
        StartCoroutine(Text_Slower());
    }
IEnumerator Text_Slower()
    {
        for (int i = 0; i < fullText.Length; ++i) {
            currenText = fullText.Substring(0, i + 1);
            this.GetComponent<Text>().text = currenText;
            if (fullText[i] == '.')
                yield return new WaitForSeconds(point);
            if (fullText[i] == ',')
                yield return new WaitForSeconds(comma);
            if (i % 2 == 1)
                audiosource.Play();
            yield return new WaitForSeconds(speed);
        }
    }
}
