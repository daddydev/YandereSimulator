using UnityEngine;

// Token: 0x020000EA RID: 234
public class GridScript : MonoBehaviour {

  // Token: 0x060004B8 RID: 1208 RVA: 0x0003D420 File Offset: 0x0003B820
  private void Start() {
    while (this.ID < this.Rows * this.Columns) {
      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Tile, new Vector3((float)this.Row, 0f, (float)this.Column), Quaternion.identity);
      gameObject.transform.parent = base.transform;
      this.Row++;
      if (this.Row > this.Rows) {
        this.Row = 1;
        this.Column++;
      }
      this.ID++;
    }
    base.transform.localScale = new Vector3(4f, 4f, 4f);
    base.transform.position = new Vector3(-52f, 0f, -52f);
  }

  // Token: 0x04000A6B RID: 2667
  public GameObject Tile;

  // Token: 0x04000A6C RID: 2668
  public int Row;

  // Token: 0x04000A6D RID: 2669
  public int Column;

  // Token: 0x04000A6E RID: 2670
  public int Rows = 25;

  // Token: 0x04000A6F RID: 2671
  public int Columns = 25;

  // Token: 0x04000A70 RID: 2672
  public int ID;
}