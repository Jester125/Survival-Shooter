using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;


public class ConversationStart : MonoBehaviour
{

    [SerializeField] private NPCConversation myConversation;

    // Start is called before the first frame update
    void Start()
    {
        ConversationManager.Instance.StartConversation(myConversation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
