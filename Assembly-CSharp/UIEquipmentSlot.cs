using UnityEngine;

// Token: 0x02000008 RID: 8
[AddComponentMenu("NGUI/Examples/UI Equipment Slot")]
public class UIEquipmentSlot : UIItemSlot {

  // Token: 0x17000001 RID: 1
  // (get) Token: 0x0600002C RID: 44 RVA: 0x000093F8 File Offset: 0x000077F8
  protected override InvGameItem observedItem {
    get {
      return (!(this.equipment != null)) ? null : this.equipment.GetItem(this.slot);
    }
  }

  // Token: 0x0600002D RID: 45 RVA: 0x00009422 File Offset: 0x00007822
  protected override InvGameItem Replace(InvGameItem item) {
    return (!(this.equipment != null)) ? item : this.equipment.Replace(this.slot, item);
  }

  // Token: 0x040000D1 RID: 209
  public InvEquipment equipment;

  // Token: 0x040000D2 RID: 210
  public InvBaseItem.Slot slot;
}