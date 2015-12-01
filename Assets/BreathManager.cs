using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BreathManager : MonoBehaviour {
    public Slider breathslider;
    private float currentbreath;
    public float jumpBreath = 5.0f;
    // Use this for initialization
    void Start () {
        currentbreath = breathslider.value;
	}
	
	// Update is called once per frame
	void Update () {
        breathslider.value = currentbreath;
    }
    public void BreathJump()
    {
        currentbreath -= jumpBreath;
    }
    public bool CanJump()
    {
        return currentbreath >= jumpBreath;
    }
}
