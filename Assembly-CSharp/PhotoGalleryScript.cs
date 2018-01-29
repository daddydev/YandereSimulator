using System.Collections;
using UnityEngine;

// Token: 0x02000156 RID: 342
public class PhotoGalleryScript : MonoBehaviour {

  // Token: 0x06000641 RID: 1601 RVA: 0x00059E5B File Offset: 0x0005825B
  private void Start() {
    if (this.Cursor != null) {
      this.Cursor.gameObject.SetActive(false);
      base.enabled = false;
    }
  }

  // Token: 0x170000D6 RID: 214
  // (get) Token: 0x06000642 RID: 1602 RVA: 0x00059E86 File Offset: 0x00058286
  private int CurrentIndex {
    get {
      return this.Column + (this.Row - 1) * 5;
    }
  }

  // Token: 0x170000D7 RID: 215
  // (get) Token: 0x06000643 RID: 1603 RVA: 0x00059E99 File Offset: 0x00058299
  private float LerpSpeed {
    get {
      return Time.unscaledDeltaTime * 10f;
    }
  }

  // Token: 0x170000D8 RID: 216
  // (get) Token: 0x06000644 RID: 1604 RVA: 0x00059EA6 File Offset: 0x000582A6
  private float HighlightX {
    get {
      return -450f + 150f * (float)this.Column;
    }
  }

  // Token: 0x170000D9 RID: 217
  // (get) Token: 0x06000645 RID: 1605 RVA: 0x00059EBB File Offset: 0x000582BB
  private float HighlightY {
    get {
      return 225f - 75f * (float)this.Row;
    }
  }

  // Token: 0x170000DA RID: 218
  // (get) Token: 0x06000646 RID: 1606 RVA: 0x00059ED0 File Offset: 0x000582D0
  // (set) Token: 0x06000647 RID: 1607 RVA: 0x00059F08 File Offset: 0x00058308
  private float MovingPhotoXPercent {
    get {
      float num = -4150f;
      float num2 = 4150f;
      return (this.MovingPhotograph.transform.localPosition.x - num) / (num2 - num);
    }
    set {
      this.MovingPhotograph.transform.localPosition = new Vector3(-4150f + 2f * (4150f * Mathf.Clamp01(value)), this.MovingPhotograph.transform.localPosition.y, this.MovingPhotograph.transform.localPosition.z);
    }
  }

  // Token: 0x170000DB RID: 219
  // (get) Token: 0x06000648 RID: 1608 RVA: 0x00059F74 File Offset: 0x00058374
  // (set) Token: 0x06000649 RID: 1609 RVA: 0x00059FAC File Offset: 0x000583AC
  private float MovingPhotoYPercent {
    get {
      float num = -2500f;
      float num2 = 2500f;
      return (this.MovingPhotograph.transform.localPosition.y - num) / (num2 - num);
    }
    set {
      this.MovingPhotograph.transform.localPosition = new Vector3(this.MovingPhotograph.transform.localPosition.x, -2500f + 2f * (2500f * Mathf.Clamp01(value)), this.MovingPhotograph.transform.localPosition.z);
    }
  }

  // Token: 0x170000DC RID: 220
  // (get) Token: 0x0600064A RID: 1610 RVA: 0x0005A018 File Offset: 0x00058418
  // (set) Token: 0x0600064B RID: 1611 RVA: 0x0005A040 File Offset: 0x00058440
  private float MovingPhotoRotation {
    get {
      return this.MovingPhotograph.transform.localEulerAngles.z;
    }
    set {
      this.MovingPhotograph.transform.localEulerAngles = new Vector3(this.MovingPhotograph.transform.localEulerAngles.x, this.MovingPhotograph.transform.localEulerAngles.y, value);
    }
  }

  // Token: 0x170000DD RID: 221
  // (get) Token: 0x0600064C RID: 1612 RVA: 0x0005A094 File Offset: 0x00058494
  // (set) Token: 0x0600064D RID: 1613 RVA: 0x0005A0CC File Offset: 0x000584CC
  private float CursorXPercent {
    get {
      float num = -4788f;
      float num2 = 4788f;
      return (this.Cursor.transform.localPosition.x - num) / (num2 - num);
    }
    set {
      this.Cursor.transform.localPosition = new Vector3(-4788f + 2f * (4788f * Mathf.Clamp01(value)), this.Cursor.transform.localPosition.y, this.Cursor.transform.localPosition.z);
    }
  }

  // Token: 0x170000DE RID: 222
  // (get) Token: 0x0600064E RID: 1614 RVA: 0x0005A138 File Offset: 0x00058538
  // (set) Token: 0x0600064F RID: 1615 RVA: 0x0005A170 File Offset: 0x00058570
  private float CursorYPercent {
    get {
      float num = -3122f;
      float num2 = 3122f;
      return (this.Cursor.transform.localPosition.y - num) / (num2 - num);
    }
    set {
      this.Cursor.transform.localPosition = new Vector3(this.Cursor.transform.localPosition.x, -3122f + 2f * (3122f * Mathf.Clamp01(value)), this.Cursor.transform.localPosition.z);
    }
  }

  // Token: 0x06000650 RID: 1616 RVA: 0x0005A1DC File Offset: 0x000585DC
  private void UpdatePhotoSelection() {
    if (Input.GetButtonDown("A")) {
      UITexture uitexture = this.Photographs[this.CurrentIndex];
      if (uitexture.mainTexture != this.NoPhoto) {
        this.ViewPhoto.mainTexture = uitexture.mainTexture;
        this.ViewPhoto.transform.position = uitexture.transform.position;
        this.ViewPhoto.transform.localScale = uitexture.transform.localScale;
        this.Destination.position = uitexture.transform.position;
        this.Viewing = true;
        if (!this.Corkboard) {
          for (int i = 1; i < 26; i++) {
            this.Hearts[i].gameObject.SetActive(false);
          }
        }
        this.CanAdjust = false;
      }
      this.UpdateButtonPrompts();
    }
    if (Input.GetButtonDown("B")) {
      this.PromptBar.ClearButtons();
      this.PromptBar.Label[0].text = "Accept";
      this.PromptBar.Label[1].text = "Exit";
      this.PromptBar.Label[4].text = "Choose";
      this.PromptBar.Label[5].text = "Choose";
      this.PromptBar.UpdateButtons();
      this.PauseScreen.MainMenu.SetActive(true);
      this.PauseScreen.Sideways = false;
      this.PauseScreen.PressedB = true;
      base.gameObject.SetActive(false);
      this.UpdateButtonPrompts();
    }
    if (Input.GetButtonDown("X")) {
      this.ViewPhoto.mainTexture = null;
      int currentIndex = this.CurrentIndex;
      if (this.Photographs[currentIndex].mainTexture != this.NoPhoto) {
        this.Photographs[currentIndex].mainTexture = this.NoPhoto;
        PlayerGlobals.SetPhoto(currentIndex, false);
        PlayerGlobals.SetSenpaiPhoto(currentIndex, false);
        TaskGlobals.SetKittenPhoto(currentIndex, false);
        this.Hearts[currentIndex].gameObject.SetActive(false);
        this.TaskManager.UpdateTaskStatus();
      }
      this.UpdateButtonPrompts();
    }
    if (this.Corkboard) {
      if (Input.GetButtonDown("Y")) {
        this.CanAdjust = false;
        this.Cursor.gameObject.SetActive(true);
        this.Adjusting = true;
        this.UpdateButtonPrompts();
      }
    } else if (this.CanAdjust && Input.GetButtonDown("Y")) {
      int currentIndex2 = this.CurrentIndex;
      PlayerGlobals.SetSenpaiPhoto(currentIndex2, false);
      this.Hearts[currentIndex2].gameObject.SetActive(false);
      this.CanAdjust = false;
      this.Yandere.Sanity += 20f;
      this.UpdateButtonPrompts();
    }
    if (this.InputManager.TappedRight) {
      this.Column = ((this.Column >= 5) ? 1 : (this.Column + 1));
    }
    if (this.InputManager.TappedLeft) {
      this.Column = ((this.Column <= 1) ? 5 : (this.Column - 1));
    }
    if (this.InputManager.TappedUp) {
      this.Row = ((this.Row <= 1) ? 5 : (this.Row - 1));
    }
    if (this.InputManager.TappedDown) {
      this.Row = ((this.Row >= 5) ? 1 : (this.Row + 1));
    }
    bool flag = this.InputManager.TappedRight || this.InputManager.TappedLeft;
    bool flag2 = this.InputManager.TappedUp || this.InputManager.TappedDown;
    if (flag || flag2) {
      this.Highlight.transform.localPosition = new Vector3(this.HighlightX, this.HighlightY, this.Highlight.transform.localPosition.z);
      this.UpdateButtonPrompts();
    }
    this.ViewPhoto.transform.localScale = Vector3.Lerp(this.ViewPhoto.transform.localScale, new Vector3(1f, 1f, 1f), this.LerpSpeed);
    this.ViewPhoto.transform.position = Vector3.Lerp(this.ViewPhoto.transform.position, this.Destination.position, this.LerpSpeed);
    if (this.Corkboard) {
      this.Gallery.transform.localPosition = new Vector3(this.Gallery.transform.localPosition.x, Mathf.Lerp(this.Gallery.transform.localPosition.y, 0f, Time.deltaTime * 10f), this.Gallery.transform.localPosition.z);
    }
  }

  // Token: 0x06000651 RID: 1617 RVA: 0x0005A6EC File Offset: 0x00058AEC
  private void UpdatePhotoViewing() {
    this.ViewPhoto.transform.localScale = Vector3.Lerp(this.ViewPhoto.transform.localScale, (!this.Corkboard) ? new Vector3(6.5f, 6.5f, 6.5f) : new Vector3(5.8f, 5.8f, 5.8f), this.LerpSpeed);
    this.ViewPhoto.transform.localPosition = Vector3.Lerp(this.ViewPhoto.transform.localPosition, Vector3.zero, this.LerpSpeed);
    bool flag = this.Corkboard && Input.GetButtonDown("A");
    if (flag) {
      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Photograph, base.transform.position, Quaternion.identity);
      gameObject.transform.parent = this.CorkboardPanel;
      gameObject.transform.localEulerAngles = Vector3.zero;
      gameObject.transform.localPosition = Vector3.zero;
      gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
      gameObject.GetComponent<UITexture>().mainTexture = this.Photographs[this.CurrentIndex].mainTexture;
      this.MovingPhotograph = gameObject;
      this.CanAdjust = false;
      this.Adjusting = true;
      this.Viewing = false;
      this.Moving = true;
      this.UpdateButtonPrompts();
    }
    if (Input.GetButtonDown("B")) {
      this.Viewing = false;
      if (this.Corkboard) {
        this.Cursor.Highlight.transform.position = new Vector3(this.Cursor.Highlight.transform.position.x, 100f, this.Cursor.Highlight.transform.position.z);
        this.CanAdjust = true;
      } else {
        for (int i = 1; i < 26; i++) {
          if (PlayerGlobals.GetSenpaiPhoto(i)) {
            this.Hearts[i].gameObject.SetActive(true);
            this.CanAdjust = true;
          }
        }
      }
      this.UpdateButtonPrompts();
    }
  }

  // Token: 0x06000652 RID: 1618 RVA: 0x0005A928 File Offset: 0x00058D28
  private void UpdateCorkboardPhoto() {
    if (Input.GetMouseButton(1)) {
      this.MovingPhotoRotation += this.MouseDelta.x;
    } else {
      this.MovingPhotograph.transform.localPosition = new Vector3(this.MovingPhotograph.transform.localPosition.x + this.MouseDelta.x * 8.66666f, this.MovingPhotograph.transform.localPosition.y + this.MouseDelta.y * 8.66666f, 0f);
    }
    if (Input.GetButton("LB")) {
      this.MovingPhotoRotation += Time.deltaTime * 100f;
    }
    if (Input.GetButton("RB")) {
      this.MovingPhotoRotation -= Time.deltaTime * 100f;
    }
    Vector2 vector = new Vector2(this.MovingPhotograph.transform.localPosition.x, this.MovingPhotograph.transform.localPosition.y);
    Vector2 vector2 = new Vector2(Input.GetAxis("Horizontal") * 86.66666f, Input.GetAxis("Vertical") * 86.66666f);
    this.MovingPhotograph.transform.localPosition = new Vector3(Mathf.Clamp(vector.x + vector2.x, -4150f, 4150f), Mathf.Clamp(vector.y + vector2.y, -2500f, 2500f), this.MovingPhotograph.transform.localPosition.z);
    if (Input.GetButtonDown("A")) {
      this.Cursor.transform.localPosition = this.MovingPhotograph.transform.localPosition;
      this.Cursor.gameObject.SetActive(true);
      this.Moving = false;
      this.UpdateButtonPrompts();
    }
  }

  // Token: 0x06000653 RID: 1619 RVA: 0x0005AB30 File Offset: 0x00058F30
  private void UpdateCorkboardCursor() {
    Vector2 vector = new Vector2(this.Cursor.transform.localPosition.x, this.Cursor.transform.localPosition.y);
    Vector2 vector2 = new Vector2(this.MouseDelta.x * 8.66666f + Input.GetAxis("Horizontal") * 86.66666f, this.MouseDelta.y * 8.66666f + Input.GetAxis("Vertical") * 86.66666f);
    this.Cursor.transform.localPosition = new Vector3(Mathf.Clamp(vector.x + vector2.x, -4788f, 4788f), Mathf.Clamp(vector.y + vector2.y, -3122f, 3122f), this.Cursor.transform.localPosition.z);
    if (Input.GetButtonDown("A") && this.Cursor.Photograph != null) {
      this.Cursor.Highlight.transform.position = new Vector3(this.Cursor.Highlight.transform.position.x, 100f, this.Cursor.Highlight.transform.position.z);
      this.MovingPhotograph = this.Cursor.Photograph;
      this.Cursor.gameObject.SetActive(false);
      this.Moving = true;
      this.UpdateButtonPrompts();
    }
    if (Input.GetButtonDown("B")) {
      if (this.Cursor.Photograph != null) {
        this.Cursor.Photograph = null;
      }
      this.Cursor.transform.localPosition = new Vector3(0f, 0f, this.Cursor.transform.localPosition.z);
      this.Cursor.Highlight.transform.position = new Vector3(this.Cursor.Highlight.transform.position.x, 100f, this.Cursor.Highlight.transform.position.z);
      this.CanAdjust = true;
      this.Cursor.gameObject.SetActive(false);
      this.Adjusting = false;
      this.UpdateButtonPrompts();
    }
    if (Input.GetButtonDown("X") && this.Cursor.Photograph != null) {
      this.Cursor.Highlight.transform.position = new Vector3(this.Cursor.Highlight.transform.position.x, 100f, this.Cursor.Highlight.transform.position.z);
      UnityEngine.Object.Destroy(this.Cursor.Photograph);
      this.Cursor.Photograph = null;
      this.UpdateButtonPrompts();
    }
  }

  // Token: 0x06000654 RID: 1620 RVA: 0x0005AE64 File Offset: 0x00059264
  private void Update() {
    if (!this.Adjusting) {
      if (!this.Viewing) {
        this.UpdatePhotoSelection();
      } else {
        this.UpdatePhotoViewing();
      }
    } else {
      if (this.Corkboard) {
        this.Gallery.transform.localPosition = new Vector3(this.Gallery.transform.localPosition.x, Mathf.Lerp(this.Gallery.transform.localPosition.y, 1000f, Time.deltaTime * 10f), this.Gallery.transform.localPosition.z);
      }
      this.MouseDelta = new Vector2(Input.mousePosition.x - this.PreviousPosition.x, Input.mousePosition.y - this.PreviousPosition.y);
      if (this.Moving) {
        this.UpdateCorkboardPhoto();
      } else {
        this.UpdateCorkboardCursor();
      }
    }
    this.PreviousPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
  }

  // Token: 0x06000655 RID: 1621 RVA: 0x0005AF9C File Offset: 0x0005939C
  public IEnumerator GetPhotos() {
    Debug.Log("We were told to get photos.");
    if (!this.Corkboard) {
      for (int i = 1; i < 26; i++) {
        this.Hearts[i].gameObject.SetActive(false);
      }
    }
    for (int ID = 1; ID < 26; ID++) {
      if (PlayerGlobals.GetPhoto(ID)) {
        Debug.Log("Photo " + ID + " is ''true''.");
        string path = string.Concat(new object[]
        {
          "file:///",
          Application.streamingAssetsPath,
          "/Photographs/Photo_",
          ID,
          ".png"
        });
        Debug.Log("Attempting to get " + path);
        WWW www = new WWW(path);
        yield return www;
        if (www.error == null) {
          this.Photographs[ID].mainTexture = www.texture;
          if (!this.Corkboard && PlayerGlobals.GetSenpaiPhoto(ID)) {
            this.Hearts[ID].gameObject.SetActive(true);
          }
        } else {
          Debug.Log(string.Concat(new object[]
          {
            "Could not retrieve Photo ",
            ID,
            ". Maybe it was deleted from Streaming Assets? Setting Photo ",
            ID,
            " to ''false''."
          }));
          PlayerGlobals.SetPhoto(ID, false);
        }
      }
    }
    this.LoadingScreen.SetActive(false);
    if (!this.Corkboard) {
      this.PauseScreen.Sideways = true;
    }
    this.UpdateButtonPrompts();
    base.enabled = true;
    base.gameObject.SetActive(true);
    yield break;
  }

  // Token: 0x06000656 RID: 1622 RVA: 0x0005AFB8 File Offset: 0x000593B8
  public void UpdateButtonPrompts() {
    if (this.Moving) {
      this.PromptBar.Label[0].text = "Place";
      this.PromptBar.Label[1].text = string.Empty;
      this.PromptBar.Label[2].text = string.Empty;
      this.PromptBar.Label[4].text = "Move";
      this.PromptBar.Label[5].text = "Move";
    } else if (this.Adjusting) {
      if (this.Cursor.Photograph != null) {
        this.PromptBar.Label[0].text = "Adjust";
        this.PromptBar.Label[2].text = "Remove";
      } else {
        this.PromptBar.Label[0].text = string.Empty;
        this.PromptBar.Label[2].text = string.Empty;
      }
      this.PromptBar.Label[1].text = "Back";
      this.PromptBar.Label[3].text = string.Empty;
      this.PromptBar.Label[4].text = "Move";
      this.PromptBar.Label[5].text = "Move";
    } else if (!this.Viewing) {
      int currentIndex = this.CurrentIndex;
      if (this.Photographs[currentIndex].mainTexture != this.NoPhoto) {
        this.PromptBar.Label[0].text = "View";
        this.PromptBar.Label[2].text = "Delete";
      } else {
        this.PromptBar.Label[0].text = string.Empty;
        this.PromptBar.Label[2].text = string.Empty;
      }
      if (!this.Corkboard) {
        this.PromptBar.Label[3].text = ((!PlayerGlobals.GetSenpaiPhoto(currentIndex)) ? string.Empty : "Use");
      } else {
        this.PromptBar.Label[3].text = "Corkboard";
      }
      this.PromptBar.Label[1].text = "Back";
      this.PromptBar.Label[4].text = "Choose";
      this.PromptBar.Label[5].text = "Choose";
    } else {
      if (this.Corkboard) {
        this.PromptBar.Label[0].text = "Place";
      } else {
        this.PromptBar.Label[0].text = string.Empty;
      }
      this.PromptBar.Label[2].text = string.Empty;
      this.PromptBar.Label[3].text = string.Empty;
      this.PromptBar.Label[4].text = string.Empty;
      this.PromptBar.Label[5].text = string.Empty;
    }
    this.PromptBar.UpdateButtons();
    this.PromptBar.Show = true;
  }

  // Token: 0x04000F34 RID: 3892
  [SerializeField]
  private InputManagerScript InputManager;

  // Token: 0x04000F35 RID: 3893
  [SerializeField]
  private PauseScreenScript PauseScreen;

  // Token: 0x04000F36 RID: 3894
  [SerializeField]
  private TaskManagerScript TaskManager;

  // Token: 0x04000F37 RID: 3895
  public PromptBarScript PromptBar;

  // Token: 0x04000F38 RID: 3896
  [SerializeField]
  private HomeCursorScript Cursor;

  // Token: 0x04000F39 RID: 3897
  [SerializeField]
  private YandereScript Yandere;

  // Token: 0x04000F3A RID: 3898
  [SerializeField]
  private GameObject MovingPhotograph;

  // Token: 0x04000F3B RID: 3899
  public GameObject LoadingScreen;

  // Token: 0x04000F3C RID: 3900
  [SerializeField]
  private GameObject Photograph;

  // Token: 0x04000F3D RID: 3901
  [SerializeField]
  private Transform CorkboardPanel;

  // Token: 0x04000F3E RID: 3902
  [SerializeField]
  private Transform Destination;

  // Token: 0x04000F3F RID: 3903
  [SerializeField]
  private Transform Highlight;

  // Token: 0x04000F40 RID: 3904
  [SerializeField]
  private Transform Gallery;

  // Token: 0x04000F41 RID: 3905
  [SerializeField]
  private UITexture[] Photographs;

  // Token: 0x04000F42 RID: 3906
  [SerializeField]
  private UISprite[] Hearts;

  // Token: 0x04000F43 RID: 3907
  [SerializeField]
  private UITexture ViewPhoto;

  // Token: 0x04000F44 RID: 3908
  [SerializeField]
  private Texture NoPhoto;

  // Token: 0x04000F45 RID: 3909
  [SerializeField]
  private Vector2 PreviousPosition;

  // Token: 0x04000F46 RID: 3910
  [SerializeField]
  private Vector2 MouseDelta;

  // Token: 0x04000F47 RID: 3911
  public bool Adjusting;

  // Token: 0x04000F48 RID: 3912
  [SerializeField]
  private bool CanAdjust;

  // Token: 0x04000F49 RID: 3913
  [SerializeField]
  private bool Corkboard;

  // Token: 0x04000F4A RID: 3914
  public bool Viewing;

  // Token: 0x04000F4B RID: 3915
  [SerializeField]
  private bool Moving;

  // Token: 0x04000F4C RID: 3916
  [SerializeField]
  private bool Reset;

  // Token: 0x04000F4D RID: 3917
  [SerializeField]
  private int Column;

  // Token: 0x04000F4E RID: 3918
  [SerializeField]
  private int Row;

  // Token: 0x04000F4F RID: 3919
  private const float MaxPhotoX = 4150f;

  // Token: 0x04000F50 RID: 3920
  private const float MaxPhotoY = 2500f;

  // Token: 0x04000F51 RID: 3921
  private const float MaxCursorX = 4788f;

  // Token: 0x04000F52 RID: 3922
  private const float MaxCursorY = 3122f;

  // Token: 0x04000F53 RID: 3923
  private const float CorkboardAspectRatio = 1.53363228f;
}