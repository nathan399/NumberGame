using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject Fail;
    [SerializeField] GameObject Victory;
    [SerializeField] TMPro.TextMeshProUGUI CompletionAmountText;
    [SerializeField] TMPro.TextMeshProUGUI VictoryTimeText;

    public void EndScreenFail(int totalCorrect, int totalButtons)
    {
        gameObject.SetActive(true);
        Victory.SetActive(false);
        Fail.SetActive(true);
        CompletionAmountText.text = "You Got " + totalCorrect + "/" + totalButtons;
    }

    public void EndScreenVictory(int totalCorrect, int totalButtons, float time)
    {
        gameObject.SetActive(true);
        Victory.SetActive(true);
        Fail.SetActive(false);
        CompletionAmountText.text = "You Got " + totalCorrect + "/" + totalButtons;
        VictoryTimeText.text = "You took " + time.ToString("0.00") + " seconds";
    }
}
