using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
///Overall settings for all both the player and code
public class Settings : MonoBehaviour
{
    ///Holds common path names for the Resources folder. Path names are kept in a text file in Resources
    public static Dictionary<string, string> CommonPathNames { get; private set; } = new Dictionary<string, string>();
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
            Debug.Log(string.Join(",", Encoding.ASCII.GetBytes(t)));
            if (!CommonPathNames.TryAdd(shorthand, t)) Debug.LogWarning("Failed to add to Settings.CommonPathNames. Naming conflict likely occured");
            else Debug.Log($"Added {shorthand} : {t}");
        }
    }
}
