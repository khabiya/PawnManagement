

using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using WIA;

namespace WIATest
{
  internal class WIAScanner
  {
    private const string wiaFormatBMP = "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}";

    public static List<Image> Scan()
    {
      // ISSUE: variable of a compiler-generated type
      ICommonDialog instance = (ICommonDialog) Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("850D1D11-70F3-4BE5-9A11-77AA6B2BB201")));
      // ISSUE: reference to a compiler-generated method
      return WIAScanner.Scan((instance.ShowSelectDevice(AlwaysSelectDevice: true) ?? throw new Exception("You must select a device for scanning.")).DeviceID);
    }

    public static List<Image> Scan(string scannerId)
    {
      List<Image> imageList = new List<Image>();
      bool flag = true;
      while (flag)
      {
        // ISSUE: variable of a compiler-generated type
        DeviceManager instance1 = (DeviceManager) Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("E1C5D730-7E97-4D8A-9E42-BBAE87C2059F")));
        // ISSUE: variable of a compiler-generated type
        Device device = (Device) null;
        foreach (DeviceInfo deviceInfo in (IDeviceInfos) instance1.DeviceInfos)
        {
          if (deviceInfo.DeviceID == scannerId)
          {
            // ISSUE: reference to a compiler-generated method
            device = deviceInfo.Connect();
            break;
          }
        }
        if (device == null)
        {
          string str = "";
          foreach (DeviceInfo deviceInfo in (IDeviceInfos) instance1.DeviceInfos)
            str = str + deviceInfo.DeviceID + "\n";
          throw new Exception("The device with provided ID could not be found. Available Devices:\n" + str);
        }
        // ISSUE: variable of a compiler-generated type
        Item tem = device.Items[1];
        try
        {
          // ISSUE: variable of a compiler-generated type
          ICommonDialog instance2 = (ICommonDialog) Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("850D1D11-70F3-4BE5-9A11-77AA6B2BB201")));
          // ISSUE: reference to a compiler-generated field
          if (WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, ImageFile>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (ImageFile), typeof (WIAScanner)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated method
          // ISSUE: variable of a compiler-generated type
          ImageFile mageFile = WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__0.Target((CallSite) WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__0, instance2.ShowTransfer(tem, "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}"));
          string tempFileName = Path.GetTempFileName();
          File.Delete(tempFileName);
          // ISSUE: reference to a compiler-generated method
          mageFile.SaveFile(tempFileName);
          imageList.Add(Image.FromFile(tempFileName));
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {
          // ISSUE: variable of a compiler-generated type
          Property property1 = (Property) null;
          // ISSUE: variable of a compiler-generated type
          Property property2 = (Property) null;
          foreach (Property property3 in (IProperties) device.Properties)
          {
            if (property3.PropertyID == 3088)
              property1 = property3;
            if (property3.PropertyID == 3087)
              property2 = property3;
          }
          flag = false;
          if (property1 != null)
          {
            // ISSUE: reference to a compiler-generated field
            if (WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__4 == null)
            {
              // ISSUE: reference to a compiler-generated field
              WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (WIAScanner), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, bool> target1 = WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__4.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, bool>> p4 = WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__4;
            // ISSUE: reference to a compiler-generated field
            if (WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__3 == null)
            {
              // ISSUE: reference to a compiler-generated field
              WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof (WIAScanner), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, int, object> target2 = WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__3.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, int, object>> p3 = WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__3;
            // ISSUE: reference to a compiler-generated field
            if (WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__2 == null)
            {
              // ISSUE: reference to a compiler-generated field
              WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, uint, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.And, typeof (WIAScanner), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, uint, object> target3 = WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__2.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, uint, object>> p2 = WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__2;
            // ISSUE: reference to a compiler-generated field
            if (WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__1 == null)
            {
              // ISSUE: reference to a compiler-generated field
              WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__1 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToUInt32", (IEnumerable<Type>) null, typeof (WIAScanner), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj1 = WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__1.Target((CallSite) WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__1, typeof (Convert), property1.Value);
            object obj2 = target3((CallSite) p2, obj1, 1U);
            object obj3 = target2((CallSite) p3, obj2, 0);
            if (target1((CallSite) p4, obj3))
            {
              // ISSUE: reference to a compiler-generated field
              if (WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__8 == null)
              {
                // ISSUE: reference to a compiler-generated field
                WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, bool>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (bool), typeof (WIAScanner)));
              }
              // ISSUE: reference to a compiler-generated field
              Func<CallSite, object, bool> target4 = WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__8.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Func<CallSite, object, bool>> p8 = WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__8;
              // ISSUE: reference to a compiler-generated field
              if (WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__7 == null)
              {
                // ISSUE: reference to a compiler-generated field
                WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof (WIAScanner), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              Func<CallSite, object, int, object> target5 = WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__7.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Func<CallSite, object, int, object>> p7 = WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__7;
              // ISSUE: reference to a compiler-generated field
              if (WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__6 == null)
              {
                // ISSUE: reference to a compiler-generated field
                WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, uint, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.And, typeof (WIAScanner), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              Func<CallSite, object, uint, object> target6 = WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__6.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Func<CallSite, object, uint, object>> p6 = WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__6;
              // ISSUE: reference to a compiler-generated field
              if (WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__5 == null)
              {
                // ISSUE: reference to a compiler-generated field
                WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__5 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToUInt32", (IEnumerable<Type>) null, typeof (WIAScanner), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              object obj4 = WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__5.Target((CallSite) WIAScanner.\u003C\u003Eo__5.\u003C\u003Ep__5, typeof (Convert), property2.Value);
              object obj5 = target6((CallSite) p6, obj4, 1U);
              object obj6 = target5((CallSite) p7, obj5, 0);
              flag = target4((CallSite) p8, obj6);
            }
          }
        }
      }
      return imageList;
    }

    public static List<string> GetDevices()
    {
      List<string> devices = new List<string>();
      // ISSUE: variable of a compiler-generated type
      DeviceManager instance = (DeviceManager) Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("E1C5D730-7E97-4D8A-9E42-BBAE87C2059F")));
      foreach (DeviceInfo deviceInfo in (IDeviceInfos) instance.DeviceInfos)
        devices.Add(deviceInfo.DeviceID);
      return devices;
    }

    private class WIA_DPS_DOCUMENT_HANDLING_SELECT
    {
      public const uint FEEDER = 1;
      public const uint FLATBED = 2;
    }

    private class WIA_DPS_DOCUMENT_HANDLING_STATUS
    {
      public const uint FEED_READY = 1;
    }

    private class WIA_PROPERTIES
    {
      public const uint WIA_RESERVED_FOR_NEW_PROPS = 1024;
      public const uint WIA_DIP_FIRST = 2;
      public const uint WIA_DPA_FIRST = 1026;
      public const uint WIA_DPC_FIRST = 2050;
      public const uint WIA_DPS_FIRST = 3074;
      public const uint WIA_DPS_DOCUMENT_HANDLING_STATUS = 3087;
      public const uint WIA_DPS_DOCUMENT_HANDLING_SELECT = 3088;
    }
  }
}
