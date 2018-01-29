using UnityEngine;

// Token: 0x02000185 RID: 389
public class RivalPhoneScript : MonoBehaviour {

  // Token: 0x06000704 RID: 1796 RVA: 0x0006BE5C File Offset: 0x0006A25C
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      SchemeGlobals.SetSchemeStage(4, 2);
      this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
      this.Prompt.Yandere.RivalPhoneTexture = this.MyRenderer.material.mainTexture;
      this.Prompt.Yandere.Inventory.RivalPhone = true;
      this.Prompt.enabled = false;
      base.enabled = false;
      base.gameObject.SetActive(false);
      this.Stolen = true;
    }
  }

  // Token: 0x040011DC RID: 4572
  public Renderer MyRenderer;

  // Token: 0x040011DD RID: 4573
  public PromptScript Prompt;

  // Token: 0x040011DE RID: 4574
  public bool LewdPhotos;

  // Token: 0x040011DF RID: 4575
  public bool Stolen;
}