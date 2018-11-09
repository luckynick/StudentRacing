using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowLaps : MonoBehaviour {

    public IDChecker idc;
    float time = 0;
	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;
        string str = "Okrazenia: "; 
        str = Mathf.Clamp(idc.rounds+1, 1, RoundsManager.instance.numberOfRounds).ToString();
        str += " / " + RoundsManager.instance.numberOfRounds;
        str += "\nCzas: ";
        str += Mathf.Round(time);
        GetComponent<TextMeshProUGUI>().text = str;
    }
}
