using UnityEngine;

// Token: 0x02000145 RID: 325
public class ObstacleDetectorScript : MonoBehaviour {

  // Token: 0x0600060B RID: 1547 RVA: 0x00055348 File Offset: 0x00053748
  private void Start() {
    this.ControllerX.SetActive(false);
    this.KeyboardX.SetActive(false);
  }

  // Token: 0x04000E7E RID: 3710
  public YandereScript Yandere;

  // Token: 0x04000E7F RID: 3711
  public GameObject ControllerX;

  // Token: 0x04000E80 RID: 3712
  public GameObject KeyboardX;

  // Token: 0x04000E81 RID: 3713
  public Collider[] ObstacleArray;

  // Token: 0x04000E82 RID: 3714
  public int Obstacles;

  // Token: 0x04000E83 RID: 3715
  public bool Add;

  // Token: 0x04000E84 RID: 3716
  public int ID;
}