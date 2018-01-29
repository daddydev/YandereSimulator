using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000006 RID: 6
[AddComponentMenu("NGUI/Examples/Equip Random Item")]
public class EquipRandomItem : MonoBehaviour {

  // Token: 0x06000023 RID: 35 RVA: 0x00008C90 File Offset: 0x00007090
  private void OnClick() {
    if (this.equipment == null) {
      return;
    }
    List<InvBaseItem> items = InvDatabase.list[0].items;
    if (items.Count == 0) {
      return;
    }
    int max = 12;
    int num = UnityEngine.Random.Range(0, items.Count);
    InvBaseItem invBaseItem = items[num];
    InvGameItem invGameItem = new InvGameItem(num, invBaseItem);
    invGameItem.quality = (InvGameItem.Quality)UnityEngine.Random.Range(0, max);
    invGameItem.itemLevel = NGUITools.RandomRange(invBaseItem.minItemLevel, invBaseItem.maxItemLevel);
    this.equipment.Equip(invGameItem);
  }

  // Token: 0x040000CA RID: 202
  public InvEquipment equipment;
}