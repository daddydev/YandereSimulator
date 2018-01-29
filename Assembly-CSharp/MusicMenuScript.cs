using System.Collections;
using UnityEngine;

// Token: 0x02000139 RID: 313
public class MusicMenuScript : MonoBehaviour {

  // Token: 0x060005DE RID: 1502 RVA: 0x00051C8C File Offset: 0x0005008C
  private void Update() {
    if (this.InputManager.TappedUp) {
      this.Selected--;
      this.UpdateHighlight();
    } else if (this.InputManager.TappedDown) {
      this.Selected++;
      this.UpdateHighlight();
    }
    if (Input.GetButtonDown("A")) {
      base.StartCoroutine(this.DownloadCoroutine());
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

  // Token: 0x060005DF RID: 1503 RVA: 0x00051DA4 File Offset: 0x000501A4
  private IEnumerator DownloadCoroutine() {
    WWW CurrentDownload = new WWW(string.Concat(new object[]
    {
      "File:///",
      Application.streamingAssetsPath,
      "/Music/track",
      this.Selected,
      ".ogg"
    }));
    yield return CurrentDownload;
    this.CustomMusic = CurrentDownload.GetAudioClipCompressed();
    this.Jukebox.Custom.clip = this.CustomMusic;
    this.Jukebox.PlayCustom();
    yield break;
  }

  // Token: 0x060005E0 RID: 1504 RVA: 0x00051DC0 File Offset: 0x000501C0
  private void UpdateHighlight() {
    if (this.Selected < 0) {
      this.Selected = this.SelectionLimit;
    } else if (this.Selected > this.SelectionLimit) {
      this.Selected = 0;
    }
    this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 365f - 80f * (float)this.Selected, this.Highlight.localPosition.z);
  }

  // Token: 0x04000DFC RID: 3580
  public InputManagerScript InputManager;

  // Token: 0x04000DFD RID: 3581
  public PauseScreenScript PauseScreen;

  // Token: 0x04000DFE RID: 3582
  public PromptBarScript PromptBar;

  // Token: 0x04000DFF RID: 3583
  public JukeboxScript Jukebox;

  // Token: 0x04000E00 RID: 3584
  public int SelectionLimit = 9;

  // Token: 0x04000E01 RID: 3585
  public int Selected;

  // Token: 0x04000E02 RID: 3586
  public Transform Highlight;

  // Token: 0x04000E03 RID: 3587
  public string path = string.Empty;

  // Token: 0x04000E04 RID: 3588
  public AudioClip CustomMusic;
}