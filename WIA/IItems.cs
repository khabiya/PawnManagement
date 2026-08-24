

using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WIA
{
  [CompilerGenerated]
  [Guid("46102071-60B4-4E58-8620-397D17B0BB5B")]
  [TypeIdentifier]
  [ComImport]
  public interface IItems : IEnumerable
  {
    [DispId(0)]
    Item this[[In] int Index] { [DispId(0), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }
  }
}
