using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;

    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
        Debug.Log("doing anim");
    }


    public void TestAnimEvent()
    {
        Debug.Log("MIDDLE DEBUG EVENBT");
    }
    public void OnFadeComplete()
    {
        Debug.Log("going to next level");
        SceneManager.LoadScene(levelToLoad);
    }
}
