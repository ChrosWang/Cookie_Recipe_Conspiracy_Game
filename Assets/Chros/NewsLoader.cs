using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsLoader : MonoBehaviour
{
    public TextAsset SpreadSheetJSON;
    public NewsCollection myNewsCollection = new NewsCollection(); 
    // Start is called before the first frame update
    void Start()
    {
        myNewsCollection = JsonUtility.FromJson<NewsCollection>("{\"News\":" + SpreadSheetJSON.text+"}");
        Debug.Log(myNewsCollection.News[0].Title);
        Debug.Log(myNewsCollection.News[0].Date);
        Debug.Log(myNewsCollection.News[0].Body);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
