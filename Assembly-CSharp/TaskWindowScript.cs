using UnityEngine;

// Token: 0x020001D8 RID: 472
public class TaskWindowScript : MonoBehaviour {

  // Token: 0x06000884 RID: 2180 RVA: 0x0009A4E1 File Offset: 0x000988E1
  private void Start() {
    this.Window.SetActive(false);
  }

  // Token: 0x06000885 RID: 2181 RVA: 0x0009A4F0 File Offset: 0x000988F0
  public void UpdateWindow(int ID) {
    this.PromptBar.ClearButtons();
    this.PromptBar.Label[0].text = "Accept";
    this.PromptBar.Label[1].text = "Refuse";
    this.PromptBar.UpdateButtons();
    this.PromptBar.Show = true;
    this.TaskDescLabel.transform.parent.gameObject.SetActive(true);
    this.TaskDescLabel.text = this.Descriptions[ID];
    this.Icon.mainTexture = this.Icons[ID];
    this.Window.SetActive(true);
    this.GetPortrait(ID);
    this.StudentID = ID;
  }

  // Token: 0x06000886 RID: 2182 RVA: 0x0009A5A8 File Offset: 0x000989A8
  private void Update() {
    if (this.Window.activeInHierarchy) {
      if (Input.GetButtonDown("A")) {
        TaskGlobals.SetTaskStatus(this.StudentID, 1);
        this.Yandere.TargetStudent.TalkTimer = 100f;
        this.Yandere.TargetStudent.Interaction = StudentInteractionType.GivingTask;
        this.Yandere.TargetStudent.TaskPhase = 4;
        this.PromptBar.ClearButtons();
        this.PromptBar.Show = false;
        this.Window.SetActive(false);
      } else if (Input.GetButtonDown("B")) {
        this.Yandere.TargetStudent.TalkTimer = 100f;
        this.Yandere.TargetStudent.Interaction = StudentInteractionType.GivingTask;
        this.Yandere.TargetStudent.TaskPhase = 0;
        this.PromptBar.ClearButtons();
        this.PromptBar.Show = false;
        this.Window.SetActive(false);
      }
    }
    if (this.TaskComplete) {
      if (this.TrueTimer == 0f) {
        base.GetComponent<AudioSource>().Play();
      }
      this.TrueTimer += Time.deltaTime;
      this.Timer += Time.deltaTime;
      if (this.ID < this.TaskCompleteLetters.Length && this.Timer > 0.05f) {
        this.TaskCompleteLetters[this.ID].SetActive(true);
        this.Timer = 0f;
        this.ID++;
      }
      if (this.TaskCompleteLetters[12].transform.localPosition.y < -725f) {
        this.ID = 0;
        while (this.ID < this.TaskCompleteLetters.Length) {
          this.TaskCompleteLetters[this.ID].GetComponent<GrowShrinkScript>().Return();
          this.ID++;
        }
        this.TaskCheck();
        this.DialogueWheel.End();
        this.TaskComplete = false;
        this.TrueTimer = 0f;
        this.Timer = 0f;
        this.ID = 0;
      }
    }
  }

  // Token: 0x06000887 RID: 2183 RVA: 0x0009A7DF File Offset: 0x00098BDF
  private void TaskCheck() {
    if (this.Yandere.TargetStudent.StudentID == 15) {
      this.DialogueWheel.Yandere.TargetStudent.Cosmetic.MaleAccessories[1].SetActive(true);
    }
  }

  // Token: 0x06000888 RID: 2184 RVA: 0x0009A81C File Offset: 0x00098C1C
  private void GetPortrait(int ID) {
    string url = string.Concat(new string[]
    {
      "file:///",
      Application.streamingAssetsPath,
      "/Portraits/Student_",
      ID.ToString(),
      ".png"
    });
    WWW www = new WWW(url);
    this.Portrait.mainTexture = www.texture;
  }

  // Token: 0x04001932 RID: 6450
  public DialogueWheelScript DialogueWheel;

  // Token: 0x04001933 RID: 6451
  public TaskManagerScript TaskManager;

  // Token: 0x04001934 RID: 6452
  public PromptBarScript PromptBar;

  // Token: 0x04001935 RID: 6453
  public UILabel TaskDescLabel;

  // Token: 0x04001936 RID: 6454
  public YandereScript Yandere;

  // Token: 0x04001937 RID: 6455
  public UITexture Portrait;

  // Token: 0x04001938 RID: 6456
  public UITexture Icon;

  // Token: 0x04001939 RID: 6457
  public GameObject[] TaskCompleteLetters;

  // Token: 0x0400193A RID: 6458
  public string[] Descriptions;

  // Token: 0x0400193B RID: 6459
  public Texture[] Portraits;

  // Token: 0x0400193C RID: 6460
  public Texture[] Icons;

  // Token: 0x0400193D RID: 6461
  public bool TaskComplete;

  // Token: 0x0400193E RID: 6462
  public GameObject Window;

  // Token: 0x0400193F RID: 6463
  public int StudentID;

  // Token: 0x04001940 RID: 6464
  public int ID;

  // Token: 0x04001941 RID: 6465
  public float TrueTimer;

  // Token: 0x04001942 RID: 6466
  public float Timer;
}