using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200000A RID: 10
[AddComponentMenu("NGUI/Examples/UI Item Storage")]
public class UIItemStorage : MonoBehaviour {

  // Token: 0x17000003 RID: 3
  // (get) Token: 0x06000038 RID: 56 RVA: 0x00009488 File Offset: 0x00007888
  public List<InvGameItem> items {
    get {
      while (this.mItems.Count < this.maxItemCount) {
        this.mItems.Add(null);
      }
      return this.mItems;
    }
  }

  // Token: 0x06000039 RID: 57 RVA: 0x000094B7 File Offset: 0x000078B7
  public InvGameItem GetItem(int slot) {
    return (slot >= this.items.Count) ? null : this.mItems[slot];
  }

  // Token: 0x0600003A RID: 58 RVA: 0x000094DC File Offset: 0x000078DC
  public InvGameItem Replace(int slot, InvGameItem item) {
    if (slot < this.maxItemCount) {
      InvGameItem result = this.items[slot];
      this.mItems[slot] = item;
      return result;
    }
    return item;
  }

  // Token: 0x0600003B RID: 59 RVA: 0x00009514 File Offset: 0x00007914
  private void Start() {
    if (this.template != null) {
      int num = 0;
      Bounds bounds = default(Bounds);
      for (int i = 0; i < this.maxRows; i++) {
        for (int j = 0; j < this.maxColumns; j++) {
          GameObject gameObject = NGUITools.AddChild(base.gameObject, this.template);
          Transform transform = gameObject.transform;
          transform.localPosition = new Vector3((float)this.padding + ((float)j + 0.5f) * (float)this.spacing, (float)(-(float)this.padding) - ((float)i + 0.5f) * (float)this.spacing, 0f);
          UIStorageSlot component = gameObject.GetComponent<UIStorageSlot>();
          if (component != null) {
            component.storage = this;
            component.slot = num;
          }
          bounds.Encapsulate(new Vector3((float)this.padding * 2f + (float)((j + 1) * this.spacing), (float)(-(float)this.padding) * 2f - (float)((i + 1) * this.spacing), 0f));
          if (++num >= this.maxItemCount) {
            if (this.background != null) {
              this.background.transform.localScale = bounds.size;
            }
            return;
          }
        }
      }
      if (this.background != null) {
        this.background.transform.localScale = bounds.size;
      }
    }
  }

  // Token: 0x040000DC RID: 220
  public int maxItemCount = 8;

  // Token: 0x040000DD RID: 221
  public int maxRows = 4;

  // Token: 0x040000DE RID: 222
  public int maxColumns = 4;

  // Token: 0x040000DF RID: 223
  public GameObject template;

  // Token: 0x040000E0 RID: 224
  public UIWidget background;

  // Token: 0x040000E1 RID: 225
  public int spacing = 128;

  // Token: 0x040000E2 RID: 226
  public int padding = 10;

  // Token: 0x040000E3 RID: 227
  private List<InvGameItem> mItems = new List<InvGameItem>();
}