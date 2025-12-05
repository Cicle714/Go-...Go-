using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    [SerializeField]
    private Image BlackImage; //ˆÃ“]—p
    [SerializeField]
    private Image WhiteImage; //–¾“]—p

    private bool GameOver = false; //ƒQ[ƒ€ƒI[ƒo[”»’è



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //BlackImage = BlackImage.GetComponent<Image>();
        StartCoroutine(BlackOut()); //ˆÃ“]ˆ—
    }


    /// <summary>
    /// ˆÃ“]ˆ—
    /// </summary>
    /// <returns></returns>
    IEnumerator BlackOut()
    {

        while (BlackImage.color.a > 0)
        {
            BlackImage.color -= new Color(0, 0, 0, 1 * Time.deltaTime / 2);
            yield return null;
        }
    }
    /// <summary>
    /// ˆÃ“]ˆ—
    /// </summary>
    /// <returns></returns>
    public IEnumerator BlackOut2()
    {
        yield return new WaitForSeconds(1.5f);

        while (BlackImage.color.a < 1.0f)
        {
            BlackImage.color += new Color(0, 0, 0, 1 * Time.deltaTime / 2);
            yield return null;
        }

        SceneManager.LoadScene("Title");
        yield return null;
    }
    /// <summary>
    /// –¾“]ˆ—
    /// </summary>
    /// <returns></returns>
    public IEnumerator WhiteOut()
    {
        while (WhiteImage.color.a < 1.0f)
        {
            WhiteImage.color += new Color(0, 0, 0, 1 * Time.deltaTime / 2);
            yield return null;
        }
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(BlackOut2()); //ˆÃ“]ˆ—
        yield return null;
    }

}