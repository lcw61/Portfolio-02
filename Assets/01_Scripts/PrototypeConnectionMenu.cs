using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(NetworkManager))]
public class PrototypeConnectionMenu : MonoBehaviour
{
    private NetworkManager networkManager;

#if UNITY_EDITOR
    [SerializeField] private bool autoStartHostInEditor = true;

    private void Start()
    {
        if (autoStartHostInEditor && !networkManager.IsListening)
            networkManager.StartHost();
    }
#endif

    private void Awake()
    {
        networkManager = GetComponent<NetworkManager>();
    }

    private void OnGUI()
    {
        if (networkManager.IsListening)
            return;

        GUILayout.BeginArea(new Rect(12, 12, 160, 90));

        if (GUILayout.Button("Start Client"))
            networkManager.StartClient();

        GUILayout.EndArea();
    }
}
