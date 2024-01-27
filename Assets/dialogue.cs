using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textspeed;
    private int index;
    ISPresentItemScript script;
    public i5.VirtualAgents.Examples.ControllerScript myScript;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        startDialogue();
        Button btn = button.GetComponent<Button>();
         btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
     {
        if (textComponent.text == lines[index])
        {
            nextline();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }
    // Update is called once per frame
    /*public void Update()
    {
        button.onClick
        if (Input.GetMouseButtonDown(0))
        {
            if(textComponent.text== lines[index])
            {
                nextline();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }*/

    void startDialogue()
    {
        index = 0;
        StartCoroutine(Typeline());
    }
    IEnumerator Typeline()
    {
        foreach(char c in lines[index])
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }
    void nextline()
    {
        if(index< lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(Typeline());

        }
        else
        {
            gameObject.SetActive(false);
            myScript.startItemPickup = true;
            // Debug.Log(myScript.startItemPickup) = true;
            //script = gameObject.GetComponent<ItemDropControllerScript>;
            //ItemDropControllerScript.startItemPickup = true;
        }
    }
}
