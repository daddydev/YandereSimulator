using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000009 RID: 9
public abstract class UIItemSlot : MonoBehaviour {

  // Token: 0x17000002 RID: 2
  // (get) Token: 0x0600002F RID: 47
  protected abstract InvGameItem observedItem { get; }

  // Token: 0x06000030 RID: 48
  protected abstract InvGameItem Replace(InvGameItem item);

  // Token: 0x06000031 RID: 49 RVA: 0x00008FC0 File Offset: 0x000073C0
  private void OnTooltip(bool show) {
    InvGameItem invGameItem = (!show) ? null : this.mItem;
    if (invGameItem != null) {
      InvBaseItem baseItem = invGameItem.baseItem;
      if (baseItem != null) {
        string text = string.Concat(new string[]
        {
          "[",
          NGUIText.EncodeColor(invGameItem.color),
          "]",
          invGameItem.name,
          "[-]\n"
        });
        string text2 = text;
        text = string.Concat(new object[]
        {
          text2,
          "[AFAFAF]Level ",
          invGameItem.itemLevel,
          " ",
          baseItem.slot
        });
        List<InvStat> list = invGameItem.CalculateStats();
        int i = 0;
        int count = list.Count;
        while (i < count) {
          InvStat invStat = list[i];
          if (invStat.amount != 0) {
            if (invStat.amount < 0) {
              text = text + "\n[FF0000]" + invStat.amount;
            } else {
              text = text + "\n[00FF00]+" + invStat.amount;
            }
            if (invStat.modifier == InvStat.Modifier.Percent) {
              text += "%";
            }
            text = text + " " + invStat.id;
            text += "[-]";
          }
          i++;
        }
        if (!string.IsNullOrEmpty(baseItem.description)) {
          text = text + "\n[FF9900]" + baseItem.description;
        }
        UITooltip.Show(text);
        return;
      }
    }
    UITooltip.Hide();
  }

  // Token: 0x06000032 RID: 50 RVA: 0x00009160 File Offset: 0x00007560
  private void OnClick() {
    if (UIItemSlot.mDraggedItem != null) {
      this.OnDrop(null);
    } else if (this.mItem != null) {
      UIItemSlot.mDraggedItem = this.Replace(null);
      if (UIItemSlot.mDraggedItem != null) {
        NGUITools.PlaySound(this.grabSound);
      }
      this.UpdateCursor();
    }
  }

  // Token: 0x06000033 RID: 51 RVA: 0x000091B6 File Offset: 0x000075B6
  private void OnDrag(Vector2 delta) {
    if (UIItemSlot.mDraggedItem == null && this.mItem != null) {
      UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
      UIItemSlot.mDraggedItem = this.Replace(null);
      NGUITools.PlaySound(this.grabSound);
      this.UpdateCursor();
    }
  }

  // Token: 0x06000034 RID: 52 RVA: 0x000091F8 File Offset: 0x000075F8
  private void OnDrop(GameObject go) {
    InvGameItem invGameItem = this.Replace(UIItemSlot.mDraggedItem);
    if (UIItemSlot.mDraggedItem == invGameItem) {
      NGUITools.PlaySound(this.errorSound);
    } else if (invGameItem != null) {
      NGUITools.PlaySound(this.grabSound);
    } else {
      NGUITools.PlaySound(this.placeSound);
    }
    UIItemSlot.mDraggedItem = invGameItem;
    this.UpdateCursor();
  }

  // Token: 0x06000035 RID: 53 RVA: 0x0000925C File Offset: 0x0000765C
  private void UpdateCursor() {
    if (UIItemSlot.mDraggedItem != null && UIItemSlot.mDraggedItem.baseItem != null) {
      UICursor.Set(UIItemSlot.mDraggedItem.baseItem.iconAtlas, UIItemSlot.mDraggedItem.baseItem.iconName);
    } else {
      UICursor.Clear();
    }
  }

  // Token: 0x06000036 RID: 54 RVA: 0x000092B0 File Offset: 0x000076B0
  private void Update() {
    InvGameItem observedItem = this.observedItem;
    if (this.mItem != observedItem) {
      this.mItem = observedItem;
      InvBaseItem invBaseItem = (observedItem == null) ? null : observedItem.baseItem;
      if (this.label != null) {
        string text = (observedItem == null) ? null : observedItem.name;
        if (string.IsNullOrEmpty(this.mText)) {
          this.mText = this.label.text;
        }
        this.label.text = ((text == null) ? this.mText : text);
      }
      if (this.icon != null) {
        if (invBaseItem == null || invBaseItem.iconAtlas == null) {
          this.icon.enabled = false;
        } else {
          this.icon.atlas = invBaseItem.iconAtlas;
          this.icon.spriteName = invBaseItem.iconName;
          this.icon.enabled = true;
          this.icon.MakePixelPerfect();
        }
      }
      if (this.background != null) {
        this.background.color = ((observedItem == null) ? Color.white : observedItem.color);
      }
    }
  }

  // Token: 0x040000D3 RID: 211
  public UISprite icon;

  // Token: 0x040000D4 RID: 212
  public UIWidget background;

  // Token: 0x040000D5 RID: 213
  public UILabel label;

  // Token: 0x040000D6 RID: 214
  public AudioClip grabSound;

  // Token: 0x040000D7 RID: 215
  public AudioClip placeSound;

  // Token: 0x040000D8 RID: 216
  public AudioClip errorSound;

  // Token: 0x040000D9 RID: 217
  private InvGameItem mItem;

  // Token: 0x040000DA RID: 218
  private string mText = string.Empty;

  // Token: 0x040000DB RID: 219
  private static InvGameItem mDraggedItem;
}