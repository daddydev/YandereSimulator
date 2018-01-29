using UnityEngine;

// Token: 0x0200014B RID: 331
public class PanelScript : MonoBehaviour {

  // Token: 0x0600061C RID: 1564 RVA: 0x000561D4 File Offset: 0x000545D4
  private void Update() {
    if (this.Player.position.z > this.StairsZ || this.Player.position.z < -this.StairsZ) {
      this.Floor = "Stairs";
    } else if (this.Player.position.y < this.Floor1Height) {
      this.Floor = "First Floor";
    } else if (this.Player.position.y > this.Floor1Height && this.Player.position.y < this.Floor2Height) {
      this.Floor = "Second Floor";
    } else if (this.Player.position.y > this.Floor2Height && this.Player.position.y < this.Floor3Height) {
      this.Floor = "Third Floor";
    } else {
      this.Floor = "Rooftop";
    }
    if (this.Player.position.z < this.PracticeBuildingZ) {
      this.BuildingLabel.text = "Practice Building, " + this.Floor;
    } else {
      this.BuildingLabel.text = "Classroom Building, " + this.Floor;
    }
    this.DoorBox.Show = false;
  }

  // Token: 0x04000EAA RID: 3754
  public UILabel BuildingLabel;

  // Token: 0x04000EAB RID: 3755
  public DoorBoxScript DoorBox;

  // Token: 0x04000EAC RID: 3756
  public Transform Player;

  // Token: 0x04000EAD RID: 3757
  public string Floor = string.Empty;

  // Token: 0x04000EAE RID: 3758
  public float PracticeBuildingZ;

  // Token: 0x04000EAF RID: 3759
  public float StairsZ;

  // Token: 0x04000EB0 RID: 3760
  public float Floor1Height;

  // Token: 0x04000EB1 RID: 3761
  public float Floor2Height;

  // Token: 0x04000EB2 RID: 3762
  public float Floor3Height;
}