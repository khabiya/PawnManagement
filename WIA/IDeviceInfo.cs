

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WIA
{
  [CompilerGenerated]
  [Guid("2A99020A-E325-4454-95E0-136726ED4818")]
  [TypeIdentifier]
  [ComImport]
  public interface IDeviceInfo
  {
    [DispId(1)]
    string DeviceID { [DispId(1), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.BStr)] get; }

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    sealed extern void _VtblGap1_2();

    [DispId(4)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.Interface)]
    Device Connect();
  }
}
