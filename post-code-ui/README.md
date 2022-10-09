**Local  Server setup:-**

Go inside the project directory and run:

* **yarn install**
* **yarn start**

Open [http://localhost:3000](http://localhost:3000) to view it in the browser.****

#### **Prod Server setup**

* Inside .github\workflow folder I have creaed ui-cicd.yaml It will build and deploy the web application
* Create an AWS IAM Role, with appropriate policies
*  Add AWS SECRET Configuration keys on github project settings->secrtes->actions-> I have creted two keys here AWS_ACCESS_KEY_ID,          AWS_SECRET_ACCESS_KEY_ID
* I have create cloudformation to create s3 bucket and deploy the static website.
* We can run the  ui-cicd.yml file from github action. It will create the stack with all the resource and will upload the build in s3 bucket.
* we can browse web app using http://postcodeweb.com.s3-website-us-east-1.amazonaws.com/
