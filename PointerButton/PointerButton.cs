using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PointerButton
{
  public class PointerButton : Button
  {
    private static readonly CoreCursor handCursor = new CoreCursor(CoreCursorType.Hand, 1);

    private static readonly CoreCursor arrowCursor = new CoreCursor(CoreCursorType.Arrow, 1);


    public PointerButton() : base()
    {
      PointerEntered += (sender, e) =>
      {
        Window.Current.CoreWindow.PointerCursor = handCursor;
      };
      PointerExited += (sender, e) =>
      {
        Window.Current.CoreWindow.PointerCursor = arrowCursor;
      };
    }
  }
}
