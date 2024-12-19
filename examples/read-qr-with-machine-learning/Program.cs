using IronQr;
using IronSoftware.Drawing;
using IronQr.Enum;
using System.Collections.Generic;

var inputBmp = AnyBitmap.FromFile("IMAGE_TO_READ.png");

// Use Auto => Machine Learning Scan
// Careful Scan => Useful for scanning documents slowly and carefully
QrImageInput scan_ML_and_normal = new QrImageInput(inputBmp, QrScanMode.Auto);
IEnumerable<QrResult> results1 = new QrReader().Read(scan_ML_and_normal);

// Use Machine Learning Scan
// High Speed => Useful for scanning frames from a camera
QrImageInput scan_ML_only = new QrImageInput(inputBmp, QrScanMode.OnlyDetectionModel);
IEnumerable<QrResult> results2 = new QrReader().Read(scan_ML_only);

// Use Basic Scan without Machine Learning
QrImageInput scan_normal_only = new QrImageInput(inputBmp, QrScanMode.OnlyBasicScan);
IEnumerable<QrResult> results3 = new QrReader().Read(scan_normal_only);
