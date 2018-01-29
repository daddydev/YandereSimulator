using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x02000207 RID: 519
public class SerializableHashSet<T> : HashSet<T>, ISerializationCallbackReceiver, IXmlSerializable {

  // Token: 0x0600091B RID: 2331 RVA: 0x0009EDC4 File Offset: 0x0009D1C4
  public SerializableHashSet() {
    this.elements = new List<T>();
  }

  // Token: 0x0600091C RID: 2332 RVA: 0x0009EDD8 File Offset: 0x0009D1D8
  public void OnBeforeSerialize() {
    this.elements.Clear();
    foreach (T item in this) {
      this.elements.Add(item);
    }
  }

  // Token: 0x0600091D RID: 2333 RVA: 0x0009EE40 File Offset: 0x0009D240
  public void OnAfterDeserialize() {
    base.Clear();
    for (int i = 0; i < this.elements.Count; i++) {
      base.Add(this.elements[i]);
    }
  }

  // Token: 0x0600091E RID: 2334 RVA: 0x0009EE82 File Offset: 0x0009D282
  public XmlSchema GetSchema() {
    return null;
  }

  // Token: 0x0600091F RID: 2335 RVA: 0x0009EE88 File Offset: 0x0009D288
  public void ReadXml(XmlReader reader) {
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
    bool isEmptyElement = reader.IsEmptyElement;
    reader.Read();
    if (isEmptyElement) {
      return;
    }
    while (reader.NodeType != XmlNodeType.EndElement) {
      reader.ReadStartElement("Element");
      T item = (T)((object)xmlSerializer.Deserialize(reader));
      reader.ReadEndElement();
      base.Add(item);
      reader.MoveToContent();
    }
  }

  // Token: 0x06000920 RID: 2336 RVA: 0x0009EEFC File Offset: 0x0009D2FC
  public void WriteXml(XmlWriter writer) {
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
    foreach (T t in this) {
      writer.WriteStartElement("Element");
      xmlSerializer.Serialize(writer, t);
      writer.WriteEndElement();
    }
  }

  // Token: 0x04001A1A RID: 6682
  [SerializeField]
  private List<T> elements;

  // Token: 0x04001A1B RID: 6683
  private const string XML_Element = "Element";
}