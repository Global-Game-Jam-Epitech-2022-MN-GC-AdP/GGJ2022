using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private int LevelToLoad;

    public void FadeToLevel(int LevelIndex) {
        LevelToLoad = LevelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() {
        if (LevelToLoad == -1)
            Application.Quit();
        else
            SceneManager.LoadScene(LevelToLoad, LoadSceneMode.Single);
    }
}
