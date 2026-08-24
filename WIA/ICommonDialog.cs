

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WIA
{
  [CompilerGenerated]
  [Guid("B4760F13-D9F3-4DF8-94B5-D225F86EE9A1")]
  [TypeIdentifier]
  [ComImport]
  public interface ICommonDialog
  {
    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    sealed extern void _VtblGap1_2();

    [DispId(3)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.Interface)]
    Device ShowSelectDevice([In] WiaDeviceType DeviceType = WiaDeviceType.UnspecifiedDeviceType, [In] bool AlwaysSelectDevice = false, [In] bool CancelError = false);

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    sealed extern void _VtblGap2_3();

    [DispId(7)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.Struct)]
    object ShowTransfer([MarshalAs(UnmanagedType.Interface), In] Item Item, [MarshalAs(UnmanagedType.BStr), In] string FormatID = "{00000000-0000-0000-0000-000000000000}", [In] bool CancelError = false);
  }
}
