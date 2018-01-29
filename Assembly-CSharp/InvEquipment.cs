using UnityEngine;

// Token: 0x02000010 RID: 16
[AddComponentMenu("NGUI/Examples/Equipment")]
public class InvEquipment : MonoBehaviour {

  // Token: 0x17000006 RID: 6
  // (get) Token: 0x0600004D RID: 77 RVA: 0x000099BA File Offset: 0x00007DBA
  public InvGameItem[] equippedItems {
    get {
      return this.mItems;
    }
  }

  // Token: 0x0600004E RID: 78 RVA: 0x000099C4 File Offset: 0x00007DC4
  public InvGameItem Replace(InvBaseItem.Slot slot, InvGameItem item) {
    InvBaseItem invBaseItem = (item == null) ? null : item.baseItem;
    if (slot == InvBaseItem.Slot.None) {
      if (item != null) {
        Debug.LogWarning("Can't equip \"" + item.name + "\" because it doesn't specify an item slot");
      }
      return item;
    }
    if (invBaseItem != null && invBaseItem.slot != slot) {
      return item;
    }
    if (this.mItems == null) {
      int num = 8;
      this.mItems = new InvGameItem[num];
    }
    InvGameItem result = this.mItems[slot - InvBaseItem.Slot.Weapon];
    this.mItems[slot - InvBaseItem.Slot.Weapon] = item;
    if (this.mAttachments == null) {
      this.mAttachments = base.GetComponentsInChildren<InvAttachmentPoint>();
    }
    int i = 0;
    int num2 = this.mAttachments.Length;
    while (i < num2) {
      InvAttachmentPoint invAttachmentPoint = this.mAttachments[i];
      if (invAttachmentPoint.slot == slot) {
        GameObject gameObject = invAttachmentPoint.Attach((invBaseItem == null) ? null : invBaseItem.attachment);
        if (invBaseItem != null && gameObject != null) {
          Renderer component = gameObject.GetComponent<Renderer>();
          if (component != null) {
            component.material.color = invBaseItem.color;
          }
        }
      }
      i++;
    }
    return result;
  }

  // Token: 0x0600004F RID: 79 RVA: 0x00009AF4 File Offset: 0x00007EF4
  public InvGameItem Equip(InvGameItem item) {
    if (item != null) {
      InvBaseItem baseItem = item.baseItem;
      if (baseItem != null) {
        return this.Replace(baseItem.slot, item);
      }
      Debug.LogWarning("Can't resolve the item ID of " + item.baseItemID);
    }
    return item;
  }

  // Token: 0x06000050 RID: 80 RVA: 0x00009B40 File Offset: 0x00007F40
  public InvGameItem Unequip(InvGameItem item) {
    if (item != null) {
      InvBaseItem baseItem = item.baseItem;
      if (baseItem != null) {
        return this.Replace(baseItem.slot, null);
      }
    }
    return item;
  }

  // Token: 0x06000051 RID: 81 RVA: 0x00009B6F File Offset: 0x00007F6F
  public InvGameItem Unequip(InvBaseItem.Slot slot) {
    return this.Replace(slot, null);
  }

  // Token: 0x06000052 RID: 82 RVA: 0x00009B7C File Offset: 0x00007F7C
  public bool HasEquipped(InvGameItem item) {
    if (this.mItems != null) {
      int i = 0;
      int num = this.mItems.Length;
      while (i < num) {
        if (this.mItems[i] == item) {
          return true;
        }
        i++;
      }
    }
    return false;
  }

  // Token: 0x06000053 RID: 83 RVA: 0x00009BC0 File Offset: 0x00007FC0
  public bool HasEquipped(InvBaseItem.Slot slot) {
    if (this.mItems != null) {
      int i = 0;
      int num = this.mItems.Length;
      while (i < num) {
        InvBaseItem baseItem = this.mItems[i].baseItem;
        if (baseItem != null && baseItem.slot == slot) {
          return true;
        }
        i++;
      }
    }
    return false;
  }

  // Token: 0x06000054 RID: 84 RVA: 0x00009C18 File Offset: 0x00008018
  public InvGameItem GetItem(InvBaseItem.Slot slot) {
    if (slot != InvBaseItem.Slot.None) {
      int num = slot - InvBaseItem.Slot.Weapon;
      if (this.mItems != null && num < this.mItems.Length) {
        return this.mItems[num];
      }
    }
    return null;
  }

  // Token: 0x04000103 RID: 259
  private InvGameItem[] mItems;

  // Token: 0x04000104 RID: 260
  private InvAttachmentPoint[] mAttachments;
}