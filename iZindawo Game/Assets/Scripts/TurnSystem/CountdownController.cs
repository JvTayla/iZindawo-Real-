using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    [SerializeField]
    public int countdownTime;
    [SerializeField]
    public Text countdownDisplay;
    // Start is called before the first frame update
    public void countdownTimer()
    {
        countdownTime = 30;
        countdownDisplay.gameObject.SetActive(true);
        StartCoroutine(CountdownToNextTurn());
    }
    IEnumerator CountdownToNextTurn()
    {
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        yield return new WaitForSeconds(1f);
        countdownDisplay.gameObject.SetActive(false);
    }
}
