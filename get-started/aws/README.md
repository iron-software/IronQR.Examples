# Generating and Recognizing QR Codes with AWS Lambda and IronQR

***Based on <https://ironsoftware.com/get-started/aws/>***


<div class="container-fluid">
    <div class="row">
        <div class="col-md-2">
            <img src="https://ironsoftware.com/img/platforms/Amazon_Lambda_architecture_logo.svg">
        </div>
    </div>
</div>

This comprehensive guide explains how to utilize IronQR to generate and scan QR codes using an AWS Lambda function. You'll learn how to deploy IronQR solutions efficiently, using the infrastructure provided by AWS, specifically targeting how QR codes can be both written and read within the same environment.

## Prerequisites

This guide focuses on utilizing an Amazon S3 bucket, and therefore, you must install the **[AWSSDK.S3](https://www.nuget.org/packages/AWSSDK.S3/4.0.0-preview.3)** package.

## Setting Up the AWS Lambda Project

Creating a Docker-based AWS Lambda project is straight-forward in Visual Studio:
- First, ensure you have installed the [AWS Toolkit for Visual Studio](https://aws.amazon.com/visualstudio/).
- Then, create a new AWS Lambda Project (.NET Core - C#).
- Choose the '.NET 8 (Container Image)' template, and click 'Finish'.

![Setting up a Lambda project](https://ironsoftware.com/static-assets/ocr/how-to/iron-ocr-aws-tutorial/Blueprint.png)

## Including Necessary Dependencies

The IronQR library is fully compatible with .NET 8 on AWS Lambda and does not need extra setup steps. Here’s how to prepare Dockerfile to fit the project's needs:

```dockerfile
FROM public.ecr.aws/lambda/dotnet:8

# Update the operating environment and install any necessary packages

***Based on <https://ironsoftware.com/get-started/aws/>***

RUN dnf update -y

WORKDIR /var/task

# Copies the output of your .NET Lambda project from your local build directory into the Docker image.

***Based on <https://ironsoftware.com/get-started/aws/>***

# This should match the build output location specified in the aws-lambda-tools-defaults.json file,

***Based on <https://ironsoftware.com/get-started/aws/>***

# which typically points to "bin/Release/lambda-publish" based on the default configuration set by the AWS .NET Lambda Tooling.

***Based on <https://ironsoftware.com/get-started/aws/>***

# Alternatively, employing a Docker multi-stage build allows for building the project within the Docker image itself,

***Based on <https://ironsoftware.com/get-started/aws/>***

# as detailed in the project's documentation.

***Based on <https://ironsoftware.com/get-started/aws/>***

COPY "bin/Release/lambda-publish"  .
```

## Configuring the FunctionHandler

This example includes the creation and uploading of a QR code to an S3 bucket, followed by reading the QR code file back to verify its contents:

```csharp
using Amazon.Lambda.Core;
using Amazon.S3;
using Amazon.S3.Model;
using IronQr;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace IronQrNuGetAwsLambda
{
    public class Function
    {
        private static readonly IAmazonS3 _s3Client = new AmazonS3Client(Amazon.RegionEndpoint.APSoutheast1);

        public async Task FunctionHandler(ILambdaContext context)
        {
            // Acquire and apply your unique IronQR license key.
            IronQr.License.LicenseKey = "IronQR-MYLICENSE-KEY-1EF01";

            string bucketName = "deploymenttestbucket";
            string objectKey = $"IronQrNuget/{Guid.NewGuid()}.png";

            try
            {
                // Create the QR code containing the value "12345"
                var qrCode = QrWriter.Write("12345");
                context.Logger.LogLine("QR code is successfully created.");

                // Upload the generated JPEG QR code to S3
                await UploadJpgToS3Async(bucketName, objectKey, qrCode.Save().ExportBytesAsJpg());
                context.Logger.LogLine($"QR code successfully uploaded to {bucketName}/{objectKey}");

                // Attempt reading the QR code to verify its content
                QrImageInput imageInput = new QrImageInput(qrCode.Save());
                QrReader reader = new QrReader();
                var decodedResults = reader.Read(imageInput);

                foreach (var item in decodedResults)
                {
                    context.Logger.LogLine($"Decoded QR code value: {item.Value}");
                }
            }
            catch (Exception e)
            {
                context.Logger.LogLine($"[ERROR] FunctionHandler: {e.Message}");
            }
        }

        private async Task UploadJpgToS3Async(string bucketName, string objectKey, byte[] jpgBytes)
        {
            using (var memoryStream = new MemoryStream(jpgBytes))
            {
                var request = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = objectKey,
                    InputStream = memoryStream,
                    ContentType = "image/jpg",
                };

                await _s3Client.PutObjectAsync(request);
            }
        }
    }
}
```

## Optimize Memory and Timeout Settings

It's advisable to start with a memory allocation of 512 MB and a timeout setting of 300 seconds in the `aws-lambda-tools-defaults.json` file.

```json
"function-memory-size" : 512,
"function-timeout" : 300
```

For issues with the function's execution, such as termination due to insufficient memory, increase the allocation as detailed in the [troubleshooting guide on AWS Lambda errors](https://ironsoftware.com/csharp/barcode/troubleshooting/aws-lambda-runtime-exited-signal-killed/).

## Deploying the Function

To deploy, right-click the project in Visual Studio and select 'Publish to AWS Lambda...,' then follow the prompts to set up the deployment parameters.

## Execution

Activate your Lambda from either the [AWS Lambda Management Console](https://console.aws.amazon.com/lambda) or directly within Visual Studio to see your QR code functionality in action.