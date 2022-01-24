

using Xamarin.Forms;

namespace photouploader.Core
{
    public static class XamExtensions
    {
        public static Color ToXamarinColor(this AzUtil.Core.Color azColor)
        {
            return Color.FromRgba(azColor.R, azColor.G, azColor.B, azColor.A);
        }
    }
}