using UnityEngine;

// Token: 0x0200023B RID: 571
public class YanvaniaZombieSpawnerScript : MonoBehaviour {

  // Token: 0x06000A11 RID: 2577 RVA: 0x000B9478 File Offset: 0x000B7878
  private void Update() {
    if (this.Yanmont.transform.position.y > 0f) {
      this.ID = 0;
      this.SpawnTimer += Time.deltaTime;
      if (this.SpawnTimer > 1f) {
        while (this.ID < 4) {
          if (this.Zombies[this.ID] == null) {
            this.SpawnSide = UnityEngine.Random.Range(1, 3);
            if (this.Yanmont.transform.position.x < this.LeftBoundary + 5f) {
              this.SpawnSide = 2;
            }
            if (this.Yanmont.transform.position.x > this.RightBoundary - 5f) {
              this.SpawnSide = 1;
            }
            if (this.Yanmont.transform.position.x < this.LeftBoundary) {
              this.RelativePoint = this.LeftBoundary;
            } else if (this.Yanmont.transform.position.x > this.RightBoundary) {
              this.RelativePoint = this.RightBoundary;
            } else {
              this.RelativePoint = this.Yanmont.transform.position.x;
            }
            if (this.SpawnSide == 1) {
              this.SpawnPoints[0].x = this.RelativePoint - 2.5f;
              this.SpawnPoints[1].x = this.RelativePoint - 3.5f;
              this.SpawnPoints[2].x = this.RelativePoint - 4.5f;
              this.SpawnPoints[3].x = this.RelativePoint - 5.5f;
            } else {
              this.SpawnPoints[0].x = this.RelativePoint + 2.5f;
              this.SpawnPoints[1].x = this.RelativePoint + 3.5f;
              this.SpawnPoints[2].x = this.RelativePoint + 4.5f;
              this.SpawnPoints[3].x = this.RelativePoint + 5.5f;
            }
            this.Zombies[this.ID] = UnityEngine.Object.Instantiate<GameObject>(this.Zombie, this.SpawnPoints[this.ID], Quaternion.identity);
            this.NewZombieScript = this.Zombies[this.ID].GetComponent<YanvaniaZombieScript>();
            this.NewZombieScript.LeftBoundary = this.LeftBoundary;
            this.NewZombieScript.RightBoundary = this.RightBoundary;
            this.NewZombieScript.Yanmont = this.Yanmont;
            break;
          }
          this.ID++;
        }
        this.SpawnTimer = 0f;
      }
    }
  }

  // Token: 0x04001E9D RID: 7837
  public YanvaniaZombieScript NewZombieScript;

  // Token: 0x04001E9E RID: 7838
  public GameObject Zombie;

  // Token: 0x04001E9F RID: 7839
  public YanvaniaYanmontScript Yanmont;

  // Token: 0x04001EA0 RID: 7840
  public float SpawnTimer;

  // Token: 0x04001EA1 RID: 7841
  public float RelativePoint;

  // Token: 0x04001EA2 RID: 7842
  public float RightBoundary;

  // Token: 0x04001EA3 RID: 7843
  public float LeftBoundary;

  // Token: 0x04001EA4 RID: 7844
  public int SpawnSide;

  // Token: 0x04001EA5 RID: 7845
  public int ID;

  // Token: 0x04001EA6 RID: 7846
  public GameObject[] Zombies;

  // Token: 0x04001EA7 RID: 7847
  public Vector3[] SpawnPoints;
}