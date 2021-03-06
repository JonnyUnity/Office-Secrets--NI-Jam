using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "FluffStory-1", menuName = "Office Secrets/Email")]
public class Email : ScriptableObject, ISerializationCallbackReceiver
{

    [SerializeField] private int _id;
    [SerializeField] private int _receivedTime; // Act and Story beat.
    [SerializeField] private string _sender;
    [SerializeField] private string _subject;
    [SerializeField] [TextArea] private string _emailBody;

    [SerializeField] private bool _canReply;
    [SerializeField] [TextArea] private string _replyText;

    [SerializeField] private ResponseAction[] _replyActions;

    [SerializeField] public List<Condition> Conditions;
    [SerializeField] private bool _advanceStoryOnClose;

    public bool _isRead;
    
    [NonSerialized] public bool IsRead;

    public int ID => _id;
    public int ReceivedTime => _receivedTime;
    public string Sender => _sender;
    public string Subject => _subject;
    public string EmailBody => _emailBody;
    public bool CanReply => _canReply;
    public string ReplyText => _replyText;
    public ResponseAction[] ReplyActions => _replyActions;
    public bool AdvanceStoryOnClose => _advanceStoryOnClose;


    public bool ShouldInclude()
    {
        if (Conditions.Count() == 0)
            return true;

        return Conditions.All(x => x.IsMet());

    }

    public void OnAfterDeserialize()
    {
        IsRead = _isRead;
    }

    public void OnBeforeSerialize()
    {
    }
}
