using JsonFx.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000117 RID: 279
public abstract class JsonData {

  // Token: 0x170000BA RID: 186
  // (get) Token: 0x0600054E RID: 1358 RVA: 0x0004ABE8 File Offset: 0x00048FE8
  protected static string FolderPath {
    get {
      return Path.Combine(Application.streamingAssetsPath, "JSON");
    }
  }

  // Token: 0x0600054F RID: 1359 RVA: 0x0004ABFC File Offset: 0x00048FFC
  protected static Dictionary<string, object>[] Deserialize(string filename) {
    string value = File.ReadAllText(filename);
    return JsonReader.Deserialize<Dictionary<string, object>[]>(value);
  }
}