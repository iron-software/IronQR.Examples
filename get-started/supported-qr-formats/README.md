# Supported QR Code Formats

***Based on <https://ironsoftware.com/get-started/supported-qr-formats/>***


QR codes vary widely in form and function, designed to cater to different requirements related to **data capacity**, **physical space**, and **scanning flexibility**. From sizable shipping labels to tiny electronic components, IronQR is equipped to handle all primary QR standards, ensuring your QR integration needs are met with ease.

This guide covers three QR code types that IronQR can efficiently **generate** and **read**, complete with a practical example to get you started right away.

---

## QR code supported variants

Two-dimensional (2D) matrix codes are a space-efficient and dependable option for encoding much more information than conventional barcodes. IronQR facilitates the use of the following QR types:

### QR Code

The **standard, square QR code** is utilized worldwide for a myriad of applications such as mobile payments, restaurant menus, logistics, marketing efforts, and beyond.

* **Data Capacity:** Supports up to **7,089 numeric** or **4,296 alphanumeric** characters

* **Error Correction:** Comes in four levels (**Low**, **Medium**, **High**, **Highest**) to facilitate data recovery even when the code is partially damaged or dirty

* **Use Case:** Optimal for general uses where moderate to high data capacity and dependability are necessary

This format is the most widely recognized and utilized, providing a good balance of data capacity, scanning distance, and usage flexibility for various industry sectors.

![QR Code](https://ironsoftware.com/static-assets/barcode/how-to/supported-barcode-formats/QRCode.png)

### Micro QR Code

A **scaled-down version** of the standard QR code, crafted for instances where space is particularly restricted—such as in electronic devices, retail product tags, or warranty seals.

* **Data Capacity:** Maximum of **35 numeric** or **21 alphanumeric** characters

* **Efficiency:** Occupies less physical space and can be scanned quicker due to its smaller module size

* **Use Case:** Ideal for labeling small objects, tracking components, or contexts where minimal data storage is sufficient

Despite supporting fewer characters, the Micro QR is highly efficient for uses in limited physical spaces.

![Micro QR Code](https://ironsoftware.com/static-assets/barcode/how-to/supported-barcode-formats/MicroQRCode.png)

### Rectangular Micro Code (RMQRCode)

An **innovatively compact rectangular format**, specially designed for narrow or elongated spaces where traditional square codes are not suitable.

* **Data Capacity:** Comparable to Micro QR Code

* **Shape Advantage:** Particularly adaptable to layouts requiring rectangular printing areas

* **Use Case:** Especially suitable for **forms**, **edge-of-label applications**, and **tickets** where constraints are present in either width or height, but not both

RMQRCode offers similar functionality to Micro QR but with added flexibility in formatting not possible with square designs.

![Rectangular Micro Code](https://ironsoftware.com/static-assets/barcode/how-to/supported-barcode-formats/RMQRCode.png)

## Quick-start code example

The following code snippet allows you to create a QR code using your preferred format. Switch between the supported types conveniently by modifying the Encoding option.

```csharp
using IronQr;
using IronQr.Enum;

// Example: Generating a Micro QR code and saving it as a PNG file
QrCode myQr = QrWriter.Write(
    "Hello IronQR",
    new QrOptions { Encoding = QrEncoding.MicroQRCode }
);

myQr.Save().SaveAs("QR.png");
```

To generate a standard QR Code or RMQRCode, just adjust `QrEncoding` to `QrEncoding.QRCode` or `QrEncoding.RMQRCode`.

---

For decoding purposes, employ `QrEncoding.All` to enable IronQR to autonomously identify the type of any scanned QR code, which is particularly beneficial in environments with mixed QR code types.