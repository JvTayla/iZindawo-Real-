using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public TurnController gameScript;
    public Button BlueButt;
    // Start is called before the first frame update
    private void Start()
    {
        gameScript = GameObject.FindGameObjectWithTag("TurnController").GetComponent<TurnController>();
    }
    public void buttonPress()
    {
        gameScript.YellowMellow();
        BlueButt.gameObject.SetActive(false);
        SceneManager.LoadScene("EndScene");
    }
}