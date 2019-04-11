Until doLittle has fixed an issue be aware that all references in frontend to their queries and commands needs to be fixed manually after proxies have been generated (occurs after build). This affects the files in Web/Features

When they generate proxies, in the top of their files they import @dolittle/commands and @dolittle/queries depending on the domain model. To fix it change them to @dolittle/commands/dist/commonjs and @dolittle/queries/dist/commonjs. Afterwards you will probably have to restart your frontend with "npm start". (edited) 

---------

- Go to Source/Alerts/Web do "yarn install"
- Then "yarn build" to build
- run "yarn start" to run the application

-----------

Currently for triggered alert email is sent using basic SMTP sender.
To make it work please set up following environment variables:
export ALERT_MAILER_FROM=_from@mail.com_
export ALERT_MAILER_HOST=_smtpServerHost_
export ALERT_MAILER_USER=_username_
export ALERT_MAILER_PASSWORD=_password_
export ALERT_MAILER_PORT=_smtpPort_
export ALERT_MAILER_USESSL=_useSsl_