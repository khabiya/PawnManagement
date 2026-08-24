
using SecuGen.SecuSearchSDK;

namespace PawnManagement.Classes.PawnManagementClasses
{
  internal class FingerPrintClass
  {
    public static bool IsDataExist(int user_id, byte finger_no, byte sample_no, byte[] minData) => FormMain.m_SecuSearch.GetFPData(new SS_IDInfo()
    {
      ID = user_id,
      FingerNumber = finger_no,
      SampleNumber = sample_no
    }, minData) == 0;

    public static SS_IDInfo getCustomerIdBasedOnFingerPrint(byte[] minData)
    {
      SS_IDInfo idInfo = new SS_IDInfo();
      byte secuLevel = 5;
      return FormMain.m_SecuSearch.IdentifyFP(minData, secuLevel, idInfo) == 0 ? idInfo : idInfo;
    }
  }
}
