using UnityEngine;

[CreateAssetMenu]
public class PlayerCarSpriteTemplate : ScriptableObject
{
    public string carName;
    // 좌측 이동 이미지
    public Sprite left;
    // 좌측상단 이동 이미지
    public Sprite leftTop;
    // 상단 이동 이미지
    public Sprite top;
    // 우측상단 이동 이미지
    public Sprite rightTop;
    // 우측 이동 이미지
    public Sprite right;
    // 우측하단 이동 이미지
    public Sprite rightBottom;
    // 하단 이동 이미지
    public Sprite bottom;
    // 좌측상단 이동 이미지
    public Sprite leftbottom;
}
