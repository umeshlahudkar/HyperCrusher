using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    [SerializeField] private Image faderImage;
    private Color originalColor;

    public delegate void SceneLoad();
    public static SceneLoad OnSceneLoad;

    public void LoadScene(int index)
    {
        StartCoroutine(Load(index));
    }

    private IEnumerator Load(int index)
    {
        originalColor = faderImage.color;
        originalColor.a = 0f;
        faderImage.color = originalColor;

        faderImage.gameObject.SetActive(true);

        yield return StartCoroutine(FadeOut());

        yield return SceneManager.LoadSceneAsync(index);

        OnSceneLoad?.Invoke();
       
        yield return StartCoroutine(FadeIn());

        faderImage.gameObject.SetActive(false);
    }

    private IEnumerator FadeIn()
    {
        float duration = 1f;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            Color color = faderImage.color;
            color.a = Mathf.Lerp(1f, 0f, timer / duration);
            faderImage.color = color;
            yield return null;
        }

        originalColor.a = 0f;
        faderImage.color = originalColor;
    }

    private IEnumerator FadeOut()
    {
        float duration = 0.5f;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            Color color = faderImage.color;
            color.a = Mathf.Lerp(0f, 1f, timer / duration);
            faderImage.color = color;
            yield return null;
        }

        originalColor.a = 1f;
        faderImage.color = originalColor;
    }
}
