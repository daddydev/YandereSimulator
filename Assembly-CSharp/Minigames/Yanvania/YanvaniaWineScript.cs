using UnityEngine;

// Token: 0x02000237 RID: 567
public class YanvaniaWineScript : MonoBehaviour {

  // Token: 0x060009FA RID: 2554 RVA: 0x000B681C File Offset: 0x000B4C1C
  private void Update() {
    if (base.transform.parent == null) {
      this.Rotation += Time.deltaTime * 360f;
      base.transform.localEulerAngles = new Vector3(this.Rotation, this.Rotation, this.Rotation);
      if (base.transform.position.y < 6.5f) {
        GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Shards, new Vector3(base.transform.position.x, 6.5f, base.transform.position.z), Quaternion.identity);
        gameObject.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
        AudioSource.PlayClipAtPoint(base.GetComponent<AudioSource>().clip, base.transform.position);
        UnityEngine.Object.Destroy(base.gameObject);
      }
    }
  }

  // Token: 0x04001E1F RID: 7711
  public GameObject Shards;

  // Token: 0x04001E20 RID: 7712
  public float Rotation;
}