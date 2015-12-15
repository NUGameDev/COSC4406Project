using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class HUDUpdater : MonoBehaviour {

    PlayerManager pm;
	ConfigManager cm;
    public Slider pufferSlider;
    public Slider breathSlider;
    // Use this for initialization
    void Start () {
		cm = GetComponent<ConfigManager> ();
        pm = GameObject.Find("Player").GetComponent<PlayerManager>();
		pufferSlider.maxValue = (float)Double.Parse(cm.Load ("MaxPufferCharge"));;
		breathSlider.maxValue = (float)Double.Parse(cm.Load ("MaxBreath"));
	}
	
	// Update is called once per frame
	void Update () {
        breathSlider.value = pm.getBreath();
        pufferSlider.value = pm.getPufferCharge();
	}
}
