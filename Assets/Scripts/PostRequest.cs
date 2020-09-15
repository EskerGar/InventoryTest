using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class PostRequest : MonoBehaviour
{
    private const string URL = "https://dev3r02.elysium.today/inventory/status";
    private const string Token = "BMeHG5xqJeB4qCjpuJCTQLsqNGaqkfB6";

    public void SendPutEvent(int id)
    {
        StartCoroutine(SendPostRequest(1, "putInBackPack"));
    }

    public void SendGetOutEvent(int id)
    {
        StartCoroutine(SendPostRequest(1, "getOutOfBackPack"));
    }
    
    private IEnumerator SendPostRequest(int id, string events)
    {
        var form = new WWWForm();
        form.AddField("ID", id.ToString());
        form.AddField("Event", events);
        var www = UnityWebRequest.Post(URL, form);
        www.SetRequestHeader("AUTHORIZATION", Token);
        yield return www.SendWebRequest();
    }
}
