using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200000F RID: 15
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Examples/Item Database")]
public class InvDatabase : MonoBehaviour {

  // Token: 0x17000005 RID: 5
  // (get) Token: 0x06000043 RID: 67 RVA: 0x000097F3 File Offset: 0x00007BF3
  public static InvDatabase[] list {
    get {
      if (InvDatabase.mIsDirty) {
        InvDatabase.mIsDirty = false;
        InvDatabase.mList = NGUITools.FindActive<InvDatabase>();
      }
      return InvDatabase.mList;
    }
  }

  // Token: 0x06000044 RID: 68 RVA: 0x00009814 File Offset: 0x00007C14
  private void OnEnable() {
    InvDatabase.mIsDirty = true;
  }

  // Token: 0x06000045 RID: 69 RVA: 0x0000981C File Offset: 0x00007C1C
  private void OnDisable() {
    InvDatabase.mIsDirty = true;
  }

  // Token: 0x06000046 RID: 70 RVA: 0x00009824 File Offset: 0x00007C24
  private InvBaseItem GetItem(int id16) {
    int i = 0;
    int count = this.items.Count;
    while (i < count) {
      InvBaseItem invBaseItem = this.items[i];
      if (invBaseItem.id16 == id16) {
        return invBaseItem;
      }
      i++;
    }
    return null;
  }

  // Token: 0x06000047 RID: 71 RVA: 0x0000986C File Offset: 0x00007C6C
  private static InvDatabase GetDatabase(int dbID) {
    int i = 0;
    int num = InvDatabase.list.Length;
    while (i < num) {
      InvDatabase invDatabase = InvDatabase.list[i];
      if (invDatabase.databaseID == dbID) {
        return invDatabase;
      }
      i++;
    }
    return null;
  }

  // Token: 0x06000048 RID: 72 RVA: 0x000098AC File Offset: 0x00007CAC
  public static InvBaseItem FindByID(int id32) {
    InvDatabase database = InvDatabase.GetDatabase(id32 >> 16);
    return (!(database != null)) ? null : database.GetItem(id32 & 65535);
  }

  // Token: 0x06000049 RID: 73 RVA: 0x000098E4 File Offset: 0x00007CE4
  public static InvBaseItem FindByName(string exact) {
    int i = 0;
    int num = InvDatabase.list.Length;
    while (i < num) {
      InvDatabase invDatabase = InvDatabase.list[i];
      int j = 0;
      int count = invDatabase.items.Count;
      while (j < count) {
        InvBaseItem invBaseItem = invDatabase.items[j];
        if (invBaseItem.name == exact) {
          return invBaseItem;
        }
        j++;
      }
      i++;
    }
    return null;
  }

  // Token: 0x0600004A RID: 74 RVA: 0x00009958 File Offset: 0x00007D58
  public static int FindItemID(InvBaseItem item) {
    int i = 0;
    int num = InvDatabase.list.Length;
    while (i < num) {
      InvDatabase invDatabase = InvDatabase.list[i];
      if (invDatabase.items.Contains(item)) {
        return invDatabase.databaseID << 16 | item.id16;
      }
      i++;
    }
    return -1;
  }

  // Token: 0x040000FE RID: 254
  private static InvDatabase[] mList;

  // Token: 0x040000FF RID: 255
  private static bool mIsDirty = true;

  // Token: 0x04000100 RID: 256
  public int databaseID;

  // Token: 0x04000101 RID: 257
  public List<InvBaseItem> items = new List<InvBaseItem>();

  // Token: 0x04000102 RID: 258
  public UIAtlas iconAtlas;
}