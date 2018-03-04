
using UnityEngine;
using UnityEngine.UI;

public class ArrowSelectorScript : MonoBehaviour {

    [SerializeField]
    private Image image;

    public CarSelectorScript carSelectorScript;
    public StatScript statScript;

    // Use this for initialization
    void Start () {
		statScript.SetStats(carSelectorScript.curCar);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnEnter()
    {
        image.color = new Color32(220,220,220,255);
    }

    public void OnLeave()
    {
        image.color = Color.white;
    }

    public void OnClick()
    {
        if (carSelectorScript.readyButton.interactable)
        {
            switch (name)
            {
                case "LeftArrow":
                    carSelectorScript.SetPreviousCar();
                    statScript.SetStats(carSelectorScript.curCar);
                    break;
                case "RightArrow":
                    carSelectorScript.SetNextCar();
                    statScript.SetStats(carSelectorScript.curCar);
                    break;

            }
        }

    }
}
