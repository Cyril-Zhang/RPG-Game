using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//the script now is simulating Database for testing.
//此脚本用来存储修改角色的属性信息
public class AttributesMap : MonoBehaviour
{
    static Dictionary<string, Dictionary<string,int>> attributeMap;
    // Start is called before the first frame update
    void Start()
    {
        attributeMap = new Dictionary<string, Dictionary<string,int>>();
        Add("Player_1", "ability1", "ability2", "ability3", "ability4",1,2,3,4);
        Add("Classmate_5_1", "ability1", "ability2", "ability3", "ability4", 10, 20, 30, 40);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Add 方法 的name必须与GameObject的name一致,目前只支持4个属性和其值
    public static void Add(string name,string str1, string str2, string str3, string str4, int a, int b, int c, int d) {
        Dictionary<string, int> dic = new Dictionary<string, int>();
        dic.Add(str1,a);
        dic.Add(str2, b);
        dic.Add(str3, c);
        dic.Add(str4, d);
        attributeMap.Add(name,dic);
    }
    
    public static Dictionary<string, int> get(string name) {
        return attributeMap[name];
    }

    public static List<string> getAbilityNames(string name) {
        List<string> result = new List<string>();
        foreach (string key in get(name).Keys) {
            result.Add(key);
        }
        return result;

    }
}
