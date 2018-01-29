using UnityEngine;

// Token: 0x020001D7 RID: 471
public class TaskManagerScript : MonoBehaviour {

  // Token: 0x06000880 RID: 2176 RVA: 0x00099F85 File Offset: 0x00098385
  private void Start() {
    this.UpdateTaskStatus();
  }

  // Token: 0x06000881 RID: 2177 RVA: 0x00099F90 File Offset: 0x00098390
  private void Update() {
    if (TaskGlobals.GetTaskStatus(6) == 1 && this.Prompts[6].Circle[3].fillAmount == 0f) {
      if (this.StudentManager.Students[6] != null) {
        this.StudentManager.Students[6].TaskPhase = 5;
      }
      TaskGlobals.SetTaskStatus(6, 2);
      UnityEngine.Object.Destroy(this.TaskObjects[6]);
    }
    if (TaskGlobals.GetTaskStatus(15) == 1 && this.Prompts[15].Circle[3] != null && this.Prompts[15].Circle[3].fillAmount == 0f) {
      if (this.StudentManager.Students[15] != null) {
        this.StudentManager.Students[15].TaskPhase = 5;
      }
      TaskGlobals.SetTaskStatus(15, 2);
      UnityEngine.Object.Destroy(this.TaskObjects[15]);
    }
    if (TaskGlobals.GetTaskStatus(33) == 1 && this.Prompts[33].Circle[3] != null && this.Prompts[33].Circle[3].fillAmount == 0f) {
      if (this.StudentManager.Students[33] != null) {
        this.StudentManager.Students[33].TaskPhase = 5;
      }
      TaskGlobals.SetTaskStatus(33, 2);
      UnityEngine.Object.Destroy(this.TaskObjects[33]);
    }
    if (!this.Yandere.Talking) {
      if (TaskGlobals.GetTaskStatus(32) == 1) {
        if (this.Yandere.Inventory.Cigs) {
          if (this.StudentManager.Students[32] != null) {
            this.StudentManager.Students[32].TaskPhase = 5;
          }
          TaskGlobals.SetTaskStatus(32, 2);
        }
      } else if (TaskGlobals.GetTaskStatus(32) == 2 && !this.Yandere.Inventory.Cigs) {
        if (this.StudentManager.Students[32] != null) {
          this.StudentManager.Students[32].TaskPhase = 4;
        }
        TaskGlobals.SetTaskStatus(32, 1);
      }
    }
  }

  // Token: 0x06000882 RID: 2178 RVA: 0x0009A1E0 File Offset: 0x000985E0
  public void UpdateTaskStatus() {
    if (TaskGlobals.GetTaskStatus(6) == 1) {
      if (this.StudentManager.Students[6] != null) {
        if (this.StudentManager.Students[6].TaskPhase == 0) {
          this.StudentManager.Students[6].TaskPhase = 4;
        }
        this.TaskObjects[6].SetActive(true);
      }
    } else if (this.TaskObjects[6] != null) {
      this.TaskObjects[6].SetActive(false);
    }
    if (TaskGlobals.GetTaskStatus(7) == 1 && this.StudentManager.Students[7] != null && this.StudentManager.Students[7].TaskPhase == 0) {
      this.StudentManager.Students[7].TaskPhase = 4;
    }
    if (TaskGlobals.GetTaskStatus(13) == 1 && this.StudentManager.Students[13] != null) {
      this.StudentManager.Students[13].TaskPhase = 4;
      for (int i = 1; i < 26; i++) {
        if (TaskGlobals.GetKittenPhoto(i)) {
          this.StudentManager.Students[13].TaskPhase = 5;
        }
      }
    }
    if (TaskGlobals.GetTaskStatus(14) == 1) {
      if (this.StudentManager.Students[14] != null && this.StudentManager.Students[14].TaskPhase == 0) {
        this.StudentManager.Students[14].TaskPhase = 4;
      }
    } else if (TaskGlobals.GetTaskStatus(14) == 2 && this.StudentManager.Students[14] != null) {
      this.StudentManager.Students[14].TaskPhase = 5;
    }
    if (TaskGlobals.GetTaskStatus(15) == 1) {
      if (this.StudentManager.Students[15] != null) {
        if (this.StudentManager.Students[15].TaskPhase == 0) {
          this.StudentManager.Students[15].TaskPhase = 4;
        }
        this.TaskObjects[15].SetActive(true);
      }
    } else if (this.TaskObjects[15] != null) {
      this.TaskObjects[15].SetActive(false);
    }
    if (TaskGlobals.GetTaskStatus(32) == 3) {
    }
    if (TaskGlobals.GetTaskStatus(33) == 1) {
      if (this.StudentManager.Students[33] != null) {
        if (this.StudentManager.Students[33].TaskPhase == 0) {
          this.StudentManager.Students[33].TaskPhase = 4;
        }
        this.TaskObjects[33].SetActive(true);
      }
    } else if (this.TaskObjects[33] != null) {
      this.TaskObjects[33].SetActive(false);
    }
  }

  // Token: 0x0400192E RID: 6446
  public StudentManagerScript StudentManager;

  // Token: 0x0400192F RID: 6447
  public YandereScript Yandere;

  // Token: 0x04001930 RID: 6448
  public GameObject[] TaskObjects;

  // Token: 0x04001931 RID: 6449
  public PromptScript[] Prompts;
}