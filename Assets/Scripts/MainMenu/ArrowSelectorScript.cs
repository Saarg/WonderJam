
using UnityEngine;
using UnityEngine.UI;

public class ArrowSelectorScript : MonoBehaviour {

    [SerializeField]
    private Image image;

    public CarSelectorScript carSelectorScript;

    // Use this for initialization
    void Start () {
		
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

    public void OnSelect()
    {
        image.color = new Color32(200, 200, 200, 255);
    }

    public void OnClick()
    {
        switch (name)
        {
            case "ArrowLeft":
                carSelectorScript.SetPreviousCar();
                break;
            case "ArrowRight":
                carSelectorScript.SetNextCar();
                break;

        }

    }
}
