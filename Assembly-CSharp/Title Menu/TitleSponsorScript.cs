using UnityEngine;

// Token: 0x020001E0 RID: 480
public class TitleSponsorScript : MonoBehaviour {

  // Token: 0x060008A3 RID: 2211 RVA: 0x0009C4A0 File Offset: 0x0009A8A0
  private void Start() {
    base.transform.localPosition = new Vector3(1050f, base.transform.localPosition.y, base.transform.localPosition.z);
    this.UpdateHighlight();
    if (GameGlobals.LoveSick) {
      this.TurnLoveSick();
    }
  }

  // Token: 0x060008A4 RID: 2212 RVA: 0x0009C4FE File Offset: 0x0009A8FE
  public int GetSponsorIndex() {
    return this.Column + this.Row * this.Columns;
  }

  // Token: 0x060008A5 RID: 2213 RVA: 0x0009C514 File Offset: 0x0009A914
  public bool SponsorHasWebsite(int index) {
    return !string.IsNullOrEmpty(this.SponsorURLs[index]);
  }

  // Token: 0x060008A6 RID: 2214 RVA: 0x0009C528 File Offset: 0x0009A928
  private void Update() {
    if (!this.Show) {
      base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 1050f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
    } else {
      base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
      if (this.InputManager.TappedUp) {
        this.Row = ((this.Row <= 0) ? (this.Rows - 1) : (this.Row - 1));
      }
      if (this.InputManager.TappedDown) {
        this.Row = ((this.Row >= this.Rows - 1) ? 0 : (this.Row + 1));
      }
      if (this.InputManager.TappedRight) {
        this.Column = ((this.Column >= this.Columns - 1) ? 0 : (this.Column + 1));
      }
      if (this.InputManager.TappedLeft) {
        this.Column = ((this.Column <= 0) ? (this.Columns - 1) : (this.Column - 1));
      }
      bool flag = this.InputManager.TappedUp || this.InputManager.TappedDown || this.InputManager.TappedRight || this.InputManager.TappedLeft;
      if (flag) {
        this.UpdateHighlight();
      }
      if (Input.GetButtonDown("A")) {
        int sponsorIndex = this.GetSponsorIndex();
        if (this.SponsorHasWebsite(sponsorIndex)) {
          Application.OpenURL(this.SponsorURLs[sponsorIndex]);
        }
      }
    }
  }

  // Token: 0x060008A7 RID: 2215 RVA: 0x0009C760 File Offset: 0x0009AB60
  private void UpdateHighlight() {
    this.Highlight.localPosition = new Vector3(-384f + (float)this.Column * 256f, 128f - (float)this.Row * 256f, this.Highlight.localPosition.z);
    this.SponsorName.text = this.Sponsors[this.GetSponsorIndex()];
  }

  // Token: 0x060008A8 RID: 2216 RVA: 0x0009C7D0 File Offset: 0x0009ABD0
  private void TurnLoveSick() {
    this.BlackSprite.color = Color.black;
    foreach (UISprite uisprite in this.RedSprites) {
      uisprite.color = new Color(1f, 0f, 0f, uisprite.color.a);
    }
    foreach (UILabel uilabel in this.Labels) {
      uilabel.color = new Color(1f, 0f, 0f, uilabel.color.a);
    }
  }

  // Token: 0x040019A3 RID: 6563
  public InputManagerScript InputManager;

  // Token: 0x040019A4 RID: 6564
  public string[] SponsorURLs;

  // Token: 0x040019A5 RID: 6565
  public string[] Sponsors;

  // Token: 0x040019A6 RID: 6566
  public UILabel SponsorName;

  // Token: 0x040019A7 RID: 6567
  public Transform Highlight;

  // Token: 0x040019A8 RID: 6568
  public bool Show;

  // Token: 0x040019A9 RID: 6569
  public int Columns;

  // Token: 0x040019AA RID: 6570
  public int Rows;

  // Token: 0x040019AB RID: 6571
  private int Column;

  // Token: 0x040019AC RID: 6572
  private int Row;

  // Token: 0x040019AD RID: 6573
  public UISprite BlackSprite;

  // Token: 0x040019AE RID: 6574
  public UISprite[] RedSprites;

  // Token: 0x040019AF RID: 6575
  public UILabel[] Labels;
}