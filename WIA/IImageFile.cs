
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WIA
{
  [CompilerGenerated]
  [Guid("F4243B65-3F63-4D99-93CD-86B6D62C5EB2")]
  [TypeIdentifier]
  [ComImport]
  public interface IImageFile
  {
    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    sealed extern void _VtblGap1_18();

    [DispId(18)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void SaveFile([MarshalAs(UnmanagedType.BStr), In] string Filename);
  }
}
