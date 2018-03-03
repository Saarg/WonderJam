
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    private int step = 0;



    private float distance = 2;
    private int maxStep = 20;

    private int maxOpacity = 255;

    private Color yellowColor = new Color(255.0f, 195.0f, 0.0f);
    private Color whiteColor = new Color(255.0f, 255.0f, 255.0f);
    private Color currentColor;
    

    [SerializeField]
    private Image arrow;

    [SerializeField]
    private Text text;

    private bool isTrigged = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	    if (isTrigged)
	    {
	        if (step < maxStep)
	        {
	            step++;

                // Translate text right
	            text.transform.Translate(distance, 0, 0);

                // Set ocacity arrow
	            float newOpcaity = maxOpacity * (float) step / maxStep/ 255.0f;
	            arrow.color = new Color(arrow.color.r, arrow.color.g, arrow.color.b, newOpcaity);

                // Change text color
	            byte new_g = (byte) (whiteColor.g - (whiteColor.g - yellowColor.g) * step / maxStep);
	            byte new_b = (byte) (whiteColor.b - (whiteColor.b - yellowColor.b) * step / maxStep);
                currentColor = new Color32(255, (byte) new_g, new_b, 255);
	            text.color = currentColor;

	        }
        }
    }

    public void PointerDown()
    {
        isTrigged = true;
    }

    public void PointerExit()
    {
        isTrigged = false;
        text.transform.Translate(-step*distance, 0, 0);
        arrow.color = new Color(arrow.color.r, arrow.color.g, arrow.color.b, 0.0f);
        text.color = whiteColor;
        step = 0;
    }

    public void OnClick()
    {
        switch (name)
        {
            case "Options":
                onOptions();
                break;
            case "Quit":
                onQuit();
                break;
        }
    }

    private void onOptions()
    {

    }

    private void onQuit()
    {
        Application.Quit();
    }

}
