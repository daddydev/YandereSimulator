using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x0200011A RID: 282
[Serializable]
public class TopicJson : JsonData {

  // Token: 0x170000D1 RID: 209
  // (get) Token: 0x06000575 RID: 1397 RVA: 0x0004B0DF File Offset: 0x000494DF
  public static string FilePath {
    get {
      return Path.Combine(JsonData.FolderPath, "Topics.json");
    }
  }

  // Token: 0x06000576 RID: 1398 RVA: 0x0004B0F0 File Offset: 0x000494F0
  public static TopicJson[] LoadFromJson(string path) {
    TopicJson[] array = new TopicJson[101];
    foreach (Dictionary<string, object> d in JsonData.Deserialize(path)) {
      int num = TFUtils.LoadInt(d, "ID");
      if (num == 0) {
        break;
      }
      array[num] = new TopicJson();
      TopicJson topicJson = array[num];
      topicJson.topics = new int[26];
      for (int j = 1; j <= 25; j++) {
        topicJson.topics[j] = TFUtils.LoadInt(d, j.ToString());
      }
    }
    return array;
  }

  // Token: 0x170000D2 RID: 210
  // (get) Token: 0x06000577 RID: 1399 RVA: 0x0004B18F File Offset: 0x0004958F
  public int[] Topics {
    get {
      return this.topics;
    }
  }

  // Token: 0x04000CFB RID: 3323
  [SerializeField]
  private int[] topics;
}