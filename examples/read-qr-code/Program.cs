using IronQr;
using IronSoftware.Drawing;
using System.Collections.Generic;

// Open the asset to read a QR Code from
var inputBmp = AnyBitmap.FromFile("IMAGE_TO_READ.png");

// Load the asset into QrImageInput
QrImageInput imageInput = new QrImageInput(inputBmp);

// Create a QR Reader object
QrReader reader = new QrReader();

// Read the Input an get all embedded QR Codes
IEnumerable<QrResult> results = reader.Read(imageInput);
