namespace TrainsOnline.Application.Interfaces
{
    using System;

    public interface IQRCodeService
    {
        byte[] CreateTextCode(string text, int pixelsPerModule = 8);
        byte[] CreateBinaryCode(byte[] data, int pixelsPerModule = 8);

        byte[] CreateCalendarCode(string subject,
                                  string description,
                                  double latitude,
                                  double longitude,
                                  DateTime start,
                                  DateTime end,
                                  bool allDayEvent = false,
                                  int pixelsPerModule = 8);
        
        byte[] CreateCalendarCode(string subject,
                                  string description,
                                  double latitude,
                                  double longitude,
                                  DateTime start,
                                  TimeSpan duration,
                                  bool allDayEvent = false,
                                  int pixelsPerModule = 8);
    }
}
