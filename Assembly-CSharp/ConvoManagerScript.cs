using UnityEngine;

// Token: 0x02000072 RID: 114
public class ConvoManagerScript : MonoBehaviour {

  // Token: 0x060001A4 RID: 420 RVA: 0x0001DB54 File Offset: 0x0001BF54
  public void CheckMe(int StudentID) {
    if (StudentID > 1 && StudentID < 14) {
      this.ID = 2;
      while (this.ID < 14) {
        if (this.ID != StudentID && this.SM.Students[this.ID] != null) {
          if ((double)Vector3.Distance(this.SM.Students[this.ID].transform.position, this.SM.Students[StudentID].transform.position) < 2.5) {
            this.SM.Students[StudentID].Alone = false;
            break;
          }
          this.SM.Students[StudentID].Alone = true;
        }
        this.ID++;
      }
    } else if (StudentID == 17) {
      if ((double)Vector3.Distance(this.SM.Students[17].transform.position, this.SM.Students[18].transform.position) < 1.4) {
        this.SM.Students[17].Alone = false;
      } else {
        this.SM.Students[17].Alone = true;
      }
    } else if (StudentID == 18) {
      if ((double)Vector3.Distance(this.SM.Students[18].transform.position, this.SM.Students[17].transform.position) < 1.4) {
        this.SM.Students[18].Alone = false;
      } else {
        this.SM.Students[18].Alone = true;
      }
    }
  }

  // Token: 0x04000545 RID: 1349
  public StudentManagerScript SM;

  // Token: 0x04000546 RID: 1350
  public int ID;
}