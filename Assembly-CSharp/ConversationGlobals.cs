using System.Collections.Generic;

// Token: 0x020000D5 RID: 213
public static class ConversationGlobals {

  // Token: 0x0600036E RID: 878 RVA: 0x0003AC20 File Offset: 0x00039020
  public static bool GetTopicDiscovered(int topicID) {
    return GlobalsHelper.GetBool("TopicDiscovered_" + topicID.ToString());
  }

  // Token: 0x0600036F RID: 879 RVA: 0x0003AC40 File Offset: 0x00039040
  public static void SetTopicDiscovered(int topicID, bool value) {
    string text = topicID.ToString();
    KeysHelper.AddIfMissing("TopicDiscovered_", text);
    GlobalsHelper.SetBool("TopicDiscovered_" + text, value);
  }

  // Token: 0x06000370 RID: 880 RVA: 0x0003AC77 File Offset: 0x00039077
  public static int[] KeysOfTopicDiscovered() {
    return KeysHelper.GetIntegerKeys("TopicDiscovered_");
  }

  // Token: 0x06000371 RID: 881 RVA: 0x0003AC84 File Offset: 0x00039084
  public static bool GetTopicLearnedByStudent(int topicID, int studentID) {
    return GlobalsHelper.GetBool(string.Concat(new object[]
    {
      "TopicLearnedByStudent_",
      topicID.ToString(),
      '_',
      studentID.ToString()
    }));
  }

  // Token: 0x06000372 RID: 882 RVA: 0x0003ACD4 File Offset: 0x000390D4
  public static void SetTopicLearnedByStudent(int topicID, int studentID, bool value) {
    string text = topicID.ToString();
    string text2 = studentID.ToString();
    KeysHelper.AddIfMissing("TopicLearnedByStudent_", text + '^' + text2);
    GlobalsHelper.SetBool(string.Concat(new object[]
    {
      "TopicLearnedByStudent_",
      text,
      '_',
      text2
    }), value);
  }

  // Token: 0x06000373 RID: 883 RVA: 0x0003AD40 File Offset: 0x00039140
  public static IntAndIntPair[] KeysOfTopicLearnedByStudent() {
    KeyValuePair<int, int>[] keys = KeysHelper.GetKeys<int, int>("TopicLearnedByStudent_");
    IntAndIntPair[] array = new IntAndIntPair[keys.Length];
    for (int i = 0; i < keys.Length; i++) {
      KeyValuePair<int, int> keyValuePair = keys[i];
      array[i] = new IntAndIntPair(keyValuePair.Key, keyValuePair.Value);
    }
    return array;
  }

  // Token: 0x06000374 RID: 884 RVA: 0x0003AD9C File Offset: 0x0003919C
  public static void DeleteAll() {
    Globals.DeleteCollection("TopicDiscovered_", ConversationGlobals.KeysOfTopicDiscovered());
    foreach (IntAndIntPair intAndIntPair in ConversationGlobals.KeysOfTopicLearnedByStudent()) {
      Globals.Delete(string.Concat(new object[]
      {
        "TopicLearnedByStudent_",
        intAndIntPair.first.ToString(),
        '_',
        intAndIntPair.second.ToString()
      }));
    }
    KeysHelper.Delete("TopicLearnedByStudent_");
  }

  // Token: 0x040009C9 RID: 2505
  private const string Str_TopicDiscovered = "TopicDiscovered_";

  // Token: 0x040009CA RID: 2506
  private const string Str_TopicLearnedByStudent = "TopicLearnedByStudent_";
}