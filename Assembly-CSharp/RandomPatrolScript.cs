﻿using UnityEngine;

// Token: 0x02000172 RID: 370
public class RandomPatrolScript : MonoBehaviour {

  // Token: 0x060006DF RID: 1759 RVA: 0x00069958 File Offset: 0x00067D58
  private void Start() {
    for (int i = 1; i < 5; i++) {
      this.Height[i] = UnityEngine.Random.Range(1, 5);
      if (this.Height[i] == 1) {
        this.Height[i] = 0;
      } else if (this.Height[i] == 2) {
        this.Height[i] = 4;
      } else if (this.Height[i] == 3) {
        this.Height[i] = 8;
      } else if (this.Height[i] == 4) {
        this.Height[i] = 12;
      }
    }
    Transform transform = this.PatrolPoints[1];
    Transform transform2 = this.PatrolPoints[2];
    Transform transform3 = this.PatrolPoints[3];
    Transform transform4 = this.PatrolPoints[4];
    transform.position = new Vector3(UnityEngine.Random.Range(-21f, 21f), (float)this.Height[1], UnityEngine.Random.Range(21f, 19f));
    transform2.position = new Vector3(UnityEngine.Random.Range(19f, 21f), (float)this.Height[2], UnityEngine.Random.Range(29f, -37f));
    transform3.position = new Vector3(UnityEngine.Random.Range(-21f, 21f), (float)this.Height[3], UnityEngine.Random.Range(-21f, -19f));
    transform4.position = new Vector3(UnityEngine.Random.Range(-19f, -21f), (float)this.Height[4], UnityEngine.Random.Range(29f, -37f));
    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, UnityEngine.Random.Range(0f, 360f), transform.localEulerAngles.z);
    transform2.localEulerAngles = new Vector3(transform2.localEulerAngles.x, UnityEngine.Random.Range(0f, 360f), transform2.localEulerAngles.z);
    transform3.localEulerAngles = new Vector3(transform3.localEulerAngles.x, UnityEngine.Random.Range(0f, 360f), transform3.localEulerAngles.z);
    transform4.localEulerAngles = new Vector3(transform4.localEulerAngles.x, UnityEngine.Random.Range(0f, 360f), transform4.localEulerAngles.z);
  }

  // Token: 0x04001143 RID: 4419
  public Transform[] PatrolPoints;

  // Token: 0x04001144 RID: 4420
  public int[] Height;
}