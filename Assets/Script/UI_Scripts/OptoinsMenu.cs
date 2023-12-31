
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class OptionsMenu : MonoBehaviour
{
    //scene name we want to open
    public string sceneName;

    //the button this is attached to
    public Button button1;

    //text that could be on a UI but we want it blank
    public TMP_Text b1text;

    // Start is called before the first frame update
    void Start()
    {
      // adding the listender so it can be clicked
        button1.onClick.AddListener(taskonclick);

        // setting up communication with the text value to then get rid of the text
        b1text = gameObject.GetComponentInChildren<TMP_Text>(true);
        btnValue();
    }

    //To load the main level
    void taskonclick()
    {
       // SceneManager.LoadScene(sceneName);

    }


    //To blank out the autogenerated text
    public void btnValue()
    {
        b1text.text = "";
    }


    // Update is called once per frame
    void Update()
    {
 
    }

   
}
