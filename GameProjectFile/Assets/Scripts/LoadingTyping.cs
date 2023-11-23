using System.Collections; 
using UnityEngine; 
using UnityEngine.UI; 

public class LoadingTyping : MonoBehaviour 
{ 
    public Text tx; 
    public string m_text ="Loading...";     

    void Start() 
    { 

        StartCoroutine(_typing()); 
    } 

    IEnumerator _typing() 
    { 
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < m_text.Length; i++) 
        { 
            tx.text = m_text.Substring(0, i); 
            yield return new WaitForSeconds(0.5f); 
        } 
    } 
}