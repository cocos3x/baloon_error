using UnityEngine;

namespace Cinema
{
    public static class ImageExt
    {
        // Methods
        public static void SetAlpha(UnityEngine.UI.Image image, float alpha)
        {
            UnityEngine.Color val_1 = image.color;
            image.color = new UnityEngine.Color() {r = 0f, g = 0f, b = 0f, a = 0f};
        }
    
    }

}
