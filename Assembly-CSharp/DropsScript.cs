using UnityEngine;

// Token: 0x02000091 RID: 145
public class DropsScript : MonoBehaviour {

  // Token: 0x06000241 RID: 577 RVA: 0x00030A58 File Offset: 0x0002EE58
  private void Start() {
    this.ID = 1;
    while (this.ID < this.DropNames.Length) {
      this.NameLabels[this.ID].text = this.DropNames[this.ID];
      this.ID++;
    }
  }

  // Token: 0x06000242 RID: 578 RVA: 0x00030AB4 File Offset: 0x0002EEB4
  private void Update() {
    if (this.InputManager.TappedUp) {
      this.Selected--;
      if (this.Selected < 1) {
        this.Selected = this.DropNames.Length - 1;
      }
      this.UpdateDesc();
    }
    if (this.InputManager.TappedDown) {
      this.Selected++;
      if (this.Selected > this.DropNames.Length - 1) {
        this.Selected = 1;
      }
      this.UpdateDesc();
    }
    if (Input.GetButtonDown("A")) {
      AudioSource component = base.GetComponent<AudioSource>();
      if (!this.Purchased[this.Selected]) {
        if (this.PromptBar.Label[0].text != string.Empty) {
          if (PlayerGlobals.PantyShots >= this.DropCosts[this.Selected]) {
            PlayerGlobals.PantyShots -= this.DropCosts[this.Selected];
            this.Purchased[this.Selected] = true;
            this.InfoChanWindow.Orders++;
            this.InfoChanWindow.ItemsToDrop[this.InfoChanWindow.Orders] = this.Selected;
            this.InfoChanWindow.DropObject();
            this.UpdateList();
            this.UpdateDesc();
            component.clip = this.InfoPurchase;
            component.Play();
            if (this.Selected == 2) {
              SchemeGlobals.SetSchemeStage(3, 2);
              this.Schemes.UpdateInstructions();
            }
          }
        } else if (PlayerGlobals.PantyShots < this.DropCosts[this.Selected]) {
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

  // Token: 0x06000243 RID: 579 RVA: 0x00030D1C File Offset: 0x0002F11C
  public void UpdateList() {
    this.ID = 1;
    while (this.ID < this.DropNames.Length) {
      UILabel uilabel = this.NameLabels[this.ID];
      if (!this.Purchased[this.ID]) {
        this.CostLabels[this.ID].text = this.DropCosts[this.ID].ToString();
        uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 1f);
      } else {
        this.CostLabels[this.ID].text = string.Empty;
        uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
      }
      this.ID++;
    }
  }

  // Token: 0x06000244 RID: 580 RVA: 0x00030E38 File Offset: 0x0002F238
  public void UpdateDesc() {
    if (!this.Purchased[this.Selected]) {
      if (PlayerGlobals.PantyShots >= this.DropCosts[this.Selected]) {
        this.PromptBar.Label[0].text = "Purchase";
        this.PromptBar.UpdateButtons();
      } else {
        this.PromptBar.Label[0].text = string.Empty;
        this.PromptBar.UpdateButtons();
      }
    } else {
      this.PromptBar.Label[0].text = string.Empty;
      this.PromptBar.UpdateButtons();
    }
    this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 200f - 25f * (float)this.Selected, this.Highlight.localPosition.z);
    this.DropIcon.mainTexture = this.DropIcons[this.Selected];
    this.DropDesc.text = this.DropDescs[this.Selected];
    this.UpdatePantyCount();
  }

  // Token: 0x06000245 RID: 581 RVA: 0x00030F60 File Offset: 0x0002F360
  public void UpdatePantyCount() {
    this.PantyCount.text = PlayerGlobals.PantyShots.ToString();
  }

  // Token: 0x040007BA RID: 1978
  public InfoChanWindowScript InfoChanWindow;

  // Token: 0x040007BB RID: 1979
  public InputManagerScript InputManager;

  // Token: 0x040007BC RID: 1980
  public PromptBarScript PromptBar;

  // Token: 0x040007BD RID: 1981
  public SchemesScript Schemes;

  // Token: 0x040007BE RID: 1982
  public GameObject FavorMenu;

  // Token: 0x040007BF RID: 1983
  public Transform Highlight;

  // Token: 0x040007C0 RID: 1984
  public UILabel PantyCount;

  // Token: 0x040007C1 RID: 1985
  public UITexture DropIcon;

  // Token: 0x040007C2 RID: 1986
  public UILabel DropDesc;

  // Token: 0x040007C3 RID: 1987
  public UILabel[] CostLabels;

  // Token: 0x040007C4 RID: 1988
  public UILabel[] NameLabels;

  // Token: 0x040007C5 RID: 1989
  public bool[] Purchased;

  // Token: 0x040007C6 RID: 1990
  public Texture[] DropIcons;

  // Token: 0x040007C7 RID: 1991
  public int[] DropCosts;

  // Token: 0x040007C8 RID: 1992
  public string[] DropDescs;

  // Token: 0x040007C9 RID: 1993
  public string[] DropNames;

  // Token: 0x040007CA RID: 1994
  public int Selected = 1;

  // Token: 0x040007CB RID: 1995
  public int ID = 1;

  // Token: 0x040007CC RID: 1996
  public AudioClip InfoUnavailable;

  // Token: 0x040007CD RID: 1997
  public AudioClip InfoPurchase;

  // Token: 0x040007CE RID: 1998
  public AudioClip InfoAfford;
}