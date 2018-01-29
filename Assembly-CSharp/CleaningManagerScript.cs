using UnityEngine;

// Token: 0x02000066 RID: 102
public class CleaningManagerScript : MonoBehaviour {

  // Token: 0x0600016D RID: 365 RVA: 0x00017CE4 File Offset: 0x000160E4
  private void Start() {
    if (SchoolGlobals.RoofFence) {
      for (int i = 1; i < this.ClappingSpots.Length; i++) {
        this.ClappingSpots[i].transform.position = new Vector3(this.ClappingSpots[i].transform.position.x, this.ClappingSpots[i].transform.position.y, this.ClappingSpots[i].transform.position.z + 1f);
      }
    }
  }

  // Token: 0x0600016E RID: 366 RVA: 0x00017D80 File Offset: 0x00016180
  public void GetRole(int StudentID) {
    switch (StudentID) {
      case 1:
        this.Role = 4;
        this.Spot = this.Toilets[0];
        break;

      case 2:
        this.Role = 1;
        this.Spot = this.Windows[1];
        break;

      case 3:
        this.Role = 1;
        this.Spot = this.Windows[2];
        break;

      case 4:
        this.Role = 1;
        this.Spot = this.Windows[3];
        break;

      case 5:
        this.Role = 1;
        this.Spot = this.Windows[4];
        break;

      case 6:
        this.Role = 1;
        this.Spot = this.Windows[5];
        break;

      case 7:
        this.Role = 1;
        this.Spot = this.Windows[6];
        break;

      case 8:
        this.Role = 2;
        this.Spot = this.Desks[1];
        break;

      case 9:
        this.Role = 2;
        this.Spot = this.Desks[2];
        break;

      case 10:
        this.Role = 2;
        this.Spot = this.Desks[3];
        break;

      case 11:
        this.Role = 2;
        this.Spot = this.Desks[4];
        break;

      case 12:
        this.Role = 2;
        this.Spot = this.Desks[5];
        break;

      case 13:
        this.Role = 2;
        this.Spot = this.Desks[6];
        break;

      case 14:
        this.Role = 5;
        this.Spot = this.Rooftops[1];
        break;

      case 15:
        this.Role = 5;
        this.Spot = this.Rooftops[2];
        break;

      case 16:
        this.Role = 5;
        this.Spot = this.Rooftops[5];
        break;

      case 17:
        this.Role = 5;
        this.Spot = this.Rooftops[3];
        break;

      case 18:
        this.Role = 5;
        this.Spot = this.Rooftops[4];
        break;

      case 19:
        this.Role = 5;
        this.Spot = this.Rooftops[6];
        break;

      case 20:
        this.Role = 3;
        this.Spot = this.Floors[5];
        break;

      case 21:
        this.Role = 3;
        this.Spot = this.Floors[6];
        break;

      case 22:
        this.Role = 3;
        this.Spot = this.Floors[4];
        break;

      case 23:
        this.Role = 3;
        this.Spot = this.Floors[2];
        break;

      case 24:
        this.Role = 3;
        this.Spot = this.Floors[3];
        break;

      case 25:
        this.Role = 3;
        this.Spot = this.Floors[1];
        break;

      case 26:
        this.Role = 4;
        this.Spot = this.Toilets[6];
        break;

      case 27:
        this.Role = 4;
        this.Spot = this.Toilets[5];
        break;

      case 28:
        this.Role = 4;
        this.Spot = this.Toilets[4];
        break;

      case 29:
        this.Role = 4;
        this.Spot = this.Toilets[3];
        break;

      case 30:
        this.Role = 4;
        this.Spot = this.Toilets[2];
        break;

      case 31:
        this.Role = 4;
        this.Spot = this.Toilets[1];
        break;

      case 33:
        this.Role = 4;
        this.Spot = this.Toilets[0];
        break;
    }
  }

  // Token: 0x0400045E RID: 1118
  public Transform[] Windows;

  // Token: 0x0400045F RID: 1119
  public Transform[] Desks;

  // Token: 0x04000460 RID: 1120
  public Transform[] Floors;

  // Token: 0x04000461 RID: 1121
  public Transform[] Toilets;

  // Token: 0x04000462 RID: 1122
  public Transform[] Rooftops;

  // Token: 0x04000463 RID: 1123
  public Transform[] ClappingSpots;

  // Token: 0x04000464 RID: 1124
  public Transform Spot;

  // Token: 0x04000465 RID: 1125
  public int Role;
}