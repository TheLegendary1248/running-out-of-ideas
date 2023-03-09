using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
///Overall settings for all both the player and code
public class Settings : MonoBehaviour
{
    ///<summary>The settings of the game, such as volume and such</summary>
    public static Dictionary<string, object> settings { get; set; } = new Dictionary<string, object>();
    ///<summary>Holds common path names for the Resources folder. Path names are kept in a text file in Resources</summary>
    public static Dictionary<string, string> commonPathNames { get; private set; } = new Dictionary<string, string>();
    [RuntimeInitializeOnLoadMethod]
    static void GetPaths()
    {
        TextAsset txt = Resources.Load<TextAsset>("Misc/ResourcesPaths");
        //Debug.Log(txt);
        var lines = txt.text.Split(new char[] {'\n','\r'}, System.StringSplitOptions.RemoveEmptyEntries);
        foreach (var t in lines)
        {
            string[] split = t.Split("/");
            string shorthand = split[split.Length - 1];
            if (!commonPathNames.TryAdd(shorthand, t)) Debug.LogWarning("Failed to add to Settings.commonPathNames. Naming conflict likely occured");
            //else Debug.Log($"Added {shorthand} : {t}");
        }
    }
}
