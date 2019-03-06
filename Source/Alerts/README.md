Until doLittle has fixed an issue be aware that all references in frontend to their queries and commands needs to be fixed manually after proxies have been generated (occurs after build). This affects the files in Web/Features

When they generate proxies, in the top of their files they import @dolittle/commands and @dolittle/queries depending on the domain model. To fix it change them to @dolittle/commands/dist/commonjs and @dolittle/queries/dist/commonjs. Afterwards you will probably have to restart your frontend with "npm start". (edited) 

---------

To get frontend to build, the following needs to be done (until build is simplified):
NB. This needs to be done in a terminal that supports "cp" (Git Bash does so for Windows)
- Go to Source/Navigation/Web.Commons do "npm install"
- Go to Source/Navigation/Web.Nodejs do "npm install"
- Go to Source/..bounded context../Web do "npm install"
- If you get an error saying that it can find a file or directory in a foldername with the word .staging in it delete the whole package.json-lock file in Source/..bounded context../Web and rerun "npm install" in the same place
- run "npm start"

-----------

Currently for triggered alert email is sent using basic SMTP sender.
To make it work please set up following environment variables:
export ALERT_MAILER_FROM=_from@mail.com_
export ALERT_MAILER_HOST=_smtpServerHost_
export ALERT_MAILER_USER=_username_
export ALERT_MAILER_PASSWORD=_password_
export ALERT_MAILER_PORT=_smtpPort_
export ALERT_MAILER_USESSL=_useSsl_