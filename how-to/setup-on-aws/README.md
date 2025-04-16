# Read & Write QR Codes with AWS Lambda

***Based on <https://ironsoftware.com/how-to/setup-on-aws/>***


<div class="container-fluid">
    <div class="row">
        <div class="col-md-2">
            <img src="https://ironsoftware.com/img/platforms/Amazon_Lambda_architecture_logo.svg">
        </div>
    </div>
</div>

Learn to setup an AWS Lambda function for handling QR codes using IronQR through this step-by-step guide. This tutorial will demonstrate how to both generate and decode QR codes using an S3 bucket with IronQR.

## Setup Requirements

To follow this guide, you'll need to ensure that the **[AWSSDK.S3](https://www.nuget.org/packages/AWSSDK.S3/4.0.0-preview.3)** package is installed, as it's essential for working with an S3 bucket.

## Creating an AWS Lambda Project

Setting up a specialized AWS Lambda project in Visual Studio is straightforward:
- Begin by installing the [AWS Toolkit for Visual Studio](https://aws.amazon.com/visualstudio/)
- Opt for 'AWS Lambda Project (.NET Core - C#)'
- Choose the '.NET 8 (Container Image)' template and click 'Finish'.

![Select AWS Lambda container image](https://ironsoftware.com/static-assets/ocr/how-to/iron-ocr-aws-tutorial/Blueprint.png)

## Integrating Necessary Packages

The IronQR library is fully compatible with .NET 8 on AWS Lambda and can be set up without additional dependencies. Configure your project's Dockerfile like so:

```dockerfile
FROM public.ecr.aws/lambda/dotnet:8

# Update packages

***Based on <https://ironsoftware.com/how-to/setup-on-aws/>***

RUN dnf update -y

WORKDIR /var/task

# The following copy command moves the .NET Lambda project's output from your local machine into the Docker image.

***Based on <https://ironsoftware.com/how-to/setup-on-aws/>***

# Match the source path here to the directory where your project artifacts are stored. Typically set via the `aws-lambda-tools-defaults.json` file, you can customize the output directory with the `--docker-host-build-output-dir`.

***Based on <https://ironsoftware.com/how-to/setup-on-aws/>***

# You might also consider using a Docker multi-stage build to compile the .NET project directly within the Docker image. For details on this method, see the project README.md.

***Based on <https://ironsoftware.com/how-to/setup-on-aws/>***

COPY "bin/Release/lambda-publish" .
```

## Adjust the FunctionHandler Code

The function below exemplifies the process of creating and reading QR codes directly uploaded to an S3 bucket.

```cs
using Amazon.Lambda.Core;
using Amazon.S3;
using Amazon.S3.Model;
using IronQr;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace IronQrNuGetAwsLambda;

public class Function
{
    private static readonly IAmazonS3 _s3Client = new AmazonS3Client(Amazon.RegionEndpoint.APSoutheast1);

    public async Task FunctionHandler(ILambdaContext context)
    {
        IronQr.License.LicenseKey = "IronQR-MYLICENSE-KEY-1EF01";

        string bucketName = "deploymenttestbucket";
        string objectKey = $"IronQrNuget/{Guid.NewGuid()}.png";

        try
        {
            var myQr = QrWriter.Write("12345");
            context.Logger.LogLine($"QR created.");

            await UploadJpgToS3Async(bucketName, objectKey, myQr.Save().ExportBytesAsJpg());

            context.Logger.LogLine($"QR uploaded successfully to {bucketName}/{objectKey}");

            QrImageInput imageInput = new QrImageInput(myQr.Save());
            QrReader reader = new QrReader();
            var resultFromByte = reader.Read(imageInput);

            foreach (var result in resultFromByte)
            {
                context.Logger.LogLine($"Read QR value: {result.Value}");
            }
        }
        catch (Exception e)
        {
            context.Logger.LogLine($"Error in FunctionHandler: {e.Message}");
        }
    }

    private async Task UploadJpgToS3Async(string bucketName, string objectKey, byte[] jpgBytes)
    {
        using (var memoryStream = new MemoryStream(jpgBytes))
        {
            var uploadRequest = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = objectKey,
                InputStream = memoryStream,
                ContentType = "image/jpg",
            };

            await _s3Client.PutObjectAsync(uploadRequest);
        }
    }
}
```
## Memory and Timeout Settings

Initially, allocate 512 MB of memory and set a 300-second timeout for your Lambda function:

```json
"function-memory-size" : 512,
"function-timeout" : 300
```

Be prepared to enhance memory if errors occur due to insufficient resources, as detailed in: [AWS Lambda - Runtime Exited Signal: Killed](https://ironsoftware.com/csharp/barcode/troubleshooting/aws-lambda-runtime-exited-signal-killed/).

## Deploy the Function

To deploy your function, right-click the project within Visual Studio and choose 'Publish to AWS Lambda...'. To learn more, check the [AWS guide](https://docs.aws.amazon.com/toolkit-for-visual-studio/latest/user-guide/lambda-creating-project-in-visual-studio.html#publish-to-lam).

## Activation

Launch your Lambda function from either Visual Studio or the [AWS Lambda console](https://console.aws.amazon.com/lambda).