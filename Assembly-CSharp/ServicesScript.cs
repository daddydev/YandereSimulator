using UnityEngine;

// Token: 0x020001AC RID: 428
public class ServicesScript : MonoBehaviour {

  // Token: 0x0600077A RID: 1914 RVA: 0x000706A4 File Offset: 0x0006EAA4
  private void Start() {
    for (int i = 1; i < this.ServiceNames.Length; i++) {
      SchemeGlobals.SetServicePurchased(i, false);
      this.NameLabels[i].text = this.ServiceNames[i];
    }
  }

  // Token: 0x0600077B RID: 1915 RVA: 0x000706E8 File Offset: 0x0006EAE8
  private void Update() {
    if (this.InputManager.TappedUp) {
      this.Selected--;
      if (this.Selected < 1) {
        this.Selected = this.ServiceNames.Length - 1;
      }
      this.UpdateDesc();
    }
    if (this.InputManager.TappedDown) {
      this.Selected++;
      if (this.Selected > this.ServiceNames.Length - 1) {
        this.Selected = 1;
      }
      this.UpdateDesc();
    }
    AudioSource component = base.GetComponent<AudioSource>();
    if (Input.GetButtonDown("A")) {
      if (!SchemeGlobals.GetServicePurchased(this.Selected)) {
        if (this.PromptBar.Label[0].text != string.Empty) {
          if (PlayerGlobals.PantyShots >= this.ServiceCosts[this.Selected]) {
            PlayerGlobals.PantyShots -= this.ServiceCosts[this.Selected];
            SchemeGlobals.SetServicePurchased(this.Selected, true);
            AudioSource.PlayClipAtPoint(this.InfoPurchase, base.transform.position);
            if (this.Selected == 4) {
              SchemeGlobals.SetSchemeStage(1, 2);
              this.Schemes.UpdateInstructions();
              SchemeGlobals.DarkSecret = true;
              this.TextMessageManager.SpawnMessage();
            }
            this.UpdateList();
            this.UpdateDesc();
          }
        } else if (PlayerGlobals.PantyShots < this.ServiceCosts[this.Selected]) {
          component.clip = this.InfoAfford;
          component.Play();
        } else {
          component.clip = this.InfoUnavailable;
          component.Play();
        }
      } else {
        component.clip = this.InfoUnavailable;
        component.Play();
      }
    }
    if (Input.GetButtonDown("B")) {
      this.PromptBar.ClearButtons();
      this.PromptBar.Label[0].text = "Accept";
      this.PromptBar.Label[1].text = "Exit";
      this.PromptBar.Label[5].text = "Choose";
      this.PromptBar.UpdateButtons();
      this.FavorMenu.SetActive(true);
      base.gameObject.SetActive(false);
    }
  }

  // Token: 0x0600077C RID: 1916 RVA: 0x00070928 File Offset: 0x0006ED28
  public void UpdateList() {
    this.ID = 1;
    while (this.ID < this.ServiceNames.Length) {
      this.CostLabels[this.ID].text = this.ServiceCosts[this.ID].ToString();
      bool servicePurchased = SchemeGlobals.GetServicePurchased(this.ID);
      UILabel uilabel = this.NameLabels[this.ID];
      uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, (!this.ServiceActive[this.ID] || servicePurchased) ? 0.5f : 1f);
      this.ID++;
    }
  }

  // Token: 0x0600077D RID: 1917 RVA: 0x00070A08 File Offset: 0x0006EE08
  public void UpdateDesc() {
    if (this.ServiceActive[this.Selected] && !SchemeGlobals.GetServicePurchased(this.Selected)) {
      this.PromptBar.Label[0].text = ((PlayerGlobals.PantyShots < this.ServiceCosts[this.Selected]) ? string.Empty : "Purchase");
      this.PromptBar.UpdateButtons();
    } else {
      this.PromptBar.Label[0].text = string.Empty;
      this.PromptBar.UpdateButtons();
    }
    this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 200f - 25f * (float)this.Selected, this.Highlight.localPosition.z);
    this.ServiceIcon.mainTexture = this.ServiceIcons[this.Selected];
    this.ServiceLimit.text = this.ServiceLimits[this.Selected];
    this.ServiceDesc.text = this.ServiceDescs[this.Selected];
    this.UpdatePantyCount();
  }

  // Token: 0x0600077E RID: 1918 RVA: 0x00070B38 File Offset: 0x0006EF38
  public void UpdatePantyCount() {
    this.PantyCount.text = PlayerGlobals.PantyShots.ToString();
  }

  // Token: 0x040012F0 RID: 4848
  public TextMessageManagerScript TextMessageManager;

  // Token: 0x040012F1 RID: 4849
  public InputManagerScript InputManager;

  // Token: 0x040012F2 RID: 4850
  public PromptBarScript PromptBar;

  // Token: 0x040012F3 RID: 4851
  public SchemesScript Schemes;

  // Token: 0x040012F4 RID: 4852
  public GameObject FavorMenu;

  // Token: 0x040012F5 RID: 4853
  public Transform Highlight;

  // Token: 0x040012F6 RID: 4854
  public UILabel PantyCount;

  // Token: 0x040012F7 RID: 4855
  public UITexture ServiceIcon;

  // Token: 0x040012F8 RID: 4856
  public UILabel ServiceLimit;

  // Token: 0x040012F9 RID: 4857
  public UILabel ServiceDesc;

  // Token: 0x040012FA RID: 4858
  public UILabel[] CostLabels;

  // Token: 0x040012FB RID: 4859
  public UILabel[] NameLabels;

  // Token: 0x040012FC RID: 4860
  public Texture[] ServiceIcons;

  // Token: 0x040012FD RID: 4861
  public int[] ServiceCosts;

  // Token: 0x040012FE RID: 4862
  public bool[] ServiceActive;

  // Token: 0x040012FF RID: 4863
  public string[] ServiceLimits;

  // Token: 0x04001300 RID: 4864
  public string[] ServiceDescs;

  // Token: 0x04001301 RID: 4865
  public string[] ServiceNames;

  // Token: 0x04001302 RID: 4866
  public int Selected = 1;

  // Token: 0x04001303 RID: 4867
  public int ID = 1;

  // Token: 0x04001304 RID: 4868
  public AudioClip InfoUnavailable;

  // Token: 0x04001305 RID: 4869
  public AudioClip InfoPurchase;

  // Token: 0x04001306 RID: 4870
  public AudioClip InfoAfford;
}