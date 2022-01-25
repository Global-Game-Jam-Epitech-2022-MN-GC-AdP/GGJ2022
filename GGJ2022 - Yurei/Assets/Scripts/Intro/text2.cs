using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class text2 : MonoBehaviour
{
    bool is_text2_gone = false;
    public GameObject is_text1;
    private text text1;
    private AudioSource audioSource;
    public float speed = 0.06f;
    public float delay = 4;
    public float point = 0.7f;
    public string fullText;
    private string currenText = "";
    private Text UIText;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        text1 = is_text1.GetComponent<text>();
        UIText = GetComponent<Text>();
        GetComponent<Text>().enabled = false;
    }

    void Update()
    {
        if (text1.is_test1_gone == true && is_text2_gone == false) {
            GetComponent<Text>().enabled = true;
            StartCoroutine(TextSlower());
            is_text2_gone = true;
        }
    }

    IEnumerator TextSlower()
    {
        for (int i = 0; i < fullText.Length; i++) {
            currenText = fullText.Substring(0, i + 1);
            this.GetComponent<Text>().text = currenText;
            if (fullText[i] == '.')
                yield return new WaitForSeconds(point);
            if (fullText[i] == ',')
                yield return new WaitForSeconds(point);
            if (i % 2 == 1)
                audioSource.Play();
            yield return new WaitForSeconds(speed);
        }
        if (currenText == fullText) {
            yield return new WaitForSeconds(delay);
            UIText.CrossFadeAlpha(0.0f, 0.5f, false);
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }
}
