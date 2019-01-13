#!/bin/bash
docker-compose -f cbs-admin.yml -f cbs-reporting.yml -f cbs-usermanagement.yml -f cbs-notificationgateway.yml build