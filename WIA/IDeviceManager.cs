
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WIA
{
  [CompilerGenerated]
  [Guid("73856D9A-2720-487A-A584-21D5774E9D0F")]
  [TypeIdentifier]
  [ComImport]
  public interface IDeviceManager
  {
    [DispId(1)]
    DeviceInfos DeviceInfos { [DispId(1), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }
  }
}
