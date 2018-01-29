using UnityEngine;

// Token: 0x0200000B RID: 11
[AddComponentMenu("NGUI/Examples/UI Storage Slot")]
public class UIStorageSlot : UIItemSlot {

  // Token: 0x17000004 RID: 4
  // (get) Token: 0x0600003D RID: 61 RVA: 0x0000969B File Offset: 0x00007A9B
  protected override InvGameItem observedItem {
    get {
      return (!(this.storage != null)) ? null : this.storage.GetItem(this.slot);
    }
  }

  // Token: 0x0600003E RID: 62 RVA: 0x000096C5 File Offset: 0x00007AC5
  protected override InvGameItem Replace(InvGameItem item) {
    return (!(this.storage != null)) ? item : this.storage.Replace(this.slot, item);
  }

  // Token: 0x040000E4 RID: 228
  public UIItemStorage storage;

  // Token: 0x040000E5 RID: 229
  public int slot;
}