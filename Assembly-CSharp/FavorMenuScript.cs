using UnityEngine;

// Token: 0x020000BE RID: 190
public class FavorMenuScript : MonoBehaviour {

  // Token: 0x060002DB RID: 731 RVA: 0x00036A78 File Offset: 0x00034E78
  private void Update() {
    if (this.InputManager.TappedRight) {
      this.ID++;
      this.UpdateHighlight();
    } else if (this.InputManager.TappedLeft) {
      this.ID--;
      this.UpdateHighlight();
    }
    if (Input.GetButtonDown("A")) {
      this.PromptBar.ClearButtons();
      this.PromptBar.Label[0].text = "Accept";
      this.PromptBar.Label[1].text = "Exit";
      this.PromptBar.Label[4].text = "Choose";
      this.PromptBar.UpdateButtons();
      if (this.ID == 1) {
        this.SchemesMenu.UpdatePantyCount();
        this.SchemesMenu.UpdateSchemeList();
        this.SchemesMenu.UpdateSchemeInfo();
        this.SchemesMenu.gameObject.SetActive(true);
        base.gameObject.SetActive(false);
      } else if (this.ID == 2) {
        this.ServicesMenu.UpdatePantyCount();
        this.ServicesMenu.UpdateList();
        this.ServicesMenu.UpdateDesc();
        this.ServicesMenu.gameObject.SetActive(true);
        base.gameObject.SetActive(false);
      } else if (this.ID == 3) {
        this.DropsMenu.UpdatePantyCount();
        this.DropsMenu.UpdateList();
        this.DropsMenu.UpdateDesc();
        this.DropsMenu.gameObject.SetActive(true);
        base.gameObject.SetActive(false);
      }
    }
    if (Input.GetButtonDown("B")) {
      this.PromptBar.ClearButtons();
      this.PromptBar.Label[0].text = "Accept";
      this.PromptBar.Label[1].text = "Exit";
      this.PromptBar.Label[4].text = "Choose";
      this.PromptBar.UpdateButtons();
      this.PauseScreen.MainMenu.SetActive(true);
      this.PauseScreen.Sideways = false;
      this.PauseScreen.PressedB = true;
      base.gameObject.SetActive(false);
    }
  }

  // Token: 0x060002DC RID: 732 RVA: 0x00036CC4 File Offset: 0x000350C4
  private void UpdateHighlight() {
    if (this.ID > 3) {
      this.ID = 1;
    } else if (this.ID < 1) {
      this.ID = 3;
    }
    this.Highlight.transform.localPosition = new Vector3(-500f + 250f * (float)this.ID, this.Highlight.transform.localPosition.y, this.Highlight.transform.localPosition.z);
  }

  // Token: 0x0400091B RID: 2331
  public InputManagerScript InputManager;

  // Token: 0x0400091C RID: 2332
  public PauseScreenScript PauseScreen;

  // Token: 0x0400091D RID: 2333
  public ServicesScript ServicesMenu;

  // Token: 0x0400091E RID: 2334
  public SchemesScript SchemesMenu;

  // Token: 0x0400091F RID: 2335
  public DropsScript DropsMenu;

  // Token: 0x04000920 RID: 2336
  public PromptBarScript PromptBar;

  // Token: 0x04000921 RID: 2337
  public Transform Highlight;

  // Token: 0x04000922 RID: 2338
  public int ID = 1;
}