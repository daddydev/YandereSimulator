using System;

// Token: 0x02000193 RID: 403
[Serializable]
public class EventSaveData {

  // Token: 0x0600072C RID: 1836 RVA: 0x0006D300 File Offset: 0x0006B700
  public static EventSaveData ReadFromGlobals() {
    return new EventSaveData {
      befriendConversation = EventGlobals.BefriendConversation,
      event1 = EventGlobals.Event1,
      event2 = EventGlobals.Event2,
      kidnapConversation = EventGlobals.KidnapConversation,
      livingRoom = EventGlobals.LivingRoom
    };
  }

  // Token: 0x0600072D RID: 1837 RVA: 0x0006D34B File Offset: 0x0006B74B
  public static void WriteToGlobals(EventSaveData data) {
    EventGlobals.BefriendConversation = data.befriendConversation;
    EventGlobals.Event1 = data.event1;
    EventGlobals.Event2 = data.event2;
    EventGlobals.KidnapConversation = data.kidnapConversation;
    EventGlobals.LivingRoom = data.livingRoom;
  }

  // Token: 0x04001222 RID: 4642
  public bool befriendConversation;

  // Token: 0x04001223 RID: 4643
  public bool event1;

  // Token: 0x04001224 RID: 4644
  public bool event2;

  // Token: 0x04001225 RID: 4645
  public bool kidnapConversation;

  // Token: 0x04001226 RID: 4646
  public bool livingRoom;
}