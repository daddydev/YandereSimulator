using UnityEngine;

// Token: 0x020001DA RID: 474
public class TextMessageManagerScript : MonoBehaviour {

  // Token: 0x0600088C RID: 2188 RVA: 0x0009A8D8 File Offset: 0x00098CD8
  private void Update() {
    if (Input.GetButtonDown("B")) {
      UnityEngine.Object.Destroy(this.NewMessage);
      this.PromptBar.ClearButtons();
      this.PromptBar.Label[0].text = "Accept";
      this.PromptBar.Label[1].text = "Exit";
      this.PromptBar.Label[5].text = "Choose";
      this.PromptBar.UpdateButtons();
      this.PauseScreen.Sideways = true;
      this.ServicesMenu.SetActive(true);
      base.gameObject.SetActive(false);
    }
  }

  // Token: 0x0600088D RID: 2189 RVA: 0x0009A980 File Offset: 0x00098D80
  public void SpawnMessage() {
    this.PromptBar.ClearButtons();
    this.PromptBar.Label[1].text = "Exit";
    this.PromptBar.UpdateButtons();
    this.PauseScreen.Sideways = false;
    this.ServicesMenu.SetActive(false);
    base.gameObject.SetActive(true);
    if (this.NewMessage != null) {
      UnityEngine.Object.Destroy(this.NewMessage);
    }
    this.NewMessage = UnityEngine.Object.Instantiate<GameObject>(this.Message);
    this.NewMessage.transform.parent = base.transform;
    this.NewMessage.transform.localPosition = new Vector3(-225f, -275f, 0f);
    this.NewMessage.transform.localEulerAngles = Vector3.zero;
    this.NewMessage.transform.localScale = new Vector3(1f, 1f, 1f);
    this.MessageText = "You're going to love this. I've got video footage of Kokona selling used panties to a boy from another school. Enjoy.";
    this.MessageHeight = 5;
    this.NewMessage.GetComponent<UISprite>().height = 36 + 36 * this.MessageHeight;
    this.NewMessage.GetComponent<TextMessageScript>().Label.text = this.MessageText;
  }

  // Token: 0x04001945 RID: 6469
  public PauseScreenScript PauseScreen;

  // Token: 0x04001946 RID: 6470
  public PromptBarScript PromptBar;

  // Token: 0x04001947 RID: 6471
  public GameObject ServicesMenu;

  // Token: 0x04001948 RID: 6472
  private GameObject NewMessage;

  // Token: 0x04001949 RID: 6473
  public GameObject Message;

  // Token: 0x0400194A RID: 6474
  public int MessageHeight;

  // Token: 0x0400194B RID: 6475
  public string MessageText = string.Empty;
}