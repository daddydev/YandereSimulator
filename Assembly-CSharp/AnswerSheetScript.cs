using System;
using UnityEngine;

// Token: 0x0200002F RID: 47
public class AnswerSheetScript : MonoBehaviour {

  // Token: 0x060000AD RID: 173 RVA: 0x0000C170 File Offset: 0x0000A570
  private void Start() {
    this.OriginalMesh = this.MyMesh.mesh;
    if (SchemeGlobals.GetSchemeStage(5) == 100) {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      base.gameObject.SetActive(false);
    } else {
      if (SchemeGlobals.GetSchemeStage(5) > 4) {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
      if (DateGlobals.Weekday == DayOfWeek.Friday && this.Clock.HourTime > 13.5f) {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        base.gameObject.SetActive(false);
      }
    }
  }

  // Token: 0x060000AE RID: 174 RVA: 0x0000C22C File Offset: 0x0000A62C
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      if (this.Phase == 1) {
        SchemeGlobals.SetSchemeStage(5, 2);
        this.Schemes.UpdateInstructions();
        this.Prompt.Yandere.Inventory.AnswerSheet = true;
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        this.DoorGap.Prompt.enabled = true;
        this.MyMesh.mesh = null;
        this.Phase++;
      } else {
        SchemeGlobals.SetSchemeStage(5, 5);
        this.Schemes.UpdateInstructions();
        this.Prompt.Yandere.Inventory.AnswerSheet = false;
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        this.MyMesh.mesh = this.OriginalMesh;
        this.Phase++;
      }
    }
  }

  // Token: 0x0400029C RID: 668
  public SchemesScript Schemes;

  // Token: 0x0400029D RID: 669
  public DoorGapScript DoorGap;

  // Token: 0x0400029E RID: 670
  public PromptScript Prompt;

  // Token: 0x0400029F RID: 671
  public ClockScript Clock;

  // Token: 0x040002A0 RID: 672
  public Mesh OriginalMesh;

  // Token: 0x040002A1 RID: 673
  public MeshFilter MyMesh;

  // Token: 0x040002A2 RID: 674
  public int Phase = 1;
}