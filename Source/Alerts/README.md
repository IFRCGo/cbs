Currently for triggered alert email is sent using basic SMTP sender.
To make it work please set up following environment variables:
export ALERT_MAILER_FROM=_from@mail.com_
export ALERT_MAILER_HOST=_smtpServerHost_
export ALERT_MAILER_USER=_username_
export ALERT_MAILER_PASSWORD=_password_
export ALERT_MAILER_PORT=_smtpPort_
export ALERT_MAILER_USESSL=_useSsl_