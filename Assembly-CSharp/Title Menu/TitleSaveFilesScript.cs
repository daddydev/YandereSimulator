using System;
using UnityEngine;

// Token: 0x020001DF RID: 479
public class TitleSaveFilesScript : MonoBehaviour {

  // Token: 0x0600089F RID: 2207 RVA: 0x0009C1B8 File Offset: 0x0009A5B8
  private void Start() {
    base.transform.localPosition = new Vector3(1050f, base.transform.localPosition.y, base.transform.localPosition.z);
    this.UpdateHighlight();
  }

  // Token: 0x060008A0 RID: 2208 RVA: 0x0009C208 File Offset: 0x0009A608
  private void Update() {
    if (!this.Show) {
      base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 1050f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
    } else {
      base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
      if (this.InputManager.TappedDown) {
        this.ID++;
        if (this.ID > 3) {
          this.ID = 1;
        }
        this.UpdateHighlight();
      }
      if (this.InputManager.TappedUp) {
        this.ID--;
        if (this.ID < 1) {
          this.ID = 3;
        }
        this.UpdateHighlight();
      }
      if (Input.GetButtonDown("A")) {
        if (this.SaveDatas[this.ID].EmptyFile.activeInHierarchy) {
          SaveFile saveFile = new SaveFile(this.ID);
          SaveFileData data = saveFile.Data;
          data.playerData.kills = 0;
          data.schoolData.schoolAtmosphere = 1f;
          data.playerData.alerts = 0;
          data.dateData.week = 1;
          data.dateData.weekday = DayOfWeek.Sunday;
          data.playerData.reputation = 0f;
          data.clubData.club = ClubType.None;
          saveFile.Save();
          this.SaveDatas[this.ID].Start();
        } else {
          SaveFileGlobals.CurrentSaveFile = this.ID;
          this.Menu.FadeOut = true;
          this.Menu.Fading = true;
        }
      } else if (Input.GetButtonDown("X")) {
        SaveFile.Delete(this.ID);
        this.SaveDatas[this.ID].Start();
      }
    }
  }

  // Token: 0x060008A1 RID: 2209 RVA: 0x0009C467 File Offset: 0x0009A867
  private void UpdateHighlight() {
    this.Highlight.localPosition = new Vector3(0f, 700f - 350f * (float)this.ID, 0f);
  }

  // Token: 0x0400199D RID: 6557
  public InputManagerScript InputManager;

  // Token: 0x0400199E RID: 6558
  public TitleSaveDataScript[] SaveDatas;

  // Token: 0x0400199F RID: 6559
  public TitleMenuScript Menu;

  // Token: 0x040019A0 RID: 6560
  public Transform Highlight;

  // Token: 0x040019A1 RID: 6561
  public bool Show;

  // Token: 0x040019A2 RID: 6562
  public int ID = 1;
}