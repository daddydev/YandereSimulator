using UnityEngine;

// Token: 0x0200015C RID: 348
public class PoisonBottleScript : MonoBehaviour {

  // Token: 0x0600066D RID: 1645 RVA: 0x0005CD0C File Offset: 0x0005B10C
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Prompt.Yandere.TheftTimer = 1f;
      InventoryScript inventory = this.Prompt.Yandere.Inventory;
      if (this.ID == 1) {
        inventory.EmeticPoison = true;
      } else if (this.ID == 2) {
        inventory.LethalPoison = true;
      } else if (this.ID == 3) {
        inventory.RatPoison = true;
      }
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x04000F9B RID: 3995
  public PromptScript Prompt;

  // Token: 0x04000F9C RID: 3996
  public int ID;
}