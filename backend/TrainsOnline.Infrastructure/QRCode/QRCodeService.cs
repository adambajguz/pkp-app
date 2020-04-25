﻿namespace TrainsOnline.Infrastructure.QRCode
{
    using System;
    using System.Globalization;
    using QRCoder;
    using TrainsOnline.Application.Interfaces;
    using static QRCoder.PayloadGenerator;

    public class QRCodeService : IQRCodeService
    {
        private QRCodeGenerator QRGenerator { get; }

        public QRCodeService()
        {
            QRGenerator = new QRCodeGenerator();
        }

        public byte[] CreateTextCode(string text, int pixelsPerModule = 8)
        {
            QRCodeData qrCodeData = QRGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);

            return qrCode.GetGraphic(pixelsPerModule);
        }

        public byte[] CreateBinaryCode(byte[] data, int pixelsPerModule = 8)
        {
            QRCodeData qrCodeData = QRGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);

            return qrCode.GetGraphic(pixelsPerModule);
        }

        public byte[] CreateCalendarCode(string subject,
                                         string description,
                                         double latitude,
                                         double longitude,
                                         DateTime start,
                                         TimeSpan duration,
                                         bool allDayEvent = false,
                                         int pixelsPerModule = 8)
        {
            return CreateCalendarCode(subject,
                                      description,
                                      latitude,
                                      longitude,
                                      start,
                                      start.Add(duration),
                                      allDayEvent,
                                      pixelsPerModule);
        }

        public byte[] CreateCalendarCode(string subject,
                                         string description,
                                         double latitude,
                                         double longitude,
                                         DateTime start,
                                         DateTime end,
                                         bool allDayEvent = false,
                                         int pixelsPerModule = 8)
        {
            CalendarEvent generator = new CalendarEvent(subject,
                                                        description,
                                                        string.Format(CultureInfo.InvariantCulture, "{0},{1}", latitude, longitude),
                                                        start,
                                                        end,
                                                        allDayEvent);
            string payload = generator.ToString();
            QRCodeData qrCodeData = QRGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);

            return qrCode.GetGraphic(pixelsPerModule);
        }
    }
}