using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDUpdater : MonoBehaviour {

    PlayerManager pm;
    public Slider pufferSlider;
    public Slider breathSlider;
    // Use this for initialization
    void Start () {
        pm = GameObject.Find("Player").GetComponent<PlayerManager>();
        pufferSlider.maxValue = pm.MaxPufferCharge;
        breathSlider.maxValue = pm.MaxBreath;
	}
	
	// Update is called once per frame
	void Update () {
        breathSlider.value = pm.getBreath();
        pufferSlider.value = pm.getPufferCharge();
	}
}
