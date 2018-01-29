using System.Collections;
using UnityEngine;

// Token: 0x020001D6 RID: 470
public class TaskListScript : MonoBehaviour {

  // Token: 0x0600087C RID: 2172 RVA: 0x00099B90 File Offset: 0x00097F90
  private void Update() {
    if (this.InputManager.TappedUp) {
      this.ID--;
      if (this.ID < 1) {
        this.ID = 16;
      }
      base.StartCoroutine(this.UpdateTaskInfo());
    }
    if (this.InputManager.TappedDown) {
      this.ID++;
      if (this.ID > 16) {
        this.ID = 1;
      }
      base.StartCoroutine(this.UpdateTaskInfo());
    }
    if (Input.GetButtonDown("B")) {
      this.PauseScreen.PromptBar.ClearButtons();
      this.PauseScreen.PromptBar.Label[0].text = "Accept";
      this.PauseScreen.PromptBar.Label[1].text = "Back";
      this.PauseScreen.PromptBar.Label[4].text = "Choose";
      this.PauseScreen.PromptBar.Label[5].text = "Choose";
      this.PauseScreen.PromptBar.UpdateButtons();
      this.PauseScreen.Sideways = false;
      this.PauseScreen.PressedB = true;
      this.MainMenu.SetActive(true);
      base.gameObject.SetActive(false);
    }
  }

  // Token: 0x0600087D RID: 2173 RVA: 0x00099CEC File Offset: 0x000980EC
  public void UpdateTaskList() {
    for (int i = 1; i < this.TaskNames.Length; i++) {
      this.TaskNameLabels[i].text = ((TaskGlobals.GetTaskStatus(i) != 0) ? this.TaskNames[i] : "?????");
      this.Checkmarks[i].enabled = (TaskGlobals.GetTaskStatus(i) == 3);
    }
  }

  // Token: 0x0600087E RID: 2174 RVA: 0x00099D54 File Offset: 0x00098154
  public IEnumerator UpdateTaskInfo() {
    this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 200f - 25f * (float)this.ID, this.Highlight.localPosition.z);
    if (TaskGlobals.GetTaskStatus(this.ID) == 0) {
      this.StudentIcon.mainTexture = this.Silhouette;
      this.TaskIcon.mainTexture = this.QuestionMark;
      this.TaskDesc.text = "This task has not been discovered yet.";
    } else {
      string path = string.Concat(new string[]
      {
        "file:///",
        Application.streamingAssetsPath,
        "/Portraits/Student_",
        this.ID.ToString(),
        ".png"
      });
      WWW www = new WWW(path);
      yield return www;
      this.StudentIcon.mainTexture = www.texture;
      this.TaskIcon.mainTexture = this.TaskIcons[this.ID];
      this.TaskDesc.text = this.TaskDescs[this.ID];
    }
    yield break;
  }

  // Token: 0x0400191F RID: 6431
  public InputManagerScript InputManager;

  // Token: 0x04001920 RID: 6432
  public PauseScreenScript PauseScreen;

  // Token: 0x04001921 RID: 6433
  public GameObject MainMenu;

  // Token: 0x04001922 RID: 6434
  public UITexture StudentIcon;

  // Token: 0x04001923 RID: 6435
  public UITexture TaskIcon;

  // Token: 0x04001924 RID: 6436
  public UILabel TaskDesc;

  // Token: 0x04001925 RID: 6437
  public Texture QuestionMark;

  // Token: 0x04001926 RID: 6438
  public Transform Highlight;

  // Token: 0x04001927 RID: 6439
  public Texture Silhouette;

  // Token: 0x04001928 RID: 6440
  public UILabel[] TaskNameLabels;

  // Token: 0x04001929 RID: 6441
  public UISprite[] Checkmarks;

  // Token: 0x0400192A RID: 6442
  public Texture[] TaskIcons;

  // Token: 0x0400192B RID: 6443
  public string[] TaskDescs;

  // Token: 0x0400192C RID: 6444
  public string[] TaskNames;

  // Token: 0x0400192D RID: 6445
  public int ID = 1;
}