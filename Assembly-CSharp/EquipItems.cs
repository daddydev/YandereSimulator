using UnityEngine;

// Token: 0x02000005 RID: 5
[AddComponentMenu("NGUI/Examples/Equip Items")]
public class EquipItems : MonoBehaviour {

  // Token: 0x06000021 RID: 33 RVA: 0x00008BAC File Offset: 0x00006FAC
  private void Start() {
    if (this.itemIDs != null && this.itemIDs.Length > 0) {
      InvEquipment invEquipment = base.GetComponent<InvEquipment>();
      if (invEquipment == null) {
        invEquipment = base.gameObject.AddComponent<InvEquipment>();
      }
      int max = 12;
      int i = 0;
      int num = this.itemIDs.Length;
      while (i < num) {
        int num2 = this.itemIDs[i];
        InvBaseItem invBaseItem = InvDatabase.FindByID(num2);
        if (invBaseItem != null) {
          invEquipment.Equip(new InvGameItem(num2, invBaseItem) {
            quality = (InvGameItem.Quality)UnityEngine.Random.Range(0, max),
            itemLevel = NGUITools.RandomRange(invBaseItem.minItemLevel, invBaseItem.maxItemLevel)
          });
        } else {
          Debug.LogWarning("Can't resolve the item ID of " + num2);
        }
        i++;
      }
    }
    UnityEngine.Object.Destroy(this);
  }

  // Token: 0x040000C9 RID: 201
  public int[] itemIDs;
}