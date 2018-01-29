using System;

// Token: 0x02000190 RID: 400
[Serializable]
public class ConversationSaveData {

  // Token: 0x06000723 RID: 1827 RVA: 0x0006CDF4 File Offset: 0x0006B1F4
  public static ConversationSaveData ReadFromGlobals() {
    ConversationSaveData conversationSaveData = new ConversationSaveData();
    foreach (int num in ConversationGlobals.KeysOfTopicDiscovered()) {
      if (ConversationGlobals.GetTopicDiscovered(num)) {
        conversationSaveData.topicDiscovered.Add(num);
      }
    }
    foreach (IntAndIntPair intAndIntPair in ConversationGlobals.KeysOfTopicLearnedByStudent()) {
      if (ConversationGlobals.GetTopicLearnedByStudent(intAndIntPair.first, intAndIntPair.second)) {
        conversationSaveData.topicLearnedByStudent.Add(intAndIntPair);
      }
    }
    return conversationSaveData;
  }

  // Token: 0x06000724 RID: 1828 RVA: 0x0006CE8C File Offset: 0x0006B28C
  public static void WriteToGlobals(ConversationSaveData data) {
    foreach (int topicID in data.topicDiscovered) {
      ConversationGlobals.SetTopicDiscovered(topicID, true);
    }
    foreach (IntAndIntPair intAndIntPair in data.topicLearnedByStudent) {
      ConversationGlobals.SetTopicLearnedByStudent(intAndIntPair.first, intAndIntPair.second, true);
    }
  }

  // Token: 0x04001216 RID: 4630
  public IntHashSet topicDiscovered = new IntHashSet();

  // Token: 0x04001217 RID: 4631
  public IntAndIntPairHashSet topicLearnedByStudent = new IntAndIntPairHashSet();
}