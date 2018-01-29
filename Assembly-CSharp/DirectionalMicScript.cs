using UnityEngine;

// Token: 0x0200008A RID: 138
public class DirectionalMicScript : MonoBehaviour {

  // Token: 0x06000229 RID: 553 RVA: 0x0002EB04 File Offset: 0x0002CF04
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      InventoryScript inventory = this.Prompt.Yandere.Inventory;
      inventory.DirectionalMic = true;
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x04000785 RID: 1925
  public PromptScript Prompt;
}