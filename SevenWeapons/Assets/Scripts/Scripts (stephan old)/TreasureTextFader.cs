using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TreasureTextFader : MonoBehaviour {

    Text treasureText;
    Color textColor;

	// Use this for initialization
	void Start () {
        treasureText = GetComponent<Text>();
        textColor = GetComponent<Text>().color;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public IEnumerator  fadeTreasureText(int value)
    {
        treasureText.text = "You collect " + value + " coins!";
                
        for (float f = 1.0f; f >= 0; f -= 0.1f)
        {
            treasureText.CrossFadeAlpha(f, 0, true);
            yield return new  WaitForSeconds(0.15f);
        }
        treasureText.text = "";
    }

}
