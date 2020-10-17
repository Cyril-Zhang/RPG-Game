using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;



public class NewBehaviourScript : MonoBehaviour
{
    [Header("UI")]
    public Text textlabel;

    [Header("textfile")]
    public TextAsset txtfile;
    public int index;


    List<string> textlist = new List<string>();

    // Start is called before the first frame update
    void Awake()
    {
        Gettextfromfile(txtfile);
        index = 0;
    }
    private void OnEnable()
    {
        textlabel.text = textlist[index];
    }
    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.F))&& index == textlist.Count)
        {
            gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            textlabel.text = textlist[index];
            index++;
        }
    }
    private void OntriggerExit2D(Collider2D other)
    {
       
    }
    void Gettextfromfile(TextAsset file)
    {
        textlist.Clear();
        index = 0;
        //file.text.Split('\n');
        var linedata = file.text.Split('\n');
        foreach (var line in linedata)
        {
            textlist.Add(line);
        }
    }
    
}
