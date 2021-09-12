using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class SceneController : MonoBehaviour
{
    /// <summary>
    /// Animator that have the scene change
    /// </summary>
    Animator animator;

    /// <summary>
    /// Transition time for make the transition
    /// </summary>
    public float transitionTime = 1f;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Method to load scene from string name
    /// </summary>
    /// <param name="scene">name of the scene</param>
    public void LoadScene(string scene)
    {
        StartCoroutine(Load(scene));
    }

    /// <summary>
    /// Async method to load scene from string name
    /// </summary>
    /// <param name="scene">name of the scene</param>
    /// <returns>yield response</returns>
    IEnumerator Load(string scene)
    {
        animator.SetTrigger("load");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(scene);
    }

    /// <summary>
    /// Method to close the app
    /// </summary>
    public void ExitApplication()
    {
        Application.Quit();
    }

}
