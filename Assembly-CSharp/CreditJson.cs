using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000119 RID: 281
[Serializable]
public class CreditJson : JsonData {

  // Token: 0x170000CE RID: 206
  // (get) Token: 0x06000570 RID: 1392 RVA: 0x0004B04B File Offset: 0x0004944B
  public static string FilePath {
    get {
      return Path.Combine(JsonData.FolderPath, "Credits.json");
    }
  }

  // Token: 0x06000571 RID: 1393 RVA: 0x0004B05C File Offset: 0x0004945C
  public static CreditJson[] LoadFromJson(string path) {
    List<CreditJson> list = new List<CreditJson>();
    foreach (Dictionary<string, object> dictionary in JsonData.Deserialize(path)) {
      list.Add(new CreditJson {
        name = TFUtils.LoadString(dictionary, "Name"),
        size = TFUtils.LoadInt(dictionary, "Size")
      });
    }
    return list.ToArray();
  }

  // Token: 0x170000CF RID: 207
  // (get) Token: 0x06000572 RID: 1394 RVA: 0x0004B0C7 File Offset: 0x000494C7
  public string Name {
    get {
      return this.name;
    }
  }

  // Token: 0x170000D0 RID: 208
  // (get) Token: 0x06000573 RID: 1395 RVA: 0x0004B0CF File Offset: 0x000494CF
  public int Size {
    get {
      return this.size;
    }
  }

  // Token: 0x04000CF9 RID: 3321
  [SerializeField]
  private string name;

  // Token: 0x04000CFA RID: 3322
  [SerializeField]
  private int size;
}