# PostCodeWebAPI ASP.NET Core Web API Serverless Application

I have used ASP.NET Core Web API an AWS Lambda and it has been exposed through Amazon API Gateway.

This project has two api methods -
1. GetPostCodes --> It is returning postcode list matching with the input parameter
2. GetPostCodeDetail --> It is returing postcode details by using input postcode

Deployment Steps :-

* Create an AWS IAM Role, with appropriate policy 
* Add AWS SECRET Configuration keys on github project settings->secrtes->actions-> I have creted two keys here AWS_ACCESS_KEY_ID, AWS_SECRET_ACCESS_KEY_ID
* In workflow folder I have created dotnet.yml which have all the steps to run build and deploy the application
* We can run the dotnet.yml file from github action it will deploy on AWS and will create a stack with resources like API Gateway and lambda.
* we can access webapi using https://j5utrffkv3.execute-api.us-east-1.amazonaws.com/Prod/