using Android.Graphics;

namespace XamarinSampleAndroid.Resources.layout
{
    public class PictureClass
    {
        public Bitmap PhotoDrawable { get; set; }
        public byte[] ImageByteArray { get; set; }
        public string PhotoName { get; set; }

        public PictureClass(Bitmap photoDrawable, string photoName, byte[] imageByteArray)
        {
            PhotoDrawable = photoDrawable;
            PhotoName = photoName;
            ImageByteArray = imageByteArray;
        }
    }
}