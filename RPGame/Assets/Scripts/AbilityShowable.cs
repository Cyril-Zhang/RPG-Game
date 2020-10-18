using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//介绍：脚本负责让角色属性可视，鼠标悬停到角色，或按下tab可见角色属性
//1.attach此脚本的物体需要有collider2D component
//2.此脚本需要attach一个UI panel && panel （包含属性种类个数的Text子元素）
//3.Main character 需要被tag成Player，对应36行如需改变
public class AbilityShowable : MonoBehaviour
{
    public GameObject panel;
    
    private Dictionary<string, int> abilityMap;
    private List<string> abilities;
    private bool open = false;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        
        
        //get ability from database,now is AttributesMap script
        
        abilityMap = AttributesMap.get(name);
        abilities = AttributesMap.getAbilityNames(name);
        updatePanel();

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && this.tag.Equals("Player"))
        {
            open = !open;
            updatePanel();
            panel.SetActive(open);
        }
    }

    public void OnMouseOver()
    {
        updatePanel();
        panel.SetActive(true);
        
    }
    public void OnMouseExit()
    {
        updatePanel();
        panel.SetActive(false);
    }

    private void updatePanel()
    {
        //position update
        RectTransform transform = panel.GetComponent<RectTransform>();
        Vector2 objectPos = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector2 newposition = new Vector2(objectPos.x, objectPos.y+this.transform.localScale.y);
        transform.position = newposition;
        //value update
        Text[] texts = panel.GetComponentsInChildren<Text>();
        for (int i = 0;i<texts.Length;i++)
        {
            if (abilities == null || abilityMap == null) {
                break;
            }
            texts[i].text = abilities[i] + ": " + abilityMap[abilities[i]];
        }
        
    }


}
