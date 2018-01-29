using UnityEngine;

// Token: 0x020001C3 RID: 451
public class StolenPhoneSpotScript : MonoBehaviour {

  // Token: 0x060007D4 RID: 2004 RVA: 0x000786E4 File Offset: 0x00076AE4
  private void Update() {
    if (SchemeGlobals.GetSchemeStage(4) > 1) {
      this.Prompt.enabled = true;
      if (this.Prompt.Circle[0].fillAmount == 0f) {
        if (SchemeGlobals.GetSchemeStage(4) == 3) {
          SchemeGlobals.SetSchemeStage(4, 4);
        }
        this.Prompt.Yandere.SmartphoneRenderer.material.mainTexture = this.Prompt.Yandere.YanderePhoneTexture;
        this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
        this.Prompt.Yandere.Inventory.RivalPhone = false;
        this.Prompt.Yandere.RivalPhone = false;
        this.RivalPhone.transform.parent = null;
        this.RivalPhone.transform.position = base.transform.position;
        this.RivalPhone.transform.eulerAngles = base.transform.eulerAngles;
        this.RivalPhone.SetActive(true);
        UnityEngine.Object.Destroy(base.gameObject);
      }
    }
  }

  // Token: 0x04001414 RID: 5140
  public PromptScript Prompt;

  // Token: 0x04001415 RID: 5141
  public GameObject RivalPhone;
}