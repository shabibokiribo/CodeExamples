using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dice : MonoBehaviour {
    [SerializeField] public TMP_Text diceText;
    [SerializeField] public Canvas infoCanvas;
    [SerializeField] public Canvas diceCanvas;
    [SerializeField] public Button[] buttons;
    [SerializeField] public TMP_InputField inputField;
    [SerializeField] public TMP_Text inputFieldClampText;
    private int pickedSide = -1;
    private int betMoney = 0;
    private Component[] sides;
    private GameManager gameManager;

    private void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        inputFieldClampText.text = "/ $" + gameManager.Money;
    }

    private IEnumerator RollDice(float intervalSeconds) {
        yield return new WaitForSeconds(1);
        
        int randomSide = 1;
        for(int i=10;i>0;i--) {
            int newSide = UnityEngine.Random.Range(1,7);
            while(randomSide == newSide) {
                newSide = UnityEngine.Random.Range(1,7);
            } randomSide = newSide;
            diceText.text = randomSide.ToString();
            yield return new WaitForSeconds(intervalSeconds);
        }

        if(pickedSide == randomSide) {
            Debug.Log("win");
            gameManager.Money += betMoney * 2;
        } else {
            Debug.Log("lose");
            gameManager.Money -= betMoney;
        }

        yield return new WaitForSeconds(3f - intervalSeconds);
        inputFieldClampText.text = "/ $" + gameManager.Money;
        inputField.text = "";
        betMoney = 0;
        infoCanvas.gameObject.SetActive(true);
        diceCanvas.gameObject.SetActive(false);

        yield return null;
    }

    public void OnValueChanged() {
        inputFieldClampText.text = "/ $" + gameManager.Money;
    
        string str_onlyNumbers = Regex.Replace(inputField.text, "[^0-9]", "");

        // check if string is empty after regex and return
        if(str_onlyNumbers == "") {
            inputField.text = "";
            return;
        }

        // parse as int -- should never fail (clueless)
        if(int.TryParse(str_onlyNumbers, out betMoney)) {
            betMoney = Mathf.Clamp(betMoney, 0, gameManager.Money);
            inputField.text = betMoney.ToString();
        } else {
            inputField.text = str_onlyNumbers;
            betMoney = -1;
            Debug.LogError("Could not parse string.");
        }
    }

    public void OnClickOne() {
        pickedSide = 1;
        ButtonActions();
    } public void OnClickTwo() {
        pickedSide = 2;
        ButtonActions();
    } public void OnClickThree() {
        pickedSide = 3;
        ButtonActions();
    } public void OnClickFour() {
        pickedSide = 4;
        ButtonActions();
    } public void OnClickFive() {
        pickedSide = 5;
        ButtonActions();
    } public void OnClickSix() {
        pickedSide = 6;
        ButtonActions();
    }

    private void ButtonActions() {
        foreach(Button button in buttons) {
            button.interactable = true;
        } UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;
    }

    public void OnClickLOCKIN() {
        if(betMoney == 0 || betMoney == -1)
            return;

        if(pickedSide == -1)
            return;
        
        diceText.text = null;
        infoCanvas.gameObject.SetActive(false);
        diceCanvas.gameObject.SetActive(true);
        StartCoroutine(RollDice(0.25f));
    }

    public void OnClickBack() {
        gameManager.LoadNewScene(gameManager.SceneToLoad);
    }
}
