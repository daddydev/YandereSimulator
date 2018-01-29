using UnityEngine;

// Token: 0x0200006D RID: 109
public class CollectibleScript : MonoBehaviour {

  // Token: 0x06000189 RID: 393 RVA: 0x0001A890 File Offset: 0x00018C90
  private void Start() {
    bool flag = (this.CollectibleType == CollectibleType.BasementTape && CollectibleGlobals.GetBasementTapeCollected(this.ID)) || (this.CollectibleType == CollectibleType.Manga && CollectibleGlobals.GetMangaCollected(this.ID)) || (this.CollectibleType == CollectibleType.Tape && CollectibleGlobals.GetTapeCollected(this.ID));
    if (flag) {
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x1700001C RID: 28
  // (get) Token: 0x0600018A RID: 394 RVA: 0x0001A904 File Offset: 0x00018D04
  public CollectibleType CollectibleType {
    get {
      if (this.Name == "BasementTape") {
        return CollectibleType.BasementTape;
      }
      if (this.Name == "Manga") {
        return CollectibleType.Manga;
      }
      if (this.Name == "Tape") {
        return CollectibleType.Tape;
      }
      Debug.LogError("Unrecognized collectible \"" + this.Name + "\".", base.gameObject);
      return CollectibleType.Tape;
    }
  }

  // Token: 0x0600018B RID: 395 RVA: 0x0001A978 File Offset: 0x00018D78
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      if (this.CollectibleType == CollectibleType.BasementTape) {
        CollectibleGlobals.SetBasementTapeCollected(this.ID, true);
      } else if (this.CollectibleType == CollectibleType.Manga) {
        CollectibleGlobals.SetMangaCollected(this.ID, true);
      } else if (this.CollectibleType == CollectibleType.Tape) {
        CollectibleGlobals.SetTapeCollected(this.ID, true);
      } else {
        Debug.LogError("Collectible \"" + this.Name + "\" not implemented.", base.gameObject);
      }
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x040004DB RID: 1243
  public PromptScript Prompt;

  // Token: 0x040004DC RID: 1244
  public string Name = string.Empty;

  // Token: 0x040004DD RID: 1245
  public int ID;
}